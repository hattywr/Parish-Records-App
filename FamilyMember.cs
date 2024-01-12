using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class FamilyMember
    {
        public int familyID {  get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public bool isFather { get; set; }
        public bool isMother { get; set; }
        public bool isChild { get; set; }

        public FamilyMember(int ID, string first, string middle, string last, bool Father, bool Mother, bool Child) 
        {
            familyID = ID;
            firstName = first;
            middleName = middle;
            lastName = last;
            isFather = Father;
            isMother = Mother;
            isChild = Child;
        }
    }
}