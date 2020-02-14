using BandScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandScheduler.Services
{
    public interface IPerformanceService : IService<Performance>
    {
        public void Create(Performance model, string startDateString, string endDateString);
    }
}
