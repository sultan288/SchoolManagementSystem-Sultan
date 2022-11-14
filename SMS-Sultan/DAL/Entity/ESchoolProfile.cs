using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class ESchoolProfile
    {
        public int Action { get; set; }
        public int SchoolId { get; set; }
        public string RegNo { get; set; }
        public string SchoolName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DistrictId { get; set; }
        public int UpazilaId { get; set; }
        public string Address { get; set; }
        public Nullable<int> EntryBy { get; set; }
        public Nullable<DateTime> EntryDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
    }
}
