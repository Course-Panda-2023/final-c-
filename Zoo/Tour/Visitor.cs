using Zoo.Utils.Enum;
using System;

namespace Zoo.Tour
{
    internal class Visitor
    {
        public string Name { get; init; }

        Dictionary<ZooZonesType, string> places = new()
        {
            { ZooZonesType.BirdZone, "Birds Zone" },
            { ZooZonesType.OrdinaryLandZone, "Land Zone" },
            { ZooZonesType.SeaCreatureZone, "Sea Zone" },
            { ZooZonesType.AmphibiaZone, "Amphibia Zone" }
        };


        public Visitor(string Name)
        {
            Random random = new Random();
            ZooZonesType randomZone = ZooZonesType.None;

            int value = random.Next(1, 4);
            switch (value)
            {
                case 1:
                    randomZone = ZooZonesType.BirdZone;
                    break;

                case 2:
                    randomZone = ZooZonesType.AmphibiaZone;
                    break;

                case 3:
                    randomZone = ZooZonesType.SeaCreatureZone;
                    break;

                case 4:
                    randomZone = ZooZonesType.OrdinaryLandZone;
                    break;
            }


            Console.WriteLine($"Visitor {Name} is waiting to {places[randomZone]}");
        }
    }
}
