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

        

        public Task<cliente> getClienteById(int id)
        {
           var db=dbconnection();
           var consulta = @"select * from clientes where idclientes=@Id";
            return db.QueryFirstOrDefaultAsync<cliente>(consulta, new {Id = id});
            

        }

        public Task<IEnumerable<cliente>> getClientes()
        {
            var db= dbconnection();
            var consulta = @"select * from clientes";
            return db.QueryAsync<cliente>(consulta);
        }

        public async Task<bool> insertCliente(cliente cliente)
        {
            var db = dbconnection();
            var sql = @"insert into clientes(documento, nombre, edad) values(@documento, @nombre, @edad)";
            var result =await db.ExecuteAsync(sql, new { cliente.documento, cliente.nombre, cliente.edad });
            return result > 0;
        }

        public async Task<bool> updateCliente(cliente cliente)
        {
           var db = dbconnection();
            var sql = @"update clientes set 
            documento=@documento,
            nombre=@nombre,
            edad=edad
            where (idclientes=@idclientes)";
            var result = await db.ExecuteAsync(sql, new { cliente.documento, cliente.nombre, cliente.edad, cliente.idclientes });
            return result > 0;

        }

        public async Task<bool>deleteCliente(int id)
        {
            var db = dbconnection();
            var sql = @"delete from clientes where idclientes=@Id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

      
    }
}
