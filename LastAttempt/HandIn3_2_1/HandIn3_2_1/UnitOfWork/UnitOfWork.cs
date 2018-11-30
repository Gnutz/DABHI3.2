using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandIn3_2_1.Models;

namespace HandIn3_2_1.Repository
{
  
    public class UnitOfWork : IUnitOfWork
    {
        private readonly E18I4DABau569735Context context_;
        public IRepository<Person> Persons { get; private set; }

        public UnitOfWork(E18I4DABau569735Context context)
        {
            context_ = context;
            Persons = new Repository<Person>(context);
        }

        public void Complete()
        {
            context_.SaveChanges();
        }

        public void Dispose()
        {
            context_.Dispose();
        }
    }
}
