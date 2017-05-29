using System;
using System.Collections.Generic;
using Zoo.Animals;

namespace Zoo
{
    class Zoo
    {
        public List<Animal> Animals { get; private set; }
        public Timer ZooTimer { get; private set; }
        public int DeadAnimals { get; set; }
		
		public Zoo()
        {
            Animals=new List<Animal>();
            ZooTimer=new Timer(MyEventHandler);
        }

        void MyEventHandler(object o, EventArgs e)
        {
            var index= GetRandomIndex();
            if (index != -1) 
            {
                Animals[index]?.Decline();

            }
            
        }

        int GetRandomIndex()
        {
            if (Animals.Count == 0)
            {
                return -1;
            }
            return new Random().Next(0, Animals.Count-DeadAnimals);
        }

    }
}
