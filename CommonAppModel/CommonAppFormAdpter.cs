using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonAppModel
{
    public class CommonAppFormAdpter
    {
        public IList<QuestionAnswer> Answers
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
}
