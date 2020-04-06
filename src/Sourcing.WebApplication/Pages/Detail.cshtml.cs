using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sourcing.Domain;
using Sourcing.Domain.RFxCreation;

namespace Sourcing.WebApplication.Pages
{
    public class DetailModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string EntityName { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid EntityId { get; set; }
        public Model Model { get; set; }
        public void OnGet()
        {
            if (string.Equals(this.EntityName, "rfx", StringComparison.OrdinalIgnoreCase))
            {
                this.Model = new RFxModel
                {
                    Name = "AH 28-3-1",
                    BiddingStartDateInUtc = DateTime.UtcNow,
                    Id = this.EntityId
                };
            }
        }
    }
}