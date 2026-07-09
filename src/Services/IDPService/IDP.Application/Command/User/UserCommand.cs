using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace IDP.Application.Command.User
{
    public record UserCommand : IRequest<bool>
    {
        [Required(ErrorMessage ="Name is Requiered")]
        [MinLength(4)]
        public required string FullName { get; set; }

        public required string CodeNumber { get; set; }

    }

}
