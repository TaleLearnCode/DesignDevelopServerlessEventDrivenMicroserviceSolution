#nullable disable

namespace BuildingBricks.Notice.Models;

/// <summary>
/// Represents the log of notices sent to customers.
/// </summary>
public partial class NoticeLog
{

	/// <summary>
	/// Identifier for the notice log.
	/// </summary>
	public string NoticeLogId { get; set; }

	/// <summary>
	/// Identifier for the associated notice type.
	/// </summary>
	public int NoticeTypeId { get; set; }

	/// <summary>
	/// Identifier for the associated customer.
	/// </summary>
	public int CustomerId { get; set; }

	/// <summary>
	/// The UTC date and time the notice was sent.
	/// </summary>
	public DateTime SentDateTime { get; set; }

	/// <summary>
	/// The body of the notice message.
	/// </summary>
	public string NoticeBody { get; set; }

	public virtual Customer Customer { get; set; }

	public virtual NoticeType NoticeType { get; set; }

}