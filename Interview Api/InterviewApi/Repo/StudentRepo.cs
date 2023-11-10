using InterviewApi.Models;

namespace InterviewApi.Repo
{
    public class StudentRepo : IStudentRepo
    {

        //CRUD
        StudentDbContext con;

        public StudentRepo(StudentDbContext _con)
        {
            con = _con;
        }

        public List<Student> GetAll()
        {
            return con.Students.ToList();
        }

        public Student GetById(int id)
        {
            return con.Students.Find(id);
        }

        public bool Update(Student student)
        {
            try
            {
                con.Students.Update(student);
                con.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Student student = GetById(id);
                con.Students.Remove(student);
                con.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Insert(Student student)
        {
            
            try
            {
                con.Students.Add(student);
                con.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
