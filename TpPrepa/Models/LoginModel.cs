using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace TpPrepa.Models
{
	public class LoginModel
	{
        [Required(ErrorMessage = "login obligatoire")]
        public string Login { get; set; }
        [Required(ErrorMessage = "password obligatoire")]
        [MinLength(6, ErrorMessage = "mot de passe doit etre au minimum 6 caractere")]
        [MaxLength(10, ErrorMessage = "mot de passe doit etre au maximum 10 caractere")]
        [DisplayName("Mot De Passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public UserModel LoginUser()
        {

            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=User;User Id=sa;Password=ilyhmfe@123;TrustServerCertificate=True;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [user] WHERE login = @login", conn);
            cmd.Parameters.AddWithValue("@login", Login);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new UserModel
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Nom = reader["nom"].ToString(),
                    Prenom = reader["prenom"].ToString(),
                    Login = reader["login"].ToString(),
                    Password = reader["password"].ToString(),
                    Tentative = Convert.ToInt32(reader["tentative"]),
                    Valide = Convert.ToInt32(reader["valide"])

                };
            }
            conn.Close();
            return null;
        }


        public void incrementerFunction(UserModel user)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=User;User Id=sa;Password=ilyhmfe@123;TrustServerCertificate=True;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [user] SET tentative = @tentative WHERE id = @id AND login=@login", conn);
            cmd.Parameters.AddWithValue("@id", user.Id);
            cmd.Parameters.AddWithValue("@login", user.Login);
            cmd.Parameters.AddWithValue("@tentative", user.Tentative);
            cmd.ExecuteNonQuery();
            conn.Close();


        }
    }
}

