using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public interface iempleadorepositorio
    {
        Task<IEnumerable<empleado>> getempleado();
        Task<empleado> getempleadoById(int id);
        Task<bool> insertempleado(empleado empleado);
        Task<bool> updateempleado(empleado empleado);
        Task<bool> deleteempleado(int id);

    }
}
