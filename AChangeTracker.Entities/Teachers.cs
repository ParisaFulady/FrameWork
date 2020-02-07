using System;

namespace AChangeTracker.Entities
{
    public class Teachers: IAuditable
    {
        public int TeachersID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int InsertBy { get; set; }
        public int UpdateBy { get; set; }
        public DateTime InertDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
