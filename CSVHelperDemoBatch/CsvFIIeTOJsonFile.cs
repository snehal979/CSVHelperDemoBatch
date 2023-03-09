using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSVHelperDemoBatch
{
    public class CsvFIIeTOJsonFile
    {
        public void ImplementationCsvFile_JsonFile()
        {
            string importFilepath = @"C:\Users\hp\Desktop\newBatch2\CSVHelperDemoBatch\CSVHelperDemoBatch\DemoImportFile.csv";
            string jsonFilepath = @"C:\Users\hp\Desktop\newBatch2\CSVHelperDemoBatch\CSVHelperDemoBatch\DemoJsonFile.json";

            using (var reader = new StreamReader(importFilepath))
            using (var csvRead = new CsvReader(reader, CultureInfo.InvariantCulture)) // only get property 
            {
                var records = csvRead.GetRecords<ContactData>().ToList();
                Console.WriteLine("Read data successfully from file csv");
                foreach (ContactData data in records)
                {
                    Console.WriteLine("\t" + data.Name);
                    Console.WriteLine("\t" + data.Email);
                    Console.WriteLine("\t" + data.City);
                    Console.WriteLine("\t" + data.PhoneNumber);
                    Console.WriteLine("\n");
                }
                Console.WriteLine("-----------Read CSV TO Write JSON-------------");
                //Write json File
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(jsonFilepath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                } 
                
            }
            
        }
    }
}
