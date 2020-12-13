using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace Script
{
    class Program
    {
        static void Main(string[] args)
        {
            Producer p1 = new Producer("gas power plant", "Engie", new Information("kW", 23434), new Information("Dollar", 234), new Information("kg/m3", 3234), "flexible production");
            Producer p2 = new Producer("nuclear power plant", "Tihange", new Information("kW", 232), new Information("Dollar", 2211), new Information("kg/m3", 123), "constant production, expensive and slow to start and stop");
            Producer p3 = new Producer("wind farm", "Engie", new Information("kW", 22), new Information("Dollar", 2121), new Information("kg/m3", 1123));
            Producer p4 = new Producer("solar power plant", "Luminus", new Information("kW", 23), new Information("Dollar", 234433), new Information("kg/m3", 2), "weather dependent production cannot be reduced");
            Producer p5 = new Producer("international purchasing", "Tesla", new Information("kW", 23), new Information("Dollar", 23434), new Information("kg/m3", 34));

            ProducerManager.AddProducer(p1);
            ProducerManager.AddProducer(p2);
            ProducerManager.AddProducer(p3);
            ProducerManager.AddProducer(p4);
            ProducerManager.AddProducer(p5);

            ProducerManager.AddNewType("my big arms");

            JsonManager.UpdateProducers();

            Consumer c1 = new Consumer("city", "Namur", new Information("kW", 2324));
            Consumer c2 = new Consumer("company", "Engie", new Information("kW", 234));
            
            ConsumerManager.AddConsumer(c1);
            ConsumerManager.AddConsumer(c2);

            JsonManager.UpdateConsumers();

            FocusNode fn1 = new FocusNode(new List<string>(){p1.Id, p2.Id}, p3.Id);
            PowerLine pl1 = new PowerLine(c1.Id, c2.Id);
            PowerLine pl2 = new PowerLine(c2.Id, p1.Id);
            DistributionNode dn1 = new DistributionNode(p2.Id, new List<string>(){c1.Id, c2.Id});
            
            PowerGrid.AddFocusNode(fn1);
            PowerGrid.AddPowerLine(pl1);
            PowerGrid.AddPowerLine(pl2);
            PowerGrid.AddDistributionNode(dn1);

            JsonManager.UpdatePowerGrid();
            
            Location l = new Location("50° 51' 1 N", "4° 20' 55 E");
            l.GetSunshine();
            l.GetTemperature();
            l.GetWindSpeed();

            Alerts.OverProduction("PP1002");
            Alerts.OverloadedLine("PL1003");
            Alerts.UnderProduction("PP1003");
            Alerts.Blackout("PP1001");

            Console.WriteLine("total consumption : " + ConsumerManager.GetTotalConsumption() + " kW");
            Console.WriteLine("total production : " + ProducerManager.GetTotalProduction() + " kW");
        
            Console.WriteLine(GlobalMarket.GetGlobalExportPrice());
            Console.WriteLine(GlobalMarket.GetGlobalImportPrice());
        }
    }

}
