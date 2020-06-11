using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CommonAppModel
{

    class Program
    {
        static void Main(string[] args)
        {

            var model = new CounselorProfileModel { FirstName = "John", LastName = "Douglas" };

            var answers = model.Answers;

            //Test how it will be serialized    
            var json = JsonConvert.SerializeObject(answers);
            Console.WriteLine(json);
            Console.ReadKey();
        }
    }    
}
