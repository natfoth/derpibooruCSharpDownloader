using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace derpibooruCSharpDownloader
{
    public class Configuration
    {
        public static Configuration Instance;
        private string _path;

        // ReSharper disable once UnusedMember.Local
        private Configuration() { }

        private Configuration(string path)
        {
            _path = path;
        }

        public string SaveLocation { get; set; } = "";

        public int NumOfPages { get; set; } = 5000;

        public string APIKey { get; set; } = "";
        public int NumOfPicsPerPage { get; set; } = 15;
        public int NumOfPicsTotal { get; set; } = 0;
        public int OrderingSelectedIndex { get; set; } = 0;

        public int ImageWidth { get; set; } = 0;
        public int ImageHeight { get; set; } = 0;

        public int MinRating { get; set; } = 0;

        public string LastSearchTerm { get; set; } = "Luna";


        #region Load & Save
        public static void LoadConfig(string path)
        {
            if (!File.Exists(path))
            {
                var config = CreateDefaultConfig(path);
                Instance = config;
            }
            else
            {
                var config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(path));
                config._path = path;
                Instance = config;
            }
        }

        private static Configuration CreateDefaultConfig(string path)
        {
            var config = new Configuration(path);

            config.Save();

            return config;
        }

        public void Save()
        {
            File.WriteAllText(_path, JsonConvert.SerializeObject(this));
        }

       
        #endregion
    }
}
