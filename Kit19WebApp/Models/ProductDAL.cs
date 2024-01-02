using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Kit19WebApp.Models
{
    public class ProductDAL
    {
        string csKit19 = ConfigurationManager.ConnectionStrings["kit19"].ConnectionString;
        SqlConnection conKit19 = null;
        SqlCommand cmdGetProducts = null;
        
        
        public List<Product> searchProducts(string op, string productName, string size, int? price, 
            DateTime? mfgDate, string category)
        {
            List<Product> products = new List<Product>();
            using (conKit19= new SqlConnection(csKit19))
            {
                cmdGetProducts = new SqlCommand("spSearchProduct", conKit19);
                cmdGetProducts.CommandType = CommandType.StoredProcedure;

                cmdGetProducts.Parameters.AddWithValue("@Operator", op);
                if(productName.ToString() != string.Empty)
                {
                    cmdGetProducts.Parameters.AddWithValue("@ProductName", productName);
                }
                if (size != string.Empty)
                {
                    cmdGetProducts.Parameters.AddWithValue("@Size", size);
                }
                if (price.ToString () != string.Empty)
                {
                    cmdGetProducts.Parameters.AddWithValue("@Price", price);
                }
                if (mfgDate.ToString() != string.Empty)
                {
                    
                    cmdGetProducts.Parameters.AddWithValue("@MfgDate", mfgDate.ToString());
                }
                if (category.ToString() != string.Empty)
                {
                    cmdGetProducts.Parameters.AddWithValue("@Category", category);
                }
                conKit19.Open();
                SqlDataReader rdrProducts = cmdGetProducts.ExecuteReader();
                
                while(rdrProducts.Read())
                {
                    Product product = new Product();
                    product.ProductId = (int)rdrProducts["ProductId"];
                    product.ProductName = (string)rdrProducts["ProductName"];
                    product.Size = (string)rdrProducts["Size"];
                    product.Price = (int)rdrProducts["Price"];
                    product.MfgDate = (DateTime)rdrProducts["MfgDate"];
                    product.Category = (string)rdrProducts["Category"];
                    products.Add(product);
                }
                
            }
           return products;

        }
        public List<Product> getProducts()
        {
            List<Product> products = new List<Product>();
            using (conKit19 = new SqlConnection(csKit19))
            {
                cmdGetProducts = new SqlCommand("spGetProducts", conKit19);
                cmdGetProducts.CommandType = CommandType.StoredProcedure;
                conKit19.Open();
                SqlDataReader rdrProducts = cmdGetProducts.ExecuteReader();

                while (rdrProducts.Read())
                {
                    Product product = new Product();
                    product.ProductId = (int)rdrProducts["ProductId"];
                    product.ProductName = (string)rdrProducts["ProductName"];
                    product.Size = (string)rdrProducts["Size"];
                    product.Price = (int)rdrProducts["Price"];
                    product.MfgDate = (DateTime)rdrProducts["MfgDate"];
                    product.Category = (string)rdrProducts["Category"];
                    products.Add(product);
                }

            }
            return products;

        }
    }
}