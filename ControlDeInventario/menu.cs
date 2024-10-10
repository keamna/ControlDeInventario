using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeInventario
{
    internal class menu
    {
        public static void principal()
        {

            int opcion = 0;

            do
            {
                Console.WriteLine("1- Ingresar la Cantidad de Artículos");
                Console.WriteLine("2- Ingresar Artículos");
                Console.WriteLine("3- Modificar Artículos");
                Console.WriteLine("4- Borrar Artículos");
                Console.WriteLine("5- Consultar Todos los Artículos Almacenados");
                Console.WriteLine("6- Salir");
                Console.WriteLine("Digite una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        articulos.cantidadArticulos();
                        break;
                    case 2:
                        articulos.ingresarProductos();
                        break;
                    case 3:
                        articulos.modificarProductos();
                        break;
                    case 4:
                        articulos.borrarProductos();
                        break;
                    case 5:
                        articulos.consultarProductos();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del Sistema...");
                        Console.WriteLine("Ha salido del Sistema");
                        Environment.Exit(0); // termina el programa
                        break;
                    default:
                        Console.WriteLine("*** Opción incorrecta *** ");
                        break;
                }

            } while (opcion != 6);

        }
    }

}

