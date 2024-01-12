using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class ParentOption
    {
        public string familyID {  get; set; }
        public string parentNames {  get; set; }
        public string familyName { get; set; }
        public ParentOption(string ID, string names, string lastName) 
        {
            this.familyID = ID;
            this.parentNames = names;
            this.familyName = lastName;

        }
    }
}