using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MVC_People.Data;
using MVC_People.Models;
using MVC_People.Models.People.PeopleRepo;
using MVC_People.Models.People.PeopleService;
using MVC_People.Models.People.ViewModels;
using MVC_People.Models.Service;
using MVC_People.Models.ViewModels;
using System.Dynamic;

namespace MVC_People.Controllers
{
    public class AjaxController : Controller
    {
        IPeopleService? _peopleService;
        ICityService _cityService;
        public AjaxController(IPeopleService peopleService, ICityService cityService)
        {
            _peopleService = peopleService;
            _cityService = cityService;
        }
        public IActionResult _AjaxPersonList()
        {
            List<Person> person = _peopleService.All();
            if (person != null)
            {
                return PartialView("_PeopleListPartial", person);

            }
            return BadRequest();

        }
        public IActionResult PeopleIndexAJAX()
        {
            var PeopleList = _peopleService.All();
            return View(PeopleList);
        }

        [HttpGet]
        public IActionResult AjaxDelete(int id)
        {
            _peopleService.Remove(id);
            return RedirectToAction(nameof(PeopleIndexAJAX));
        }
        [HttpPost]
        public IActionResult _PeopleSearchPartial(string id)
        {
            var p = _peopleService.Search(id);
            return PartialView(p);
        }
        public IActionResult _NewPersonPartial()
        {
            List<string> cityList = new List<string>();
            foreach (City city in _cityService.All())
            {
                cityList.Add(city.CityName);
            }
            CreatePersonViewModel viewModel = new CreatePersonViewModel();
            viewModel.CityList = cityList;
            return PartialView(viewModel);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult _NewPersonPartial(CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                try// STEP1 
                {
                    _peopleService.Add(person);
                }
                catch (ArgumentException exception)
                {
                    // Add our own message
                    ModelState.AddModelError("error", exception.Message);// Key And value
                    return PartialView(person);
                }


                return RedirectToAction(nameof(PeopleIndexAJAX));
            }
            return RedirectToAction(nameof(PeopleIndexAJAX));
        }
        [HttpPost]
        public IActionResult _PeopleDetailsAjax(int id)
        {
            var p = _peopleService.FindById(id);
            return PartialView(p);
        }
        public IActionResult _UpdatePartial(int id)
        {
            return PartialView(_peopleService.FindById(id));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(int id, CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {

                try// STEP1 
                {
                    _peopleService.Edit(id, person);
                }
                catch (ArgumentException exception)
                {
                    // Add our own message
                    ModelState.AddModelError("error", exception.Message);// Key And value
                    return PartialView("_UpdatePartial", person);
                }


                return RedirectToAction(nameof(PeopleIndexAJAX));
            }
            return PartialView("_UpdatePartial", person);
        }
    }
}
