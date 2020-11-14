using Gighub.Controllers;
using Gighub.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gighub.Models.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public string Heading { get; set; }

        public string Action
        { 
            get
            {
                Expression<Func<GigsController, IActionResult>> update = 
                    (c => c.Update(this));
                Expression<Func<GigsController, IActionResult>> create = 
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;

                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}
