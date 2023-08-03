using System;
using System.Collections.Generic;

namespace BuildingBricks.NM.Models
{
    public partial class NotificationType
    {
        public NotificationType()
        {
            NotificationLogs = new HashSet<NotificationLog>();
        }

        public int NotificationTypeId { get; set; }
        public string NotificationTypeName { get; set; } = null!;

        public virtual ICollection<NotificationLog> NotificationLogs { get; set; }
    }
}
