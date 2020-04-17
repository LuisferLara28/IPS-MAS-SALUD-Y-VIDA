using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class LiquidacionCuotaModeradora
    {
        public string NumeroLiquidacion { get; set; }
        public string Identificacion { get; set; }
        public string TipoAfiliacion { get; set; }
        public int SalarioDevengado { get; set; }
        public decimal ServicioHospitalizacion { get; set; }
        public decimal CuotaModerada { get; set; }
        public decimal Tarifa { get; set; }


        public LiquidacionCuotaModeradora(int salariodevengado,string tipoafiliacion,decimal serviciohospitalizacion,string numeroliquidacion,string identificacion)
        {
            SalarioDevengado = salariodevengado;
            TipoAfiliacion = tipoafiliacion;
            ServicioHospitalizacion = serviciohospitalizacion;
            NumeroLiquidacion = numeroliquidacion;
            Identificacion = identificacion;
        }


        public abstract decimal LiquidarPaciente();

    }
}
