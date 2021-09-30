using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace WA_NF_Oracle_CRUD.Models
{
    public class OracleDB
    {

        // Basic connection
        //static string data_source = ConfigurationManager.AppSettings["ORCL_DATA_SOURCE"];
        //static string user_id = ConfigurationManager.AppSettings["ORCL_USER_ID"];
        //static string password = ConfigurationManager.AppSettings["ORCL_PASSWORD"];
        //static string sConnection = "DATA SOURCE = " + data_source + " ; PASSWORD = " + password + " ; USER ID = " + user_id;

        static string sHost = ConfigurationManager.AppSettings["ORCL_HOST"];
        static string sPort = ConfigurationManager.AppSettings["ORCL_PORT"];
        static string sServiceName = ConfigurationManager.AppSettings["ORCL_SERVICE_NAME"];
        static string sUserId = ConfigurationManager.AppSettings["ORCL_USER_ID"];
        static string sPassword = ConfigurationManager.AppSettings["ORCL_PASSWORD"];

        static string sConnection = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + sHost + ")(PORT=" + sPort + ")))  "
                                  + "  (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = " + sServiceName + "))); User Id = " + sUserId + "; "
                                  + "  Password = " + sPassword + "; ";

        OracleConnection conn = null;
        OracleCommand cmd = null;

        public string TestOracle()
        {

            string sMessage = "";

            try
            {
                conn = new OracleConnection(sConnection);
                conn.Open();
                sMessage = conn.ServerVersion;
                conn.Close();
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return sMessage;

        }
        /*
         * Listado de Productos
         */
        public List<Product> ListProducts()
        {

            Product pro = null;
            List<Product> list = new List<Product>();
            DataTable data = new DataTable();

            try
            {
                conn = new OracleConnection(sConnection);
                conn.Open();

                cmd = new OracleCommand("SELECT ID_PRODUCT, NAME, DESCRIPTION, PRICE FROM DEMO_PRODUCTS", conn);

                OracleDataAdapter adap = new OracleDataAdapter(cmd);
                adap.Fill(data);

                if (data.Rows.Count != 0)
                {
                    foreach (DataRow item in data.Rows)
                    {
                        pro = new Product();
                        pro.IdProduct = Convert.ToInt32(item["ID_PRODUCT"]);
                        pro.Name = Convert.ToString(item["NAME"]);
                        pro.Description = Convert.ToString(item["DESCRIPTION"]);
                        pro.Price = Convert.ToDouble(item["PRICE"]);
                        list.Add(pro);
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                list = null;
            }

            return list;

        }
        /*
         * Creacion de Productos
         */
        public string InsertProduct(Product req)
        {
            string sMessage = "";
            try
            {
                conn = new OracleConnection(sConnection);
                conn.Open();
                cmd = new OracleCommand("INSERT INTO DEMO_PRODUCTS (ID_PRODUCT,NAME,DESCRIPTION,PRICE) VALUES (:ID_PRODUCT,:NAME,:DESCRIPTION,:PRICEE)", conn);
                cmd.Parameters.Add(":ID_PRODUCT", req.IdProduct);
                cmd.Parameters.Add(":NAME", req.Name);
                cmd.Parameters.Add(":DESCRIPTION", req.Description);
                cmd.Parameters.Add(":PRICE", req.Price);
                cmd.ExecuteNonQuery();
                conn.Close();

                sMessage = "OK";
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return sMessage;
        }

        /*
         * Actualización de Producto
         */

        public string UpdateProduct(Product req, int IdProduct)
        {
            string sMessage = "";
            try
            {
                conn = new OracleConnection(sConnection);
                conn.Open();
                cmd = new OracleCommand("UPDATE DEMO_PRODUCTS SET NAME = :NAME , DESCRIPTION = :DESCRIPTION , PRICE = :PRICE WHERE  ID_PRODUCT = :ID_PRODUCT ", conn);
                cmd.Parameters.Add(":NAME", req.Name);
                cmd.Parameters.Add(":DESCRIPTION", req.Description);
                cmd.Parameters.Add(":PRICE", req.Price);
                cmd.Parameters.Add(":PRODUCT_ID", IdProduct);
                cmd.ExecuteNonQuery();
                conn.Close();

                sMessage = "OK";
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return sMessage;
        }

        /*
         * Eliminación de Producto
         */
        public string DeleteProduct(string IdProduct)
        {
            string sMessage = "";
            try
            {
                conn = new OracleConnection(sConnection);
                conn.Open();
                cmd = new OracleCommand("DELETE FROM DEMO_PRODUCTS WHERE ID_PRODUCT = :ID_PRODUCT", conn);
                cmd.Parameters.Add(":ID_PRODUCT", IdProduct);
                cmd.ExecuteNonQuery();
                conn.Close();

                sMessage = "OK";
            }
            catch (Exception ex)
            {
                sMessage = ex.Message;
            }

            return sMessage;
        }

        



    }
}