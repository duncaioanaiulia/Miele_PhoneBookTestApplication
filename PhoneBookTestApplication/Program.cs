using System;
using PhoneBookTestApplication.ViewModels.ViewModels;

namespace PhoneBookTestApplication
{
	class MainClass
	{
		private static PersonViewModel _personViewModel;

		public static void Main(string[] args)
		{
			_personViewModel = new PersonViewModel();

			Console.WriteLine("Available commands: \n list \n add (Person) \n remove (Person Name) \n command example: add Ionica|Popescu|Crisului|6|||1|0742131415");

			while (true)
			{
				Console.WriteLine("Insert command:");
				ParseCommand(Console.ReadLine());

				Console.ReadLine();
			}
		}

		private static void ParseCommand(string command)
		{
			switch (command)
			{
				case ("list"):
					{
						var persons = _personViewModel.GetAllPersons();

						foreach (var person in persons)
						{
							// TODO override ToString to show the actual list of persons
							Console.WriteLine(person.ToString());
						}

						break;
					}
				// TODO implement the add and remove command parsings (also make checks that the user does not enter
				// faulty data and the mandatory fields are filled in)
				default:
					break;
			}

		}
	}
}
