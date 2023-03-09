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
        /// <summary>
        /// Reading from CSV File and writing Json File
        /// </summary>
        public void ImplementationCsvFile_JsonFile()
        {
            string importFilepath = @"C:\Users\hp\Desktop\newBatch2\CSVHelperDemoBatch\CSVHelperDemoBatch\Files\DemoImportFile.csv";
            string jsonFilepath = @"C:\Users\hp\Desktop\newBatch2\CSVHelperDemoBatch\CSVHelperDemoBatch\Files\DemoJsonFile.json";

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
        /// <summary>
        /// Reading from JSON File and writing to CSV File
        /// </summary>
        public void ImplementationJsonToCsv()
        {
            string newCsvFilePath = @"C:\Users\hp\Desktop\newBatch2\CSVHelperDemoBatch\CSVHelperDemoBatch\Files\NewCsvFile.csv";
            string jsonFilePath = @"C:\Users\hp\Desktop\newBatch2\CSVHelperDemoBatch\CSVHelperDemoBatch\Files\DemoJsonFile.json";
            //Read file Json
            List<ContactData> contacts = JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(jsonFilePath));
            Console.WriteLine("\n----------write to csv Other file--------------");
            // write csv file
            using var writer = new StreamWriter(newCsvFilePath);
            using (var csvWrite = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWrite.WriteRecords(contacts);
            }
        }
    }
}
