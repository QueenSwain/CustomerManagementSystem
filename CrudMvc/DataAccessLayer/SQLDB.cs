using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CrudMvc.Models;

namespace CrudMvc.DataAccessLayer
{
    public class SQLDB
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public void AddRecord(Employee emp)
        {
            SqlCommand cmd = new SqlCommand("SP_Employee_Add",con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name",emp.Name);
            cmd.Parameters.AddWithValue("@Address",emp.Address);
            cmd.Parameters.AddWithValue("@City", emp.City);
            cmd.Parameters.AddWithValue("@PinCode", emp.PinCode);
            cmd.Parameters.AddWithValue("@Designation", emp.Designation);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateRecord(Employee emp)
        {
            SqlCommand cmd = new SqlCommand("SP_Employee_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", emp.EmpId);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Address", emp.Address);
            cmd.Parameters.AddWithValue("@City", emp.City);
            cmd.Parameters.AddWithValue("@PinCode", emp.PinCode);
            cmd.Parameters.AddWithValue("@Designation", emp.Designation);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteRecord(int Id)
        {
            SqlCommand cmd = new SqlCommand("SP_Employee_Delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId",Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet SelectRecordById(int EmpId)
        {
            SqlCommand cmd = new SqlCommand("SP_Employee_SelectById",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", EmpId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);  //sending cmd(query) to DB by using DataAdapter
            DataSet ds = new DataSet();
            da.Fill(ds); //ds=contains fethcing data by DataAdapter Fill method
            return ds;
        }

        public DataSet SelectAllRecord()
        {
            SqlCommand cmd = new SqlCommand("SP_Employee_SelectAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd); 
            DataSet ds = new DataSet(); 
            da.Fill(ds); 
            return ds;
        }
    }
}