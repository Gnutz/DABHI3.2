using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandIn3_2_1.Repository
{
    public interface IUnitOfWork
    {
        void Complete();
        void Dispose();
    }
}
