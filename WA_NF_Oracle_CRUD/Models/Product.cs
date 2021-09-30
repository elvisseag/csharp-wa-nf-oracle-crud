using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WA_NF_Oracle_CRUD.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}