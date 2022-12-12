namespace MVC_People.Models.Repo
{
    public interface ICityRepo
    {
        public City Create(City city);
        public List<City> Read();
        public bool Delete(City city);
        public List<City> ReadInMemory();
        public List<Country> ReadCountries();
    }
}
