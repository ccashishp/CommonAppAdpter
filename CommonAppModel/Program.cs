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

    public class CommonAppFormAdpter
    {
        public List<QuestionAnswer> Answers
        {
            get
            {
                return GetAnswes();
            }
        }

        protected List<QuestionAnswer> GetAnswes()
        {
            var questionAnswers = new List<QuestionAnswer>();
            var properties = GetType().GetProperties().Where(
                prop => Attribute.IsDefined(prop, typeof(QuestionIdAttribute)));

            foreach(var property in properties)
            {
                var attributes = property.GetCustomAttributes(true).Where(a => a is QuestionIdAttribute);
                var attr = attributes.FirstOrDefault() as QuestionIdAttribute;
                if (attr !=null)
                {
                    var propValue = property.GetValue(this).ToString();
                    var questionId = int.Parse(attr.Id);
                    questionAnswers.Add(new QuestionAnswer { QuestionId = questionId, Response = propValue });
                }
            }

            return questionAnswers;
        }
    }

   
    //Example model

    public class CounselorProfileModel : CommonAppFormAdpter {

        [QuestionId("1023")]
        public string FirstName { get; set; }
        [QuestionId("13")]
        public string LastName { get; set; }

        public string Address { get; set; }

    }

    public class QuestionIdAttribute: Attribute {
        public QuestionIdAttribute(string id)
        {
            this.Id = id;
        }

        public string Id { get; }
    }

    //Common app Answers
    public class QuestionAnswer
    {
        public int QuestionId { get; set; }
        public string Response { get; set; }
    }
}
