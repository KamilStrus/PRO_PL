using Onion.Domain.Entities;
using Onion.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Onion.Infrastructure.SqlDbService.Services
{
    public class SqlDbService : IStudentDbService
    {
        private static readonly ICollection<Student> _students = new List<Student>();
        public IEnumerable<Student> GetStudents()
        {
            
            var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s17090;Integrated Security=True");
            var com = new SqlCommand();

            com.Connection = con;
            com.CommandText = "select * from Students";
            
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                string numerid = dr["IdStudent"].ToString();
                _students.Add(new Student
                (
                 

                  dr["FirstName"].ToString(),
                  dr["LastName"].ToString()


             ));
                _students.ElementAt(i).IdStudent = int.Parse(numerid);
                i++;

            }


            con.Dispose();
            return _students;
        }
        public bool EnrollStudent(Student newStudent, int semestr)
        {

            var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s17090;Integrated Security=True");
            var com = new SqlCommand();

            com.Connection = con;
            con.Open();
            com.CommandText = "INSERT INTO Students (FirstName, LastName) VALUES('" + newStudent.FirstName + "','" + newStudent.LastName + "')";
            con.Dispose();

            return true;
        }
    }
}