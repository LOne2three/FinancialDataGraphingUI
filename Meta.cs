using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialDataApp
{

    public class Meta
    {
        public string? symbol { get; set; }
        public string? interval { get; set; }
        public string? currency { get; set; }
        public string? exchange_timezone { get; set; }
        public string? exchange { get; set; }
        public string? mic_code { get; set; }
        public string? type { get; set; }
        public string? currency_base { get; set; }
        public string? currency_quote { get; set; }
    }

}
