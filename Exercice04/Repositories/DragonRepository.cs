using Exercice04.Data;
using Exercice04.Models;
using System;
using System.Linq.Expressions;

namespace Exercice04.Repositories
{
    public class DragonRepository : IRepository<Dragon>
    {

        private ApplicationDbContext _dbcontext;

        public DragonRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public bool Ajouter(Dragon dragon)
        {
            var dragonAAjouter = _dbcontext.Dragons.Add(dragon);
            _dbcontext.SaveChanges();

            return dragonAAjouter.Entity.Id > 0;
        }

        public Dragon? ObtenirViaId(int id)
        {
            var dragonRecherche = _dbcontext.Dragons.Find(id);

            return dragonRecherche;
        }

        public Dragon? Obtenir(Expression<Func<Dragon, bool>> predicate)
        {
            return _dbcontext.Dragons.FirstOrDefault(predicate);
        }

        public List<Dragon> ObtenirTous()
        {
            return _dbcontext.Dragons.ToList();
        }

        public List<Dragon> ObtenirTous(Expression<Func<Dragon, bool>> predicate)
        {
            return _dbcontext.Dragons.Where(predicate).ToList();
        }

        public bool Modifier(Dragon dragonModifie)
        {
            var dragonDeBase = ObtenirViaId(dragonModifie.Id);

            if (dragonDeBase == null)
            {
                return false;
            }

            if (dragonDeBase.Nom != dragonModifie.Nom)
            {
                dragonDeBase.Nom = dragonModifie.Nom;
            }
            if (dragonDeBase.Age != dragonModifie.Age)
            {
                dragonDeBase.Age = dragonModifie.Age;
            }
            if (dragonDeBase.Description != dragonModifie.Description)
            {
                dragonDeBase.Description = dragonModifie.Description;
            }

            return _dbcontext.SaveChanges() > 0;
        }

        public bool Supprimer(int id)
        {
            var dragonASupprimer = ObtenirViaId(id);

            if (dragonASupprimer == null)
            {
                return false;
            }

            _dbcontext.Remove(dragonASupprimer);
            return _dbcontext.SaveChanges() > 0;
        }
    }
}
