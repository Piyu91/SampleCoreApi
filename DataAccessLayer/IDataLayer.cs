using DataBaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IDataLayer
    {
        List<DbStudent> GetStudents();
        DbStudent GetStudentById(int id);
    }
}
