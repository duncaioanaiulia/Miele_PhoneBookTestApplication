using System;
using PhoneBookTestApplication.Models.Enums;

namespace PhoneBookTestApplication.Models
{
	public class PhoneNumberModel
	{
		// mandatory
		public PhoneTypeEnum PhoneType { get; set; }

		// mandatory
		public string PhoneNumber { get; set; }
	}
}
