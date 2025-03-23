using APBD_Z_CW2_s28038;
using Container = System.ComponentModel.Container;

var ship1 = new Ship("Monster", 10, 50, 70);
//var ship2 = new Ship("Arielka", 5, 15, 90);

var cont1 = new LiquidCont(1000, 250, 30, 50, false, false);
// var cont2 = new LiquidCont(1500, 400, 20, 45, true, false);
// var cont3 = new RefrigeratedCont(1500, 200, 25, 45, 13.3);

cont1.Load("Woda", 800);
// cont2.Load("Benzyna", 800);
// cont3.Load("Banany", 1000);

ship1.LoadCont(cont1);
ship1.LoadInfo();

