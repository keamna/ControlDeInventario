using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeInventario
{
    internal class articulos
    {
        public static int[] id;
        public static string[] nombre;
        public static double[] precio;

        static Dictionary<int, List<int>> almacen = new Dictionary<int, List<int>>(); 

        public static int cantidadProductos = 0;


        public static void cantidadArticulos()
        {
            Console.WriteLine("Ingrese la cantidad de productos: ");
            int tamano = int.Parse(Console.ReadLine());

            id = new int[tamano];
            nombre = new string[tamano];
            precio = new double[tamano];

            for (int i = 0; i < tamano; i++)
            {
                id[i] = 0;
                nombre[i] = "";
                precio[i] = 0;
            }

            cantidadProductos = 0;
            Console.WriteLine($"Sistema inicializado con {tamano} artículos");
            Console.Clear();
        }

        public static void ingresarProductos()
        {
            while (cantidadProductos < id.Length)
            {
                Console.WriteLine("Digite un código: ");
                id[cantidadProductos] = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite el nombre del artículo: ");
                nombre[cantidadProductos] = Console.ReadLine();
                Console.WriteLine("Digite un precio: ");
                precio[cantidadProductos] = double.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el número de la bodega donde se almacenará el artículo: ");
                int bodega = int.Parse(Console.ReadLine());

                if (!almacen.ContainsKey(bodega))
                {
                    almacen[bodega] = new List<int>();
                }

                almacen[bodega].Add(cantidadProductos); // Almacenamos el índice del producto
                cantidadProductos++;
                Console.Clear();
            }
        }


        public static void modificarProductos()
        {
            Console.Clear();
            for (int i = 0; i < cantidadProductos; i++)
            {   
                Console.WriteLine("Productos ingresados: ");
                Console.WriteLine($"Código: {id[i]} Nombre: {nombre[i]}, Precio: {precio[i]}\n");
            }

            Console.WriteLine("Ingrese \n 1- Modificar código de artículo \n 2- Modificar nombre del artículo \n 3- Modificar precio del artículo");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    // Modificar código
                    Console.WriteLine("Digite el código del artículo que desea modificar: ");
                    int codigoviejo = int.Parse(Console.ReadLine());
                    for (int i = 0; i < cantidadProductos; i++)
                    {
                        if (codigoviejo == id[i])
                        {
                            Console.WriteLine("Digite un nuevo código: ");
                            id[i] = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Código actualizado: {id[i]}, Nombre actual: {nombre[i]}, Precio actual: {precio[i]}");
                            return;
                        }
                    }
                    Console.WriteLine("Código no encontrado.");
                    break;

                case 2:
                    // Modificar nombre
                    Console.WriteLine("Digite el nombre del artículo que desea modificar: ");
                    string nombreviejo = Console.ReadLine();
                    for (int i = 0; i < cantidadProductos; i++)
                    {
                        if (nombreviejo == nombre[i])
                        {
                            Console.WriteLine("Digite un nuevo nombre: ");
                            nombre[i] = Console.ReadLine();
                            Console.WriteLine($"Código actual: {id[i]}, Nombre actualizado: {nombre[i]}, Precio actual: {precio[i]}");
                            return;
                        }
                    }
                    Console.WriteLine("Nombre no encontrado.");
                    break;

                case 3:
                    // Modificar precio
                    Console.WriteLine("Digite el precio del artículo que desea modificar: ");
                    double precioviejo = double.Parse(Console.ReadLine());
                    for (int i = 0; i < cantidadProductos; i++)
                    {
                        if (precioviejo == precio[i])
                        {
                            Console.WriteLine("Digite un nuevo precio: ");
                            precio[i] = double.Parse(Console.ReadLine());
                            Console.WriteLine($"Código actual: {id[i]}, Nombre actual: {nombre[i]}, Precio actualizado: {precio[i]}");
                            return;
                        }
                    }
                    Console.WriteLine("Precio no encontrado");
                    break;

                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }



        public static void consultarProductos()
        {
            Console.Clear();
            Console.WriteLine("*** REPORTE DE ARTÍCULOS ***");

            // Recorre todas las bodegas y los productos almacenados en ellas
            foreach (var entry in almacen)
            {
                int bodegaNumero = entry.Key;
                List<int> productosEnBodega = entry.Value;

                Console.WriteLine($"\nBodega {bodegaNumero}:");
                Console.WriteLine($"Total de artículos en la bodega: {productosEnBodega.Count}");

                // Para cada producto en la bodega, imprime su información
                foreach (int productoIndice in productosEnBodega)
                {
                    Console.WriteLine($"  Código: {id[productoIndice]} Nombre: {nombre[productoIndice]} Precio: {precio[productoIndice]}");
                }
            }

            Console.WriteLine("\n*** FIN DEL REPORTE ***");

            // Lógica para pedir que ingrese "salir"
            int salir = 0;
            do
            {
                Console.WriteLine("Ingresa [3] Menú: ");
                salir = int.Parse(Console.ReadLine());
            }
            while (salir != 3);

            Console.WriteLine("Has salido del reporte");
        }

        public static void borrarProductos()
            {
                Console.Clear();
                int opcion = 0;

            // Mostrar todos los productos almacenados
            for (int i = 0; i < cantidadProductos; i++)
            {
                if (id[i] != 0 && !string.IsNullOrEmpty(nombre[i]) && precio[i] != 0)  // Imprime los productos con código diferente a 0 y los nombres de productos que no sean nulos o vacíos
                {
                    Console.WriteLine($"Código: {id[i]} Nombre: {nombre[i]}, Precio: {precio[i]}");
                }
            }

            while (true)
                {
                    Console.WriteLine("Digite: \n 1- Eliminar artículo por código \n 2- Eliminar artículo por nombre \n 3- Menú ");
                    opcion = int.Parse(Console.ReadLine());

                    if (opcion == 1)
                    {
                        Console.WriteLine("Ingrese el código del artículo a eliminar o [3] Menú: ");
                        int codigoeliminado = int.Parse(Console.ReadLine());

                        if (codigoeliminado == 3)
                        {
                            Console.WriteLine("Ha salido de la opción borrar artículos");
                            break;
                        }

                        for (int i = 0; i < cantidadProductos; i++)
                        {
                            if (codigoeliminado == id[i])
                            {
                                eliminarProducto(i);
                                Console.WriteLine($"Artículo con código {codigoeliminado} eliminado.");
                                break;
                            }
                        }
                    }
                    else if (opcion == 2)
                    {
                        Console.WriteLine("Ingresa el nombre del artículo a eliminar o [salir]: ");
                        string nombreeliminado = Console.ReadLine();

                        if (nombreeliminado.ToLower() == "salir")
                        {
                            Console.WriteLine("Ha salido de la opción borrar artículos");
                            break;
                        }

                        for (int i = 0; i < cantidadProductos; i++)
                        {
                            if (nombreeliminado == nombre[i])
                            {
                                eliminarProducto(i);
                                Console.WriteLine($"Artículo con nombre '{nombreeliminado}' eliminado.");
                                break;
                            }
                        }
                    }
                    else if (opcion == 3)
                    {
                        Console.WriteLine("Saliendo..");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("*** Opción incorrecta, inténtelo de nuevo ***");
                    }
                }
            }

            // Método para eliminar un producto desplazando de indice los elementos restantes de forma descendente
            public static void eliminarProducto(int indice)
            {
                for (int i = indice; i < cantidadProductos - 1; i++)
                {
                    id[i] = id[i + 1];
                    nombre[i] = nombre[i + 1];
                }

                id[cantidadProductos - 1] = 0;
                nombre[cantidadProductos - 1] = "";
                cantidadProductos--;
            }
        }
}

