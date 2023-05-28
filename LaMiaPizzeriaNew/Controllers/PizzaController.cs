using LaMiaPizzeriaNew.Database;
using LaMiaPizzeriaNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeriaNew.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<GustiPizza> gustiPizza = db.GustiPizza.ToList(); 
                return View(gustiPizza);
            }

                
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                GustiPizza? pizzaDetails = db.GustiPizza.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaDetails != null)
                {
                    return View(pizzaDetails);
                }
                else
                {
                    return NotFound($"La pizza con id {id} non è stato trovato");
                }
            }
        }







        //CREATE
        [HttpGet]
        public IActionResult AddPizza()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AggiungiPizza(GustiPizza newPizza)
        {
            if (!ModelState.IsValid)
            {
                return View(newPizza);
            }
            else
            {
                using (PizzaContext db = new PizzaContext())
                {
                    db.GustiPizza.Add(newPizza);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
        }

        //UPDATE
        [HttpGet]
        public IActionResult UpdatePizza(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                GustiPizza? pizzaToUpdate = db.GustiPizza.Where(pizza => pizza.Id == id).FirstOrDefault();
                if (pizzaToUpdate != null)
                {
                    return View(pizzaToUpdate);
                }
                else
                {
                    return NotFound("La pizza con questo id non esiste");
                }
            }
        }
    }
}
