using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Producto
    {
        public int CodigoProducto{ get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public Producto()
        {
        }

        public Producto(int codigoProducto)
        {
            CodigoProducto = codigoProducto;
        }

        public Producto(int codigoProducto, string descripcion, decimal precio)
        {
            CodigoProducto = codigoProducto;
            Descripcion = descripcion;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"{CodigoProducto} {Descripcion}";
        }

        //metodo en el que insertamos datos en el archivo
        public string Insert()
        {
            using (StreamWriter objSW = new StreamWriter(@"C:\Database\producto.txt", true))
            {
                objSW.WriteLine($"{CodigoProducto}|{Descripcion}|{Precio}");
            }
            return "Producto Agregado!!!";
        }

        public List<Producto> GetList()
        {
            //
            List<Producto> productos = new List<Producto>();
            Producto producto = new Producto();

            string[] registros;
            string registro;
            

            using (StreamReader objSR = new StreamReader(@"C:\Database\producto.txt"))
            {
                //recorrer archivo
                while ((registro=objSR.ReadLine())!=null)
                {
                    //convertir literal a arreglo de string

                    registros = registro.Split('|');

                    //asignar valores del arreglo string al obj Producto
                    producto = new Producto
                    {
                        CodigoProducto = Int32.Parse(registros[0]),
                        Descripcion = registros[1],
                        Precio = decimal.Parse(registros[2]),
                    };

                    //Agregar a la lista de productos
                    productos.Add(producto);

                }

            }
            return productos;
        }

    }
}
