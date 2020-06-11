using System;

namespace CommonAppModel
{
    public class QuestionIdAttribute: Attribute {
        public QuestionIdAttribute(string id)
        {
            this.Id = id;
        }

        public string Id { get; }
    }
}
