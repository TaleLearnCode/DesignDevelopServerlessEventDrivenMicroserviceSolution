#nullable disable

namespace BuildingBricks.Notice.Models;

/// <summary>
/// Represents a customer receiving notifications.
/// </summary>
public partial class Customer
{

	/// <summary>
	/// Identifier for the customer.
	/// </summary>
	public int CustomerId { get; set; }

	/// <summary>
	/// The email address where the customer will receive notifications.
	/// </summary>
	public string EmailAddress { get; set; }

	public virtual ICollection<NoticeLog> NoticeLogs { get; set; } = new List<NoticeLog>();

}