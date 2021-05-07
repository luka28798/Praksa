using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.Model
{
    public class People
    {
        public int HumanID;
        public string FirstName;
        public string LastName;
        
        public People(int HumanID, string FirstName, string LastName)
        {
            this.HumanID = HumanID;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public People() { }
    }
}
