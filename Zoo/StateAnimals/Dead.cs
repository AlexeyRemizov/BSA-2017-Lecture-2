using System;
using Zoo.Animals;

namespace Zoo.StateAnimal
{
    class Dead : StateAnimal.State
    {
		public override void Decline(Animal animal)
		{

		}

		public override void Feed(Animal animal)
		{
			Console.WriteLine("You can't feed dead animal");
		}

		public override void Cure(Animal animal)
        {
            Console.WriteLine("You can't cure dead animal");
        }
		
        public override void Remove(Animal animal)
        {
            animal.Zoo.Animals.Remove(animal);
            Console.WriteLine("The animal with alias {0} has been removed", animal.PetName);
            animal.Zoo.DeadAnimals--;
        }
    }
}
