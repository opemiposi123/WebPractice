using EFCore_DatabaseFirst.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_DatabaseFirst
{
    public class PersonService
    {
        private readonly DbFirstDemoContext _dbContext;
        public PersonService(DbFirstDemoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPerson()
        {
            var person = new Person
            {
                FirstName = "MahmoodAhmad",
                LastName = "AdbulWaheed",
                DateOfBirth = Convert.ToDateTime("07 / 10 / 2007")
            };
            _dbContext.Add(person);
            _dbContext.SaveChanges();
        }

        public int GetPersonCount()
        {
            return _dbContext.People.ToList().Count;
        }

        public void UpdateRecord(int id)
        {
            var person = _dbContext.People.Find(id);
            // removed null check validation for brevity
            person.FirstName = "MD";
            person.DateOfBirth = Convert.ToDateTime("11 / 22 / 2016");
            _dbContext.Update(person);
            _dbContext.SaveChanges();
        }

        public Person GetRecord(int id)
        {
            return _dbContext.People.SingleOrDefault(p => p.Id.Equals(id));
        }

        public void DeleteRecord(int id)
        {
            var person = _dbContext.People.Find(id);
            // removed null check validation for brevity
            _dbContext.Remove(person);
            _dbContext.SaveChanges();
        }
    }
}
