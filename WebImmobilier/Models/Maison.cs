using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebImmobilier.Models
{
    public class Maison:Bien
    {
        [Display(Name = "Nombre de chambre "), Required(ErrorMessage = "*")]
        public int NbreChambre { get; set; }
    }
}