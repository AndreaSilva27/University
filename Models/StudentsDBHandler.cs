using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace University.Models
{
    public class StudentsDBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["UCLManagementString"].ToString();
            con = new SqlConnection(constring);
        }

        //insert item
        public bool InsertItem(StudentsModel iList)
        {
            connection();
            string query = "INSERT INTO Students VALUES('" + iList.StudentId + "','" + iList.Name + "'," + iList.DateOfBirth + ")";
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
        public List<StudentsModel> GetItemList()
        {
            connection();
            List<StudentsModel> iList = new List<StudentsModel>();

            string query = "SELECT * FROM Students";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            adapter.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                iList.Add(new StudentsModel
                {
                    StudentId = Convert.ToInt32(dr["StudentId"]),
                    Name = Convert.ToString(dr["Name"]),
                    DateOfBirth = Convert.ToString(dr["DateOfBirth"]),

                });
            }
            return iList;
        }

        // update item
        public bool UpdateItem(StudentsModel iList)
        {
            connection();
            string query = "UPDATE Students SET Name = '" + iList.Name + "', DateOfBirth = '" + iList.DateOfBirth + "'  WHERE StudentId = " + iList.StudentId;
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
            string query = "DELETE FROM Students WHERE StudentId = " + id;
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