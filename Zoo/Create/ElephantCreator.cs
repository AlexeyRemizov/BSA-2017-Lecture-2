using Zoo.Animals;

namespace Zoo.Factory
{
    class ElephantCreator : AnimalCreator
    {
        public override Animal CreateAnimal(string petname, Zoo zoo)
        {
            return new Elephant(petname, zoo);
        }
    }
}
