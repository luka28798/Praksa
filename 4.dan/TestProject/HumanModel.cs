using System;

namespace PeopleModel
{
    public class People
    {
        public int HumanID;
        public string FirstName;
        public string LastName;
        public Student(int HumanID, string FirstName, string LastName)
        {
            this.HumanID = HumanID;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public People() { }
    }
}
