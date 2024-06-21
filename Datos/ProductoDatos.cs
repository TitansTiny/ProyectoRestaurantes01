using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProductoDatos : IDatos<Pizzas>
    {
        PizzeriaDBEntities1 contexto;
        public ProductoDatos()
        {
            contexto = new PizzeriaDBEntities1();
        }
        public bool Actualizar(Pizzas item)
        {
            Pizzas temp = ById(item.PizzaID);
            temp.Nombre = item.Nombre;
            temp.Descripcion = item.Descripcion;
            temp.Imagen = item.Imagen;
            contexto.SaveChanges();
            return true;
        }

        public bool Eliminar(int id)
        {
            Pizzas temp = contexto.Pizzas.Where(p => p.PizzaID == id).FirstOrDefault();
            if (temp != null)
            {
                contexto.Pizzas.Remove(temp);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
        public Pizzas ByNombre(string nombre)
        {
            return contexto.Pizzas.Where(p => p.Nombre == nombre).FirstOrDefault();
        }
        public Pizzas ById(int id)
        {
            return contexto.Pizzas.Where(p => p.PizzaID == id).FirstOrDefault();
        }
        public List<Pizzas> Listar()
        {
            return contexto.Pizzas.ToList();
        }

        public bool Nuevo(Pizzas item)
        {
            if (contexto.Pizzas.Add(item) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
