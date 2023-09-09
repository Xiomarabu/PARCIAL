using Dapper;
using model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositorio
{
    public class clienterepositorio : iclienterepositorio
    {
        public readonly mysqlConfig _connection;
        public clienterepositorio(mysqlConfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbconnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }

        public Task<bool> deleteCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<cliente> getClienteById(int id)
        {
           var db=dbconnection();
           var consulta = @"select * from clientes where idclientes=@Id";
            return db.QueryFirstOrDefaultAsync<cliente>(consulta, new {Id = id});
            

        }

        public Task<IEnumerable<cliente>> getClientes()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> insertCliente(cliente cliente)
        {
            var db = dbconnection();
            var sql = @"insert into clientes(documento, nombre, edad) values(@documento, @nombre, @edad)";
            var result =await db.ExecuteAsync(sql, new { cliente.documento, cliente.nombre, cliente.edad });
            return result > 0;
        }

        public Task<bool> updateCliente(cliente cliente)
        {
            throw new NotImplementedException();
        }

      
    }
}
