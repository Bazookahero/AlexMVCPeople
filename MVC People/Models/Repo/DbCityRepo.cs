using MVC_People.Data;
using MVC_People.Models.People.PeopleRepo;

namespace MVC_People.Models.Repo
{
    public class DbCityRepo : ICityRepo
    {
        List<City> inMemoryCityList = new List<City>();
        readonly PeopleDbContext _peopleDbContext;
        public DbCityRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public City Create(City city)
        {
            inMemoryCityList.Add(city);
            _peopleDbContext.Cities.Add(city);
            _peopleDbContext.SaveChanges();
            return city;
        }
        public List<City> Read()
        {
            return _peopleDbContext.Cities.ToList();
        }
        public List<Country> ReadCountries()
        {
            return _peopleDbContext.Countries.ToList();
        }
        public bool Delete(City city)
        {
            foreach (City c in Read())
                if (city.Id == c.Id)
                {
                    _peopleDbContext.Remove(c);
                    _peopleDbContext.SaveChanges();
                    return true;
                }
            return false;
        }
        public List<City> ReadInMemory()
        {
            return inMemoryCityList;
        }
    }
}
