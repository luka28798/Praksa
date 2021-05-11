using Human.Model.Common;
namespace Human.Model
{
    public class People : IHumanModel
    {
        public int HumanID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public People(int HumanID, string FirstName, string LastName)
        {
            this.HumanID = HumanID;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public People() { }
    }
}
