using System;
using System.Threading;
using Zoo.Animals;

namespace Zoo.StateAnimal
{
    class Sick : State
    {
        public override void Cure(Animal animal)
        {
            if (animal.Health < animal.MaxHealth)
            {
                animal.Health++;
                Console.WriteLine("The {0} has been cured to health {1}", animal.PetName, animal.Health);
            }
            else { Console.WriteLine("The {0} has maximum health {1}", animal.PetName, animal.MaxHealth);}
        }

        public override void Decline(Animal animal)
        {
            if (animal.Health > 1)
            {
                animal.Health--;
            }
            else
            {
                animal.CurrentState=new Dead();
                animal.Health = 0;
                animal.Zoo.DeadAnimals++;
                if (animal.Zoo.DeadAnimals==animal.Zoo.Animals.Count)
                {
                    Console.WriteLine(" Your journey does not end here. Maybe one more time. All dead");
                    
                }
				animal.Zoo.Animals.Add(animal);
				animal.Zoo.Animals.Remove(animal);
                
            }
        }

        public override void Feed(Animal animal)
        {
            Console.WriteLine("\nI'm sick! Please, cure me!\n");
        }

        public override void Remove(Animal animal)
        {
            Console.WriteLine("\nI'm alive! You can't remove me\n");
        }
    }
}
