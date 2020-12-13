using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Script
{
    public class Information
    {
        public string Unit { get; set; }
        public string Period { get; set; }
        public int Data { get; set; }
        private static readonly List<string> typeOfUnit = new List<string>()
        {
            "Dollar",
            "kW",
            "kg/m3"
        };
        
        public Information(string unit, int data)
        {
            if (typeOfUnit.Contains(unit))
                this.Unit = unit;
            else
                throw new ArgumentException(string.Format("The type '{0}' does not exist", unit), "unit");
            
            this.Period = "daily";
            this.Data = data;
        }
    }
}