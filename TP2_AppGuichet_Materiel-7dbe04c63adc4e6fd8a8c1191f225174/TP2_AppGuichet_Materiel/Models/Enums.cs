using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum SorteTransactions { Dépôt, Retrait }
    public enum Roles {Administrateur, Client }
    public enum SorteComptes {aucun,Épargne,chèque,Interet }
    public enum filtreOperation { Toutes ,Dépot, Retrait}
}
