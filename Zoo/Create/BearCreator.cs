using Zoo.Animals;

namespace Zoo.Factory
{
    class BearCreator : AnimalCreator
    {
        public override Animal CreateAnimal(string petname, Zoo zoo)
        {
            return new Bear(petname, zoo);
        }
    }
}
