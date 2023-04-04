using Zoo.Utils.Enum;

namespace Zoo.Tour
{
    internal class PlaceOfTour
    {
        private readonly Dictionary<ZooZonesType, string> places = new()
        {
            { ZooZonesType.BirdZone, "Birds Zone" },
            { ZooZonesType.OrdinaryLandZone, "Land Zone" },
            { ZooZonesType.SeaCreatureZone, "Sea Zone" },
            { ZooZonesType.AmphibiaZone, "Amphibia Zone" }
        };

        public ZooZonesType ZooZonesTypeZooZonesType { get; set; }

        public PlaceOfTour(ZooZonesType zooZonesType)
        {
            ZooZonesTypeZooZonesType = zooZonesType;
        }

        public bool IsEqual(PlaceOfTour other)
        {
            return other.ZooZonesTypeZooZonesType == ZooZonesTypeZooZonesType;
        }

        public override string ToString()
        {
            return places[ZooZonesTypeZooZonesType];
        }
    }
}
