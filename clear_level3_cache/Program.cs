using System;

namespace clear_level3_cache
{
    class Program
    {
        public static void Main(string[] args)
        {
//            var inputReader = new HardCodedInput();
//            var inputReader = new OctopusInput();
            var inputReader = new ArgumentsInput(args);
            new CacheInvalidatorProgram(inputReader).Execute();

            Console.ReadKey(true);
        }

        public class HardCodedInput : CacheInvalidatorProgram.IInputReader
        {
            public CacheInvalidatorProgram.Input Read()
            {
                return new CacheInvalidatorProgram.Input
                {
                    ApiKey = "YOUR_API_KEY",
                    ApiSecret = "YOUR_API_SECRET",
                    UrlsSeparatedByComma = "subdomain1.mydomain.com,subdomain2.mydomain.com,subdomain3.mydomain.com",
                    NotificationEmail = "youremail@yourcompany.com"
                };
            }
        }

    }
}