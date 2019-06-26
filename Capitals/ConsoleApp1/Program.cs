using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var capitals = new Dictionary<string, string>
            {
                { "Bulgaria", "Sofia" },
                { "Greece", "Athens" },
                { "Serbia", "Belgrade" },
                { "Albania", "Tirana" },
                { "Kosovo", "Prishtina" },
                { "Madagaskar", "Antanarive" },
                { "Chile", "Santiago" },
                { "Mongolia", "Ulan Bator" }
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Add new country  2. Find country's capital or reverse");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("enter name of the country: ");
                    string country = Console.ReadLine().ToLower();
                    Console.WriteLine("enter name of the capital: ");
                    string capital = Console.ReadLine().ToLower();

                    capitals.Add( country, capital );
                }
                else if (input == "2")
                {
                    Console.WriteLine("1. Country or 2. Capital");
                    string input2 = Console.ReadLine();
                    Console.Write("Enter the name: ");
                    if (input2 == "1")
                    {
                        string country = Console.ReadLine().ToLower();

                        try
                        {
                            string capital = capitals.Single(x => x.Key.ToLower() == country).Value;
                            Console.WriteLine($"The capital of {country} is {capital}");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("there is no country like " + country);
                        }
                    }
                    else if(input2 == "2")
                    {
                        string capital = Console.ReadLine().ToLower();
                        try
                        {
                            string country = capitals.Single(x => x.Value.ToLower() == capital).Key;
                            Console.WriteLine($"{capital} is capital of {country}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("there is no capital like " + capital);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input! Please input 1 or 2");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input! Please input 1 or 2");
                }

                Console.ReadLine();
            }
        }
    }
}