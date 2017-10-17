using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        //defalut constructor
        public AddCheeseViewModel()
        { }


        //select list constructor
        public AddCheeseViewModel(IEnumerable<CheeseCategory> categories) {

            Categories = new List<SelectListItem>();
            
            // <option value="0">Hard</option>
            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name
                });
            }


            
            /*
                Categories.Add(new SelectListItem {
                Value = ((int)Categories.Hard).ToString(),
                Text = Categories.Hard.ToString()
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)Categories.Soft).ToString(),
                Text = Categories.Soft.ToString()
            });

            Categories.Add(new SelectListItem
            {
                Value = ((int)Categories.Fake).ToString(),
                Text = Categories.Fake.ToString()
            });
            */
        }
    }
}
