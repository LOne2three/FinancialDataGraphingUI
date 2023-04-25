using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinancialDataWeb.ViewModels
{
    public class IndexViewModel
    {
        public Root? root { get; set; }

        public string? Interval { get; set; }
        public string? symbol { get; set; }
    }
}
