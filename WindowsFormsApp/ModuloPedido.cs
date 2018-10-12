using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class ModuloPedido : Form
    {
        List<Proveedor> Proveedores;
        
        Proveedor Proveedor;

        List<Producto> Productos;

        Producto Producto;

        List<Pedido> Pedidos;

        Pedido Pedido;

        //se agrega para la lista de detalles a leer
        List<Pedido.Detalle> Detalles;//

        Pedido.Detalle Detalle;

        public ModuloPedido()
        {
            InitializeComponent();

            Proveedores = new List<Proveedor>();

            Productos = new List<Producto>();

            Pedidos = new List<Pedido>();
            //
            Detalles = new List<Pedido.Detalle>();//

            Pedido = new Pedido();



            //instanciamos producto
            Producto = new Producto();
            Productos = Producto.GetList();
            dgvProductos.DataSource = Productos;//

            //instanciamos proveedor
            Proveedor = new Proveedor();
            Proveedores = Proveedor.GetList();
            dgvProveedores.DataSource = Proveedores;//

            //instanciamos Detalle
            Detalle = new Pedido.Detalle();
            //Detalles = Detalle.GetList();
            
           
            dgvDetallePedido.DataSource = Detalle.GetList();//
           


            //Para que los proveedores y productos ya guardados en archivo se puedan visualizar en los combobox al inicar el programa
            cmbProveedores.DataSource = Proveedores.ToList();
            cmbProductos.DataSource = Productos.ToList();//

        }


        

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            Proveedor = new Proveedor
            {
                Apellidos = txtApellido.Text,
                CodigoProveedor = int.Parse(txtCodigoProveedor.Text),
                Contacto = txtContacto.Text,
                CUI = Int64.Parse(txtCUI.Text),
                Direccion = txtDireccion.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                NIT = txtNIT.Text,
                NombreComercial = txtNombreComercial.Text,
                Nombres = txtNombre.Text
            };

            //invocamos o usamos el metodo
            Proveedor.Insert();//

            Proveedores.Add(Proveedor);

            dgvProveedores.DataSource = Proveedores.ToList();

            cmbProveedores.DataSource = Proveedores.ToList();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Producto = new Producto
            {
                CodigoProducto = int.Parse( txtCodigoProducto.Text),
                Descripcion = txtDescripcion.Text,
                Precio = decimal.Parse( txtPrecio.Text)
            };

            //invocamos o usamos el metodo
            Producto.Insert();//

            Productos.Add(Producto);

            dgvProductos.DataSource = Productos.ToList();

            cmbProductos.DataSource = Productos.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int codigoProducto = Convert.ToInt32( cmbProductos.SelectedValue);

            var producto = Productos.Find( p => p.CodigoProducto == codigoProducto);

            Detalle = new Pedido.Detalle
            {
                Cantidad = Convert.ToInt32(txtCantidad.Text),
                Producto = producto,
                codigoProducto = codigoProducto,//le damos al codigo el del combobox seleccionado fuera de los datos de la clase Producto
            };

            
            
            Pedido.DetallePedido.Add(Detalle);

            //invocamos o usamos el metodo
            Pedido.Insert(Detalle);

            dgvDetallePedido.DataSource = Pedido.DetallePedido.ToList();


        }
    }
}
