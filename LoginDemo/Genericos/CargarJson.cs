using System.IO;
using Newtonsoft.Json;

namespace LoginDemo.Genericos
{
    public class CargarJson
    {
        public POJO.loginData login_data() {
            var Json = JsonConvert.DeserializeObject<POJO.loginData>(File.ReadAllText(@"..\..\..\Data\login.json"));
            return Json;
        }
    }
}
