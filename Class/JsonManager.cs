using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Script
{
    public class JsonManager
    {
        // ------------------------------------------------------------------------ Gestionnaire JSON pour les producteurs d'électricité

        public static void UpdateProducers()
        {
            byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(ProducerManager.producers, options);
            File.WriteAllBytes(@"Data/producersData.json", jsonUtf8Bytes);
        }

        public static object GetProducers()
        {
            string jsonRead = String.Empty;
            jsonRead = File.ReadAllText(@"Data/producersData.json");
            var listPowerProducers = JsonSerializer.Deserialize<object>(jsonRead);

            return listPowerProducers;
        }

        // ------------------------------------------------------------------------ Gestionnaire JSON pour les consommateurs d'électricité

        public static void UpdateConsumers()
        {
            byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(ConsumerManager.consumers, options);
            File.WriteAllBytes(@"Data/consumersData.json", jsonUtf8Bytes);
        }
        public static object GetConsumers()
        {
            string jsonRead = String.Empty;
            jsonRead = File.ReadAllText(@"Data/consumersData.json");
            var listConsumers = JsonSerializer.Deserialize<object>(jsonRead);

            return listConsumers;
        }
        
        // ------------------------------------------------------------------------ Gestionnaire JSON pour l'infractructure réseau

        public static Dictionary<string,object> pg = new Dictionary<string, object>();

        public static void UpdatePowerGrid()
        {
            pg.Add("Power_lines", PowerGrid.Power_lines);
            pg.Add("Focus_nodes", PowerGrid.Focus_nodes);
            pg.Add("Distribution_nodes", PowerGrid.Distribution_nodes);

            byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(pg, options);
            File.WriteAllBytes(@"Data/powerGridData.json", jsonUtf8Bytes);
        }
    }
}