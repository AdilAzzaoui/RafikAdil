using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TpPrepa.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TpPrepa.Controllers
{
    public class EtudiantController : Controller
    {
        // GET: /<controller>/
        public string Serialiser()
        {
            EtudiantModel etudiant = new EtudiantModel();
            etudiant.nom = "Azzaoui";
            etudiant.prenom = "Adil";
            EtudiantModel etudiant2 = new EtudiantModel();
            EtudiantModel etudiant3 = new EtudiantModel();
            List<EtudiantModel> etudiants = new List<EtudiantModel>();
            etudiants.Add(etudiant);
            etudiants.Add(etudiant2);
            etudiants.Add(etudiant3);
            string etudiantsJson = JsonSerializer.Serialize(etudiants);
            HttpContext.Session.SetString("etudiantsSession", etudiantsJson);
            return etudiantsJson;
        }
        public IActionResult Index()
        {
            string data = Serialiser();
            List<EtudiantModel> etudiantsDeserialiser = JsonSerializer.Deserialize<List<EtudiantModel>>(data);
            return View(etudiantsDeserialiser);
        }
    }
}

