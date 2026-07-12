using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace IDP.Application.Command.Auth
{
    public record AuthCommand : IRequest<bool>
    {
        public required string MobileNumber { get; set; }
    }

}
