using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace TpPrepa.Models
{
	public class UserModel
	{
		public int Id { get; set; }
        [Required(ErrorMessage = "nom obligatoire")]
		public string Nom { get; set; }
        [Required(ErrorMessage = "prenom obligatoire")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "login obligatoire")]
        public string Login { get; set; }
        [Required(ErrorMessage = "password obligatoire")]
        [MinLength(6 , ErrorMessage = "mot de passe doit etre au minimum 6 caractere")]
        [MaxLength(10 , ErrorMessage = "mot de passe doit etre au maximum 10 caractere")]
        [DisplayName("Mot De Passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int Valide { get; set; }
        public int Tentative { get; set; }

        public void AjouterUser()
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=User;User Id=sa;Password=ilyhmfe@123;TrustServerCertificate=True;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [user] (nom , prenom , login , password) VALUES(@nom , @prenom , @login , @password)", conn);
            cmd.Parameters.AddWithValue("@nom", Nom);
            cmd.Parameters.AddWithValue("@prenom", Prenom);
            cmd.Parameters.AddWithValue("@login", Login);
            cmd.Parameters.AddWithValue("@password", Password);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

