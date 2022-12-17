using MessagePack.Formatters;
using Microsoft.AspNetCore.Mvc;
using MVC_People.Data;
using MVC_People.Models;
using MVC_People.Models.People;
using MVC_People.Models.People.PeopleRepo;
using MVC_People.Models.People.PeopleService;
using MVC_People.Models.People.ViewModels;
using MVC_People.Models.Repo;
using MVC_People.Models.Service;
using MVC_People.Models.ViewModels;
using System;
using System.Xml.Linq;

namespace MVC_People.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        ICityService _cityService;
        PeopleDbContext _context;
        public PeopleController(IPeopleService peopleService, ICityService cityService, PeopleDbContext context)
        {
            _peopleService = peopleService;
            _cityService = cityService;
            _context = context;
        }
        [HttpGet]
        public IActionResult PeopleIndex()
        {
            return View(_peopleService.All());
        }

        [HttpGet]
        public IActionResult PeopleDetails(int id)
        {
            var findPerson = _peopleService.FindById(id);
            if(findPerson == null)
            {
                return RedirectToAction(nameof(PeopleIndex));
            }
            if(findPerson.Id == id)
            {
                return View(findPerson);
            }
            return View();
        }
        [HttpGet]
        public IActionResult NewPerson()
        {

            return View(new CreatePersonViewModel());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult NewPerson(CreatePersonViewModel person)
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
                    return View(person);
                }


                return RedirectToAction(nameof(NewPerson));
            }
            return View(person);
        }
        public IActionResult Delete(int id)
        {
            var deletePerson = _peopleService.Remove(id);

            if(deletePerson)
            return RedirectToAction(nameof(PeopleIndex));
            else
            {
                return null;
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult _PeopleIndexPartial(CreatePersonViewModel person)
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
                    return View(person);
                }
                return RedirectToAction(nameof(PeopleIndex));
            }
            return View(person);
        }
        [HttpGet]
        public IActionResult _PeopleIndexPartial(int id)
        {
            var findPerson = _peopleService.FindById(id);
            if (findPerson == null)
            {
                return RedirectToAction(nameof(PeopleIndex));
            }
            if (findPerson.Id == id)
            {
                return PartialView(findPerson);
            }
            return RedirectToAction(nameof(PeopleIndex));
        }
        public IActionResult _PeopleListPartial(List<Person> peopleList)
        {
            if (ModelState.IsValid)
            {
                try// STEP1 
                {
                    peopleList = _peopleService.All();
                }
                catch (ArgumentException exception)
                {
                    // Add our own message
                    ModelState.AddModelError("error", exception.Message);// Key And value
                    return RedirectToAction(nameof(PeopleIndex));
                }
                return PartialView(peopleList);
            }
            return PartialView(peopleList);
        }

        [HttpPost]
        public IActionResult _PeopleDetailsPartial(int id)
        {
            var findPerson = _peopleService.FindById(id);
            return PartialView(findPerson);
        }
        [HttpPost]
        public IActionResult _PeopleSearchPartial(string id)
        {
            var findPerson = _peopleService.Search(id);
            return PartialView(findPerson);
        }
        public IActionResult Search(string search)
        {
            var searchResult = _peopleService.Search(search);
            return View(searchResult);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            EditPersonViewModel viewModel = new EditPersonViewModel();
            
            Person editPerson = _peopleService.FindById(id);
            List<string> cityList = new List<string>();
            foreach (City city in _cityService.All())
            {
                viewModel.CityList.Add(city.CityName);
            }
            viewModel.Age = editPerson.Age;
            viewModel.FirstName = editPerson.FirstName;
            viewModel.LastName = editPerson.LastName;
            viewModel.PhoneNumber = editPerson.PhoneNumber;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, EditPersonViewModel editPerson)
        {
            if (ModelState.IsValid)
            {
                Person editedPerson = _peopleService.FindById(id);
                editedPerson.FirstName = editPerson.FirstName;
                editedPerson.LastName = editPerson.LastName;
                editedPerson.PhoneNumber = editPerson.PhoneNumber;
                editedPerson.Age = editPerson.Age;
                editedPerson.Location = _cityService.All().FirstOrDefault(c => c.CityName == editPerson.CityName);
                _context.SaveChanges();
                return RedirectToAction("PeopleIndexAJAX", "Ajax");
            }
            else
                return View(editPerson);
        }
    }
}
