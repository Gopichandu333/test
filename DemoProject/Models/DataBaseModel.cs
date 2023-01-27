using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace DemoProject.Models
{
    public class DataBaseModel
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Demo;User Id=SA;Password=J@rus123");
        public string AddStudentRecord(StudentModel studentModel)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("INSERT StudentDetails ( Id ,SurName,Name,Age,Class,Section,ParentName,MobileNumber,City,Gender,Hobbies,Address) Values (@Id,@SurName,@Name,@Age,@Class,@Section,@ParentName,@MobileNumber,@City,@Gender,@Hobbies,@Address)", con);
                // cmd.CommandText = "INSERT StudentDetails (Id, SurName) Values(" + studentModel.Id + "," + studentModel.SurName + ")";
                // cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Emp_Name", employeeEntities.Emp_Name);
                //cmd.Parameters.AddWithValue("@City", employeeEntities.City);
                //cmd.Parameters.AddWithValue("@State", employeeEntities.State);
                //cmd.Parameters.AddWithValue("@Country", employeeEntities.Country);
                //cmd.Parameters.AddWithValue("@Department", employeeEntities.Department);
                cmd.Parameters.AddWithValue("@Id", studentModel.Id);
                cmd.Parameters.AddWithValue("@SurName", studentModel.SurName);
                cmd.Parameters.AddWithValue("@Name", studentModel.Name);
                cmd.Parameters.AddWithValue("@Age", studentModel.Age);
                cmd.Parameters.AddWithValue("@class", studentModel.Class);
                cmd.Parameters.AddWithValue("@Section", studentModel.Section);
                cmd.Parameters.AddWithValue("@ParentName", studentModel.ParentName);
                cmd.Parameters.AddWithValue("@MobileNumber", studentModel.MobileNumber);
                cmd.Parameters.AddWithValue("@City", studentModel.City);
                cmd.Parameters.AddWithValue("@Gender", studentModel.Gender);
                cmd.Parameters.AddWithValue("@Hobbies", studentModel.Hobbies);
                cmd.Parameters.AddWithValue("@Address", studentModel.Address);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }

        public string AddStudentRecord_SP(StudentModel studentModel)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("SP_InsertStudent", con);
                // cmd.CommandText = "INSERT StudentDetails (Id, SurName) Values(" + studentModel.Id + "," + studentModel.SurName + ")";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Emp_Name", employeeEntities.Emp_Name);
                //cmd.Parameters.AddWithValue("@City", employeeEntities.City);
                //cmd.Parameters.AddWithValue("@State", employeeEntities.State);
                //cmd.Parameters.AddWithValue("@Country", employeeEntities.Country);
                //cmd.Parameters.AddWithValue("@Department", employeeEntities.Department);
                cmd.Parameters.AddWithValue("@Id", studentModel.Id);
                cmd.Parameters.AddWithValue("@SurName", studentModel.SurName);
                cmd.Parameters.AddWithValue("@Name", studentModel.Name);
                cmd.Parameters.AddWithValue("@Age", studentModel.Age);
                cmd.Parameters.AddWithValue("@class", studentModel.Class);
                cmd.Parameters.AddWithValue("@Section", studentModel.Section);
                cmd.Parameters.AddWithValue("@ParentName", studentModel.ParentName);
                cmd.Parameters.AddWithValue("@MobileNumber", studentModel.MobileNumber);
                cmd.Parameters.AddWithValue("@City", studentModel.City);
                cmd.Parameters.AddWithValue("@Gender", studentModel.Gender);
                cmd.Parameters.AddWithValue("@Hobbies", studentModel.Hobbies);
                cmd.Parameters.AddWithValue("@Address", studentModel.Address);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }




        public DataSet GetStudentList()//dataset contains  multiple tables
        {
            DataSet dsStudent = new DataSet();

            SqlCommand objSqlCommand = new SqlCommand("SP_GetStudentDetails", con);
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);//syntax
            try
            {
                objSqlDataAdapter.Fill(dsStudent);
             //   dsStudent.Tables[0].TableName = "Student";
              
            }
            catch (Exception ex)
            {
                return dsStudent;
            }

            return dsStudent;
        }



    }

}
