using Zoo.Animals;

namespace Zoo.Factory
{
    class FoxCreator : AnimalCreator
    {
        public override Animal CreateAnimal(string petname, Zoo zoo)
        {
            return new Fox(petname, zoo);
        }
    }
}
