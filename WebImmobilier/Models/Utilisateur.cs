using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebImmobilier.Models
{
    public class Utilisateur
    {
        [Key]
        public int IdUtilisateur { get; set; }

        [Display(Name = "Nom utilisateur"), Required(ErrorMessage = "*"), MaxLength(100)]
        public string NomUtilisateur { get; set; }

        [Display(Name = "Prenom utilisateur"), Required(ErrorMessage = "*"), MaxLength(100)]
        public string PrenomUtilisateur { get; set; }

        [Display(Name = "Login utilisateur"), Required(ErrorMessage = "*"), MaxLength(100)]
        public string LoginUtilisateur { get; set; }

    }
}