﻿using Zoo.Util.Enum;

namespace Zoo.Model.Animals.SeaCreature
{
    internal class GoldFish : SeaCreatureAnimal
    {
        private readonly string Sound = "GlogGlog";

        public GoldFish()
        {
            AnimalType = ZooAnimalType.GoldFish;
        }

        public override void MakeSound()
        {
            Console.WriteLine($"Race: {RaceName}. \tGoldFish make sound {Sound}");
        }
    }
}
