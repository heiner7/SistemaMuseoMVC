using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

    public class EntidadTipoMuseo
    {

        public int TipoMuseo_id { get; set; }

        [Display(Name = "TipoMuseo_tipo")]
        [Required(ErrorMessage = "Debe seleccionar el tipo")]
        public string TipoMuseo_tipo { get; set; }

        [Display(Name = "TipoMuseo_descripcion")]
        [Required(ErrorMessage = "Debe digitar la descripción del TipoMuseo")]
        public string TipoMuseo_descripcion { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Debe digitar el estado del TipoMuseo")]
        public string TipoMuseo_estado { get; set; }

    }
