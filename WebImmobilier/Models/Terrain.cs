using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebImmobilier.Models
{
    public class Terrain:Bien
    {
        [Display(Name = "Type de terrain"), Required(ErrorMessage = "*"), MaxLength(300)]
        public string TypeTerrain { get; set; }
    }
}