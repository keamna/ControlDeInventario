using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeInventario
{
    internal class arreglo
    {
        // esto es un ejercicio en clase no es parte del programa
        public void ejercicioEnCLase()      
        {
            // declaración
            int[] codigo = new int[10];
            string[] producto = new string[10];
            float[] costo = new float[10];
            int[] cantidad = new int[10];

            // asignación manual
            costo[2] = 200;
            costo[9] = 500;
            producto[0] = "Teclado";
            producto[2] = "Mouse";
            producto[9] = "Pantalla";
            codigo[9] = 100;
            costo[3] = 600;
            costo[4] = 800;
            costo[5] = 300;

            //recorrido
            for (int i = 0; i < 10; i++) {

                if (codigo[i] == 0 && costo[i] >= 200 && costo[i] <= 300) {

                    Console.WriteLine($"Código: {codigo[i]} Producto: {producto[i]} Precio: {costo[i]}"); // $ interpolación          
                } 
            
            }
        
        }



    }
}
