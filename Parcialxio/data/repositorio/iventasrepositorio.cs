using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public interface iventasrepositorio
    {
        Task<bool> insertventas(ventas ventas);
    }
}
