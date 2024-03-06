using Exercice04.Data;
using Exercice04.Models;
using Exercice04.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exercice04.Controllers
{
    public class DragonController : Controller
    {
        private readonly IRepository<Dragon> _dragonRepository;

        public DragonController(IRepository<Dragon> dragonRepository)
        {
            _dragonRepository = dragonRepository;
        }

        public IActionResult AccueilDragon()
        {
            return View(_dragonRepository.ObtenirTous());
        }       


        public IActionResult AjouterDragonAleatoire()
        {
            Random aleatoire = new Random();
            int nombreAleatoire = aleatoire.Next(3, 11);

            string nomAleatoire = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", nombreAleatoire);

            Dragon dragonAAjouter = new Dragon() {Nom = nomAleatoire, Age = nombreAleatoire, Description = "Nouveau dragon"};

            _dragonRepository.Ajouter(dragonAAjouter);

            return RedirectToAction("AccueilDragon");
        }

        public IActionResult FormulaireAjouterDragon()
        {
            return View();
        }

        public IActionResult AjouterDragon(Dragon dragonAAjouter)
        {
            _dragonRepository.Ajouter(dragonAAjouter);

            return RedirectToAction(nameof(AccueilDragon));
        }

        public IActionResult DetailsDragon(int id)
        {
            Dragon? dragon = _dragonRepository.ObtenirViaId(id);

            return View(dragon);
        }

        public IActionResult FormulaireModifierDragon(int id)
        {
            Dragon? dragon = _dragonRepository.ObtenirViaId(id);

            return View(dragon);
        }

        public IActionResult ModifierDragon(Dragon dragonAModifier)
        {
            _dragonRepository.Modifier(dragonAModifier);

            return RedirectToAction("AccueilDragon");
        }

        public IActionResult SupprimerDragon(int id)
        {
            _dragonRepository.Supprimer(id);

            return RedirectToAction("AccueilDragon");
        }

        [NonAction] // ce n'est plus une action => un méthode classique sans route 
        public static string RandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
