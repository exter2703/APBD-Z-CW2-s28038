using APBD_Z_CW2_s28038;

//Ships
var ship1 = new Ship("Monster", 10, 50, 70);
var ship2 = new Ship("Arielka", 3, 3, 120);

//Containers
var cont1 = new LiquidCont(1000, 250, 30, 50, false);
var cont2 = new GasCont(600, 100, 10, 25, 300);
var cont3 = new RefrigeratedCont(1500, 200, 25, 45, 13.3);
var cont4 = new LiquidCont(400, 100, 20, 70, true);

//Container Loading
cont1.Load("Woda", 850);
cont2.Load("Gaz", 450);
cont3.Load("Banany", 1350);
cont3.Load("Banany", 100);
cont4.Load("Benzyna", 200);

//Container Unloading
cont3.Unload();

//Container Info
cont1.GetInfo();
//cont2.GetInfo();
//cont3.GetInfo();

//Ship Loading
ship1.LoadCont(cont1);
ship1.LoadCont(cont2);
ship1.LoadCont(cont3);

//Ship Unloading
ship1.RemoveCont("KON-C-3");

//Container Loading and Unloading on Ship
cont1.Unload();

//Ship Replacing
ship1.ReplaceCont("KON-L-1", cont4);

//Ship Transfering
ship1.TransferCont("KON-G-2", ship1, ship2);

//Ship Info
ship1.LoadInfo();
ship2.LoadInfo();




