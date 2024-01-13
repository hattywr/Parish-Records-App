using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class FamilyMember
    {
        public int familyID {  get; set; }
        public int childID { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }

        public string DOB { get; set; }
        public bool isBaptized { get; set; }
        public bool fstCommunion { get; set; }
        public bool isConfirmed { get; set; }
        public int status { get; set; }


        public FamilyMember(int ID, int chID, string first, string middle, string last, string birthDate, bool baptized, bool communion, bool confirmed, int currentStatus) 
        {
            familyID = ID;
            childID = chID;
            firstName = first;
            middleName = middle;
            lastName = last;
            DOB = birthDate;
            isBaptized = baptized;
            fstCommunion = communion;
            isConfirmed = confirmed;
            status = currentStatus;
        }
    }
}