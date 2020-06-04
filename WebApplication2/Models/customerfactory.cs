using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class customerfactory
    {
        public customer getbyId(int id)
        {
            string sql = "SELECT * FROM tCustomer WHERE fid=" + id.ToString();
            customer[] x = lazysql(sql);
            if (x.Length > 0)
            {
                return x[0];
            }
            else
            {
                return null;
            }
        }
        public customer getbyemail(string email)
        {
            string sql = "SELECT * FROM tCustomer WHERE femail='" +email+"'";
            customer[] x = lazysql(sql);
            if (x.Length > 0)
            {
                return x[0];
            }
            else
            {
                return null;
            }
        }

        public customer[] getbykeyword(string keyword)
        {
            string sql = "SELECT * FROM tCustomer WHERE fName LIKE '%"+keyword+ "%'";
            
            sql += "or fPhone LIKE '%" + keyword + "%'";
            sql += "or fEmail LIKE '%" + keyword + "%'";
            sql += "or fAddress LIKE '%" + keyword + "%'";
            return lazysql(sql);
        }

        public customer[] getall()
        {
            string sql = "SELECT * FROM tCustomer";
            
            return lazysql(sql);
        }

        private static customer[] lazysql(string sql)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbdemo;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<customer> list = new List<customer>();
            while (reader.Read())
            {
                list.Add(new customer()
                {
                    id = (int)reader["fid"],
                    name = reader["fName"].ToString(),
                    phone = reader["fPhone"].ToString(),
                    email = reader["fEmail"].ToString(),
                    address = reader["fAddress"].ToString(),
                    password=reader["fPassword"].ToString()
                    
                });
            }
            con.Close();
           
            return list.ToArray();
        }
        public void Insert(customer p)
        {
            string sql = "INSERT INTO tCustomer (";
            sql += "fName,";
            sql += "fPhone,";
            sql += "fEmail,";
            sql += "fAddress";
            sql += ")VALUES(";
            sql += "N'" + p.name + "',";
            sql += "'" + p.phone + "',";
            sql += "'" + p.email + "',";
            sql += "'" + p.address + "')";
            NewMe(sql);

        }
        public void changes(customer p)
        {
            string sql = "UPDATE tCustomer SET";
            sql += " fName= N'" + p.name+"'," ;
            sql += " fEmail='" + p.email + "',";
            sql += " fAddress= N'" + p.address + "',";
            sql += " fPhone= N'" + p.phone + "' ";
            sql += " WHERE fId=" + p.id.ToString() ;
            NewMe(sql);
        }

        private static void NewMe(string sql)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbdemo;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

       
        public void del(int id)
        {
            string sql = "DELETE tCustomer WHERE fId=" + id.ToString();
            NewMe(sql);
        }
    }
}