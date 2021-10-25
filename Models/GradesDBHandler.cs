using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace University.Models
{
    public class GradesDBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["UCLManagementString"].ToString();
            con = new SqlConnection(constring);
        }

        //insert item
        public bool InsertItem(GradesModel iList)
        {
            connection();
            string query = "INSERT INTO Grades VALUES('" + iList.Id + "','" + iList.CourseId + "','" + iList.SubjectId +"' ,'" + iList.StudentId + "' ,'" + iList.Grade + "')";
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
        public List<GradesModel> GetItemList()
        {
            connection();
            List<GradesModel> iList = new List<GradesModel>();

            string query = "SELECT * FROM Grades";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            adapter.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                iList.Add(new GradesModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    CourseId = Convert.ToInt32(dr["CourseId"]),
                    SubjectId = Convert.ToInt32(dr["SubjectId"]),
                    StudentId = Convert.ToInt32(dr["StudentId"]),
                    Grade = Convert.ToString(dr["Grade"]),

                });
            }
            return iList;
        }

        // update item
        public bool UpdateItem(GradesModel iList)
        {
            connection();
            string query = "UPDATE Grades SET CourseId = '" + iList.CourseId + "', SubjectId = '" + iList.SubjectId + "', StudentId = '" + iList.StudentId + "', Grade = '" + iList.Grade + "'  WHERE Id = " + iList.Id;
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
            string query = "DELETE FROM Grades WHERE Id = " + id;
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