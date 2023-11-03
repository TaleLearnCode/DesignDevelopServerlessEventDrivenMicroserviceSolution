#nullable disable

namespace BuildingBricks.Shipping.Models;

public partial class Customer
{

	public int CustomerId { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string StreetAddress { get; set; }

	public string City { get; set; }

	public string CountryDivisionCode { get; set; }

	public string CountryCode { get; set; }

	public string PostalCode { get; set; }

}