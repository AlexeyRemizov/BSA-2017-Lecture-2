using System;
using Zoo.Animals;

namespace Zoo.StateAnimal
{
    class Hungry : StateAnimal.State
    {
        public override void Cure(Animal animal)
        {
            Console.WriteLine( "I am not sick! I am hungry! Please feed me:)" );
        }

        public override void Decline(Animal animal)
        {
            animal.CurrentState=new Sick();
        }

        public override void Feed(Animal animal)
        {
            animal.CurrentState = new Full();
            Console.WriteLine("The animal with alias {0} has been fed!", animal.PetName);
        }

        public override void Remove(Animal animal)
        {
            Console.WriteLine("You cannot remove me from the zoo! I am alive!");
        }
    }
}
