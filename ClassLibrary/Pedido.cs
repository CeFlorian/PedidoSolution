using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Pedido
    {
        // relationships
        List<Producto> productos;
        
        Producto producto = new Producto();
        
        public Proveedor Proveedor { get; set; }//asociacion 1 a 1**
        public List<Detalle> DetallePedido { get; set; }//composicion 1 a 1**

        // properties
        public string Serie { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }

        public Pedido()
        {
            Proveedor = new Proveedor();

            DetallePedido = new List<Detalle>();
        }

        public string Insert(Detalle detalle)
        {
            detalle.Insert();

            return "Pedido agregado";
        }


        






        public class Detalle
        {
            //
            List<Producto> productos;
            Producto producto;//

            //relationships

            public Producto Producto { get; set; }//agregacion 0** a 1**

            //properties

            //
            public int codigoProducto { get; set; }

            public int Cantidad { get; set; }
            public decimal Precio
            {
                get
                {
                    return Producto.Precio;
                }
            }

            public decimal Total
            {
                get
                {
                    if (Cantidad <= 0)
                    {
                        return 0;
                    }

                    return (Cantidad * Producto.Precio);
                }
            }

           
            
            public Detalle()
            {
                Producto = new Producto();
                productos = new List<Producto>();
                
                producto = new Producto();

                productos = producto.GetList();//
            }

            //metodo en el que insertamos datos en el archivo
            public string Insert()
            {
                using (StreamWriter objSW = new StreamWriter(@"C:\Database\pedido.txt", true))
                {
                    objSW.WriteLine($"{codigoProducto}|{Producto}|{Cantidad}|{Precio}|{Total}");
                }
                return "Pedido Agregado!!!";
            }

            public List<Detalle> GetList()
            {
                //
                List<Detalle> detalles = new List<Detalle>();
                Detalle detalle = new Detalle();

                string[] registros;
                string registro;



                using (StreamReader objSR = new StreamReader(@"C:\Database\pedido.txt"))
                {
                    //recorrer archivo
                    while ((registro = objSR.ReadLine()) != null)
                    {
                        //convertir literal a arreglo de string

                        registros = registro.Split('|');



                        //asignar valores del arreglo string al obj Producto
                        detalle = new Detalle
                        {
                            codigoProducto = int.Parse(registros[0]),


                        };

                        var productoEncontrado = productos.Find(p => p.CodigoProducto == detalle.codigoProducto);

                        detalle = new Detalle
                        {
                            codigoProducto = int.Parse(registros[0]),
                            Cantidad = int.Parse(registros[2]),
                            Producto = productoEncontrado,
                        };

                        //Agregar a la lista de productos
                        detalles.Add(detalle);

                    }

                }
                return detalles;
            }



        }
    }
}
