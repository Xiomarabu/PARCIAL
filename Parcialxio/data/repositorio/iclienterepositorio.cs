using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public interface iclienterepositorio
    {

        Task<IEnumerable<cliente>> getClientes();
        Task<cliente> getClienteById(int id);
        Task<bool> insertCliente(cliente cliente);
        Task<bool> updateCliente(cliente cliente);
        Task<bool> deleteCliente(int id);
    }
}
