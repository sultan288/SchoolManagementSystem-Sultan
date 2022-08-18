﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
   public class EStudent
    {
        public int StudentId { get; set; }
        public string RegistrationNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string FatherName { get; set; }
        public string FatherContactNo { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherName { get; set; }
        public string MotherContactNo { get; set; }
        public string MotherOcupation { get; set; }
        public string GurdianName { get; set; }
        public string Relation { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> UpazilaId { get; set; }
        public string Address { get; set; }
        public Nullable<int> ReligionId { get; set; }
        public string StuPic { get; set; }
        public Nullable<int> EntryBy { get; set; }
        public Nullable<DateTime> EntryDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
        public int Action { get; set; }
    }

}
