using Zoo.StateAnimal;

namespace Zoo.Animals
{
    abstract class Animal
    {
        public Animal(string petname, int health, Zoo zoo)
        {
            Health = health;
            MaxHealth = health;
            PetName = petname;
            Zoo = zoo;
            CurrentState = new Full();
		}

		public void Decline()
		{
			CurrentState.Decline(this);
		}

		public void Feed()
        {
            CurrentState.Feed(this);
        }

        public void Treat()
        {
            CurrentState.Cure(this);
        }

        public void Remove()
        {
            CurrentState.Remove(this);
        }
        
        public override string ToString()
        {
            return $"{GetAnimalType()} with pet name {PetName}: current health {Health}, current state {GetAnimalState()}";
        }

		public string GetAnimalState()
		{
			return CurrentState.GetType().ToString().Split('.')[2].Replace("State", "");
		}

		public string GetAnimalType()
		{
			return GetType().ToString().Split('.')[2];
		}
		

		public int Health { get; set; }
		public int MaxHealth { get; private set; }
		public string PetName { get; private set; }
		public Zoo Zoo { get; private set; }
		public State CurrentState { get; set; }

	}



}
