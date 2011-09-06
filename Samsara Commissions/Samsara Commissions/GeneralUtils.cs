using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComisionesSamsara
{
    public class GeneralUtils
    {
        public static bool IsRightAlignment(string columnName)
        {
            switch (columnName)
            {
                case "anio":
                case "mes":
                case "q":
                case "Q":
                case "Concepto":
                case "estado_actual":
                case "es_excepcion":
                case "fiscal":
                case "factura":
                case "factura_anterior":
                case "factura_original":
                case "fiscal_original":
                case "comentarios_cancelacion":
                    break;
                default:
                    return true;
            }

            return false;
        }

        public static bool IsCurrencyFormat(string columnName)
        {
            switch (columnName)
            {
                case "importe":
                case "costo":
                case "utilidad":
                case "utilidad_real":
                case "total_acumulado":
                case "acumulado_cuota":
                case "acumulado_comision":
                case "total":
                case "total_pagado":
                case "cuota":
                case "utilidad_general":
                case "utilidad_Q":
                case "monto_comision":
                case "saldo_a_pagar":
                case "fecha_ultimo_ajuste":
                    return true;
                default:
                    break;
            }

            return false;
        }
    }
}
