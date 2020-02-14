using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandScheduler.Services
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
    }

    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
    }
}
