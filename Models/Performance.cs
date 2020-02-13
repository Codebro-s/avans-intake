using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandScheduler.Models
{
    public class Performance
    {
        public int Id { get; set; }

        public int PerformerId { get; set; }

        public int StageId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
