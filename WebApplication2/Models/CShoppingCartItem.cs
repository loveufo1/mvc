using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class CShoppingCartItem
    {
        public int productID { get; set; }
        public string productname { get; set; }
        public int count { get; set; }
        public double price{ get; set; }
        //public double sum { get{ this.count * this.price}; } 
    }
}