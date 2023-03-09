using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVHelperDemoBatch
{
    public class CSVHandler
    {
       public string importFilepath = @"C:\Users\hp\Desktop\newBatch2\CSVHelperDemoBatch\CSVHelperDemoBatch\DemoImportFile.csv";
       public string exportFilepath = @"C:\Users\hp\Desktop\newBatch2\CSVHelperDemoBatch\CSVHelperDemoBatch\DemoExportFile.csv";
        /// <summary>
        /// Read / Write CSV File into  String Array
        /// </summary>
        public void ImplementationCsvHanding()
        {
            //read CSV file
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
                Console.WriteLine("\n----------write to csv file--------------");
                // write csv file
                using var writer = new StreamWriter(exportFilepath);
                using (var csvWrite = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWrite.WriteRecords(records);
                }


            }
        }
    }
}
