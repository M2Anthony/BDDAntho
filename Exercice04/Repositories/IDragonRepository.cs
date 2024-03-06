using Exercice04.Models;
using System.Linq.Expressions;

namespace Exercice04.Repositories
{
    public interface IDragonRepository
    {

            // Create

        bool Ajouter(Dragon dragonAAjouter);

            // Read

        Dragon Obtenir(Expression<Func<Dragon, bool>> predicate);

        Dragon? ObtenirViaId(int id);

        List<Dragon> ObtenirTous();

        List<Dragon> ObtenirTous(Expression<Func<Dragon, bool>> predicate);

            // Update

        bool Modifier(Dragon dragonModifie);

            // Delete

        bool Supprimer(int id);


    }
}
