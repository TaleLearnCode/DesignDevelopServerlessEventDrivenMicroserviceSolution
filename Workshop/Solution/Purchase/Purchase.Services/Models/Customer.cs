#nullable disable

namespace BuildingBricks.Purchase.Models;

/// <summary>
/// Represents a customer making purchases.
/// </summary>
public partial class Customer
{

	/// <summary>
	/// Identifier for the customer.
	/// </summary>
	public int CustomerId { get; set; }

	/// <summary>
	/// The first name of the customer.
	/// </summary>
	public string FirstName { get; set; }

	/// <summary>
	/// The last name of the customer.
	/// </summary>
	public string LastName { get; set; }

	/// <summary>
	/// The street address for the customer.
	/// </summary>
	public string StreetAddress { get; set; }

	/// <summary>
	/// The city for the customer shipping address.
	/// </summary>
	public string City { get; set; }

	/// <summary>
	/// Code for the country division for the customer shipping address.
	/// </summary>
	public string CountryDivisionCode { get; set; }

	/// <summary>
	/// Code for the country for the customer shipping address.
	/// </summary>
	public string CountryCode { get; set; }

	/// <summary>
	/// Postal code for the customer shipping address.
	/// </summary>
	public string PostalCode { get; set; }

	/// <summary>
	/// Email address for the customer
	/// </summary>
	public string EmailAddress { get; set; }

	public virtual CountryDivision CountryDivision { get; set; }

	public virtual Country Country { get; set; }

	public virtual ICollection<CustomerPurchase> CustomerPurchases { get; set; } = new List<CustomerPurchase>();

}