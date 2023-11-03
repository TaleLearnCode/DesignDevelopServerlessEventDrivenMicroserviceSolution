#nullable disable

namespace BuildingBricks.Notice.Models;

/// <summary>
/// Represents the types of notices sent to customers.
/// </summary>
public partial class NoticeType
{

	/// <summary>
	/// Identifier for the notice type.
	/// </summary>
	public int NoticeTypeId { get; set; }

	/// <summary>
	/// Name of the notice type.
	/// </summary>
	public string NoticeTypeName { get; set; }

	public virtual ICollection<NoticeLog> NoticeLogs { get; set; } = new List<NoticeLog>();

}