using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ConsciousbetApp.Model;

namespace ConsciousbetApp.Utils
{
    public class FileManager
    {
        private static string path = "apostas.json";

        public static void Salvar(List<Aposta> apostas)
        {
            string json = JsonConvert.SerializeObject(apostas, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public static List<Aposta> Carregar()
        {
            if (!File.Exists(path)) return new List<Aposta>();
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Aposta>>(json);
        }
    }
}
