using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

public class EntidadColeccion
{

    public int Coleccion_id { get; set; }
    public int Museo_id { get; set; }

    [Display(Name = "Coleccion_nombre")]
    [Required(ErrorMessage = "Debe digitar el nombre")]
    public string Coleccion_nombre { get; set; }

    [Display(Name = "Coleccion_siglo")]
    [Required(ErrorMessage = "Debe digitar la instalacion del coleccion")]
    public string Coleccion_siglo { get; set; }

    [Display(Name = "Coleccion_observaciones")]
    [Required(ErrorMessage = "Debe digitar la instalacion del coleccion")]
    public string Coleccion_observaciones { get; set; }

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "Debe digitar el estado del coleccion")]
    public string Coleccion_estado { get; set; }

}
