using DataBaseEntity;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class DataLayer : IDataLayer
    {
        private readonly DbContext _context;
        public DataLayer(DbContext context)
        {
            _context = context;
        }

        public List<DbStudent> GetStudents()
        {
            return _context.GetStudents();
        }
        public DbStudent GetStudentById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id should be greater than 0");
            }
            try
            {
                return _context.GetStudents().Find(x=> x.ID == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
