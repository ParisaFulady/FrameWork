using System;
using System.Collections.Generic;
using System.Text;

namespace AChangeTracker.Entities
{
    public interface IAuditable
    {
        int InsertBy { get; set; }
        int UpdateBy { get; set; }
        DateTime InertDate { get; set; }
        DateTime UpdateDate { get; set; }
    }
}
