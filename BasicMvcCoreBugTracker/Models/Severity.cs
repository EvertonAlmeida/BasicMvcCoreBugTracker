using AppMvcBasica.Models;
using System.ComponentModel.DataAnnotations;

namespace BasicMvcCoreBugTracker.Models
{
    public class Severity : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }
    }
}
