using AppMvcBasica.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace BasicMvcCoreBugTracker.Models
{
    public class Bug : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Number { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Description { get; set; }

        public Guid StatusId { get; set; }

        public Guid SeverityId { get; set; }

        /* EF Relations */
        public Status Status { get; set; }

        public Severity Severity { get; set; }
    }
}
