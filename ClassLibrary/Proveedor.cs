using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Proveedor : Persona
    {
        public int CodigoProveedor { get; set; }
        public string NombreComercial { get; set; }
        public string NIT { get; set; }
        public string Contacto { get; set; }

        public Proveedor()
        {

        }

        public Proveedor(int codigoProveedor, string nombreComercial, string nIT, string contacto)
        {
            CodigoProveedor = codigoProveedor;
            NombreComercial = nombreComercial;
            NIT = nIT;
            Contacto = contacto;
        }

        //metodo en el que insertamos datos en el archivo
        public string Insert()
        {
            using (StreamWriter objSW = new StreamWriter(@"C:\Database\proveedor.txt", true))
            {
                objSW.WriteLine($"{CUI}|{Nombres}|{Apellidos}|{NombreCompleto}|{Direccion}|{FechaNacimiento}|{Edad}|{CodigoProveedor}|{NombreComercial}|{NIT}|{Contacto}");
            }
            return "Proveedor Agregado!!!";
        }

        public List<Proveedor> GetList()
        {
            //
            List<Proveedor> proveedores = new List<Proveedor>();
            Proveedor proveedor = new Proveedor();

            string[] registros;
            string registro;

            using (StreamReader objSR = new StreamReader(@"C:\Database\proveedor.txt"))
            {
                //recorrer archivo
                while ((registro = objSR.ReadLine()) != null)
                {
                    //convertir literal a arreglo de string

                    registros = registro.Split('|');

                    //asignar valores del arreglo string al obj Producto
                    proveedor = new Proveedor
                    {
                        CUI = long.Parse(registros[0]),
                        Nombres =  registros[1],
                        Apellidos = registros[2],
                        Direccion = registros[4],
                        FechaNacimiento = DateTime.Parse(registros[5]),
                        CodigoProveedor = Int32.Parse(registros[7]),
                        NombreComercial = registros[8],
                        NIT = registros[9],
                        Contacto = registros[10],
                    };

                    //Agregar a la lista de productos
                    proveedores.Add(proveedor);

                }

            }
            return proveedores;
        }


    }
}
