using System;
using System.Collections.Generic;

namespace BuildingBricks.OM.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? CountryDivisionCode { get; set; }
        public string CountryCode { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string EmailAddress { get; set; } = null!;
    }
}
