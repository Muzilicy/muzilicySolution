using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDTO;
using TestIService;

namespace TestService
{
    public class PersonService : IPeronService
    {
        public async Task<long> AddAsync(string name, int age)
        {
            using(MyDbContext ctx = new MyDbContext())
            {
                Person p = new Person();
                p.Age = age;
                p.Name = name;
                ctx.Persons.Add(p);
                await ctx.SaveChangesAsync();
                return p.Id;
            }
        }

        public async Task DeleteByIdAsync(long id)
        {
            using(MyDbContext ctx = new MyDbContext())
            {
                Person p = await ctx.Persons.FirstAsync(d => d.Id == id);
                ctx.Entry(p).State = EntityState.Deleted;
                await ctx.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PersonDTO>> GetAllAsync()
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                List<PersonDTO> persons = new List<PersonDTO>();
                await ctx.Persons.Where(u=>u.Age>5).ForEachAsync(person =>
                {
                    PersonDTO dto = new PersonDTO();
                    dto.Id = person.Id;
                    dto.Name = person.Name;
                    dto.Age = person.Age;
                    persons.Add(dto);
                });
                return persons;
            }
        }

        public async Task<PersonDTO> GetByIdAsync(long id)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                Person p = await ctx.Persons.FirstAsync(d => d.Id == id);
                if(p == null)
                {
                    return null;
                }
                PersonDTO dto = new PersonDTO();
                dto.Age = p.Age;
                dto.Name = p.Name;
                dto.Id = p.Id;
                return dto;
            }
        }
    }
}
