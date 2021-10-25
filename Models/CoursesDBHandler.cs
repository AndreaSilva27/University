using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace University.Models
{
    public class CoursesDBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["UCLManagementString"].ToString();
            con = new SqlConnection(constring);
        }

        //insert item
        public bool InsertItem(CoursesModel iList)
        {
            connection();
            string query = "INSERT INTO Courses VALUES('" + iList.CourseId + "','" + iList.Name + "')";
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
        public List<CoursesModel> GetItemList()
        {
            connection();
            List<CoursesModel> iList = new List<CoursesModel>();

            string query = "SELECT * FROM Courses";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            adapter.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                iList.Add(new CoursesModel
                {
                    CourseId = Convert.ToInt32(dr["CourseId"]),
                    Name = Convert.ToString(dr["Name"]),
                    

                });
            }
            return iList;
        }

        // update item
        public bool UpdateItem(CoursesModel iList)
        {
            connection();
            string query = "UPDATE Courses SET Name = '" + iList.Name + "'  WHERE CourseId = " + iList.CourseId;
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
            string query = "DELETE FROM Courses WHERE CourseId = " + id;
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