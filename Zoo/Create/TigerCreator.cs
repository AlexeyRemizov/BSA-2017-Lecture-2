using Zoo.Animals;

namespace Zoo.Factory
{
    class TigerCreator : AnimalCreator
    {
        public override Animal CreateAnimal(string petname, Zoo zoo)
        {
            return new Tiger(petname, zoo);
        }
    }
}
