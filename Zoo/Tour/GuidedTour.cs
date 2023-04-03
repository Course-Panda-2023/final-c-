using System.Collections;
using System.Xml.Linq;
using Zoo.EventLogger;
using Zoo.Utils.CustomException;
using Zoo.Utils.Enum;

namespace Zoo.Tour
{
    internal class GuidedTour
    {
        public Thread touring;

        public Visitor[] visitor = new Visitor[5];

        public List<TourPlace> places;

        private readonly List<List<TourPlace>> legallTourPlaces = new()
        {
            new List <TourPlace> ()
            {
                new TourPlace(ZooZonesType.OrdinaryLandZone),
                new TourPlace(ZooZonesType.AmphibiaZone)
            },

            new List<TourPlace>
            {
                new TourPlace(ZooZonesType.OrdinaryLandZone),
                new TourPlace(ZooZonesType.SeaCreatureZone)
            },

            new List<TourPlace>
            {
                new TourPlace(ZooZonesType.AmphibiaZone),
                new TourPlace(ZooZonesType.SeaCreatureZone)
            }
        };

        private void CheckIfTourCanBeParallel(List<TourPlace> places)
        {
            try
            {
                if (places.Count == 0)
                    throw new NoTourWasGivenException("No tour was given");

                if (places.Count >= 3)
                    throw new CannotBeTourInThreeOrMorePlacesAtTheSameTimeException("Make several tours at the same time");

                if (places.Count == 1)
                    return;

                TourPlace tourPlace1 = places[0];
                TourPlace tourPlacetourPlace2 = places[1];

                if (tourPlace1.ZooZonesTypeZooZonesType == tourPlacetourPlace2.ZooZonesTypeZooZonesType)
                    throw new TwoOfTheSameTourException($"There are two of {tourPlace1.ZooZonesTypeZooZonesType}");

                bool isLegalCombination = false;



                foreach (var legalCombination in legallTourPlaces)
                {
                    BitArray bitArray = new(2);

                    bitArray[0] = legalCombination[0].IsEqual(tourPlace1) && legalCombination[1].IsEqual(tourPlacetourPlace2);
                    bitArray[1] = legalCombination[0].IsEqual(tourPlacetourPlace2) && legalCombination[1].IsEqual(tourPlace1);

                    if (bitArray[0] || bitArray[1])
                    {
                        isLegalCombination = true;
                        break;
                    }
                }

                if (!isLegalCombination)
                    throw new CannotMakeIllegalToursException($"Tour one {tourPlace1} cannot be parallel with {tourPlacetourPlace2}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public GuidedTour(List<TourPlace> places)
        {
            CheckIfTourCanBeParallel(places);
            this.places = places;

            touring = new Thread(ActivateTour);
        }

        private void ActivateTour()
        {
            Thread thread = new(() =>
            {
                if (places.Count == 1)
                {
                    Console.WriteLine($"Tour starts to {places[0]} ");
                    EventLoggerSingleton.GetInstance().LogIntoEvent($"Tour starts to {places[0]} ");
                }

                else
                {
                    Console.WriteLine($"Tours start to {places[0]} and {places[1]}");
                    EventLoggerSingleton.GetInstance().LogIntoEvent($"Tours start to {places[0]} and {places[1]}");
                }
                Thread.Sleep(10000);

                if (places.Count == 1)
                {
                    Console.WriteLine($"Tour ends to {places[0]} ");
                    EventLoggerSingleton.GetInstance().LogIntoEvent($"Tour ends to {places[0]} ");
                }
                else
                {
                    Console.WriteLine($"Tours end to {places[0]} and {places[1]}");
                    EventLoggerSingleton.GetInstance().LogIntoEvent($"Tours end to {places[0]} and {places[1]}");
                }
            });
            thread.Start();
        }



    }
}
