using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Script
{
    public class ProducerManager
    {
        public static List<Producer> producers = new List<Producer>();
        public static int producersCounter = 1000;
        public static int totalProduction = 0;
        public static List<string> typeOfProducer = new List<string>()
        {
            "gas power plant",
            "nuclear power plant",
            "wind farm",
            "solar power plant",
            "international purchasing"
        };

        public static void AddNewType(string type)
        {
            typeOfProducer.Add(type);
        }

        public static void AddProducer(Producer producer)
        {
            producers.Add(producer);
        }

        public static int GetTotalProduction()
        {
            foreach (Producer p in producers)
                totalProduction += p.Electricity_production.Data;
            
            return totalProduction;
        }
    }

    public class Producer
    {
        public string Id { get; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Information Electricity_production { get; set; }
        public Information Cost_production { get; set; }
        public Information CO2_production { get; set; }

        public Producer(string type, string name, Information electricityProduction, Information costProduction, Information CO2Production, string description=null)
        {
            if (ProducerManager.typeOfProducer.Contains(type))
                this.Type = type;
            else
                throw new ArgumentException(string.Format("The type '{0}' does not exist", type), "type");

            this.Id = "PP" + ++ProducerManager.producersCounter;
            this.Type = type;
            this.Name = name;
            this.Description = description;
            this.Electricity_production = electricityProduction;
            this.Cost_production = costProduction;
            this.CO2_production = CO2Production;
        }
    }
}