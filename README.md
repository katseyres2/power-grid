# Power Grid Developpement Project
---
*Maximilien Denis, 18332*

Hi, I've made this Grid Network Platform for my IT teacher. You can see the instructions the link below.
The goal is to provide a new tool for the electrical network builders or scientists.
You can create a lot of power providers or electricity consumers who each have some data.
It's also possible to make a complex power grid with power lines, focus nodes or distribution nodes.

[Here]()'s the class diagram ...
and [there]()'s the sequence diagram !

So lets' explain this project ! :)

## How to create a new Producer

A producer has a lot of informations

* Id    : PPxxxx (PowerProducer) (It's automatic, every producer has a different Id)
* Type (existing types : ```{"gas power plant", "nuclear power plant", "wind farm", "solar power plant", "international purchasing"}```)
* Name
* Electricity production
  * Unit (you have to write ```"kW"```)
  * Period = ```daily```
  * Data (the quantity of kW produced)
* Cost production
  * Unit (you  have to write ```"Dollar```)
  * Period = ```daily```
  * Data (the quantity of Dollar spent)
* CO² production
  * Unit (you have to write ```"kg/m3"```)
  * Period = ```daily```
  * Data = (the quantity of CO² produced)
* Description

I chose to set the period to ```daily``` because I've to keep a reference for every new data, so you can easily get the total amount of electricity production with one function. It's the same reason for ```"kW"```, ```"Dollar"``` and ```"kg/m3```.

Example to create a producer : 
```Csharp
Producer p1 = new Producer(
    "gas power plant",
    "Engie",
    new Information("kW", 23434),
    new Information("Dollar", 234),
    new Information("kg/m3", 3234),
    "flexible production");
```

Add the producer to the list : 
```Csharp
ProducerManager.AddProducer(p1); // Add the producer to the list of producers
```

Then update the JSON file :
```Csharp
JsonManager.UpdateProducers();
```

Other functions :
```Csharp
ProducerManager.AddNewType("my big arms"); // You can add a new type of producer (like 'gas power plant')
ProducerManager.GetTotalProduction() // Get the totol production from all sources
```

## How to create a new Consumer

The consumer has less informations than the producer

* Id : PCxxxx (Power Consumer) (It's automatic, every consumer has a different Id)
* Type (existing type : ```{"city", "company", "international sales", "electricity sink"}```)
* Name
* Power consumption
  * Unit (you have to write ```"kW"```)
  * Period = ```daily```
  * Data (the quantity of power consumed)

Example (same as producer) :
```Csharp
Consumer c1 = new Consumer(
    "city",
    "Namur",
    new Information("kW", 2324));

ConsumerManager.AddConsumer(c1);
JsonManager.UpdateConsumers();
```

## How to build a Grid Network

First, create _power lines_, _focus nodes_ and _distribution nodes_

```Csharp
// FocusNode(FROM{}, TO)
FocusNode fn1 = new FocusNode(new List<string>(){"PP1001", "PP1002"}, "PL1001");

// PowerLine(FROM, TO)
PowerLine pl1 = new PowerLine("FN1001", "DB1001");

// DistributionNode(FROM, TO{})
DistributionNode dn1 = new DistributionNode("PL1001", new List<string>(){"PL1002", "PC1001"});

PowerLine pl2 = new PowerLine(c2.Id, p1.Id);
```

* **Focus node** : receiving power from multiple lines and sending it to an output line.
* **Distribution node** : receiving energy from a line and distributing it between several output lines in controllable proportions.
* **Power line** : characterized by the maximum power they can convey.

To see the application of this code, [click here](https://1drv.ms/u/s!AvEfKPLChyNUhKgZL3ftFKpzM6efEw?e=fVDzeG) (don't worry, it's a picture)

Add all components to the grid network :
```Csharp
PowerGrid.AddFocusNode(fn1);
PowerGrid.AddPowerLine(pl1);
PowerGrid.AddDistributionNode(dn1);
PowerGrid.AddPowerLine(pl2);
```

And update JSON file :
```Csharp
JsonManager.UpdatePowerGrid();
```

## Weather widget
Get the weather from one place with latitude and longitude
* Wind speed
* Temperature
* Sunshine

```Csharp
Location l = new Location("50° 51' 1 N", "4° 20' 55 E");

l.GetSunshine();
l.GetTemperature();
l.GetWindSpeed();
```

There are abstract classes, you have to override them.

## Alert widget
There are four different alerts to be aware of what is happening on the network.

```Csharp
Alerts.OverProduction("PP1002");
Alerts.OverloadedLine("PL1003");
Alerts.UnderProduction("PP1003");
Alerts.Blakout("PP1001");
```
Each new alert is recorded in the *Data/alerts.log* file.