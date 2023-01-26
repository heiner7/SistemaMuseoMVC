using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


public class EntidadMuseo
{
    public int Museo_id { get; set; }
    public int TipoMuseo_id { get; set; }

    [Display(Name = "Museo_nombre")]
    [Required(ErrorMessage = "Debe digitar el nombre")]
    public string Museo_nombre { get; set; }

    [Display(Name = "Museo_instalacion")]
    [Required(ErrorMessage = "Debe digitar la instalacion del museo")]
    public string Museo_instalacion { get; set; }

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "Debe digitar el estado del museo")]
    public string Museo_estado { get; set; }

    }
