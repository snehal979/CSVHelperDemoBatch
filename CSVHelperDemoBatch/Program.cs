namespace CSVHelperDemoBatch
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("hint 1 .Csv File Read or Write \n 2.Csv File to Json File");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1 :
                    CSVHandler cSVHandler = new CSVHandler();
                    cSVHandler.ImplementationCsvHanding();
                    break;
                case 2:
                    CsvFIIeTOJsonFile csvFIIeTOJson = new CsvFIIeTOJsonFile();
                    csvFIIeTOJson.ImplementationCsvFile_JsonFile();
                    break;
            }
        }
    }
}
