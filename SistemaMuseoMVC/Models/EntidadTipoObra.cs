using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



    public class EntidadTipoObra
    {

    public int TipoObra_id { get; set; }

    [Display(Name = "TipoObra_tipoObra")]
    [Required(ErrorMessage = "Debe digitar el TipoObra")]
    public string TipoObra_tipoObra { get; set; }

    [Display(Name = "TipoObra_descripcion")]
    [Required(ErrorMessage = "Debe digitar la descripcion del TipoObra")]
    public string TipoObra_descripcion { get; set; }

    [Display(Name = "Estado")]
    [Required(ErrorMessage = "Debe digitar el estado del TipoObra")]
    public string TipoObra_estado { get; set; }

}
