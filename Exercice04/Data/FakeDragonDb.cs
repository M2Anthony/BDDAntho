using Exercice04.Models;

namespace Exercice04.Data
{
    public class FakeDragonDb
    {
        private List<Dragon> _listeDragons;
        private int _dernierId = 0;

        public FakeDragonDb()
        {
            _listeDragons = new List<Dragon>()
            {
                new Dragon {Id = ++_dernierId, Nom = "Drogon", Age = 6, Description = "Le favori des dragons"},

                new Dragon {Id = ++_dernierId, Nom = "Viserion", Age = 6, Description = "Le dragon qui porte le nom de son frère"},

                new Dragon {Id = ++_dernierId, Nom = "Rhaegal", Age = 6, Description = "Le dragon qui porte le nom de son père (enfin je crois...)"},
            };
        }

        public string RandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        // CRUD

        // Create

        public bool Ajouter(Dragon dragon)
        {
            dragon.Id = ++_dernierId;
            _listeDragons.Add(dragon);
            return true;
        }

        // Read

        public List<Dragon> ObtenirTous()
        {
            return _listeDragons;
        }

        public Dragon? ObtenirViaId(int id)
        {
            return _listeDragons.FirstOrDefault(d => d.Id == id);            
        }

        // Update

        public bool Modifier(Dragon dragon)
        {
            var dragonEnDb = ObtenirViaId(dragon.Id);

            if (dragonEnDb == null)
            {
                return false;
            }

            dragonEnDb.Nom = dragon.Nom;
            dragonEnDb.Age = dragon.Age;
            dragonEnDb.Description = dragon.Description;

            return true;

        }

        // Delete

        public bool Supprimer(int id)
        {
            var dragonASupprimer = ObtenirViaId(id);

            if (dragonASupprimer == null)
            {
                return false;
            }
            
            _listeDragons.Remove(dragonASupprimer);
            return true;
        }




    }
}

