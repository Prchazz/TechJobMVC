using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {

            List<Job> searchresults = new List<Job>();

            
            if (searchTerm == null)
            {
                searchresults = JobData.FindAll();
                
            }
            else
            {

                searchresults = JobData.FindByColumnAndValue(searchType, searchTerm);
                
            }
            

            ViewBag.searchresults = searchresults;

            ViewBag.columns = ListController.ColumnChoices;

            return View("~/Views/Search/Index.cshtml");

            // TODO #3: Create an action method to process a search request and render the updated search view. 

        }

    }
}
