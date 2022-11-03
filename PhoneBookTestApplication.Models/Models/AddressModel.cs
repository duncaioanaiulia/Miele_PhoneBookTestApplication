using System;
using System.Collections.Generic;

namespace PhoneBookTestApplication.Models
{
	public class AddressModel
	{
		// mandatory
		public string StreetName { get; set; }

		// mandatory
		public int StreetNumber { get; set; }

		// not mandatory
		public string City { get; set; }

		// not mandatory
		public string Country { get; set; }

		// at least one is mandatory
		public List<PhoneNumberModel> PhoneNumbers { get; set; }
	}
}
