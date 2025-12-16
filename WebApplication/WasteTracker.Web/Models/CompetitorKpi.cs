using System;

namespace WasteTracker.Web.Models
{
    public class CompetitorKpi
    {
        public string Company { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal TotalWasteKg { get; set; }
        public decimal KantspildKg { get; set; }
        public decimal KvalitetsspildKg { get; set; }
        public decimal InternalReuseKg { get; set; }
        public decimal WasteToIncinerationKg { get; set; }
        public decimal ReusePercentage { get; set; }
        public string DataSource { get; set; } = string.Empty;
    }
}
