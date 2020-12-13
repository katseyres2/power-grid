using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Script
{
    public class Alerts
    {
        public static void OverProduction(string id)
        {
            Console.WriteLine(string.Format("[OVERPRODUCTION ALERT] {0} is overproducting !", id));

            var sw = new StreamWriter(@"Data/alerts.log", true);
            sw.Write(string.Format("{0} - [OVERPRODUCTION ALERT] id : {1}\n", DateTime.Now, id));
            sw.Dispose();
        }

        public static void OverloadedLine(string id)
        {
            Console.WriteLine(string.Format("[OVERLOADED ALERT] the line {0} is overloading !", id));

            var sw = new StreamWriter(@"Data/alerts.log", true);
            sw.Write(string.Format("{0} - [OVERLOADED ALERT] id : {1}\n", DateTime.Now, id));
            sw.Dispose();
        }

        public static void UnderProduction(string id)
        {
            Console.WriteLine(string.Format("[UNDERPRODUCTION ALERT] {0} does not product enough !", id));

            var sw = new StreamWriter(@"Data/alerts.log", true);
            sw.Write(string.Format("{0} - [UNDERPRODUCTION ALERT] id : {1}\n", DateTime.Now, id));
            sw.Dispose();
        }

        public static void Blakout(string id)
        {
            Console.WriteLine(string.Format("[BLACKOUT ALERT] !!! {0} has crashed !!!", id));

            var sw = new StreamWriter(@"Data/alerts.log", true);
            sw.Write(string.Format("{0} - !!! [BLACKOUT ALERT] id : {1}\n", DateTime.Now, id));
            sw.Dispose();
        }
    }
}