using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        // This code would need to be added to each controller class that you want to have access to the 
        // persistent collections defined within CheeseDbContext.
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<CheeseCategory> categories = context.Categories.ToList();

            return View(categories);
        }

        //Add Action Method to render the form
        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        //Post Add Action to receive form info
        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            // if ViewModel is valid Redirect to homepage 
            if (ModelState.IsValid)
            {

                // create new CheeseCategory object
                CheeseCategory newCategory = new CheeseCategory
                {
                    // assign name property with name from form input box
                    Name = addCategoryViewModel.Name,
                };

                // add new object to database context
                context.Categories.Add(newCategory);
                // save changes to database
                context.SaveChanges();

                // redirect
                return Redirect("/Category/Index");
            }

            // return form again if ViewModel is invalid
            return View(addCategoryViewModel);
        }
    }
}
