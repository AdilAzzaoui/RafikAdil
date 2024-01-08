using System;
namespace TpPrepa.Models
{
	public class EtudiantModel
	{
		public string nom { set; get; }
        public string prenom { set; get; }

        public EtudiantModel()
        {
            this.nom = "Yajbar";
            this.prenom = "Rafik";  
        }
    }
}

