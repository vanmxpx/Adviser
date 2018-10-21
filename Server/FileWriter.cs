using System;
using GetFromPoster;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace FileWriter
{
    class FileWriter
    {
        const string writePath = @"E:\";
        static void WriteToFile(JObject data)
        {
            using (StreamWriter file = File.CreateText(writePath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                data.WriteTo(writer);
            }
        }
    }

}