using Zoo.Utils.EnumTypes;

namespace Zoo.ZooRelated.Tour
{
    internal class TourPlace
    {
        Dictionary<ZooZonesType, string> places = new()
        {
            { ZooZonesType.BirdZone, "Birds Zone" },
            { ZooZonesType.OrdinaryLandZone, "Land Zone" },
            { ZooZonesType.SeaCreatureZone, "Sea Zone" },
            { ZooZonesType.AmphibiaZone, "Amphibia Zone" }
        };

        public ZooZonesType ZooZonesTypeZooZonesType { get; set; }

        public TourPlace(ZooZonesType zooZonesType)
        {
            this.ZooZonesTypeZooZonesType = zooZonesType;
        }

        public bool IsEqual(TourPlace other)
        {
            return other.ZooZonesTypeZooZonesType == this.ZooZonesTypeZooZonesType;
        }

        public override string ToString()
        {
            return places[this.ZooZonesTypeZooZonesType];
        }
    }
}
