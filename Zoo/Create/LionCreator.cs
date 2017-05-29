using Zoo.Animals;

namespace Zoo.Factory
{
    class LionCreator : AnimalCreator
    {
        public override Animal CreateAnimal(string petname, Zoo zoo)
        {
            return new Lion(petname, zoo);
        }
    }
}
