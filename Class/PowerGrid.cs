using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Script
{
    public class PowerGrid
    {
        public static int fnCounter = 1000;
        public static int dnCounter = 1000;
        public static int plCounter = 1000;

        public static List<FocusNode> Focus_nodes = new List<FocusNode>();
        public static List<DistributionNode> Distribution_nodes  = new List<DistributionNode>();
        public static List<PowerLine> Power_lines = new List<PowerLine>();

        public static void AddFocusNode(FocusNode fn)
        {
            Focus_nodes.Add(fn);
        }

        public static void AddDistributionNode(DistributionNode dn)
        {
            Distribution_nodes.Add(dn);
        }
        
        public static void AddPowerLine(PowerLine pl)
        {
            Power_lines.Add(pl);
        }
    }

    public class FocusNode
    {
        public string Id { get; set; }
        public List<string> From { get; set; }
        public string To { get; set; }

        public FocusNode(List<string> FROM, string TO)
        {
            this.Id = "FN" + ++PowerGrid.fnCounter;
            this.From = FROM;
            this.To = TO;
        }
    }

    public class DistributionNode
    {
        public string Id { get; set; }
        public string From { get; set; }
        public List<string> To { get; set; }

        public DistributionNode(string FROM, List<string> TO)
        {
            this.Id = "DN" + ++PowerGrid.dnCounter;
            this.From = FROM;
            this.To = TO;
        }
    }

    public class PowerLine
    {
        public string Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public PowerLine(string FROM, string TO)
        {
            this.Id = "PL" + ++PowerGrid.plCounter;
            this.From = FROM;
            this.To = TO;
        }
    }

    // public class User
    // {
    //     public object Power_user { get; set; }
    //     public string Connection_to { get; set; }

    //     public User(string connection_to, Consumer client=null, PowerProducer source=null)
    //     {
    //         if ((client == null && source == null) || (client != null && source != null))
    //         {
    //             throw new ArgumentNullException();
    //         }
    //         else
    //         {
    //             if (client != null)
    //             {
    //                 this.Power_user = client;
    //             }
    //             else
    //             {
    //                 this.Power_user = source;
    //             }
    //         }
    //     }
    // }
}