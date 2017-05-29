using System;
using Zoo.Animals;

namespace Zoo.StateAnimal
{
    class Full : StateAnimal.State
    {
        public override void Cure(Animal animal)
        {
            Console.WriteLine("\nI'm healthy! Don't cure me!\n");
        }

        public override void Decline(Animal animal)
        {
           animal.CurrentState=new Hungry();
        }

        public override void Feed(Animal animal)
        {
            Console.WriteLine("\nI'm not hungry. Don't feed me:)\n");
        }

        public override void Remove(Animal animal)
        {
            Console.WriteLine("\nI'm alive! You can't remove me!\n");
        }
    }
}
