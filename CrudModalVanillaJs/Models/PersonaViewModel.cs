using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudModalVanillaJs.Models
{
    public class PersonaViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Campo requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
       
        public int Edad { get; set; }
    }
}