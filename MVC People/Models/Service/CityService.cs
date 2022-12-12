using Microsoft.Data.SqlClient;
using MVC_People.Models.People.PeopleRepo;
using MVC_People.Models.Repo;
using MVC_People.Models.ViewModels;
using NuGet.Configuration;
using System.Diagnostics.Metrics;

namespace MVC_People.Models.Service
{
    public class CityService : ICityService
    {
        ICityRepo _cityRepo;
        ICountryRepo _countryRepo;
        public CityService(ICityRepo cityRepo, ICountryRepo countryRepo)
        {
            _cityRepo = cityRepo;
            _countryRepo = countryRepo;
        }
        public City Add(CreateCityViewModel city)
        {
            if (string.IsNullOrWhiteSpace(city.CityName) /*|| country.CitiesInCountry == null*/)
            {
                Exception ex = new Exception();
                throw ex;
            }
            City newCity = new City();
            newCity.CityName = city.CityName;
            newCity.CityCountry = _countryRepo.SearchCountry(city.CityCountryName);
            return _cityRepo.Create(newCity);
        }
        public List<City> All()
        {
            return _cityRepo.Read();
        }
        public List<Country> AllCountries()
        {
            //IEnumerable<Country> countryQuery =
            //    from country in _cityRepo.ReadCountries()
            //    select country;

            return _cityRepo.ReadCountries();
        }
        public bool Remove(int id)
        {

            foreach (City city in _cityRepo.Read())
                if (id == city.Id)
                {
                    _cityRepo.Delete(city);
                    return true;
                }
            return false;
        }
        public List<City> GetInMemory()
        {
            return _cityRepo.ReadInMemory();
        }
        public int CityQueryCompare(City city)
        {
            List<City> cities = _cityRepo.Read();
            int cityQuery = (
                from cityQ in cities
                where cityQ.CityName == city.CityName
                select cityQ
            ).Count();
            if (cityQuery == 0)
                return 0;
            else
                return 1;
        }
    }
}
