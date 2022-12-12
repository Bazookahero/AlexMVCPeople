using MVC_People.Models.ViewModels;

namespace MVC_People.Models.Repo
{
    public interface ICountryRepo
    {
        public Country Create(Country country);
        public List<Country> Read();
        public bool Delete(Country country);
        public Country SearchCountry(string countryName);
    }
}
