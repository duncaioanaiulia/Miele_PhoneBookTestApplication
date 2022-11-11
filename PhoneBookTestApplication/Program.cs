using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;
using PhoneBookTestApplication.Models;
using PhoneBookTestApplication.Models.Enums;
using PhoneBookTestApplication.ViewModels.ViewModels;

namespace PhoneBookTestApplication
{
	class MainClass
	{
		private static PersonViewModel _personViewModel;

		private const string commandList = "list";
		private const string commandAdd = "add";
		private const string commandRemove = "remove";
		private const string commangSearch = "search";

        public static void Main(string[] args)
		{
			_personViewModel = new PersonViewModel();

			var test = _personViewModel.GetAllPersons();
				//  "Available commands: \n  {0} \n {1} (Person) \n {2} (Person Name) \n command example: add Ionica|Popescu|Crisului|6|||1|0742131415"
            
            Console.WriteLine(string.Format(
				  "Available commands: \n{0}\n{1}\n{2}\n{3}", 
				  commandList, commandAdd, commandRemove, commangSearch));

			while (true)
			{
				Console.WriteLine("Insert command:");
				ParseCommand(Console.ReadLine());
				Console.ReadLine();
			}
		}

		private static void ParseCommand(string command)
		{

            var persons = _personViewModel.GetAllPersons();

            switch (command)
			{
				case (commandList):
					{
						ShowDetailsPersons(persons);
						break;
					}
                case (commandAdd):
                    {
                        Console.WriteLine("Insert example: Ionica|Popescu|Crisului|6|Iasi|Ro|Personal/Work|0742131415");
                        ParseAddCommand(Console.ReadLine());
                        break;
                    }
                case (commandRemove):
                    {
                        Console.WriteLine("Insert name:");
                        ParseRemoveCommand(Console.ReadLine(), persons);
                        break;
                    }
				case (commangSearch):
					{
                        Console.WriteLine("Search name:");
                        ParseSearchCommand(Console.ReadLine());
                        break;
					}
                default:
					break;
			}
		}

		private static void ParseAddCommand(string command)
		{
            List<string> detailsPerson = command.Split("|").ToList();
			if (detailsPerson is null || detailsPerson.Count<8)
			{
				Console.WriteLine("Please fill all the mandatory data!!");
				ParseCommand(commandAdd);
				return;
			}

			_personViewModel.Person =
				new PersonModel()
				{
					FirstName = detailsPerson.ElementAt(0),
					LastName = detailsPerson.ElementAt(1)
                };

			_personViewModel.Person.Addresses.Add(new AddressModel()
			{
				StreetName = detailsPerson.ElementAt(2),
				StreetNumber = int.Parse(detailsPerson.ElementAt(3)),
				City = detailsPerson.ElementAt(4),
				Country = detailsPerson.ElementAt(5)
			}) ;
			_personViewModel.Person.Addresses.First().PhoneNumbers.Add(
				new PhoneNumberModel()
				{
					PhoneType = (PhoneTypeEnum)Enum.Parse(typeof(PhoneTypeEnum), detailsPerson.ElementAt(6)),
					PhoneNumber = detailsPerson.ElementAt(7)
				});

            _personViewModel.AddOrEditPerson();
        }

        private static void ParseRemoveCommand(string command, IList<PersonModel> persons)
        {
            var removePerson = persons.FirstOrDefault(person
                => command.Contains(person.FirstName)
                && command.Contains(person.LastName));

            if (removePerson is null)
                return;

            _personViewModel.RemovePerson(removePerson.PersonId);
        }

        private static void ParseSearchCommand(string command)
		{
            List<string> detailsPerson = command.Split(" ").ToList();

			if(detailsPerson.Count <2 )
			{
                Console.WriteLine("Enter First Name AND Last Name");
                ParseCommand(commangSearch);
				return;
            }

            var serchedPerson = _personViewModel.SearchPerson(detailsPerson.ElementAtOrDefault(0), detailsPerson.ElementAtOrDefault(1));

			if (serchedPerson.Any())
			{
                Console.WriteLine();
                ShowDetailsPersons(serchedPerson);
				return;
            }

            Console.WriteLine("Try again!!");
            ParseCommand(commangSearch);
        }

		private static void ShowDetailsPersons(IList<PersonModel> persons)
		{
			foreach (var person in persons)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(person.PersonId);
				stringBuilder.Append(" ");
				stringBuilder.Append(person.FirstName);
				stringBuilder.Append(" ");
				stringBuilder.Append(person.LastName);
				stringBuilder.Append(", ");
				stringBuilder.Append(person.Addresses.First().PhoneNumbers.First().PhoneNumber);
				Console.WriteLine(stringBuilder.ToString());
			}
        }
	}
}
