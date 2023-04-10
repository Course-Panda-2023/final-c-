using Zoo.Util.Enum;

namespace Zoo.Tour
{
    internal sealed class Visitor
    {
        public string? Name { get; init; }

        private readonly Dictionary<ZonesType, string> places = new()
        {
            { ZonesType.BirdZone, "Birds Zone" },
            { ZonesType.OrdinaryLandZone, "Land Zone" },
            { ZonesType.SeaCreatureZone, "Sea Zone" },
            { ZonesType.AmphibiaZone, "Amphibia Zone" }
        };


        public Visitor(string Name)
        {
            Random random = new();
            ZonesType randomZone = ZonesType.None;

            int value = random.Next(1, 4);
            switch (value)
            {
                case 1:
                    randomZone = ZonesType.BirdZone;
                    break;

                case 2:
                    randomZone = ZonesType.AmphibiaZone;
                    break;

                case 3:
                    randomZone = ZonesType.SeaCreatureZone;
                    break;

                case 4:
                    randomZone = ZonesType.OrdinaryLandZone;
                    break;
            }


            Console.WriteLine($"Visitor {Name} is waiting to {places[randomZone]}");
        }
    }
}
