using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AccesoADatos;
using Negocio;

namespace Pizzeria.Controllers
{
    public class PizzasController : ApiController
    {
        ProductosNegocio productoNegocio = new ProductosNegocio();

        //Get
        public List<Pizzas> Get()
        {
            return productoNegocio.All();
        }
        //Get/Id
        public IHttpActionResult Get(string nombre)
        {
            Pizzas producto = productoNegocio.ByNombre(nombre);
            if (producto != null)
            {
                return Ok(producto);
            }
            return NotFound();
        }
        //Post
        public IHttpActionResult Post(Pizzas producto)
        {
            try
            {
                productoNegocio.insertarProducto(producto);
                return Ok("Insertado Correctamente");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Put
        public IHttpActionResult Put(int id, Pizzas producto)
        {
            // Obtener el producto existente por su ID
            Pizzas productoExistente = productoNegocio.ById(id);
            if (productoExistente == null)
            {
                return BadRequest("El producto no existe.");
            }

            // Actualizar los valores del producto existente con los valores del producto recibido
            productoExistente.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.Imagen = producto.Imagen;

            // Guardar los cambios en la base de datos
            if (productoNegocio.actualizarProducto(productoExistente))
            {
                return Ok("Producto actualizado correctamente.");
            }
            else
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Pizzas productoEliminar = productoNegocio.ById(id);
                if (productoEliminar == null)
                {
                    return NotFound();
                }
                productoNegocio.eliminarProducto(productoEliminar.PizzaID);
                return Ok("Producto Eliminado Correctamente");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
