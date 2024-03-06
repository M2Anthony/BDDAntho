using System.Linq.Expressions;

namespace Exercice04.Repositories
{
    public interface IRepository<EntiteGenerique>
    {
        bool Ajouter(EntiteGenerique dragon);

        EntiteGenerique? Obtenir(Expression<Func<EntiteGenerique, bool>> predicate);

        List<EntiteGenerique> ObtenirTous();

        List<EntiteGenerique> ObtenirTous(Expression<Func<EntiteGenerique, bool>> predicate);

        EntiteGenerique? ObtenirViaId(int id);

        bool Modifier(EntiteGenerique dragon);

        bool Supprimer(int id);
    }
}
