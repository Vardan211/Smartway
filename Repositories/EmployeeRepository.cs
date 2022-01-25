using Dapper;
using Smartway.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Smartway.DataAccess;

namespace Smartway.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Employee entity)
        {
            try
            {
                using var connection = _context.CreateConnection();

                int companyId = 0, passportId = 0, departmentId = 0;
                
                if (entity.Company != null)
                {
                    var companyParams = new DynamicParameters();
                    companyParams.Add("Name", entity.Company.Name);
                    companyId = await connection.QueryFirstAsync<int>(DbQuery.InsertCompany, companyParams);
                }

                if (entity.Passport != null)
                {
                    var passportParams = new DynamicParameters();
                    passportParams.Add("Type", entity.Passport.Type);
                    passportParams.Add("Number", entity.Passport.Number);
                    passportId = await connection.QueryFirstAsync<int>(DbQuery.InsertPassport, passportParams);
                }

                if (entity.Department != null)
                {
                    var departmentParams = new DynamicParameters();
                    departmentParams.Add("Name", entity.Department.Name);
                    departmentParams.Add("Phone", entity.Department.Phone);
                    departmentId = await connection.QueryFirstAsync<int>(DbQuery.InsertDepartment, departmentParams);
                }
                
                var parameters = new DynamicParameters();
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("Surname", entity.Surname, DbType.String);
                parameters.Add("Phone", entity.Phone, DbType.String);
                parameters.Add("CompanyId", entity.CompanyId ?? companyId, DbType.Int32);
                parameters.Add("DepartmentId", entity.DepartmentId ?? departmentId, DbType.Int32);
                parameters.Add("PassportId", entity.PassportId ?? passportId, DbType.Int32);
                
                var id = await connection.QueryFirstAsync<int>(DbQuery.InsertEmployee, parameters);
                return Convert.ToInt32(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            try
            {
                using var connection = _context.CreateConnection();

                var result = await connection.QueryAsync<Employee, Department, Passport, Company, Employee>(DbQuery.GetAll, 
                    (employee, department, passport, company) => 
                    { 
                        employee.Company = company;
                        employee.Passport = passport;
                        employee.Department = department;
                        
                        return employee;
                    });

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Employee>> GetByCompanyIdAsync(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("CompanyId", id, DbType.Int32);

                using var connection = _context.CreateConnection();
                var result = await connection.QueryAsync<Employee, Department, Passport, Company, Employee>(DbQuery.GetByCompanyId, 
                    (employee, department, passport, company) => 
                    { 
                        employee.Company = company;
                        employee.Passport = passport;
                        employee.Department = department;
                        
                        return employee;
                    }, parameters);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Employee>> GetByDepartmentAsync(string name)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("DepartmentName", name, DbType.String);

                using var connection = _context.CreateConnection();
                var result = await connection.QueryAsync<Employee, Department, Passport, Company, Employee>(DbQuery.GetByDepartmentName, 
                    (employee, department, passport, company) => 
                    { 
                        employee.Company = company;
                        employee.Passport = passport;
                        employee.Department = department;
                        
                        return employee;
                    },parameters);
                return result.ToList();
            }            
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using var connection = _context.CreateConnection();
                var result = await connection.QueryAsync<Employee, Department, Passport, Company, Employee>(DbQuery.GetById, 
                    (employee, department, passport, company) => 
                    { 
                        employee.Company = company;
                        employee.Passport = passport;
                        employee.Department = department;
                        
                        return employee;
                    },parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(Employee entity)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.Id, DbType.Int32);
                parameters.Add("Name", entity.Name, DbType.String);
                parameters.Add("Surname", entity.Surname, DbType.String);
                parameters.Add("Phone", entity.Phone, DbType.String);
                parameters.Add("DepartmentId", entity.DepartmentId, DbType.Int32);
                parameters.Add("PassportId", entity.PassportId, DbType.Int32);
                parameters.Add("CompanyId", entity.CompanyId, DbType.Int32);
                
                using var connection = _context.CreateConnection();
                
                if (entity.Company != null)
                {
                    var companyParameters = new DynamicParameters();
                    companyParameters.Add("CompanyId", entity.Company.Id, DbType.Int32);
                    companyParameters.Add("Name", entity.Company.Name, DbType.String);
                    
                    await connection.ExecuteAsync(DbQuery.UpdateCompany,companyParameters);
                }

                if (entity.Department != null)
                {
                    var departmentParameters = new DynamicParameters();
                    departmentParameters.Add("DepartmentId", entity.Department.Id, DbType.Int32);
                    departmentParameters.Add("Name", entity.Department.Name, DbType.String);
                    departmentParameters.Add("Phone", entity.Department.Phone, DbType.String);

                    await connection.ExecuteAsync(DbQuery.UpdateDepartment, departmentParameters);
                }

                if (entity.Passport != null)
                {
                    var companyParameters = new DynamicParameters();
                    companyParameters.Add("PassportId", entity.Passport.Id, DbType.Int32);
                    companyParameters.Add("Type", entity.Passport.Type, DbType.String);
                    companyParameters.Add("Number", entity.Passport.Number, DbType.String);

                    await connection.ExecuteAsync(DbQuery.UpdatePassport, companyParameters);
                }
                
                return await connection.ExecuteAsync(DbQuery.UpdateEmployee, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        
        public async Task<int> DeleteAsync(Employee entity)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id", entity.Id, DbType.Int32);
                using var connection = _context.CreateConnection();
                if (entity.PassportId!=null)
                {
                    var passportParameters = new DynamicParameters();
                    passportParameters.Add("Id", entity.PassportId, DbType.Int32);
                    await connection.ExecuteAsync(DbQuery.DeletePassport, passportParameters);
                }
                
                return await connection.ExecuteAsync(DbQuery.DeleteEmployee, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
