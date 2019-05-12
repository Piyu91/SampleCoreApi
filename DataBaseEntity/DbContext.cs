using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseEntity
{
    public class DbContext
    {
        static List<DbStudent> dbStudentList = new List<DbStudent>()
        {
            new DbStudent
            {
                ID=1, FirstName="Sukanta", LastName="Saha", Grade = "A", Dept=new DbDepartment
                {
                    DeptId=1, DeptLocation="Ind",DeptName="Comp"
                }
            },
            new DbStudent
            {
                ID=2, FirstName="Priyanka", LastName="Saha", Grade = "E", Dept=new DbDepartment
                {
                    DeptId=2, DeptLocation="Ind",DeptName="IT"
                }
            }
        };
        public List<DbStudent> GetStudents()
        {
            return dbStudentList;
        }
    }
}
