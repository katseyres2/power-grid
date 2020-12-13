using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Script
{
    public class ConsumerManager
    {
        public static List<Consumer> consumers = new List<Consumer>();
        public static int consumersCounter = 1000;
        public static int totalConsumption = 0;
        public static List<string> typeOfConsumer = new List<string>()
        {
            "city",
            "company",
            "international sales",
            "electricity sink"
        };

        public static void AddNewType(string type)
        {
            typeOfConsumer.Add(type);
        }

        public static void AddConsumer(Consumer consumer)
        {
            consumers.Add(consumer);
        }

        public static int GetTotalConsumption()
        {
            foreach (Consumer c in consumers)
                totalConsumption += c.Power_consumption.Data;

            return totalConsumption;
        }
    }

    public class Consumer
    {
        public string Id { get; }
        public string Type { get; set; }
        public string Name { get; set; }
        public Information Power_consumption { get; set; }

        public Consumer(string type, string name, Information power_consumption)
        {
            if (ConsumerManager.typeOfConsumer.Contains(type))
                this.Type = type;
            else
                throw new ArgumentException(string.Format("The type '{0}' does not exist", type), "type");

            this.Id = "PC" + ++ConsumerManager.consumersCounter;
            this.Name = name;
            this.Power_consumption = power_consumption;
        }
    }
}