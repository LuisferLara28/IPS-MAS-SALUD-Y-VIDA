using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
namespace BLL
{
    public class LiquidacionModeradoraService
    {
        public LiquidacionModeradoraRepository LiquidacionModeradoraRepositorio;

        public LiquidacionModeradoraService()
        {
            LiquidacionModeradoraRepositorio = new LiquidacionModeradoraRepository();
        }

        public string GuardarLiquidacion(LiquidacionCuotaModeradora liquidacion)
        {
            if (LiquidacionModeradoraRepositorio.BuscarLiquidacion(liquidacion.NumeroLiquidacion) == null)
            {
                LiquidacionModeradoraRepositorio.GuardarLiquidacion(liquidacion);
                return $"Se ha guardado correctamente. ";
            }
            else
            {
                
                return $"La persona ya existe. ";
            }
        }

        public string EliminarLiquidacion(LiquidacionCuotaModeradora liquidacion)
        {
            if (LiquidacionModeradoraRepositorio.BuscarLiquidacion(liquidacion.NumeroLiquidacion) == null)
            {
               
                return $"La persona no existe. ";
            }
            else
            {
                LiquidacionModeradoraRepositorio.EliminarLiquidacion(liquidacion);
                return $"Se ha eliminado correctamente. ";
            }
        }

        public string ModificarLiquidacion(LiquidacionCuotaModeradora liquidacionNew)
        {
            if (LiquidacionModeradoraRepositorio.BuscarLiquidacion(liquidacionNew.NumeroLiquidacion) == null)
            {

                return $"La persona no existe. ";
            }
            else
            {
                LiquidacionModeradoraRepositorio.ModificarLiquidacion(liquidacionNew);
                return $"Se ha Modificado Correctamente. ";
            }
        }

        public IList<LiquidacionCuotaModeradora> ConsultarLiquidaciones()
        {
            return LiquidacionModeradoraRepositorio.ConsultarLiquidaciones();
        }

        public  LiquidacionCuotaModeradora BuscarLiquidacion(string numero)
        {
            return LiquidacionModeradoraRepositorio.BuscarLiquidacion(numero);
        }
    }
}
