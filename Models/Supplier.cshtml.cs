using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using NorthwindSQLiteEntity;
using NorthwindDataContext;

namespace NorthwindPages
{
    public class SupplierModel : PageModel
    {
        private Northwind db;

        public SupplierModel(Northwind context)
        {
            db = context;
        }

        public List<Supplier>? Suppliers { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "Suppliers";
        }

        [BindProperty]
        public Supplier? Supplier { get; set; }

        public IActionResult OnPost()
        {
            if ((Supplier is not null) && ModelState.IsValid)
            {
                db.Suppliers!.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            else
            {
                return Page();
            }
        }
    }
}
