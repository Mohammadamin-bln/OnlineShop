using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces.TokenProvider
{
    public interface ITokenProvider
    {
        public string Create(Domain.Entities.User user);
    }
}
