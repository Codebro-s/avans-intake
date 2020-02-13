using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandScheduler.Services
{
    public interface IService<T>
    {
        public IEnumerable<T> Get();

        public T Get(int id);

        public void Create(T model);

        public void Update(int id, T model);

        public void Delete(int id);
    }
}
