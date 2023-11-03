using System;
using System.Collections.Generic;

namespace BuildingBricks.NM.Models
{
    public partial class Customer
    {
        public Customer()
        {
            NotificationLogs = new HashSet<NotificationLog>();
        }

        public int CustomerId { get; set; }
        public string EmailAddress { get; set; } = null!;

        public virtual ICollection<NotificationLog> NotificationLogs { get; set; }
    }
}
