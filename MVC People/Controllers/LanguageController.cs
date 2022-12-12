using Microsoft.AspNetCore.Mvc;
using MVC_People.Models.People.PeopleService;
using MVC_People.Models.ViewModels;
using MVC_People.Models.Service;
using MVC_People.Models;
using MVC_People.Models.People.ViewModels;
using MVC_People.Data;
using System.Numerics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using MVC_People.Models.People.PeopleRepo;
using MVC_People.Models.Repo;

namespace MVC_People.Controllers
{
    public class LanguageController : Controller
    {
        IPeopleService _peopleService;
        ILanguageService _languageService;
        IPeopleRepo _peopleRepo;
        ILanguageRepo _languageRepo;
        public LanguageController(ILanguageService languageService, IPeopleService peopleService
            ,IPeopleRepo peopleRepo, ILanguageRepo languageRepo)
        {
            _languageService = languageService;
            _peopleService = peopleService;
            _peopleRepo = peopleRepo;
            _languageRepo = languageRepo;
    }
        public IActionResult LanguageIndex()
        {
            
            return View(_languageRepo.Read());
        }
        public IActionResult _NewLanguagePartial()
        {
            CreateLanguageViewModel viewModel = new CreateLanguageViewModel();
            return PartialView(viewModel);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult _NewLanguagePartial(CreateLanguageViewModel language)
        {
            if (ModelState.IsValid)
            {

                try// STEP1 
                {
                    _languageService.Add(language);
                }
                catch (ArgumentException exception)
                {
                    // Add our own message
                    ModelState.AddModelError("error", exception.Message);// Key And value
                    return PartialView(language);
                }


                return RedirectToAction(nameof(LanguageIndex));
            }
            return PartialView(language);
        }
        public IActionResult Delete(int id)
        {
            var deleteLanguage = _languageService.Remove(id);

            if (deleteLanguage)
                return RedirectToAction(nameof(LanguageIndex));
            else
            {
                return null;
            }
        }
        public IActionResult _AssignLanguagePartial()
        {
            LanguagePersonViewModel viewModel = new LanguagePersonViewModel();
            foreach (Language language in _languageService.All())
            {
                viewModel.Languages.Add(language.LanguageName);
            }
            foreach (Person person in _peopleService.All())
            {
                viewModel.People.Add(person.FirstName + ' ' + person.LastName);
            }
            return PartialView(viewModel);
        }
        public IActionResult AssignLanguageToPerson(LanguagePersonViewModel languagePerson)
        {
            
            foreach(Person personP in _peopleService.All())
            {
                if(languagePerson.Name == personP.FirstName + ' '+ personP.LastName)
                {
                    personP.Languages.Add(_languageRepo.SearchLanguage(languagePerson.Language));
                }
            }
            _languageRepo.SaveChanges();
            
            return RedirectToAction(nameof(AssignedLanguages));

        }
        public IActionResult AssignedLanguages()
        {
            List<Person> personList = new List<Person>();
            foreach (Person person in _peopleService.All())
            {
                if (person.Languages.Count >= 0)
                {
                    personList.Add(person);
                }
            }
            //string returnString;
            //foreach (Person p in _peopleService.All()) {
            //    returnString = string.Join(System.Environment.NewLine, p.Languages);
            //    ViewBag.ReturnString = returnString;
            //}

            return View(personList);
            //return View(personList);
        }
        //public IActionResult AssignedLanguagesTest()
        //{
        //    List<Person> personList = new List<Person>();
        //    foreach (Person person in _peopleService.All())
        //    {
        //        if (person.PersonLanguages.Count >= 0)
        //        {
        //            personList.Add(person);
        //        }
        //    }

        //    return View(personList);
        //}
    }
}
