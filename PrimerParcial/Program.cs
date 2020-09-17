using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial
{
    class Program
    {
        static void Main(string[] args)
        {
            String opcion;
            int num, contador = 0, montoTotal = 0, porcentajeDescuento = 0, montoFinal = 0;

            List<int> camisas = new List<int>();

            do
            {
                Console.Clear();
                montoFinal = CalcularDescuento(ref porcentajeDescuento, contador, montoTotal);

                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine(". Camisas PRADBIT – Ventas minoristas y mayoristas                   .");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine(". MENÚ PRINCIPAL:                                                    .");
                Console.WriteLine(".  1- Añadir camisa al carro de compras                              .");
                Console.WriteLine(".  2- Eliminar camisa del carro de compras                           .");
                Console.WriteLine(".  3- Salir                                                          .");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine(".    - Cantidad de camisas en el carro de compras: " + contador + "                 .");
                Console.WriteLine(".    - Precio unitario: $1000                                        ." );
                Console.WriteLine(".    - Precio total sin descuento: $" + montoTotal + "                             .");
                Console.WriteLine(".    - Tipo de descuento aplicado: %" + porcentajeDescuento + "                               .");
                Console.WriteLine(".    - Precio final con descuento: $" + montoFinal + "                             .");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.Write("Ingrese una opción del menú:");
                opcion = Console.ReadLine();
                num = Convert.ToInt32(opcion);
                Console.WriteLine("---------------------------------------------------------------------");

                if (num == 3)
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("¿Está seguro que desea salir? S/N");
                        opcion = Console.ReadLine();
                    }
                    while ((opcion != "s") && (opcion != "n"));

                    if (opcion == "s")
                    {
                        break;
                    }
                    if (opcion == "n")
                    {
                        num = 4;
                    }
                }
                

                switch (num)
                {
                    case 1:
                        AgregarCamisas(camisas, ref contador);
                        montoTotal = 1000 * contador;
                        break;
                    case 2:
                        EliminarCamisa(camisas, ref contador);
                        montoTotal = 1000 * contador;
                        break;
                    case 3:
                        Console.WriteLine("Adios :)");
                        break;
                    default:
                        Console.WriteLine("Error. La opcion seleccionada no existe.");
                        break;
                }
            }
            while(num != 3);
        }
        static public void AgregarCamisas(List<int> camisas, ref int contador)
        {
            char seguir = 'y';
            while (seguir == 'y')
            {
                Console.Clear();
                Random generator = new Random();
                camisas.Add(generator.Next(100, 999));
                contador++;
                Console.WriteLine("Se Agrego una camisa al carrito");

                do
                {
                    Console.WriteLine("Quiere agregar otra?");
                    Console.WriteLine("y : si | n : no");
                    seguir = Convert.ToChar(Console.ReadLine());
                } while (seguir != 'y' && seguir != 'n');
            }
        }
        static public void EliminarCamisa(List<int> camisas, ref int contador)
        {
            char seguir = 'y';
            while (seguir == 'y')
            {
                Console.Clear();
                int codigo;
                Boolean encontro = false;
                for (int i = 0; i < camisas.Count; i++)
                {
                    Console.WriteLine(Convert.ToInt32(i + 1) + ": " + +camisas[i]);
                }
                Console.WriteLine("Ingresa el codigo de la camisa que quiere borrar");
                codigo = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < camisas.Count; i++)
                {
                    if (codigo == camisas[i])
                    {
                        camisas.RemoveAt(i);
                        contador--;
                        encontro = true;
                        Console.WriteLine("Se removio la camisa");
                    }
                    
                }

                if (encontro == false)
                {
                    Console.WriteLine("No se encontro la camisa");
                }

                do
                {
                    Console.WriteLine("Quiere borrar otra?");
                    Console.WriteLine("y : si | n : no");
                    seguir = Convert.ToChar(Console.ReadLine());
                } while (seguir != 'y' && seguir != 'n');
            }
        }
        static public int CalcularDescuento(ref int porcentajeDescuento, int contador, int montoTotal)
        {

            int montoFinal = 0;

            if ((contador >= 3) && (contador <= 5))
            {
                porcentajeDescuento = 10;
                montoFinal = montoTotal - (int)(montoTotal * 0.1);
            }
            else
            {
                if (contador > 5)
                {
                    porcentajeDescuento = 20;
                    montoFinal = montoTotal - (int)(montoTotal * 0.2);
                }
                else
                {
                    porcentajeDescuento = 0;
                    montoFinal = montoTotal;
                }
            }

            return montoFinal;            
        }
    }
}
