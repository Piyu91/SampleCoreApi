using DomainModels;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IBusiness
    {
        List<Student> getStudents();
        Student getStudentById(int Id);
    }
}
