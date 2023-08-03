using System;
using System.Collections.Generic;

namespace BuildingBricks.NM.Models
{
    public partial class NotificationLog
    {
        public int NotificationLogId { get; set; }
        public int NotificationTypeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SentDateTime { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual NotificationType NotificationType { get; set; } = null!;
    }
}
