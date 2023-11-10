using InterviewApi.Models;

namespace InterviewApi.Repo
{
    public interface IStudentRepo
    {
        Student GetById(int id);
        List<Student> GetAll();
        bool Insert(Student student);
        bool Update(Student student);
        bool Delete(int id);

    }
}
