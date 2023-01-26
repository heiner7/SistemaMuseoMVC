using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


public class EntidadObra
{

    public int Obra_id { get; set; }
    public int Artista_id { get; set; }
    public int Coleccion_id { get; set; }
    public int TipoObra_id { get; set; }

    [Display(Name = "Obra_nombre")]
    [Required(ErrorMessage = "Debe digitar el nombre")]
    public string Obra_nombre { get; set; }

    [Display(Name = "Obra_descripcion")]
    [Required(ErrorMessage = "Debe digitar la instalacion del museo")]
    public string Obra_descripcion { get; set; }

    [Display(Name = "Obra_cultura")]
    [Required(ErrorMessage = "Debe digitar la cultura del museo")]
    public string Obra_cultura { get; set; }

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "Debe digitar el estado del museo")]
    public string Obra_estado { get; set; }

}
