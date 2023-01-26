using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


    public class EntidadArtista
    {

        public int Artista_id { get; set; }

        [Display(Name = "Artista_nombre")]
        [Required(ErrorMessage = "Debe digitar el nombre")]
        public string Artista_nombre { get; set; }

        [Display(Name = "Artista_nacionalidad")]
        [Required(ErrorMessage = "Debe digitar la nacionalidad del artista")]
        public string Artista_nacionalidad { get; set; }

        [Display(Name = "Artista_biografia")]
        [Required(ErrorMessage = "Debe digitar la biografia del artista")]
        public string Artista_biografia { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Debe digitar el estado del museo")]
        public string Artista_estado { get; set; }
    }
