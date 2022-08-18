﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
   public class EEmployee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeType { get; set; }
        public int DesignationId { get; set; }
        public Nullable<float> StartingSalary { get; set; }
        public string Nationality { get; set; }
        public string NID { get; set; }
        public string DOB { get; set; }
        public string JoiningDate { get; set; }
        public Nullable<int> ReligionId { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> UpazilaId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public int EntryBy { get; set; }
        public Nullable<DateTime> EntryDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
        public int Action { get; set; }



    //    public int EmployeeId { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string EmployeeType { get; set; }
    //    public int DesignationId { get; set; }
    //    public float StartingSalary { get; set; }
    //    public string Nationality { get; set; }
    //    public string NID { get; set; }
    //    public Nullable<DateTime> DOB { get; set; }
    //    public Nullable<DateTime> JoiningDate { get; set; }
    //    public int ReligionId { get; set; }
    //    public Nullable<int> DistrictId { get; set; }
    //    public Nullable<int> UpazilaId { get; set; }
    //    public string Address { get; set; }
    //    public string Email { get; set; }
    //    public string ContactNo { get; set; }
    //    public string Gender { get; set; }
    //    public string BloodGroup { get; set; }
    //    public int EntryBy { get; set; }
    //    public Nullable<DateTime> EntryDate { get; set; }
    //    public Nullable<int> UpdateBy { get; set; }
    //    public Nullable<DateTime> UpdateDate { get; set; }      
    //    public int Action { get; set; }
    }

}
