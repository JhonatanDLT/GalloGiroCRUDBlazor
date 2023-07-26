using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrud.Shared
{
    public class PresentacionDTO
    {
        public int PresentacionId { get; set; }

        public string? NombrePresent { get; set; }

        public string? DescripcionPresent { get; set; }
    }
}
