namespace PetStore.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PetStore.Services.Interfaces;
    using Models.Pet;
    public class PetsController : Controller
    {
        // /Pets/All
        private IPetService pets;

        public PetsController(IPetService pets) => this.pets = pets;
        public IActionResult All(int page = 1)
        {
            var allPets = this.pets.All(page);
            var totalpets = this.pets.Total();

            var model = new AllPetsViewModel
            {
                Pets = allPets,
                Total = totalpets,
                CurrentPage = page
            };

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var pet = this.pets.Details(id);

            if (pet == null)
            {
                return this.NotFound();
            }

            return View(pet);
        }
        public IActionResult ConfirmDelete(int id)
        {
            var deleted = this.pets.Delete(id);

            if (deleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}