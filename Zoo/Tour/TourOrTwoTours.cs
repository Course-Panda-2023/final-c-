using System.Collections;
using Zoo.EventLogger;
using Zoo.Utils.CustomException;
using Zoo.Utils.Enum;

namespace Zoo.Tour
{
    /// <summary>
    /// class represents one tour or two tours at the same time
    /// </summary>
    internal class TourOrTwoTours
    {
        public Action touring;

        public Visitor[] visitor = new Visitor[5];

        public List<PlaceOfTour> places;

        private readonly List<List<PlaceOfTour>> legallTourPlaces = new()
        {
            new List <PlaceOfTour> ()
            {
                new PlaceOfTour(ZooZonesType.OrdinaryLandZone),
                new PlaceOfTour(ZooZonesType.AmphibiaZone)
            },

            new List<PlaceOfTour>
            {
                new PlaceOfTour(ZooZonesType.OrdinaryLandZone),
                new PlaceOfTour(ZooZonesType.SeaCreatureZone)
            },

            new List<PlaceOfTour>
            {
                new PlaceOfTour(ZooZonesType.AmphibiaZone),
                new PlaceOfTour(ZooZonesType.SeaCreatureZone)
            }
        };

        private void CheckIfTourCanBeParallel(List<PlaceOfTour> places)
        {
            try
            {
                if (places.Count == 0)
                    throw new NoTourWasGivenException("No tour was given");

                if (places.Count >= 3)
                    throw new CannotBeTourInThreeOrMorePlacesAtTheSameTimeException("Make several tours at the same time");

                if (places.Count == 1)
                    return;

                PlaceOfTour tourPlace1 = places[0];
                PlaceOfTour tourPlacetourPlace2 = places[1];

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

        public TourOrTwoTours(List<PlaceOfTour> places)
        {
            CheckIfTourCanBeParallel(places);
            this.places = places;

            touring = new Action(ActivateTour);
        }

        private void TourStart()
        {
            if (places.Count == 1)
            {
                Console.WriteLine($"Tour starts to {places[0]} ");
                EventLoggerSingleton.GetInstance().LogIntoEvent($"Tour starts to {places[0]} ");
                return;
            }

            Console.WriteLine($"Tours start to {places[0]} and {places[1]}");
            EventLoggerSingleton.GetInstance().LogIntoEvent($"Tours start to {places[0]} and {places[1]}");

        }

        private void TourEnd()
        {
            if (places.Count == 1)
            {
                Console.WriteLine($"Tour ends to {places[0]} ");
                EventLoggerSingleton.GetInstance().LogIntoEvent($"Tour ends to {places[0]} ");
                return;
            }

            Console.WriteLine($"Tours end to {places[0]} and {places[1]}");
            EventLoggerSingleton.GetInstance().LogIntoEvent($"Tours end to {places[0]} and {places[1]}");

        }



        private void ActivateTour()
        { 
            TourStart();
            int TenSecondsInMili = 10000;
            // each tour is 10 seconds
            Thread.Sleep(TenSecondsInMili);
            TourEnd();
            
        }



    }
}
