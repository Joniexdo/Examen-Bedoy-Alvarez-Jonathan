using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Examen_de_recuperacion
{
    //Bedoy Alvarez Jonathan 21211917
    class Program
    {
        //Declaracion de la clase
        class Producto
        {
            //Declaracion de los campos
            public string producto;
            public int cantidad;
            public float precio;

            //Declaracion del Constructor de la clase producto
            public Producto(string producto, int cantidad, float precio)
            {
                //Asignacion de valores de los campos
                this.producto = producto;
                this.cantidad = cantidad;
                this.precio = precio;
            }
        }
        static void Main(string[] args)
        {
            ////un programa que capture el producto cantidad y precio aguarde en el archivo con:
            //producto-cantidad-precio-clases-constructor-obj usado-excepcion-streamwriter
            bool correcto = false;
            byte opcion;
            do
            {
                Console.WriteLine("MENU DE INVENTARIO\n");
                Console.WriteLine("1.- Capturar producto");
                Console.WriteLine("2.- Ver productos");
                Console.WriteLine("3.- Salida de programa\n");
                Console.Write("INGRESE LA OPCION DESEADA: ");
                opcion = byte.Parse(Console.ReadLine());
                Console.Clear();
                switch (opcion)
                {
                    //Caso para registrar un producto
                    case 1:
                        do
                        {
                            Console.WriteLine("REGISTRO DE PRODUCTOS");
                            try
                            {
                                //Captura de datos
                                Console.Write("Ingrese Nombre del producto: ");
                                string producto = Console.ReadLine();
                                Console.Write("Ingrese la cantidad de producto: ");
                                int cantidad = int.Parse(Console.ReadLine());
                                Console.Write("Ingrese el precio del producto: ");
                                float precio = float.Parse(Console.ReadLine());
                                correcto = true;
                                Producto product = new Producto(producto, cantidad, precio);

                                //Creacion de archivo
                                StreamWriter sw = new StreamWriter("Productos.txt", true);                  

                                //Escritura del texto en el archivo
                                sw.WriteLine("Producto: " + product.producto);
                                sw.WriteLine("Precio de producto: " + product.cantidad);
                                sw.WriteLine("Cantidad de producto: " + product.precio);

                                //Cierra archivo
                                sw.Close();
                            }
                            catch (FormatException)
                            {
                                //mensaje de error para el registro
                               Console.WriteLine("Formato incorrecto");
                            }
                            catch (OverflowException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        } while (correcto == false);
                        //mensaje que se registro bien
                        Console.WriteLine("\nProducto registrado correctamente");
                        break;

                        //Lista de los productos
                    case 2:
                        Console.Clear();
                        Console.Write("LISTA DE PRODUCTOS");

                        //Leer archivo
                       StreamReader sr = new StreamReader("Producto.txt");

                        //variable para lectura de archivo
                        string linea;

                        //Recorrer archivo
                        while ((linea = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(linea);
                        }
                        sr.Close();
                        break;
                        //Para cerrar el programa
                    case 3:
                        Console.Write("El programa a finalizado.");
                        break;
                    default:
                        Console.Write("ERROR\n");
                        break;
                }
                Console.Write("\nPulse cualquier tecla para continuar... ");
                Console.ReadKey();
                Console.Clear();
            } while (opcion != 3);
            Console.Clear();
            Console.Write("\nPulse cualquier tecla para salir del programa... ");
            Console.ReadKey();
        }
    }
}