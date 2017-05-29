using Zoo.Animals;

namespace Zoo.StateAnimal
{
    abstract class State
    {

		public abstract void Remove(Animal animal);

		public abstract void Decline(Animal animal);

		public abstract void Feed(Animal animal);

		public abstract void Cure(Animal animal);
    }
}
