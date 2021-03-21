using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Demo_Employee.Models;

namespace Demo_Employee.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-A278NMV;Initial Catalog=DemoCRUD;User ID=san;Password=***********");

        public DataSet Empget(Employee emp, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand com = new SqlCommand("Sp_Emplyee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                com.Parameters.AddWithValue("@Em_name", emp.Em_name);
                com.Parameters.AddWithValue("@City", emp.City);
                com.Parameters.AddWithValue("@STATE", emp.STATE);
                com.Parameters.AddWithValue("@Country", emp.Country);
                com.Parameters.AddWithValue("@Department", emp.Department);
                com.Parameters.AddWithValue("@flag", emp.flag);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "OK";
                return ds;


            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return ds;
            }
        }
        //Insert và Cập nhật

        public string Empdml(Employee emp,out string msg)
        {
            msg = "";
            try
            {
                SqlCommand com = new SqlCommand("Sp_Emplyee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                com.Parameters.AddWithValue("@Em_name", emp.Em_name);
                com.Parameters.AddWithValue("@City", emp.City);
                com.Parameters.AddWithValue("@STATE", emp.STATE);
                com.Parameters.AddWithValue("@Country", emp.Country);
                com.Parameters.AddWithValue("@Department", emp.Department);
                com.Parameters.AddWithValue("@flag", emp.flag);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "OK";
                return msg;
            }
            catch(Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                msg = ex.Message;
                return msg;
            }
        }
    }
}