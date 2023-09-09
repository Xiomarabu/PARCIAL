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
            var db= dbconnection();
            var consulta = @"select * from empleados";
            return db.QueryAsync<empleado>(consulta);
        }

        public Task<empleado> getempleadoById(int id)
        {
            var db = dbconnection();
            var consulta = @"select * from empleados where idempleados=@Id";
            return db.QueryFirstOrDefaultAsync<empleado>(consulta, new { Id = id });

        }

        public async Task<bool> updateempleado(empleado empleado)
        {
            var db = dbconnection();
            var sql = @"update empleados set 
                      Nombre=@Nombre,
                      documento=@documento,
                      numerodeventas=@numerodeventas where (idempleados=@idempleado)";
            var result = await db.ExecuteAsync(sql, new { empleado.Nombre, empleado.documento, empleado.numerodeventas, empleado.idEmpleado });
            return result > 0;
        }
        public async Task<bool> deleteempleado(int id)
        {
            var db= dbconnection();
            var sql = @"delete from empleados where idEmpleados=@Id";
            var result = await db.ExecuteAsync(sql, new { id });
            return result > 0;
        }

        protected MySqlConnection dbconnection()
        {
            return new MySqlConnection(_connection._connectionString);
        }


    }
    
    }

