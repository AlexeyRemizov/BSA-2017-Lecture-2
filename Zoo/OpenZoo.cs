//BSA 17 .NET. Lecture 3 - Data Structures & LINQ
using System;
using System.Linq;
using Zoo.Animals;
using System.Threading;

namespace Zoo.OpenZoo
{
	class Open
	{
		Zoo zoo;
		public void Start()
		{
			Console.WriteLine("Welcome to the new world of aminal - Zoo of Dead!\n");
			Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||\n");
			zoo = new Zoo();
			while (true)
			{
				if (zoo.Animals.Count == 0)
				{
					AddAnimal();
				}
				else SelectOperation();
			}
		}

		void SelectOperation()
		{
			int result;
			Console.WriteLine(@"Perform the operations:
======================================================
1 - Add new animal
2 - Feed the animal
3 - Cure the animal
4 - Remove the dead animal
5 - Show all animals, grouped by kind
6 - Show animals according to the state
7 - Show all sick tigers
8 - Show an elephant by pet name
9 - Show all pet names of hungry animals
10 - Show max health animal per kind
11 - Show amount of dead animal per kind
12 - Show all wolves and bears with health more than 3
13 - Show animals with min and max health
14 - Show the average health in the ''Dead Zoo''
15 - Exit
======================================================");

			var value = Console.ReadLine();
			if (!int.TryParse(value, out result) || result > 15 || result < 1)
			{
				Console.WriteLine("Incorrect value!");
			}
			else
			{

				switch (result)
				{
					case 1:
						AddAnimal();
						break;
					case 2:
						FindbyPetName()?.Feed();
						break;
					case 3:
						FindbyPetName()?.Treat();
						break;
					case 4:
						FindbyPetName()?.Remove();
						break;
					case 5: GroupByKind();
						break;
					case 6: ShowAnimalsWithState();
						break;
					case 7: ShowSickTigers();
						break;
					case 8: ShowElephant();
						break;
					case 9: ShowHungryAnimalsNames();
						break;
					case 10: MaxHealthAnimals();
						break;
					case 11: DeadAnimalsPerKind();
						break;
					case 12: ShowWolvesAndBears();
						break;
					case 13: ShowMinAndMaxHealthAnimals();
						break;
					case 14: ShowAverageHealthInZoo();
						break;
					case 15:
						Console.WriteLine("With best regards!!! Your zoo");
						Thread.Sleep(3000);
						Environment.Exit(0);
						break;
				}
			}


		}

		void GroupByKind()
		{
			Console.Clear();
			Console.WriteLine("\nAll animals, grouped by kind:");
			var Kind = zoo.Animals.GroupBy(x => x.GetType());
			Kind.Select(x => x.Key.Name).ToList().ForEach(Console.WriteLine);
			Console.ReadKey();
		}


		void ShowAnimalsWithState()
		{
			Console.Clear();
			int result1;
			Console.WriteLine(@"Perform the following state:
1 - Full
2 - Hungry
3 - Sick
4 - Dead");
			var value1 = Console.ReadLine();
			if (!int.TryParse(value1, out result1) || result1 > 4 || result1 < 1)
			{
				Console.WriteLine("Incorrect value!");
			}
			else
			{

				switch (result1)
				{
					case 1:
						var full = zoo.Animals.Where(x => x.GetAnimalState() == "Full");
						full.ToList().ForEach(Console.WriteLine);
						break;
					case 2:
						var Hungry = zoo.Animals.Where(x => x.GetAnimalState() == "Hungry");
						Hungry.ToList().ForEach(Console.WriteLine);
						break;
					case 3:
						var Sick = zoo.Animals.Where(x => x.GetAnimalState() == "Sick");
						Sick.ToList().ForEach(Console.WriteLine);
						break;
					case 4:
						var Dead = zoo.Animals.Where(x => x.GetAnimalState() == "Dead");
						Dead.ToList().ForEach(Console.WriteLine);
						break;
				}
			}
			Console.ReadKey();
		}


		void ShowSickTigers()
		{
			Console.Clear();
			var SickTigers = zoo.Animals.Where(x => x.GetAnimalState() == "Sick" && x.GetAnimalType() == "Tiger");
			SickTigers.ToList().ForEach(Console.WriteLine);
			Console.ReadKey();
		}

		void ShowElephant()
		{
			Console.Clear();
			Console.WriteLine("Enter pet name of Elephant");
			var elephPetName = Console.ReadLine();
			zoo.Animals.Where(x => (x.GetAnimalType() == "Elephant" && x.PetName == elephPetName)).ToList().ForEach(Console.WriteLine);
			Console.ReadKey();
		}

		void ShowHungryAnimalsNames()
		{
			Console.Clear();
			var hungry = zoo.Animals.Where(x => x.GetAnimalState() == "Hungry");
			hungry.Select(x => x.PetName).ToList().ForEach(Console.WriteLine);
			Console.ReadKey();
		}

		void MaxHealthAnimals()
		{
			Console.Clear();
			var groupby = zoo.Animals.GroupBy(t => t.GetAnimalType());
			groupby.SelectMany(t => t.Where(y => y.Health == t.Max(z => z.Health))).ToList().ForEach(Console.WriteLine);
			Console.ReadKey();
		}

		void DeadAnimalsPerKind()
		{
			Console.Clear();
			var result = zoo.Animals.GroupBy(t => t.GetAnimalType()).Select(group => Tuple.Create(group.Key, group.Count(x => x.GetAnimalState() == "Dead")));
			foreach (var item in result) Console.WriteLine($"{item.Item2} dead {item.Item1}");
			Console.ReadKey();
		}

		void ShowWolvesAndBears()
		{
			Console.Clear();
			var WolvesAndBear = zoo.Animals.Where(x => ((x.GetAnimalType() == "Bear" || x.GetAnimalType() == "Wolves") && (x.Health > 3)));
			WolvesAndBear.ToList().ForEach(Console.WriteLine);
			Console.ReadKey();
		}

		void ShowMinAndMaxHealthAnimals()
		{
			Console.Clear();
			var query = zoo.Animals.GroupBy(x => x.Health).OrderByDescending(x => x.Key).Take(1).
				Union(zoo.Animals.GroupBy(x => x.Health).OrderBy(x => x.Key).Take(1)).
				Select(x => x.FirstOrDefault()).ToList();
			Console.WriteLine($"Max health animal {query[0]}");
			Console.WriteLine($"Min health animal {query[1]}");
			Console.ReadKey();
		}

		void ShowAverageHealthInZoo()
		{
			Console.Clear();
			var aver = zoo.Animals.Average(x => x.Health);
			Console.WriteLine("The average health in the ''Dead Zoo'' are {0}", aver);
			Console.ReadKey();
		}
		
		void AddAnimal()
        {
			int result;
            Console.WriteLine(@"Enter a new animal: 
		=====================
		1 - Bear
		2 - Elephant
		3 - Fox
		4 - Lion
		5 - Tiger
		6 - Wolf
		=====================");
			var value = Console.ReadLine();

			if (!int.TryParse(value, out result) || result > 6 || result < 1)
            {
                Console.WriteLine("\n Incorrect value!\n");
            }
            else
            {
                Console.WriteLine("\nEnter the animal's pet name.");
                var petname = Console.ReadLine();
				if (zoo.Animals.Any(x => x.PetName == petname))
				{
					Console.WriteLine("\nThe animal with pet name {0} exists\n", petname);
					return;
				}
				if (petname.Length > 10 || petname.Length == 0 )
                {
                    Console.WriteLine("\nThe pet name should not be longer then 10 symbols or be empty!");
                    return;
                }				
                switch (result)
                {
                    case 1:
                        zoo.Animals.Add(new Bear(petname, zoo));
                        break;
                    case 2:
                        zoo.Animals.Add(new Elephant(petname, zoo));
                        break;
                    case 3:
                        zoo.Animals.Add(new Fox(petname, zoo));
                        break;
                    case 4:
                        zoo.Animals.Add(new Lion(petname, zoo));
                        break;
                    case 5:
                        zoo.Animals.Add(new Tiger(petname, zoo));
                        break;
                    case 6:
                        zoo.Animals.Add(new Wolf(petname, zoo));
                        break;
					case 7:
						Console.WriteLine("With best regards!!! Your zoo");
						Thread.Sleep(3000);
						Environment.Exit(0);
						break;
					default:
						break;
                }
                Console.WriteLine("The animal has been added!");
            }
        }

        Animal FindbyPetName()
        {
			Console.WriteLine("Pet name is");
            var petname = Console.ReadLine();
            var animal = zoo.Animals.FirstOrDefault(x => x.PetName == petname);
            if (animal == null)
            {
                Console.WriteLine("There is no animal with pet name {0} ", petname);
                return null;
            }
            else return animal;
        }

        
    }
}
