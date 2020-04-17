using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RegimenSubsidiado:LiquidacionCuotaModeradora
    {
        


        public RegimenSubsidiado(int salariodevengado, string tipoafiliacion, decimal serviciohospitalizacion,string numeroliquidacion, string identificacion):base(salariodevengado,tipoafiliacion,serviciohospitalizacion,numeroliquidacion,identificacion)
        {

        }


        public decimal ValidarCuota()
        {
            Tarifa = 0.5m;
            CuotaModerada = ServicioHospitalizacion * Tarifa;
            if (CuotaModerada > 200000)
            {
                CuotaModerada = 200000;
            }
            return CuotaModerada;
        }
        public override decimal LiquidarPaciente()
        {
            return ValidarCuota();  
        }
    }
}
