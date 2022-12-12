using MVC_People.Models.ViewModels;

namespace MVC_People.Models.Service
{
    public interface ICityService
    {
        public City Add(CreateCityViewModel city);
        public List<City> All();
        public bool Remove(int id);
        public List<City> GetInMemory();
        public int CityQueryCompare(City city);
        public List<Country> AllCountries();
    }
}
