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
        
        public static int GetGlobalImportPrice(List<int> data)
        {
            foreach (int price in data)
                GlobalImportPrice += price;

            return GlobalImportPrice;
        }

        public static int GetGlobalExportPrice(List<int> data)
        {
            foreach (int price in data)
                GlobalExportPrice += price;

            return GlobalExportPrice;
        }
    }
}