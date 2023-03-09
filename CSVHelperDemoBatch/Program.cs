namespace CSVHelperDemoBatch
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("hint 1 .Csv File Read or Write \n 2.Csv File to Json File \n 3.Json File To Cs File");
            CsvFIIeTOJsonFile csvFIIeTOJson = new CsvFIIeTOJsonFile();
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1 :
                    CSVHandler cSVHandler = new CSVHandler();
                    cSVHandler.ImplementationCsvHanding();
                    break;
                case 2:
                    csvFIIeTOJson.ImplementationCsvFile_JsonFile();
                    break;
                case 3:
                    csvFIIeTOJson.ImplementationJsonToCsv();
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }
    }
}
