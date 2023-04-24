using System.ComponentModel.DataAnnotations;
using Zoo;

List<Animal> animals = new List<Animal>();
List<Worker> workers = new List<Worker>();

bool isBonus = true;
Lion l = new Lion("Harry");
Alligator a = new Alligator("Charles");
Dolphin d = new Dolphin("Dolly");
Vulture v = new Vulture("Vienna");

animals.Add(l);
animals.Add(a);
animals.Add(d);
animals.Add(v);
animals.Add(new GoldFish("Goldie"));
animals.Add(new Elephant("Elle"));
animals.Add(new Hippopotumus("Grey"));
animals.Add(new Turtle("Henry"));
animals.Add(new Shark("Cherry"));
animals.Add(new Zebra("Crosswalk"));
animals.Add(new Eagle("America"));
animals.Add(new Hawk("Harold"));


workers.Add(new Cleaner(Areas.Mixed, isBonus));
workers.Add(new Doctor(d, Areas.Mixed, isBonus));
workers.Add(new Feader(a, Areas.Sky, isBonus));



MainZoo z = new MainZoo(animals, workers);

z.Run(isBonus);