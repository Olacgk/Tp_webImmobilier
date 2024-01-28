using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebImmobilier.Models
{
    public class Proprietaire:Utilisateur
    {
        [Display(Name = "Telephone proprietaire"), Required(ErrorMessage = "*")]
        public int TelephoneProprio { get; set; }

        public virtual ICollection<Bien> Propries { get; set; }
    }
}