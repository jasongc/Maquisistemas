using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetAdminUTL
{
    public class Log
    {
        public void Generar(EnLog enLog)
        {
            List<EnLog> enLogList = new List<EnLog>();
            enLogList.Add(enLog);
            string sCarpeta = enLog.RutaLog + "\\" + DateTime.Now.ToString("yyyyMMdd");
            DirectoryInfo dir = new DirectoryInfo(sCarpeta);
            if (!dir.Exists)
                dir.Create();

            string sRuta = dir + "\\LOG_" + enLog.Esquema + ".json";

            FileInfo file = new FileInfo(sRuta);
            if (file.Exists)
            {
                using (StreamReader jsonStream = file.OpenText())
                {
                    var jsonAnterior = jsonStream.ReadToEnd();
                    List<EnLog> logsAnteriores = JsonConvert.DeserializeObject<List<EnLog>>(jsonAnterior) ?? new List<EnLog>();
                    enLogList.AddRange(logsAnteriores);
                    jsonStream.Dispose();
                }
            }

            string json = System.Text.Json.JsonSerializer.Serialize(enLogList);
            File.WriteAllText(sRuta, json);
        }
    }
}
