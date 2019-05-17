using DataBaseEntity;
using DomainModels;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class DataLayer : IDataLayer
    {
        private readonly DbContext _context;
        Logger logginvar;
        public DataLayer(DbContext context)
        {
            _context = context;

            logginvar = Logger.GetInstance();
        }

        public List<DbStudent> GetStudents()
        {
            return _context.GetStudents();
        }
        public DbStudent GetStudentById(int id)
        {
            if (id < 1)
            {
                logginvar.LogData($"Log data from datalayer {id} failed");
                throw new ArgumentException("id should be greater than 0");
            }
            try
            {
                logginvar.LogData($"Log data from datalayer {id}");
                return _context.GetStudents().Find(x=> x.ID == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
