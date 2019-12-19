using System.IO;
using System.Linq;
namespace TM.Core.Configuration
{
    public class Configurator : IConfigurator
    {
        Config config = new Config();
        public Config GetConfig()
        {
            config.path = File.ReadLines(@".\Config.txt").First().Split(new char[] {'='})[1];
            return config;
        }
    }
}
