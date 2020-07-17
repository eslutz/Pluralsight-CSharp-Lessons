using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.BegCShCollections.TopTenPops
{
	class Program
	{
		static void Main(string[] args)
		{
			string filePath = @"C:\Users\eslutz\OneDrive - KNEX\Documents\Dev.Build(4.0)\Pluralsight CSharp Lessons\TopTenPops\Pop by Largest Final.csv";
			CsvReader reader = new CsvReader(filePath);

			//Dictionary<string, Country> countries = reader.ReadAllCountries();
			//Country lilliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
			////int lilliputIndex = countries.FindIndex(x => x.Population < 2_000_000);
			//countries.Add(lilliput.Code, lilliput);
			////countries.RemoveAt(lilliputIndex);

			//// NB. Bear in mind when trying this code that string comparison is by default case-sensitive.
			//// Hence, for example, to display Finland, you need to type in "FIN" in capitals. "fin" won't work.
			//Console.WriteLine("Which country code do you want to look up? ");
			//string userInput = Console.ReadLine();

			//bool gotCountry = countries.TryGetValue(userInput, out Country country);
			//if (!gotCountry)
			//	Console.WriteLine($"Sorry, there is no country with code, {userInput}");
			//else
			//	Console.WriteLine($"{country.Name} has population {PopulationFormatter.FormatPopulation(country.Population)}");

			Dictionary<string, List<Country>> countries = reader.ReadAllCountries();

			foreach (string region in countries.Keys)
				Console.WriteLine(region);

			Console.Write("Which of the above regions do you want? ");
			string chosenRegion = Console.ReadLine();

			if (countries.ContainsKey(chosenRegion))
			{
				// display 10 highest population countries in the selected region
				foreach (Country country in countries[chosenRegion].Take(10))
					Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
			}
			else
				Console.WriteLine("That is not a valid region");
		}
	}
}