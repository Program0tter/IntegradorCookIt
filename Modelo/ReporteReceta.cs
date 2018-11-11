using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class ReporteReceta
    {
        Receta _Receta { get; set; }
        Cliente _Reportador { get; set; }
        Administrador _Respondedor { get; set; }
        string _RazonReporte { get; set; }
        DateTime _FechaReportado { get; set; }
        bool _Resuelto { get; set; }
        DateTime _FechaRespuesta { get; set; }
        string _Conclucion { get; set; }

        public ReporteReceta(Receta Receta, Cliente Reportador, Administrador Respondedor, string RazonReporte, DateTime FechaReportado) {
            _Receta = Receta;
            _Reportador = Reportador;
            _Respondedor = Respondedor;
            _RazonReporte = RazonReporte;
            _FechaReportado = FechaReportado;
            _Resuelto = false;

        }

        private void ResolverReporte() { }
    }
}
