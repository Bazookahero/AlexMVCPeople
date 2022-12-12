using Microsoft.AspNetCore.Mvc;
using MVC_People.Models.People.PeopleService;
using MVC_People.Models.ViewModels;
using MVC_People.Models.Service;
using MVC_People.Models;
using MVC_People.Models.People.ViewModels;

namespace MVC_People.Controllers
{
    public class CountryController : Controller
    {
        ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public IActionResult CountryIndex()
        {
            List<Country> countryList = _countryService.All();
            return View(countryList);
        }
        public IActionResult _CountryListPartial()
        {
            List<Country> countries = _countryService.All();
            if (countries != null)
            {
                return PartialView("_CountryListPartial", countries);

            }
            return BadRequest();

        }
        public IActionResult _NewCountryPartial()
        {
            return PartialView(new CreateCountryViewModel());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult _NewCountryPartial(CreateCountryViewModel country)
        {
            if (ModelState.IsValid)
            {

                try// STEP1 
                {
                    _countryService.Add(country);
                }
                catch (ArgumentException exception)
                {
                    // Add our own message
                    ModelState.AddModelError("error", exception.Message);// Key And value
                    return PartialView(country);
                }


                return RedirectToAction(nameof(CountryIndex));
            }
            return PartialView(country);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult _CountryIndexPartial(CreateCountryViewModel country)
        {
            if (ModelState.IsValid)
            {
                try// STEP1 
                {
                    _countryService.Add(country);
                }
                catch (ArgumentException exception)
                {
                    // Add our own message
                    ModelState.AddModelError("error", exception.Message);// Key And value
                    return View(country);
                }
                return RedirectToAction(nameof(CountryIndex));
            }
            return View(country);
        }
        public IActionResult Delete(int id)
        {
            var deleteCountry = _countryService.Remove(id);

            if (deleteCountry)
                return RedirectToAction(nameof(CountryIndex));
            else
            {
                return null;
            }
        }
    }
}
