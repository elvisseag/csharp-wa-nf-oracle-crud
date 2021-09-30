using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WA_NF_Oracle_CRUD.Models;

namespace WA_NF_Oracle_CRUD.Controllers
{
    public class ProductsController : ApiController
    {

        /**
        * LISTAR PRODUCTOS RUTA: /api/v1/products/ListProducts
        */
        [HttpGet]
        [ActionName("ListProducts")]
        public List<Product> Get()
        {
            OracleDB o = new OracleDB();
            // return o.TestOracle();
            return o.ListProducts();
        }

        [HttpPost]
        [ActionName("InsertProduct")]
        public string Post(Product req)
        {
            OracleDB o = new OracleDB();
            // return o.TestOracle();
            return o.InsertProduct(req);
        }

        [HttpPut]
        [ActionName("UpdateProduct")]
        public string Put(Product req, int IdProduct)
        {
            OracleDB o = new OracleDB();
            // return o.TestOracle();
            return o.UpdateProduct(req, IdProduct);
        }

        [HttpDelete]
        [ActionName("DeleteProduct")]
        public string Delete(string IdProduct)
        {
            OracleDB o = new OracleDB();
            // return o.TestOracle();
            return o.DeleteProduct(IdProduct);
        }

    }
}
