using APBD_Cw2;

var liquidContainer1 = new LiquidContainer(100, 200, 10, 10000, false);
var liquidContainer2 = new LiquidContainer(100, 200, 10, 2000, true);
var gasContainer = new GasContainer(100, 200, 10, 2000, 2);
var coolingContainer = new CoolingContainer(200, 1000, 200, 1000, "Bananas", 10);
var containerShip1 = new ContainerShip(100, 20, 10);
var containerShip2 = new ContainerShip(100, 2, 10);

liquidContainer1.LoadIn(10000);
liquidContainer2.LoadIn(2000);
// gasContainer.LoadIn(2000);
containerShip1.AddContainer(liquidContainer1);
containerShip1.AddContainer(liquidContainer2);
containerShip1.AddContainer(gasContainer);
containerShip1.GetShipInfo();
containerShip1.SwapContainers(liquidContainer1.SerialNumber, gasContainer);
containerShip1.GetShipInfo();
