using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;

namespace HandIn3_2_2
{
    public interface IPersonCatalogueRepository<T> where T : class
    {
        Task<Document> CreatePersonAsync(T person);
        Task DeletePersonAsync(string id);
        Task<T> GetPersonAsync(string id);
        Task<IEnumerable<T>> GetPersonsAsync();
        Task<Document> UpdatePersonAsync(string id, T person);
    }
}