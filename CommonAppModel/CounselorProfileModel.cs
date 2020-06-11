namespace CommonAppModel
{
    //Example model

    public class CounselorProfileModel : CommonAppFormAdpter {

        [QuestionId("1023")]
        public string FirstName { get; set; }
        [QuestionId("13")]
        public string LastName { get; set; }

        public string Address { get; set; }

    }
}
