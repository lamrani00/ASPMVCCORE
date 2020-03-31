using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public class Client
    {
        public Client()
        {
            Commandes = new List<Commande>();
        }

        public int ClientId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public List<Commande> Commandes { get; set; }
    }
}
