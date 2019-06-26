using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;
using System;

namespace LINQExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>()
            {
                new Person("Nathanael", "Holt", 20, Job.Choreographer),
                new Person("Jabari", "Chapman", 35, Job.Designer),
                new Person("Oswaldo", "Wilson", 19, Job.Developer),
                new Person("Kody", "Walton", 43, Job.Sculptor),
                new Person("Andreas", "Weeks", 17, Job.Developer),
                new Person("Kayla", "Douglas", 28, Job.Designer),
                new Person("Xander", "Campbell", 19, Job.Waiter),
                new Person("Soren", "Velasquez", 33, Job.Interpreter),
                new Person("August", "Rubio", 21, Job.Developer),
                new Person("Malakai", "Mcgee", 57, Job.Barber),
                new Person("Emerson", "Rollins", 42, Job.Choreographer),
                new Person("Everett", "Parks", 39, Job.Sculptor),
                new Person("Amelia", "Moody", 24, Job.Waiter),
                new Person("Emilie", "Horn", 16, Job.Waiter),
                new Person("Leroy", "Baker", 44, Job.Interpreter),
                new Person("Nathen", "Higgins", 60, Job.Archivist),
                new Person("Erin", "Rocha", 37, Job.Developer),
                new Person("Freddy", "Gordon", 26, Job.Interpreter),
                new Person("Valeria", "Reynolds", 26, Job.Dentist),
                new Person("Cristofer", "Stanley", 22, Job.Dentist),
                new Person("William", "Favorite", 29, Job.Waiter),
                new Person("James", "Ferguson", 34, Job.Tattooist),
                new Person("Julian", "Stanley", 47, Job.Auctioneer),
                new Person("Tom", "Barnes", 19, Job.Barber),
                new Person("James", "Rodriguez", 55, Job.Dentist),
                new Person("Jean", "Gaylord", 23, Job.Archivist),
                new Person("Erika", "Lawrence", 67, Job.Sculptor),
                new Person("Vanessa", "Braman", 33, Job.Lecturer),
                new Person("Donna", "Snider", 36, Job.Sculptor),
                new Person("Larry", "Ellington", 41, Job.Dietician)
            };

            var dogs = new List<Dog>()
            {
                new Dog("Charlie", Color.Black, 3, Race.Collie),
                new Dog("Buddy", Color.Brown, 1, Race.Doberman),
                new Dog("Max", Color.Olive, 1, Race.Plott),
                new Dog("Archie", Color.Black, 2, Race.Doberman),
                new Dog("Oscar", Color.Mix, 1, Race.Mudi),
                new Dog("Toby", Color.Silver, 3, Race.Bulldog),
                new Dog("Ollie", Color.Golden, 4, Race.Husky),
                new Dog("Bailey", Color.White, 4, Race.Pointer),
                new Dog("Frankie", Color.Olive, 2, Race.Retriever),
                new Dog("Jack", Color.Black, 5, Race.Dalmatian),
                new Dog("Chanel", Color.White, 1, Race.Pug),
                new Dog("Henry", Color.Black, 7, Race.Plott),
                new Dog("Bo", Color.Maroon, 3, Race.Boxer),
                new Dog("Scout", Color.Mix, 2, Race.Boxer),
                new Dog("Ellie", Color.Brown, 6, Race.Doberman),
                new Dog("Hank", Color.Silver, 2, Race.Collie),
                new Dog("Shadow", Color.Brown, 3, Race.Mudi),
                new Dog("Diesel", Color.Golden, 1, Race.Bulldog),
                new Dog("Abby", Color.Mix, 1, Race.Dalmatian),
                new Dog("Trixie", Color.Maroon, 6, Race.Mudi),
                new Dog("Alfi", Color.Black, 3, Race.Chihuahua),
                new Dog("Benji", Color.Brown, 2, Race.Cocker),
                new Dog("Ava", Color.Golden, 4, Race.Bulldog),
                new Dog("Chet", Color.Olive, 1, Race.Boxer),
                new Dog("Rigby", Color.Mix, 5, Race.Collie),
                new Dog("Sam", Color.Silver, 1, Race.Inu),
                new Dog("Tilly", Color.White, 3, Race.Retriever),
                new Dog("Yumi", Color.White, 4, Race.Retriever),
                new Dog("Zoe", Color.Brown, 9, Race.Husky),
                new Dog("Gonzo", Color.Mix, 1, Race.Doberman),
            };

            #region Exercises

            //==============================
            // TODO LINQ expressions :)
            // Your turn guys...
            //==============================

            //PART 1
            // 1. Structure the solution (create class library and move classes and enums accordingly)

            //PART 2
            // 1. Take person Cristofer and add Jack, Ellie, Hank and Tilly as his dogs.

            var cristofer = people.Where(p => p.FirstName == "Cristofer").SingleOrDefault();
            var jack = FindingDogs("Jack", dogs);
            var ellie = FindingDogs("Ellie", dogs);
            var hank = FindingDogs("Hank", dogs);
            var tilly = FindingDogs("Tilly", dogs);
            cristofer.Dogs.Add(jack);
            cristofer.Dogs.Add(ellie);
            cristofer.Dogs.Add(hank);
            cristofer.Dogs.Add(tilly);


            // 2. Take person Freddy and add Oscar, Toby, Chanel, Bo and Scout as his dogs.

            var freddy = people.Where(p => p.FirstName == "Freddy").SingleOrDefault();
            var oscar = FindingDogs("Oscar", dogs);
            var toby = FindingDogs("Toby", dogs);
            var chanel = FindingDogs("Chanel", dogs);
            var bo = FindingDogs("Bo", dogs);
            var scout = FindingDogs("Scout", dogs);
            freddy.Dogs.Add(oscar);
            freddy.Dogs.Add(toby);
            freddy.Dogs.Add(chanel);
            freddy.Dogs.Add(bo);
            freddy.Dogs.Add(scout);

            // 3. Add Trixie, Archie and Max as dogs from Erin.

            var erin = people.Where(p => p.FirstName == "Erin").SingleOrDefault();
            var trixie = FindingDogs("Trixie", dogs);
            var archie = FindingDogs("Archie", dogs);
            var max = FindingDogs("Max", dogs);
            erin.Dogs.Add(trixie);
            erin.Dogs.Add(archie);
            erin.Dogs.Add(max);


            // 4. Give Abby and Shadow to Amelia.

            var amelia = people.Where(p => p.FirstName == "Amelia").SingleOrDefault();
            var abby = FindingDogs("Abby", dogs);
            var shadow = FindingDogs("Shadow", dogs);
            amelia.Dogs.Add(abby);
            amelia.Dogs.Add(shadow);

            // 5. Take person Larry and Zoe, Ollie as his dogs.
            var larry = people.Where(p => p.FirstName == "Larry").SingleOrDefault();
            var zoe = FindingDogs("Zoe", dogs);
            var ollie = FindingDogs("Ollie", dogs);
            larry.Dogs.Add(zoe);
            larry.Dogs.Add(ollie);

            // 6. Add all retrievers to Erika.

            var erika = people.Where(p => p.FirstName == "Erika").SingleOrDefault();
            var retrievers = dogs.Where(d => d.Race == Race.Retriever).ToList();
            erika.Dogs.AddRange(retrievers);

            // 7. Erin has Chet and Ava and now give Diesel to August thah previously has just Rigby

            var august = people.Where(p => p.FirstName == "August").SingleOrDefault();
            var diesel = FindingDogs("Diesel", dogs);
            var rigby = FindingDogs("Rigby", dogs);
            var chet = FindingDogs("Chet", dogs);
            var ava = FindingDogs("Ava", dogs);
            august.Dogs.Add(diesel);
            august.Dogs.Add(rigby);
            erin.Dogs.Add(chet);
            erin.Dogs.Add(ava);


            //PART 3 - LINQ
            // 1. Find and print all persons firstnames starting with 'R', ordered by age - DESCENDING ORDER.
            Console.WriteLine("Person's name starts with R ordered by age(DESCENDING)");
            Console.WriteLine();

            var firstNameWithR = people
                .Where(p => p.FirstName.StartsWith("R"))
                .OrderByDescending(p => p.Age);
            Print(firstNameWithR);

            // 2. Find and print all brown dogs names and ages older than 3 years, ordered by age - ASCENDING ORDER.
            Console.WriteLine("Brown dogs older than 3 years, ordered by age(ASCENDING)");
            Console.WriteLine();

            var brownDogsOlderThan3 = dogs
                .Where(d => d.Color == Color.Brown)
                .Where(d => d.Age > 3)
                .OrderBy(d => d.Age);
            Print(brownDogsOlderThan3);

            // 3. Find and print all persons with more than 2 dogs, ordered by name - DESCENDING ORDER.
            Console.WriteLine("Persons with more than 2 dogs ordered by name(DESCENDING)");
            Console.WriteLine();

            var personsWithMoreThan2Dogs = people
                .Where(p => p.Dogs.Count() > 2)
                .OrderByDescending(p => p.FirstName);
            Print(personsWithMoreThan2Dogs);

            // 4. Find and print all persons names, last names and job positions that have just one race type dogs.
            Console.WriteLine("Persons that have just one race type dogs");
            Console.WriteLine();

            var peopleWithOneTypeDog = people
                .Where(p => p.Dogs.Count() >= 1)
                .Where(p => DogRace(p.Dogs));

            Print(peopleWithOneTypeDog);

            // 5. Find and print all Freddy`s dogs names older than 1 year, grouped by dogs race.
            Console.WriteLine("Freddy`s dogs older than 1 year, grouped by dogs race");
            Console.WriteLine();

            var freddyDogsOlderThan1 = freddy.Dogs.Where(d => d.Age > 1).OrderBy(d => d.Race);
            Print(freddyDogsOlderThan1);

            // 6. Find and print last 10 persons grouped by their age.

            var last10Persons = people.Where((p, index) => index > people.Count - 11).OrderBy(p => p.Age);
            Print(last10Persons);

            // 7. Find and print all dogs names from Cristofer, Freddy, Erin and Amelia, grouped by color and ordered by name - ASCENDING ORDER.

            //var dogsByCFEA = new List<Dog>();
            //dogsByCFEA.AddRange(cristofer.Dogs);
            //dogsByCFEA.AddRange(freddy.Dogs);
            //dogsByCFEA.AddRange(erin.Dogs);
            //dogsByCFEA.AddRange(amelia.Dogs);

            // Dont know how to use GroupBy
            
            //var orderDogsByCFEA = dogsByCFEA.GroupBy(d => d.Name).OrderBy(d => d.Color);
            //Print(orderDogsByCFEA);

            // 8. Find and persons that have same dogs races and order them by name length ASCENDING, then by age DESCENDING.
            Console.WriteLine("persons that have same dogs races and order them by name length ASCENDING,then by age DESCENDING");

            var personsWithSameRace = people
                .Where(p => p.Dogs.Count() >= 1)
                .Where(p => SameDogRaces(p.Dogs))
                .OrderBy(p => p.FirstName.Length);

            Print(personsWithSameRace);
            Print(personsWithSameRace.OrderByDescending(p => p.Age));
            // 9. Find the last dog of Amelia and print all dogs form other persons older than Amelia, ordered by dogs age DESCENDING.

            var lastDogOfAmelia = amelia.Dogs.Last();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Last dog of amelia: " + lastDogOfAmelia.Name);
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();
            var dogsFromPeopleOlderThanAmelia = people
                .Where(p => p.Dogs.Count() > 0)
                .Where(p => p.Age > amelia.Age)
                .Select(p => p.Dogs);

            Console.WriteLine("All dogs form other persons older than Amelia");
            Console.WriteLine();
            foreach (var item in dogsFromPeopleOlderThanAmelia)
            {
                Print(item);
            }

            // 10. Find all developers older than 20 with more than 1 dog that contains letter 'e' in the name and print their names and job positions.

            var developers = people
                .Where(p => p.Occupation == Job.Developer)
                .Where(p => p.Age >= 20)
                .Where(p => p.Dogs.Count > 1)
                .Where(p => p.FirstName.ToLower().Contains("e"));

            Print(developers);

            #endregion
        }

        public static Dog FindingDogs(string name, IEnumerable<Dog> dogs)
        {
            return dogs.Where(p => p.Name == name).SingleOrDefault();            
        }

        public static void Print<T>(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------------");
        }

        public static bool DogRace(List<Dog> dogs)
        {

            var race = dogs[0].Race;
            foreach (var item in dogs)
            {
                if (item.Race != race)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool SameDogRaces(List<Dog> dogs)
        {
            for (int i = 0; i < dogs.Count(); i++)
            {
                for (int j = i + 1; j < dogs.Count(); j++)
                {
                    if(dogs[i].Race == dogs[j].Race)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}