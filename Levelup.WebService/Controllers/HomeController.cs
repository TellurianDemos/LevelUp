using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Levelup.Data.Core;
using Levelup.DAL.Abstract;
using Levelup.WebService.Models;
using Levelup.DAL.Context;
using WebGrease.Css.Extensions;

namespace Levelup.WebService.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var departments = new List<Department>
            {
                new Department() { Title = ".Net", ImagePath = "Content/Images/Departments/dotnet-logo.png"},
                new Department() { Title = "JS", ImagePath = "Content/Images/Departments/js-logo.png"},
                new Department() { Title = "Java", ImagePath = "Content/Images/Departments/java-logo.png"}
            };
            departments.ForEach(d => _unitOfWork.Departments.AddAsync(d));

            var categories = new List<Category>
            {
                new Category() {Title = "C#", ImagePath = "Content/Images/Categories/csharp-logo.png"},
                new Category() {Title = "JS", ImagePath = "Content/Images/Categories/javaScript-logo.png"},
                new Category() {Title = "Asp-Net", ImagePath = "Content/Images/Categories/asp-net-logo.png"},
                new Category() {Title = "Java ", ImagePath = "Content/Images/Categories/java_logo.png"},
                new Category() {Title = "DB", ImagePath = "Content/Images/Categories/db-logo.png"}
            };
            categories.ForEach(c=> _unitOfWork.Categories.AddAsync(c));

            var complexityLevel = new List<ComplexityLevel>
            {
                new ComplexityLevel() { Title = "Easy"},
                new ComplexityLevel() { Title = "Medium"},
                new ComplexityLevel() { Title = "Hard"}
            };
            complexityLevel.ForEach(c => _unitOfWork.ComplexityLevels.AddAsync(c));

            var skillLevels = new List<SkillLevel>
            {
                new SkillLevel() { Title = "Junior"},
                new SkillLevel() { Title = "Middle"},
                new SkillLevel() { Title = "Senior"}
            };
            skillLevels.ForEach(s => _unitOfWork.SkillLevels.AddAsync(s));

            var tests = new List<Test>
            {
                new Test() { AmountQuestions = 2, Department = departments[0], ImagePath = "null", SkillLevel = skillLevels[0]}
            };
            tests.ForEach(t =>_unitOfWork.Tests.AddAsync(t));


            var categoriesInTests = new List< CategoriesInTest>
            {
                new CategoriesInTest() { Category = categories[0], ComplexityLevel = complexityLevel[0], PassingScore = 0, Persentage = 50, Test = tests[0]},
                new CategoriesInTest () { Category = categories[3], ComplexityLevel = complexityLevel[0], PassingScore = 0, Persentage = 50, Test = tests[0]}
            };
            categoriesInTests.ForEach(c =>_unitOfWork.CategoriesInTest.AddAsync(c));

            //_unitOfWork.SaveAsync();

            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
