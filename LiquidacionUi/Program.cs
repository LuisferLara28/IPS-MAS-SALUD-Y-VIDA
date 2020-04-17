using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;
namespace LiquidacionUi
{
    class Program
    {
        static void Main(string[] args)
        {

            LiquidacionCuotaModeradora liquidacion;
            LiquidacionModeradoraService liquidacionmoderadoraservice= new LiquidacionModeradoraService();
            string identificacion,numeroliquidacion;
            int salario;
            decimal servicio;
            char Opcion = 'S';

            while (Opcion == 'S')
            {
                Console.Clear();
                int menu = Menu();
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Digite los datos a registrar. ");
                        Console.WriteLine("Identificacion: ");
                        identificacion = Console.ReadLine();
                        Console.WriteLine("Salario de vengado: ");
                        salario = int.Parse(Console.ReadLine());
                        Console.WriteLine("Valor del servicio: ");
                        servicio = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Nummero de liquidacion; ");
                        numeroliquidacion = Console.ReadLine();
                        Console.WriteLine("Tipo de afiliacion. ");
                        Console.WriteLine("1 - Subsidiado. ");
                        Console.WriteLine("2 - Contributivo. ");
                        int opcion = int.Parse(Console.ReadLine());
                        if (opcion == 1)
                        {
                            liquidacion = new RegimenSubsidiado(salario, "Subsidiado", servicio, numeroliquidacion, identificacion);
                            liquidacion.LiquidarPaciente();
                        }
                        else
                        {
                            liquidacion = new RegimenContributivo(salario, "Contributivo", servicio, numeroliquidacion, identificacion);
                            liquidacion.LiquidarPaciente();
                        }
                        Console.WriteLine(liquidacionmoderadoraservice.GuardarLiquidacion(liquidacion));
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Consulta de  liquidaciones. ");
                        foreach (var item in liquidacionmoderadoraservice.ConsultarLiquidaciones())
                        {
                            Console.WriteLine($"Identificacion: {item.Identificacion} Numero: {item.NumeroLiquidacion} Regimen: {item.TipoAfiliacion} Servicio: {item.ServicioHospitalizacion} Salario: {item.SalarioDevengado} Cuota: {item.CuotaModerada} Tarifa: {item.Tarifa}");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Consulta de liquidacion individual. ");
                        Console.WriteLine("Digite el numero de la liquidacion. ");
                        string numero = Console.ReadLine();

                        if (liquidacionmoderadoraservice.BuscarLiquidacion(numero) == null)
                        {
                            Console.WriteLine("No existe la liquidacion. ");

                        }
                        else
                        {
                            liquidacion = liquidacionmoderadoraservice.BuscarLiquidacion(numero);
                            Console.WriteLine($"Identificacion: {liquidacion.Identificacion} Numero: {liquidacion.NumeroLiquidacion} Regimen: {liquidacion.TipoAfiliacion} Servicio: {liquidacion.ServicioHospitalizacion} Salario: {liquidacion.SalarioDevengado} Cuota: {liquidacion.CuotaModerada} Tarifa: {liquidacion.Tarifa}");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Modificar liquidacion. ");
                        Console.WriteLine("Digite el numero de liquidacion a modificar. ");
                        string liqui = Console.ReadLine();
                        if (liquidacionmoderadoraservice.BuscarLiquidacion(liqui) == null)
                        {
                            Console.WriteLine("La liquidacion no existe.");
                        }
                        else
                        {
                            liquidacion = liquidacionmoderadoraservice.BuscarLiquidacion(liqui);
                            Console.WriteLine("Salario nuevo: ");
                            liquidacion.SalarioDevengado = int.Parse(Console.ReadLine());
                            Console.WriteLine("Servicio nuevo: ");
                            liquidacion.ServicioHospitalizacion = decimal.Parse(Console.ReadLine());
                            liquidacion.LiquidarPaciente();
                            Console.WriteLine(liquidacionmoderadoraservice.ModificarLiquidacion(liquidacion));
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Eliminar liquidacion. ");
                        Console.WriteLine("Digite el numero de liquidacion a Eliminar. ");
                        string liquiEli = Console.ReadLine();
                        if (liquidacionmoderadoraservice.BuscarLiquidacion(liquiEli) == null)
                        {
                            Console.WriteLine("La liquidacion no existe.");
                        }
                        else
                        {
                            liquidacion = liquidacionmoderadoraservice.BuscarLiquidacion(liquiEli);
                            Console.WriteLine(liquidacionmoderadoraservice.EliminarLiquidacion(liquidacion));
                            Console.ReadKey();
                        }
                        break;
                    case 6:
                        Opcion = 'N';
                        break;
                }
            }

            
            Console.ReadKey();
        }

        public static int Menu()
        {
            Console.WriteLine("1 - Registrar liquidacion. ");
            Console.WriteLine("2 - Consultar Liquidaciones. ");
            Console.WriteLine("3 - Buscar liquidacion. ");
            Console.WriteLine("4 - Modificar Liquidaciones. ");
            Console.WriteLine("5 - Eliminar Liquidacion. ");
            Console.WriteLine("6 - Salir. ");
            return int.Parse(Console.ReadLine());
        }
    }
}
