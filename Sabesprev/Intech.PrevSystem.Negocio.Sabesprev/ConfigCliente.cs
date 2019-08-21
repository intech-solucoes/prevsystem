using Newtonsoft.Json;
using System.IO;

namespace Intech.PrevSystem.Negocio.Sabesprev
{
    public class ConfigSabesprev
    {
        public string EmailDestinoArquivoBancario { get; set; }

        public static ConfigSabesprev Get()
        {
            var file = File.ReadAllText("sabesprev.json");
            return JsonConvert.DeserializeObject<ConfigSabesprev>(file);
        }
    }
}