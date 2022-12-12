using MVC_People.Data;
using MVC_People.Models.People.PeopleRepo;
using MVC_People.Models.Repo;

namespace MVC_People.Models.Repo
{
    public class DbCountryRepo : ICountryRepo
    {
        readonly PeopleDbContext _peopleDbContext;


        public DbCountryRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Country Create(Country country)
        {
            _peopleDbContext.Countries.Add(country);
            _peopleDbContext.SaveChanges();
            return country;
        }
        public List<Country> Read()
        {
            return _peopleDbContext.Countries.ToList();
        }
        public bool Delete(Country country)
        {
            foreach (Country c in Read())
                if (country.Id == c.Id)
                {
                    _peopleDbContext.Remove(c);
                    _peopleDbContext.SaveChanges();
                    return true;
                }
            return false;
        }
        public Country SearchCountry(string countryName)
        {
            return _peopleDbContext.Countries.FirstOrDefault(c => c.CountryName == countryName);
        }
    }
}
