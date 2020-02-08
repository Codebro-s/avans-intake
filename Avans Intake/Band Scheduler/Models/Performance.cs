using System;
using System.Collections.Generic;
using System.Text;

namespace Band_Scheduler.Models
{
    class Performance
    {
        public int Id { get; set; }
        public Performer Performer { get; set; }
        public Stage Stage { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
