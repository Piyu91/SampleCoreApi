using DataAccessLayer;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Business : IBusiness
    {
        private readonly IDataLayer _dataLayer;
        Logger loggerins;
        public Business(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
            loggerins = Logger.GetInstance();
        }

        public Student getStudentById(int Id)
        {
            if (Id < 1)
            {
                throw new ArgumentException("id should be greater than 0");
            }
            try
            {
                var student = _dataLayer.GetStudentById(Id);
                loggerins.LogData($"Student found from business with id: {Id}");


                return new Student
                {
                    ID = student.ID,
                    Name = $"{student.FirstName} {student.LastName}",
                    Grade = student.Grade,
                    DeptName = student.Dept.DeptName,
                    DeptLoc = student.Dept.DeptLocation
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Student> getStudents()
        =>  _dataLayer.GetStudents().Select(student => new Student {
                ID = student.ID,
                Name = $"{student.FirstName} {student.LastName}",
                Grade = student.Grade,
                DeptName = student.Dept.DeptName,
                DeptLoc = student.Dept.DeptLocation
            }).ToList();


        
    }
}
