using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCExample.Models
{

    public class CRUD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ToString());
        public DataTable FetchCategories()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from categories", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable FetchCategoryById(int id) {
            SqlDataAdapter da = new SqlDataAdapter("select * from categories where id = '"+id+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string InsertRec(Category c)
        {
            SqlCommand cmd = new SqlCommand("insert into categories values ('"+c.name+"')",con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return "Successful Insertion Of Record!";
            }
            catch(Exception ex) { 
            return "Insertion of record failed with error" + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }


        public string Edit(Category c)
        {
            SqlCommand cmd = new SqlCommand("update categories set name = '"+c.name+"' where id='"+c.id+"'", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return "Successful updation Of Record!";
            }
            catch (Exception ex)
            {
                return "Insertion of record failed with error" + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        public string Delete(int id)
        {

            SqlCommand cmd = new SqlCommand("delete from categories where id='" + id + "'", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return "Successful Deletion";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }

}