using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC_People.Data;
using MVC_People.Models;
using MVC_People.Models.People.PeopleService;
using MVC_People.Models.People.ViewModels;
using MVC_People.Models.Service;
using MVC_People.Models.ViewModels;

namespace MVC_People.Controllers
{
    public class CityController : Controller
    {
        ICityService _cityService;
        ICountryService _countryService;
        public CityController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }
        public IActionResult CityIndex()
        {
            List<City> cityList = _cityService.All();
            List<Country> countryList = _cityService.AllCountries();
            return View(cityList);
        }
        [HttpGet]
        public IActionResult _NewCityPartial()
        {
            List<string> countryList = new List<string>();
            foreach(Country country in _countryService.All())
            {
                countryList.Add(country.CountryName);
            }
            CreateCityViewModel viewModel = new CreateCityViewModel();
            viewModel.CountryList = countryList;
            return PartialView(viewModel);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult _NewCityPartial(CreateCityViewModel city)
        {
            //IEnumerable<Country> countryQuery =
            //from country in _cityService.AllCountries()
            //select country;
            //if(countryQuery.Contains(city.CityCountry))
            //{
            //    city.CityCountry = countryQuery.ToArray()[0];
            //}
            //else
            //{
            //    return PartialView();
            //}
            if (ModelState.IsValid)
            {

                try// STEP1 
                {
                    _cityService.Add(city);
                }
                catch (ArgumentException exception)
                {
                    // Add our own message
                    ModelState.AddModelError("error", exception.Message);// Key And value
                    return PartialView(city);
                }


                return RedirectToAction(nameof(CityIndex));
            }
            return PartialView(city);
        }
        public IActionResult Delete(int id)
        {
            var deleteCity = _cityService.Remove(id);

            if (deleteCity)
                return RedirectToAction(nameof(CityIndex));
            else
            {
                return null;
            }
        }
        
    }
}
