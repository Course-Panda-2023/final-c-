// See https://aka.ms/new-console-template for more information

using Zoo;

List<Visitor> visitors = new List<Visitor>();
for (int i = 1; i <= 20; i++)
    visitors.Add(new Visitor("V_" + i));

ZooClass my = new ZooClass(visitors,
                           new List<Animal>() { new Eagle("eagle"),new Hawk("hawk"),new Owl("owl"),
                           new Elephant("elephant"), new Giraffe("giraffe"), new Kangaroo("kangaroo"),
                           new Alligator("allifator"), new Duck("duck"), new Frog("frog"),
                           new Dolphin("dolphin"),new GoldFish("goldfish"),new Shark("shark")},
                           new List<Cleaner>() { new Cleaner("clean") },
                           new List<Doctor>() { new Doctor(null, "doc") },
                           new List<Feeder>() { new Feeder(null, "feed") } );

Console.ReadLine(); 