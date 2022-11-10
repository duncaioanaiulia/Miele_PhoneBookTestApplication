using System;
using System.Collections.Generic;
using PhoneBookTestApplication;

namespace PhoneBookTestApplication.Models
{
	public class PersonModel
	{
        public int PersonId { get; set; }
        public string FirstName { get; set; }

		// mandatory
		public string LastName { get; set; }

		// at least one is mandatory
		public List<AddressModel> Addresses { get; set; }

        // not mandatory
        public DateTime? Birthday { get; set; } 
    }
}
