using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspnetVnBasics.Entities;
using AspnetVnBasics.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AspnetVnBasics.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IContactRepository _contactRepository;

        public ContactModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentException(nameof(IContactRepository));
        }

        public Contact Contact { get; set; }

        [BindProperty]
        [Required]
        public string Name { get; set; }
        [BindProperty]
        [Required]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        public string Phone { get; set; }
        [BindProperty]
        [Required]
        public string Message { get; set; }
        public async Task<IActionResult> OnPostSubscribeAsync()
        {
            Contact = await _contactRepository.Subscribe(Email, Phone, Name, Message);

            return RedirectToPage("ContactConfirm");
        }
    }
}