using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

public class EntidadEntrada
{
    public int Entrada_id { get; set; }
    public int Museo_id { get; set; }
    public int Precio_id { get; set; }
    public int Tarjeta_id { get; set; }

    [Display(Name = "Entrada_nombreVisitante")]
    [Required(ErrorMessage = "Debe digitar el nombre")]
    public string Entrada_nombreVisitante { get; set; }

    [Display(Name = "Entrada_fecha")]
    [Required(ErrorMessage = "Debe digitar la fecha del museo")]
    [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Entrada_fecha { get; set; }

    [Display(Name = "Entrada_cantidad")]
    [Required(ErrorMessage = "Debe digitar el cantidad")]
    public string Entrada_cantidad { get; set; }

    [Display(Name = "Entrada_subtotal")]
    [Required(ErrorMessage = "Debe digitar el subtotal")]
    public string Entrada_subtotal { get; set; }

    [Display(Name = "Entrada_comision")]
    [Required(ErrorMessage = "Debe digitar el comision")]
    public string Entrada_comision { get; set; }

    [Display(Name = "Entrada_total")]
    [Required(ErrorMessage = "Debe digitar el total")]
    public string Entrada_total { get; set; }

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "Debe digitar el estado del entrada")]
    public string Entrada_estado { get; set; }
}
