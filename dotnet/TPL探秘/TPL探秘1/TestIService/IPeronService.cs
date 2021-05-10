using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDTO;

namespace TestIService
{
    public interface IPeronService
    {
        Task<long> AddAsync(string name, int age);

        Task DeleteByIdAsync(long id);

        Task<PersonDTO> GetByIdAsync(long id);

        Task<IEnumerable<PersonDTO>> GetAllAsync();
    }
}
