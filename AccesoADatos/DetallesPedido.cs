//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoADatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetallesPedido
    {
        public int DetalleID { get; set; }
        public int PedidoID { get; set; }
        public int PizzaID { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    
        public virtual Pedidos Pedidos { get; set; }
        public virtual Pizzas Pizzas { get; set; }
    }
}
