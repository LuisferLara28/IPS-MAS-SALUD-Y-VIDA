using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RegimenContributivo : LiquidacionCuotaModeradora
    {
        

        public RegimenContributivo(int salario,string tipoafiliacion,decimal serviciohospitalizacion,string numeroliquidacion,string identificacion):base(salario,tipoafiliacion,serviciohospitalizacion,numeroliquidacion,identificacion)
        {

        }



       
        public decimal CalcularTarifa()
        {
            
            if (SalarioDevengado < 2)
            {
                Tarifa = 0.15m;
                CuotaModerada = ServicioHospitalizacion * Tarifa;
                if (CuotaModerada > 250000)
                {
                    CuotaModerada = 250000;
                }
            }
            if(SalarioDevengado>=2 && SalarioDevengado <= 5)
            {
                Tarifa = 0.20m;
                CuotaModerada= ServicioHospitalizacion* Tarifa;
                if (CuotaModerada > 900000)
                {
                    CuotaModerada = 900000;
                }
            }
            if (SalarioDevengado > 5)
            {
                Tarifa = 0.25m;
                CuotaModerada = ServicioHospitalizacion * Tarifa;
                if (CuotaModerada > 1500000)
                {
                    CuotaModerada = 1500000;
                }

            }

            return CuotaModerada;
        }
        

        public override decimal LiquidarPaciente()
        {
            return CalcularTarifa();
        }
    }
}
