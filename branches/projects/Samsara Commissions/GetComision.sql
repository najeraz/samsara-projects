

declare @dFechaFactura		datetime,
		@nTipoComision		int,
		@cAgente			int,
		@besLicitacion		bit,
		@nCuota				decimal(18,8),
		@nImporteFactura	decimal(18,8),
		@nresultado			decimal(18,8)

SET @dFechaFactura = '20120103'
SET @nTipoComision = 2
SET @cAgente = 10
SET @nCuota = 55555
SET @nImporteFactura = 3124.00
SET @besLicitacion = 0

IF @besLicitacion = 1 OR 10000 * Comisiones.dbo.Tipo_Cambio(@dFechaFactura) < @nImporteFactura
	SET @nresultado = 0.15
ELSE
	SELECT		@nresultado = comision
	FROM		Esquemas_Agentes ea
	INNER JOIN	Esquemas_Cuotas ec ON ec.esquema = ea.esquema
	WHERE
	ea.agente = @cAgente
	AND fecha = (
		SELECT MAX(fecha) 
		FROM Esquemas_Agentes 
		WHERE fecha <= @dFechaFactura
		AND agente = @cAgente
		AND tipo_comision = @nTipoComision
		AND borrado = 0
	)
	AND cuota = (
		SELECT MAX(cuota) 
		FROM Esquemas_Cuotas 
		WHERE cuota <= @nCuota
		AND agente = @cAgente
		AND tipo_comision = @nTipoComision
		AND borrado = 0
	)
	AND ea.borrado = 0 AND ec.borrado = 0

SELECT		@nresultado