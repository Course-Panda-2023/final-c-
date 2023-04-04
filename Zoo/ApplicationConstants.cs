using Zoo.Util.Enum;

namespace Zoo
{
    internal class ApplicationConstants
    {
        internal readonly Dictionary<ZooZonesType, string> Places = new()
        {
            { ZooZonesType.None, "" },
            { ZooZonesType.BirdZone, "Birds Zone" },
            { ZooZonesType.OrdinaryLandZone, "Land Zone" },
            { ZooZonesType.SeaCreatureZone, "Sea Zone" },
            { ZooZonesType.AmphibiaZone, "Amphibia Zone" }
        };
    }
}
