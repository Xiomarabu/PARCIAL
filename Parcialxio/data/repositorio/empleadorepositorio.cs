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
    public class empleadorepositorio: iempleadorepositorio
    {
        public readonly mysqlConfig _connection;
        public empleadorepositorio(mysqlConfig connection)
        {
            _connection = connection;
        }

        public async Task<bool> insertempleado(empleado empleado)
        {
            var db = dbconnection();
            var sql = @"insert into empleados(Nombre, documento, numerodeventas) values(@Nombre, @documento, @numerodeventas)";
            var result=await db.ExecuteAsync(sql, new {empleado.Nombre, empleado.documento, empleado.numerodeventas});
            return result > 0;
        }
       
        public Task<IEnumerable<empleado>> getempleado()
        {
            throw new NotImplementedException();
        }

        public Task<empleado> getempleadoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> updateempleado(empleado empleado)
        {
            throw new NotImplementedException();
        }
        public Task<bool> deleteempleado(int id)
        {
            throw new NotImplementedException();
        }

        protected MySqlConnection dbconnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }


    }
    
    }

