using Zoo;

List<Animal> animals = new List<Animal>();
List<Worker> workers = new List<Worker>();

Lion l = new Lion("Harry");
Alligator a = new Alligator("Charles");
Dolphin d = new Dolphin("Dolly");
Vulture v = new Vulture("Vienna");

animals.Add(l);
animals.Add(a);
animals.Add(d);
animals.Add(v);

Cleaner c = new Cleaner(Areas.Land);
Doctor dr = new Doctor(v, Areas.Sea);
Feader f = new Feader(l, Areas.Mixed);

workers.Add(c);
workers.Add(dr);
workers.Add(f);


//CHANGE CHECKZOO TO 3 INSTEAD 1
MainZoo z = new MainZoo(animals, workers);

z.Run();