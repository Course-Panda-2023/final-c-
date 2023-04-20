using Zoo.Util.Enum;

namespace Zoo
{
    internal sealed class ApplicationConstants
    {
        internal readonly Dictionary<ZonesType, string> Places = new()
        {
            { ZonesType.None, "" },
            { ZonesType.BirdZone, "Birds Zone" },
            { ZonesType.OrdinaryLandZone, "Land Zone" },
            { ZonesType.SeaCreatureZone, "Sea Zone" },
            { ZonesType.AmphibiaZone, "Amphibia Zone" }
        };
    }
}
