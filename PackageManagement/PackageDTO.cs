using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManagement
{
    public class PackageDTO
    {

        public int PackageId { get; set; }
        public string PkgName { get; set; }
        public DateTime? PkgStartDate { get; set; }
        public DateTime? PkgEndDate { get; set; }
        public string PkgDesc { get; set; }
        public decimal PkgBasePrice { get; set; }
        public decimal? PkgAgencyCommission { get; set; }

        //Override ToString() method that comes from object class.
        public override string ToString()
        {

            return $"{PkgStartDate:yyyy/MM/dd} {PkgEndDate:yyyy/MM/dd} {PkgBasePrice.ToString("c")}";

        }

    }
}
