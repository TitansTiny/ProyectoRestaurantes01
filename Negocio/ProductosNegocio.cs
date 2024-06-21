using AccesoADatos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductosNegocio
    {
        ProductoDatos productos;
        public ProductosNegocio()
        {
            productos = new ProductoDatos();
        }
        public List<Pizzas> All()
        {
            return productos.Listar();
        }
        public Pizzas ByNombre(string nombre)
        {
            return productos.Listar().Where(p => p.Nombre == nombre).SingleOrDefault();
        }
        public Pizzas ById(int id)
        {
            return productos.Listar().Where(p => p.PizzaID == id).SingleOrDefault();
        }
        public bool insertarProducto(Pizzas productoNuevo)
        {
            return productos.Nuevo(productoNuevo);
        }
        public bool actualizarProducto(Pizzas producto)
        {
            return productos.Actualizar(producto);
        }
        public bool eliminarProducto(int id)
        {
            return productos.Eliminar(id);
        }
    }
}
