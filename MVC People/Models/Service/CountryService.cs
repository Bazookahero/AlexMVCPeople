using MVC_People.Models.People.PeopleRepo;
using MVC_People.Models.ViewModels;
using MVC_People.Models.Repo;

namespace MVC_People.Models.Service
{
    public class CountryService : ICountryService
    {
        ICountryRepo _countryRepo;
        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }
        public Country Add(CreateCountryViewModel country)
        {
            if (string.IsNullOrWhiteSpace(country.CountryName) /*|| country.CitiesInCountry == null*/)
            {
                Exception ex = new Exception();
                throw ex;
            }
            Country newCountry = new Country();
            newCountry.CountryName = country.CountryName;
            var query = CountryQueryCompare(newCountry);
            if (query == 1)
            { 
                return null;
            }
            else
            {
                return _countryRepo.Create(newCountry);
            }
        }
        public List<Country> All()
        {
            return _countryRepo.Read();
        }
        public bool Remove(int id)
        {

            foreach (Country country in _countryRepo.Read())
                if (id == country.Id)
                {
                    _countryRepo.Delete(country);
                    return true;
                }
            return false;
        }
        public int CountryQueryCompare(Country country)
        {
            List<Country> countries = _countryRepo.Read();
            int countryQuery = (
                from countryQ in countries
                where countryQ.CountryName == country.CountryName
                select countryQ
            ).Count();
            if (countryQuery == 0)
                return 0;
            else
                return 1;
        }
    }
}
