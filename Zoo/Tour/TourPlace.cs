using Zoo.Util.Enum;

namespace Zoo.Tour
{
    internal class TourPlace
    {
        private readonly Dictionary<ZonesType, string> places = new()
        {
            { ZonesType.BirdZone, "Birds Zone" },
            { ZonesType.OrdinaryLandZone, "Land Zone" },
            { ZonesType.SeaCreatureZone, "Sea Zone" },
            { ZonesType.AmphibiaZone, "Amphibia Zone" }
        };

        public ZonesType ZooZonesTypeZooZonesType { get; set; }

        public TourPlace(ZonesType zooZonesType)
        {
            ZooZonesTypeZooZonesType = zooZonesType;
        }

        public bool IsEqual(TourPlace other)
        {
            return other.ZooZonesTypeZooZonesType == ZooZonesTypeZooZonesType;
        }

        public override string ToString()
        {
            return places[ZooZonesTypeZooZonesType];
        }
    }
}
