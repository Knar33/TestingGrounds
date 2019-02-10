using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestingGrounds.RateService;
using System.Runtime.CompilerServices;
using System.Net.Http;

namespace TestingGrounds
{
    public class Program
    {
        static void Main(string[] args)
        {
            Rootobject result = doStuff().Result;
        }

        public static async Task<Rootobject> doStuff()
        {
            HttpClient client = new HttpClient();
            var cityString = string.Format("https://api.battlemetrics.com/servers/433768/");
            var cityUrl = await client.GetAsync(cityString);
            var cityResponse = JsonConvert.DeserializeObject<Rootobject>(await cityUrl.Content.ReadAsStringAsync());

            return cityResponse;
        }
    }
    
    public class Rootobject
    {
        public Data data { get; set; }
        public object[] included { get; set; }
    }

    public class Data
    {
        public string type { get; set; }
        public string id { get; set; }
        public Attributes attributes { get; set; }
        public Relationships relationships { get; set; }
    }

    public class Attributes
    {
        public string id { get; set; }
        public string name { get; set; }
        public string ip { get; set; }
        public int port { get; set; }
        public int players { get; set; }
        public int maxPlayers { get; set; }
        public int rank { get; set; }
        public float[] location { get; set; }
        public string status { get; set; }
        public Details details { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int portQuery { get; set; }
        public string country { get; set; }
        public string queryStatus { get; set; }
    }

    public class Details
    {
        public string map { get; set; }
        public string environment { get; set; }
        public string rust_build { get; set; }
        public int rust_ent_cnt_i { get; set; }
        public int rust_fps { get; set; }
        public float rust_fps_avg { get; set; }
        public int rust_gc_cl { get; set; }
        public int rust_gc_mb { get; set; }
        public string rust_hash { get; set; }
        public string rust_headerimage { get; set; }
        public object rust_mem_pv { get; set; }
        public object rust_mem_ws { get; set; }
        public bool rust_pve { get; set; }
        public int rust_uptime { get; set; }
        public string rust_url { get; set; }
        public int rust_world_seed { get; set; }
        public int rust_world_size { get; set; }
        public string rust_description { get; set; }
        public bool rust_modded { get; set; }
        public int rust_queued_players { get; set; }
        public DateTime rust_last_ent_drop { get; set; }
        public DateTime rust_last_seed_change { get; set; }
        public DateTime rust_last_wipe { get; set; }
        public DateTime rust_map_size_ent_count { get; set; }
        public int rust_last_wipe_ent { get; set; }
        public string serverSteamId { get; set; }
    }

    public class Relationships
    {
        public Game game { get; set; }
    }

    public class Game
    {
        public Data1 data { get; set; }
    }

    public class Data1
    {
        public string type { get; set; }
        public string id { get; set; }
    }

}
