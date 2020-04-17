using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Entity;
namespace DAL
{
    public class LiquidacionModeradoraRepository
    {
        private IList<LiquidacionCuotaModeradora> Liquidaciones;
        private const string Direccion = @"C:\Users\Luis Fer Lara\Nox_share\ImageShare\IPS MAS SALUD Y VIDA-1\IPS MAS SALUD Y VIDA";

        public LiquidacionModeradoraRepository()
        {
            Liquidaciones = new List<LiquidacionCuotaModeradora>();
        }

        public void GuardarLiquidacion(LiquidacionCuotaModeradora liquidacion)
        {
            FileStream sourcestream = new FileStream(Direccion + "liquidaciones.txt", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(sourcestream);
            writer.WriteLine(liquidacion.Identificacion + ";" + liquidacion.NumeroLiquidacion + ";" + liquidacion.CuotaModerada + ";" + liquidacion.SalarioDevengado + ";" + liquidacion.ServicioHospitalizacion + ";" + liquidacion.Tarifa + ";" + liquidacion.TipoAfiliacion);
            writer.Close();
            sourcestream.Close();
        }
        public void EliminarLiquidacion(LiquidacionCuotaModeradora liquidacion)
        {
            FileStream sourceStream = new FileStream(Direccion + "liquidacionesAux.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(Direccion+ "liquidaciones.txt");
            StreamWriter writer = new StreamWriter(sourceStream);
            string linea = string.Empty;

            while ((linea = reader.ReadLine()) != null)
            {
                LiquidacionCuotaModeradora liquidacionnueva = new RegimenContributivo(0, null, 0, null, null);
                char delimiter = ';';
                string[] datos = linea.Split(delimiter);
                liquidacionnueva.Identificacion = datos[0];
                liquidacionnueva.NumeroLiquidacion = datos[1];
                liquidacionnueva.CuotaModerada = decimal.Parse(datos[2]);
                liquidacionnueva.SalarioDevengado = int.Parse(datos[3]);
                liquidacionnueva.ServicioHospitalizacion = decimal.Parse(datos[4]);
                liquidacionnueva.Tarifa = decimal.Parse(datos[5]);
                liquidacionnueva.TipoAfiliacion = datos[6];

                if ((liquidacionnueva.NumeroLiquidacion)!=(liquidacion.NumeroLiquidacion))
                {
                    writer.WriteLine(liquidacionnueva.Identificacion + ";" + liquidacionnueva.NumeroLiquidacion + ";" + liquidacionnueva.CuotaModerada + ";" + liquidacionnueva.SalarioDevengado + ";" + liquidacionnueva.ServicioHospitalizacion + ";" + liquidacionnueva.Tarifa + ";" + liquidacionnueva.TipoAfiliacion);

                }
            }
            writer.Close();
            sourceStream.Close();
            reader.Close();
            File.Delete(Direccion + "liquidaciones.txt");
            File.Move(Direccion + "liquidacionesAux.txt", Direccion + "liquidaciones.txt");
        }

        public void ModificarLiquidacion(LiquidacionCuotaModeradora liquidacionnueva)
        {
            FileStream sourceStream = new FileStream(Direccion + "liquidacionesAux.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(Direccion + "liquidaciones.txt");
            StreamWriter writer = new StreamWriter(sourceStream);
            string linea = string.Empty;

            while ((linea = reader.ReadLine()) != null)
            {
                LiquidacionCuotaModeradora liquidacionvieja = new RegimenContributivo(0, null, 0, null, null);
                char delimiter = ';';
                string[] datos = linea.Split(delimiter);
                liquidacionvieja.Identificacion = datos[0];
                liquidacionvieja.NumeroLiquidacion = datos[1];
                liquidacionvieja.CuotaModerada = decimal.Parse(datos[2]);
                liquidacionvieja.SalarioDevengado = int.Parse(datos[3]);
                liquidacionvieja.ServicioHospitalizacion = decimal.Parse(datos[4]);
                liquidacionvieja.Tarifa = decimal.Parse(datos[5]);
                liquidacionvieja.TipoAfiliacion = datos[6];

                if ((liquidacionvieja.NumeroLiquidacion) != (liquidacionnueva.NumeroLiquidacion))
                {
                    writer.WriteLine(liquidacionvieja.Identificacion + ";" + liquidacionvieja.NumeroLiquidacion + ";" + liquidacionvieja.CuotaModerada + ";" + liquidacionvieja.SalarioDevengado + ";" + liquidacionvieja.ServicioHospitalizacion + ";" + liquidacionvieja.Tarifa + ";" + liquidacionvieja.TipoAfiliacion);

                }
                else
                {
                    writer.WriteLine(liquidacionnueva.Identificacion + ";" + liquidacionnueva.NumeroLiquidacion + ";" + liquidacionnueva.CuotaModerada + ";" + liquidacionnueva.SalarioDevengado + ";" + liquidacionnueva.ServicioHospitalizacion + ";" + liquidacionnueva.Tarifa + ";" + liquidacionnueva.TipoAfiliacion);

                }
            }
            writer.Close();
            sourceStream.Close();
            reader.Close();
            File.Delete(Direccion + "liquidaciones.txt");
            File.Move(Direccion + "liquidacionesAux.txt", Direccion + "liquidaciones.txt");
        }

        public IList<LiquidacionCuotaModeradora> ConsultarLiquidaciones()
        {
            Liquidaciones.Clear();
            FileStream sourceStream = new FileStream(Direccion + "liquidaciones.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(sourceStream);
         
            string linea = string.Empty;

            while ((linea = reader.ReadLine()) != null)
            {
                LiquidacionCuotaModeradora liquidacion = new RegimenContributivo(0, null, 0, null, null);
                char delimiter = ';';
                string[] datos = linea.Split(delimiter);
                liquidacion.Identificacion = datos[0];
                liquidacion.NumeroLiquidacion = datos[1];
                liquidacion.CuotaModerada = decimal.Parse(datos[2]);
                liquidacion.SalarioDevengado = int.Parse(datos[3]);
                liquidacion.ServicioHospitalizacion = decimal.Parse(datos[4]);
                liquidacion.Tarifa = decimal.Parse(datos[5]);
                liquidacion.TipoAfiliacion = datos[6];

                Liquidaciones.Add(liquidacion);
            }
           
            sourceStream.Close();
            reader.Close();
            return Liquidaciones;
        }
        public LiquidacionCuotaModeradora BuscarLiquidacion(LiquidacionCuotaModeradora liquidacion)
        {
            ConsultarLiquidaciones();
            foreach (var item in Liquidaciones)
            {
                if (item.Equals(liquidacion))
                {
                    return item;
                }
            }
            return null;
        }

        public LiquidacionCuotaModeradora BuscarLiquidacion(string numero)
        {
            ConsultarLiquidaciones();
            foreach (var item in Liquidaciones)
            {
                if (item.NumeroLiquidacion.Equals(numero))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
