using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AxosNet.Models
{
    public class Recibos_Bd
    {
        [Key]
        public int ID_Proveedor { get; set; }
        public string Proveedor_Nombre { get; set; }
        public string Monto { get; set; }
        public string Fecha { get; set; }
        public string Comentarios { get; set; }
    }
}
