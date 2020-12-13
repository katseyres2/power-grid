using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Script
{
    public class GlobalMarket
    {
        public static int GlobalImportPrice = 0;
        public static int GlobalExportPrice = 0;
        
        public static int GetGlobalImportPrice()
        {
            foreach (Consumer c in ConsumerManager.consumers)
                if (c.Type == "international sales")
                    GlobalImportPrice += c.Power_consumption.Data;
            
            return GlobalImportPrice;
        }

        public static int GetGlobalExportPrice()
        {
            foreach (Producer p in ProducerManager.producers)
                if (p.Type == "international purchasing")
                    GlobalExportPrice += p.Electricity_production.Data;

            return GlobalExportPrice;
        }
    }
}