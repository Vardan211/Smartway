using Dapper;
using Microsoft.Extensions.Configuration;
using Smartway.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Smartway.Repositories
{
    public class EmployeRepository:BaseRepository,IEmployeRepository
    {
        public EmployeRepository(IConfiguration configuration)
            : base(configuration)
        { }

        public async Task<int> CreateAsync(Employe entity)
        {
            try
            {
                var query = "INSERT INTO public.\"Employees\"(\"Id\",\"Name\", \"Surname\", \"Phone\", \"CompanyId\", \"Pass_Type\", \"Pass_Number\", \"Dep_Name\", \"Dep_Phone\") VALUES (@Id,@Name, @Surname, @Phone,@CompanyId,@Pass_Type,@Pass_Number,@Dep_Name,@Dep_Phone)";

                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.Id, DbType.Int32);
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("Surname", entity.Surname, DbType.String);
                parameters.Add("Phone", entity.Phone, DbType.String);
                parameters.Add("CompanyId", entity.Companyid, DbType.Int32);
                parameters.Add("Pass_Type", entity.Passport.Type, DbType.String);
                parameters.Add("Pass_Number", entity.Passport.Number, DbType.String);
                parameters.Add("Dep_Name", entity.Department.Name, DbType.String);
                parameters.Add("Dep_Phone", entity.Department.Phone, DbType.String);


                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> DeleteAsync(Employe entity)
        {
            try
            {
                var query = "DELETE FROM public.\"Employees\" WHERE \"Id\" = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.Id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Employe>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM public.\"Employees\" ";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Employe>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Employe>> GetByCompanyIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM public.\"Employees\" WHERE \"CompanyId\" = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Employe>(query, parameters)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Employe>> GetByDepartamentAsync(string name)
        {
            try
            {
                var query = "SELECT * FROM public.\"Employees\" WHERE \"Dep_Name\" = @Dep_Name";

                var parameters = new DynamicParameters();
                parameters.Add("Dep_Name", name, DbType.String);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Employe>(query,parameters)).ToList();
                }
            }            
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Employe> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM public.\"Employees\" WHERE \"Id\" = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Employe>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(Employe entity)
        {

            try
            {
                var query = "UPDATE public.\"Employees\" SET \"Name\" = @Name, \"Surname\" = @Surname, \"Phone\" = @Phone, \"CompanyId\" = @CompanyId, \"Pass_Type\" = @Pass_Type, \"Pass_Number\" = @Pass_Number, \"Dep_Name\" = @Dep_Name, \"Dep_Phone\" = @Dep_Phone WHERE \"Id\" = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.Id, DbType.Int32);
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("Surname", entity.Surname, DbType.String);
                parameters.Add("Phone", entity.Phone, DbType.String);
                parameters.Add("CompanyId", entity.Companyid, DbType.Int32);
                parameters.Add("Pass_Type", entity.Passport.Type, DbType.String);
                parameters.Add("Pass_Number", entity.Passport.Number, DbType.String);
                parameters.Add("Dep_Name", entity.Department.Name, DbType.String);
                parameters.Add("Dep_Phone", entity.Department.Phone, DbType.String);


                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
