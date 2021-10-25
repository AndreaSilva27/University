using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace University.Models
{
    public class TeachersDBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["UCLManagementString"].ToString();
            con = new SqlConnection(constring);
        }

        //insert item
        public bool InsertItem(TeachersModel iList)
        {
            connection();
            string query = "INSERT INTO Teachers VALUES('" + iList.TeacherId + "','" + iList.Name + "','" + iList.AdmissionDate + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //get all item list
        public List<TeachersModel> GetItemList()
        {
            connection();
            List<TeachersModel> iList = new List<TeachersModel>();

            string query = "SELECT * FROM Teachers";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            adapter.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                iList.Add(new TeachersModel
                {
                    TeacherId = Convert.ToInt32(dr["TeacherId"]),
                    Name = Convert.ToString(dr["Name"]),
                    AdmissionDate = Convert.ToString(dr["AdmissionDate"]),
                   
                });
            }
            return iList;
        }

        // update item
        public bool UpdateItem(TeachersModel iList)
        {
            connection();
            string query = "UPDATE Teachers SET Name = '" + iList.Name + "', AdmissionDate = '" + iList.AdmissionDate + "'  WHERE TeacherId = " + iList.TeacherId;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //delete item 
        public bool DeleteItem(int id)
        {
            connection();
            string query = "DELETE FROM Teachers WHERE TeacherId = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}