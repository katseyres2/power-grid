using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace Script
{
    public class Location
    {
        private string longitude;
        private string latitude;

        public Location(string coordX, string coordY)
        {
            this.longitude = coordX;
            this.latitude = coordY;
        }

        public void GetWindSpeed()
        {
            Console.WriteLine(String.Format("\t> Force du vent en latitude {0} et longitude {1}", latitude, longitude));
        }

        public void GetSunshine()
        {
            Console.WriteLine(String.Format("\t> Niveau d'ensoleillement en latitude {0} et longitude {1}", latitude, longitude));
        }

        public void GetTemperature()
        {
            Console.WriteLine(String.Format("\t> Température en latitude {0} et longitude {1}", latitude, longitude));
        }

    }
}