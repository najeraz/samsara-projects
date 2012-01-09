USE [Comisiones]
GO
/****** Object:  StoredProcedure [dbo].[Comisiones_Agente]    Script Date: 01/09/2012 12:19:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[Comisiones_Agente]
(
	@cSucursal	int,
	@cAgente	int,
	@cAgentes	char(100),
	@dFecha1	datetime,
	@dFecha2	datetime
)
AS
SET NOCOUNT ON


DECLARE @tComisiones TABLE(
	fiscal					char( 12),
	factura					int,
	factura_original		int,
	fecha_factura			datetime,
	fecha_factura_original	datetime,
	anio					int,
	mes						int,
	Q						char(10),
	agente					char( 7),
	agente_original			char(7),
	nombre_cliente			char( 80),
	nombre_agente			char( 80),
	nombre_agente_original	char( 80),
	importe					decimal( 18, 8) DEFAULT 0,
	costo					decimal( 18, 8) DEFAULT 0,
	utilidad				decimal( 18, 8) DEFAULT 0,
	utilidad_comisionable			decimal( 18, 8) DEFAULT 0,
	margen_utilidad			decimal( 18, 8) DEFAULT 0,
	total_acumulado			decimal( 18, 8) DEFAULT 0,
	acumulado_cuota			decimal( 18, 8) DEFAULT 0,
	acumulado_comision		decimal( 18, 8) DEFAULT 0,
	acumulado_comision_agente	decimal( 18, 8) DEFAULT 0,
	total					decimal( 18, 8) DEFAULT 0,
	total_pagado			decimal( 18, 8) DEFAULT 0,
	es_licitacion			char( 2),
	porcentaje_comision		decimal( 18, 8) DEFAULT 0,
	cuota					decimal( 18, 8) DEFAULT 0,
	estado_actual			char(12),
	es_excepcion			char( 2),
	pendiente_pago			char( 2)
)

INSERT INTO @tComisiones
SELECT 	
	f.fiscal,
	f.factura,
	fo.factura factura_original,
	f.fecha_factura fecha_factura,
	case when fe.fecha_factura is not null then fe.fecha_factura else fo.fecha_factura end as fecha_factura_original,
	year(fo.fecha_factura) anio,
	month(fo.fecha_factura) mes,
	case when day(fo.fecha_factura) <= 15 then 'Q1' else 'Q2' end Q,
	f.agente,
	fo.agente agente_original,
	LEFT( c.nombre_cliente, 80) nombre_cliente,
    LEFT( ERP_CIE.dbo.Nombre_Persona2( f.agente), 80) nombre_agente,
    LEFT( ERP_CIE.dbo.Nombre_Persona2( fo.agente), 80) nombre_agente_original,
	d.importe, d.costo,
	case when fe.utilidad is not null then fe.utilidad else d.utilidad end as utilidad,
	case when fe.utilidad is not null then
		(f.total - Comisiones.dbo.Saldo_Factura_Cliente_Tipo_Movimiento( 
		f.factura, @dFecha2, 'Estimado', '1,6')) / f.total * fe.utilidad
	else 
		case when f.total * d.utilidad = 0 then 0 else
		(f.total - Comisiones.dbo.Saldo_Factura_Cliente_Tipo_Movimiento( 
		f.factura, @dFecha2, 'Estimado', '1,6')) / f.total * d.utilidad end
	end as utilidad_comisionable,
	case when fe.utilidad is not null then 
		case when f.total = 0 then 0 else fe.utilidad / f.total end else 
		case when f.total = 0 then 0 else d.utilidad / f.total end
	end * 100.00 as margen_utilidad,
	null as total_acumulado,
	null as acumulado_cuota,
	null as acumulado_comision,
	null as acumulado_comision_agente,
	f.total,
	f.total - Comisiones.dbo.Saldo_Factura_Cliente_Tipo_Movimiento( 
		f.factura, @dFecha2, 'Estimado', '1,6') total_pagado,
	case when f.es_licitacion = 1 then 'Si' else 'No' end es_licitacion,
	COALESCE(case when Comisiones.dbo.Porcentaje_Comision_Agente(cast(fo.agente as int), fo.fecha_factura) > 0 
		AND (f.es_licitacion = 1 
		OR 10000 * Comisiones.dbo.Tipo_Cambio(fo.fecha_factura) < d.importe) then 0.15 
		else Comisiones.dbo.Porcentaje_Comision_Agente(Comisiones.dbo.Buscar_Agente_Original(cast(fo.agente as int)), fo.fecha_factura) end, 0.0000) porcentaje_comision,
	COALESCE(Comisiones.dbo.Cuota_Agente(Comisiones.dbo.Buscar_Agente_Original(cast(fo.agente as int)), fo.fecha_factura), 0.0000) cuota,
	f.estado_actual, case when fe.factura is not null then 'Si' else 'No' end es_excepcion,
	case when (SELECT factura FROM detalle_comisiones_pagadas where ajuste = 
		(select max(id) from ajustes where agente = @cAgente) and factura = f.factura) is null
		then 'Si' else 'No' end pendiente_pago
FROM	ERP_CIE.dbo.Facturas_Clientes f
INNER JOIN	ERP_CIE.dbo.Facturas_Clientes fo ON fo.factura = Comisiones.dbo.Buscar_Factura_Original(cast(f.factura as int))
LEFT JOIN	Facturas_Excepcion fe ON fe.factura = Comisiones.dbo.Buscar_Factura_Original(cast(f.factura as int))
INNER JOIN	(
		SELECT	d.factura, SUM(importe) importe, SUM(costo) costo, SUM(utilidad) utilidad, 
				SUM(utilidad_superior_al_margen) utilidad_superior_al_margen
		FROM (
			SELECT d.factura, d.precio_pactado * d.cantidad importe,
				d.costo_promedio * d.cantidad costo,
				(d.precio_pactado - d.costo_promedio) * d.cantidad utilidad,
				CASE
					WHEN 
						Comisiones.dbo.Buscar_Margen_Minimo(
							CAST(a.familia AS INT), fo.fecha_factura
						) IS NULL
					OR	
						(d.precio_pactado - d.costo_promedio) / d.costo_promedio 
					>	
						Comisiones.dbo.Buscar_Margen_Minimo(
							CAST(a.familia AS INT), fo.fecha_factura
						)
				THEN d.precio_pactado - d.costo_promedio
				ELSE 0
				END utilidad_superior_al_margen
			FROM ERP_CIE.dbo.Detalles_Facturas_Clientes d
			INNER JOIN	ERP_CIE.dbo.Facturas_Clientes fo	
				ON fo.factura = Comisiones.dbo.Buscar_Factura_Original(cast(d.factura as int))
			INNER JOIN	ERP_CIE.dbo.Articulos a				
				ON a.articulo = d.articulo
			WHERE	a.es_servicio   = 0 
		) d
		GROUP BY d.factura
		) d ON d.factura = f.factura
INNER JOIN	ERP_CIE.dbo.Clientes c          ON c.cliente = f.cliente
WHERE
ERP_CIE.dbo.Saldo_Factura_Cliente( f.factura, @dFecha2, 'Estimado') < 1
AND f.sucursal = @cSucursal
AND	f.estado_actual <> 'Cancelada'
AND f.fecha_factura >= @dFecha1 AND f.fecha_factura < dateadd(day, 1, @dFecha2)
AND cast(fo.agente as int) in (select data from dbo.split(@cAgentes,','))
ORDER BY fo.fecha_factura asc, es_licitacion desc

UPDATE @tComisiones
SET utilidad_comisionable = case when utilidad_comisionable > utilidad then utilidad else utilidad_comisionable end

------------------------------------------ DETALLE ------------------------------------------

SELECT * FROM @tComisiones

------------------------------------------ RESUMEN ------------------------------------------

DECLARE @tComisionesAgente TABLE(
	anio					int,
	mes						varchar(30),
	Q						char(10),
	utilidad_general		decimal( 18, 8) DEFAULT 0,
	utilidad_Q				decimal( 18, 8) DEFAULT 0,
	acumulado_comision		decimal( 18, 8) DEFAULT 0,
	cuota					decimal( 18, 8) DEFAULT 0,
	porcentaje_comision		decimal( 18, 8) DEFAULT 0,
	monto_comision			decimal( 18, 8) DEFAULT 0,
	saldo_a_pagar			decimal( 18, 8) DEFAULT 0,
	total_pagado			decimal( 18, 8) DEFAULT 0,
	fecha_ultimo_ajuste		varchar(30)
)

SELECT * FROM @tComisionesAgente


------------------------------------------ PENDIENTES ------------------------------------------

SELECT
	f.fiscal, f.factura, c.nombre_cliente, c.nombre_comercial, 
	d.utilidad, 0.00 total_acumulado,year(f.fecha_factura) anio, 
	cast(month(f.fecha_factura) as varchar(20)) mes,
	case when day(f.fecha_factura) <= 15 then 'Q1' else 'Q2' end Q
FROM	ERP_CIE.dbo.Facturas_Clientes f
INNER JOIN	ERP_CIE.dbo.Facturas_Clientes fo ON fo.factura = Comisiones.dbo.Buscar_Factura_Original(cast(f.factura as int))
INNER JOIN	ERP_CIE.dbo.Clientes c          ON c.cliente = f.cliente
INNER JOIN	(
		SELECT	d.factura, SUM(importe) importe, SUM(costo) costo, SUM(utilidad) utilidad, 
				SUM(utilidad_superior_al_margen) utilidad_superior_al_margen
		FROM (
			SELECT d.factura, d.precio_pactado * d.cantidad importe,
				d.costo_promedio * d.cantidad costo,
				(d.precio_pactado - d.costo_promedio) * d.cantidad utilidad,
				CASE
					WHEN 
						Comisiones.dbo.Buscar_Margen_Minimo(
							CAST(a.familia AS INT), fo.fecha_factura
						) IS NULL
					OR	
						(d.precio_pactado - d.costo_promedio) / d.costo_promedio 
					>	
						Comisiones.dbo.Buscar_Margen_Minimo(
							CAST(a.familia AS INT), fo.fecha_factura
						)
				THEN d.precio_pactado - d.costo_promedio
				ELSE 0
				END utilidad_superior_al_margen
			FROM ERP_CIE.dbo.Detalles_Facturas_Clientes d
			INNER JOIN	ERP_CIE.dbo.Facturas_Clientes fo	
				ON fo.factura = Comisiones.dbo.Buscar_Factura_Original(cast(d.factura as int))
			INNER JOIN	ERP_CIE.dbo.Articulos a				
				ON a.articulo = d.articulo
			WHERE	a.es_servicio   = 0 
		) d
		GROUP BY d.factura
		) d ON d.factura = f.factura
WHERE
ERP_CIE.dbo.Saldo_Factura_Cliente( f.factura, @dFecha2, 'Estimado') >= 1
AND f.sucursal = @cSucursal
AND	f.estado_actual <> 'Cancelada'
AND f.fecha_factura >= @dFecha1 AND f.fecha_factura < dateadd(day, 1, @dFecha2)
AND cast(fo.agente as int) in (select data from dbo.split(@cAgentes,','))
order by anio, mes, Q

------------------------------------------ CANCELADAS ------------------------------------------

SELECT
	f.fiscal, f.factura, factura_anterior, c.nombre_cliente, c.nombre_comercial,
	f.fecha_cancelacion, f.comentarios_cancelacion,  year(f.fecha_factura) anio, 
	cast(month(f.fecha_factura) as varchar(20)) mes,
	case when day(f.fecha_factura) <= 15 then 'Q1' else 'Q2' end Q,
	case when (select max(fecha_ajuste) from ajustes where agente = @cAgente) is null 
		OR f.fecha_cancelacion > (select max(fecha_cierre) from ajustes where agente = @cAgente) 
		then 'Si' else 'No' end pendiente_cobro
FROM	ERP_CIE.dbo.Facturas_Clientes f
INNER JOIN	ERP_CIE.dbo.Clientes c          ON c.cliente = f.cliente
WHERE f.sucursal = @cSucursal
AND	f.estado_actual = 'Cancelada'
AND f.fecha_factura >= @dFecha1 AND f.fecha_factura < dateadd(day, 1, @dFecha2)
AND cast(f.agente as int) in (select data from dbo.split(@cAgentes,','))
order by anio, mes, Q, pendiente_cobro desc

------------------------------------------ AGENAS ------------------------------------------

SELECT
	f.fiscal, 
	fo.fiscal fiscal_original, 
	f.factura,
	fo.factura factura_original,
    LEFT( ERP_CIE.dbo.Nombre_Persona2( f.agente), 80) nombre_agente,
    LEFT( ERP_CIE.dbo.Nombre_Persona2( fo.agente), 80) nombre_agente_original,
	d.utilidad, year(f.fecha_factura) anio, 
	cast(month(f.fecha_factura) as varchar(20)) mes,
	case when day(f.fecha_factura) <= 15 then 'Q1' else 'Q2' end Q
FROM	ERP_CIE.dbo.Facturas_Clientes f
INNER JOIN	ERP_CIE.dbo.Facturas_Clientes fo ON fo.factura = Comisiones.dbo.Buscar_Factura_Original(cast(f.factura as int))
INNER JOIN	(
		SELECT	d.factura, SUM(importe) importe, SUM(costo) costo, SUM(utilidad) utilidad, 
				SUM(utilidad_superior_al_margen) utilidad_superior_al_margen
		FROM (
			SELECT d.factura, d.precio_pactado * d.cantidad importe,
				d.costo_promedio * d.cantidad costo,
				(d.precio_pactado - d.costo_promedio) * d.cantidad utilidad,
				CASE
					WHEN 
						Comisiones.dbo.Buscar_Margen_Minimo(
							CAST(a.familia AS INT), fo.fecha_factura
						) IS NULL
					OR	
						(d.precio_pactado - d.costo_promedio) / d.costo_promedio 
					>	
						Comisiones.dbo.Buscar_Margen_Minimo(
							CAST(a.familia AS INT), fo.fecha_factura
						)
				THEN d.precio_pactado - d.costo_promedio
				ELSE 0
				END utilidad_superior_al_margen
			FROM ERP_CIE.dbo.Detalles_Facturas_Clientes d
			INNER JOIN	ERP_CIE.dbo.Facturas_Clientes fo	
				ON fo.factura = Comisiones.dbo.Buscar_Factura_Original(cast(d.factura as int))
			INNER JOIN	ERP_CIE.dbo.Articulos a				
				ON a.articulo = d.articulo
			WHERE	a.es_servicio   = 0 
		) d
		GROUP BY d.factura
		) d ON d.factura = f.factura
WHERE
ERP_CIE.dbo.Saldo_Factura_Cliente( f.factura, @dFecha2, 'Estimado') >= 1
AND f.sucursal = @cSucursal
AND	f.estado_actual <> 'Cancelada'
AND f.fecha_factura >= @dFecha1 AND f.fecha_factura < dateadd(day, 1, @dFecha2)
AND cast(f.agente as int) in (select data from dbo.split(@cAgentes,','))
AND cast(fo.agente as int) not in (select data from dbo.split(@cAgentes,','))
order by anio, mes, Q










