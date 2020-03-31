using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class Commande
    {
        public int CommandeId { get; set; }
        public DateTime DateDemande { get; set; }
        public int ClientId { get; set; }
        public List<CommandeDetail> commandeDetails { get; set; }
    }
}
