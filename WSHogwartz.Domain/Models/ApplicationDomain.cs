using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSHogwartz.Domain.Models
{
    public class ApplicationDomain
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificacion { get; set; }
        public string Edad { get; set; }
        public string Casa { get; set; }

    }
}
