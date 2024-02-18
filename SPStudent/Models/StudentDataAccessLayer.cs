using System.Data;
using System.Data.SqlClient;


namespace SPStudent.Models
{
    public class StudentDataAccessLayer
    {
        string connectionString = "Server=YADAVJI\\SQLEXPRESS; Database=SPStudentDB;  Trusted_Connection=True; MultipleActiveResultSets=true; initial catalog =SPStudentDB;Integrated Security =True;TrustServerCertificate = True;";
  //string connectionString = "Data Source=192.168.1.68,5810;Initial Catalog=Student;Integrated Security=True";
   //To View all Student details    
    public IEnumerable<Student> GetAllStudents()
            {
                List<Student> lstStudent = new List<Student>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("usp_GetAllStudents", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                    Student Student = new Student();

                    Student.ID = Convert.ToInt32(rdr["StudentID"]);
                    Student.Name = rdr["Name"].ToString();
                    Student.Course = rdr["Course"].ToString();
                    Student.Date_Of_Birth = Convert.ToDateTime(rdr["Date_Of_Birth"]);
                    Student.Mobile = rdr["Mobile"].ToString();
                    Student.Gender = rdr["Gender"].ToString();
                    Student.Country = rdr["Country"].ToString();
                    Student.City = rdr["City"].ToString();

                    lstStudent.Add(Student);
                    }
                    con.Close();
                }
                return lstStudent;
            }

        //To Add new Student record    
        public void AddStudent(Student Student)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("usp_AddStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", Student.Name);
                    cmd.Parameters.AddWithValue("@Course", Student.Course);
                    cmd.Parameters.AddWithValue("@Mobile", Student.Mobile);
                    cmd.Parameters.AddWithValue("@Date_Of_Birth", Student.Date_Of_Birth);
                    cmd.Parameters.AddWithValue("@Gender", Student.Gender);
                    cmd.Parameters.AddWithValue("@Country", Student.Country);
                    cmd.Parameters.AddWithValue("@City", Student.City);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        //To Update the records of a particluar Student  
        public void UpdateStudent(Student Student)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("usp_UpdateStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StudentId", Student.ID);
                    cmd.Parameters.AddWithValue("@Name", Student.Name);
                    cmd.Parameters.AddWithValue("@Course", Student.Course);
                    cmd.Parameters.AddWithValue("@Mobile", Student.Mobile);
                    cmd.Parameters.AddWithValue("@Date_Of_Birth", Student.Date_Of_Birth);
                    cmd.Parameters.AddWithValue("@Gender", Student.Gender);
                    cmd.Parameters.AddWithValue("@Country", Student.Country);
                    cmd.Parameters.AddWithValue("@City", Student.City);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        //Get the details of a particular Student  
        public Student GetStudentData(int? id)
            {
            Student Student = new Student();

                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand("usp_GetStudentByID", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StudentId", id);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                    Student.ID = Convert.ToInt32(rdr["StudentID"]);
                    Student.Name = rdr["Name"].ToString();
                    Student.Course = rdr["Course"].ToString();
                    Student.Mobile = rdr["Mobile"].ToString();
                    Student.Date_Of_Birth = Convert.ToDateTime(rdr["Date_Of_Birth"]);
                    Student.Gender = rdr["Gender"].ToString();
                    Student.Country = rdr["Country"].ToString();
                    Student.City = rdr["City"].ToString();
                    }
                }
                return Student;
            }

        //To Delete the record on a particular Student  
        public void DeleteStudent(int? id)
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("usp_DeleteStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StudentId", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }

