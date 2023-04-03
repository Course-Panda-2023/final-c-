using Zoo.Utils.Enum;

namespace Zoo.Tour
{
    internal class TourPlace
    {
        private readonly Dictionary<ZooZonesType, string> places = new()
        {
            { ZooZonesType.BirdZone, "Birds Zone" },
            { ZooZonesType.OrdinaryLandZone, "Land Zone" },
            { ZooZonesType.SeaCreatureZone, "Sea Zone" },
            { ZooZonesType.AmphibiaZone, "Amphibia Zone" }
        };

        public ZooZonesType ZooZonesTypeZooZonesType { get; set; }

        public TourPlace(ZooZonesType zooZonesType)
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
