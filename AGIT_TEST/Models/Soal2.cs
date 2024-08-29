using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AGIT_TEST.Models
{
    public class Plan
    {
        [Key]
        public string id { get; set; }
        public int Senin { get; set; }
        public int Selasa { get; set; }
        public int Rabu { get; set; }
        public int Kamis { get; set; }
        public int Jumat { get; set; }
        public int Sabtu { get; set; }
        public int Minggu { get; set; }
    }

    public class Output
    {
        [Key]
        public string id { get; set; }
        public int Senin { get; set; }
        public int Selasa { get; set; }
        public int Rabu { get; set; }
        public int Kamis { get; set; }
        public int Jumat { get; set; }
        public int Sabtu { get; set; }
        public int Minggu { get; set; }
    }

    public class DataHeader
    {
        [Key]
        public long id { get; set; }
        public string PlanId { get; set; }
        public string OutputId { get; set; }
    }
}