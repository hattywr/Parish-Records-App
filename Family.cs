using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Family
    {
        public List<FamilyMember> members;
        public int familyID {  get; set; }
        public string fatherName {  get; set; }
        public string motherName { get; set; }
        public string familyAddress { get; set; }
        public string familyCity { get; set; }
        public string familyState { get; set; }
        public string familyCountry { get; set; }
        public string familyZIP { get; set; }
        public bool fatherBaptized { get; set; }
        public bool motherBaptized { get; set; }
        public bool fatherCommunion { get; set; }
        public bool motherCommunion { get; set; }
        public bool fatherConfirmed { get; set; }
        public bool motherConfirmed { get; set; }
        public string phoneOne { get; set; }
        public string phoneTwo { get; set; }
        public string phoneThree { get; set; }
        public string phoneFour { get; set; }
        public string emailOne { get; set; }
        public string emailTwo { get; set; }
        public string marriedDate { get; set; }

        public Family(
            int famID,
            string father, 
            string mother, 
            string address, 
            string city, 
            string state, 
            string country, 
            string postalCode,
            bool fathBaptized,
            bool mothBaptized,
            bool fathCommunion,
            bool mothCommunion,
            bool fathConfirmed,
            bool mothConfirmed,
            string married,
            string phone1 = "", 
            string phone2 = "", 
            string phone3 = "", 
            string phone4 = "", 
            string email1 = "", 
            string email2 = "")
        {
            familyID = famID;
            fatherName = father;
            motherName = mother;
            familyAddress = address;
            familyCity = city;
            familyState = state;
            familyCountry = country;
            familyZIP = postalCode;
            fatherBaptized = fathBaptized;
            motherBaptized = mothBaptized;
            fatherCommunion = fathCommunion;
            motherCommunion = mothCommunion;
            fatherConfirmed = fathConfirmed;
            motherConfirmed = mothConfirmed;
            marriedDate = married;
            phoneOne = phone1;
            phoneTwo = phone2;
            phoneThree = phone3;
            phoneFour = phone4;
            emailOne = email1;
            emailTwo = email2;
        } 
    }
}