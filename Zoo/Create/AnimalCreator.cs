using Zoo.Animals;

namespace Zoo.Factory
{
    abstract class AnimalCreator
    {
        public abstract Animal CreateAnimal(string petname, Zoo zoo);
    }
}
