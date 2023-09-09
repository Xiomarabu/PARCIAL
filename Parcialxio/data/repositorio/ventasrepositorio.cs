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
    public class ventasrepositorio : iventasrepositorio
    {
        public readonly mysqlConfig _connection;
        public ventasrepositorio(mysqlConfig connection)
        {
            _connection = connection;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }
        public async Task <bool> insertventas(ventas ventas)
        {
            var db = dbConnection();
            var sql = @"insert into ventas (idventas, clientes_idclientes, Empleados_idEmpleados, tipodeproducto_idtipodeproducto) values (@idventas, @clientes_idclientes, @Empleados_idEmpleados, @tipodeproducto_idtipodeproducto)";
            var result = await db.ExecuteAsync(sql, new {ventas.idventas, ventas.clientes_idclientes, ventas.Empleados_idEmpleados, ventas.tipodeproducto_idtipodeproducto});
            return result < 0;

        }
    }
}
