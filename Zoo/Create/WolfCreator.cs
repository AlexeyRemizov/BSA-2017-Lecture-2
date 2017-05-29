using Zoo.Animals;

namespace Zoo.Factory
{
    class WolfCreator : AnimalCreator
    {
        public override Animal CreateAnimal(string petname, Zoo zoo)
        {
            return new Wolf(petname, zoo);
        }
    }
}
