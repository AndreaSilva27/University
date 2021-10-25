using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace University.Models
{
    public class SubjectsDBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["UCLManagementString"].ToString();
            con = new SqlConnection(constring);
        }

        //insert item
        public bool InsertItem(SubjectsModel iList)
        {
            connection();
            string query = "INSERT INTO Subjects VALUES('" + iList.SubjectId + "','" + iList.Name + "')";
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
        public List<SubjectsModel> GetItemList()
        {
            connection();
            List<SubjectsModel> iList = new List<SubjectsModel>();

            string query = "SELECT * FROM Subjects";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            adapter.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                iList.Add(new SubjectsModel
                {
                    SubjectId = Convert.ToInt32(dr["SubjectId"]),
                    Name = Convert.ToString(dr["Name"]),
                    

                });
            }
            return iList;
        }

        // update item
        public bool UpdateItem(SubjectsModel iList)
        {
            connection();
            string query = "UPDATE Subjects SET Name = '" + iList.Name + "'  WHERE SubjectId = " + iList.SubjectId;
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
            string query = "DELETE FROM Subjects WHERE SubjectId = " + id;
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