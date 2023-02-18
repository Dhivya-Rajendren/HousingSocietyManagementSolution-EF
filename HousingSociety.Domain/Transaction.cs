using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingSociety.Domain
{
    public class Transaction
    {
        public int TransactionId { get; set; }
    
        public int TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }

        public int MaintenanceId { get; set; }
        public Maintenance Maintenance { get; set; }

        public int FlatId{ get; set; }
        public Flat Flat { get; set; }
    }
}
