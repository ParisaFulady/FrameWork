using System;
using System.Collections.Generic;
using System.Text;

namespace AChangeTracker.Entities
{
    public class DataChangeHistory
    {
        public int DataChangeHistoryID { get; set; }
        public string EntityType { get; set; }
        public string EtityID { get; set; }
        public string SerializeData { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
