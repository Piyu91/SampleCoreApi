namespace DataBaseEntity
{
    public class DbStudent
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }
        public DbDepartment Dept { get; set; }
    }
}
