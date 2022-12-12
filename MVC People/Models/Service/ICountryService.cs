using MVC_People.Models.ViewModels;

namespace MVC_People.Models.Service
{
    public interface ICountryService
    {
        public Country Add(CreateCountryViewModel country);
        public List<Country> All();
        public bool Remove(int id);
        public int CountryQueryCompare(Country country);
    }
}
