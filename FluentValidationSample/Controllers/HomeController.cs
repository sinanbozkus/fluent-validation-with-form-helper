using FluentValidationSample.Models;
using FormHelper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Form(int? id)
        {
            if (!id.HasValue)
            {
                return View(new StudentViewModel());
            }
            else
            {
                // Edit Mode
                // You can select current record from database.
                return Content("not implemented.");
            }
        }
        
        [HttpPost, FormValidator]
        public IActionResult Save(StudentViewModel viewModel)
        {
            if (viewModel.IsNew) // insert
            {
                // sample scenario: same name checking in the database 
                if (viewModel.StudentName.ToLower() == "abc")
                {
                    return FormResult.CreateWarningResult("'Abc' is already exist in the database.");
                }

                try
                {
                    //...
                    return FormResult.CreateSuccessResult("Product saved.");

                    // Success form result with redirect
                    //return FormResult.CreateSuccessResult("Product saved.", Url.Action("List", "Home");
                }
                catch
                {
                    return FormResult.CreateErrorResult("An error occurred!");
                }

                // CreateSuccessResult Called this usage:
                //return Json(new FormResult(FormResultStatus.Success)
                //{
                //    Message = "Product saved."
                //});
            }
            else // update 
            {
                return Content("not implemented.");
            }

        }
    }
}
