namespace Smartway.Repositories
{
    public static class DbQuery
    {
        public const string GetAll = "select * from \"Employees\"join \"Departments\" d on \"Employees\".\"DepartmentId\" = d.\"Id\" join \"Passports\" p on p.\"Id\" = \"Employees\".\"PassportId\" join \"Companies\" c on c.\"Id\" = \"Employees\".\"CompanyId\"";
        public const string GetById = "select * from \"Employees\" join \"Departments\" d on \"Employees\".\"DepartmentId\" = d.\"Id\" join \"Passports\" p on p.\"Id\" = \"Employees\".\"PassportId\" join \"Companies\" c on c.\"Id\" = \"Employees\".\"CompanyId\" where \"Employees\".\"Id\" = @Id";
        public const string GetByDepartmentName = "select * from \"Employees\" join \"Departments\" d on \"Employees\".\"DepartmentId\" = d.\"Id\" join \"Passports\" p on p.\"Id\" = \"Employees\".\"PassportId\" join \"Companies\" c on c.\"Id\" = \"Employees\".\"CompanyId\" where d.\"Name\" = @DepartmentName";
        public const string GetByCompanyId = "select * from \"Employees\" join \"Departments\" d on \"Employees\".\"DepartmentId\" = d.\"Id\" join \"Passports\" p on p.\"Id\" = \"Employees\".\"PassportId\" join \"Companies\" c on c.\"Id\" = \"Employees\".\"CompanyId\" where \"Employees\".\"CompanyId\" = @CompanyId";
        public const string InsertEmployee = "INSERT INTO public.\"Employees\"(\"Name\", \"Surname\", \"Phone\", \"CompanyId\", \"DepartmentId\", \"PassportId\") VALUES (@Name, @Surname, @Phone,@CompanyId,@DepartmentId,@PassportId) returning \"Id\";";
        public const string InsertCompany = "INSERT INTO public.\"Companies\"(\"Name\") VALUES (@Name) returning \"Id\";";
        public const string InsertDepartment = "INSERT INTO public.\"Departments\"(\"Name\", \"Phone\") VALUES (@Name, @Phone) returning \"Id\";";
        public const string InsertPassport = "INSERT INTO public.\"Passports\"(\"Type\", \"Number\") VALUES (@Type, @Number) returning \"Id\";";
        public const string UpdateEmployee = "update \"Employees\" set \"Name\" = coalesce(@Name,\"Name\"), \"Surname\" = coalesce(@Surname, \"Surname\"), \"Phone\" = coalesce(@Phone, \"Phone\"), \"CompanyId\" = coalesce(@CompanyId, \"CompanyId\"), \"DepartmentId\" = coalesce(@DepartmentId, \"DepartmentId\"), \"PassportId\" = coalesce(@PassportId, \"PassportId\") where \"Id\" = @Id;";
        public const string UpdateCompany = "update \"Companies\" set \"Name\" = coalesce(@Name, \"Name\") where \"Id\" = @CompanyId";
        public const string UpdatePassport = "update \"Passports\" set \"Number\" = coalesce(@Number, \"Number\"), \"Type\" = coalesce(@Type, \"Type\") where \"Id\" = @PassportId";
        public const string UpdateDepartment = "update \"Departments\" set \"Name\" = coalesce(@Name, \"Name\"), \"Phone\" = coalesce(@Phone, \"Phone\") where \"Id\" = @DepartmentId";
        public const string DeleteEmployee = "DELETE FROM public.\"Employees\" WHERE \"Id\" = @Id";
        public const string DeletePassport = "DELETE FROM public.\"Passports\" WHERE \"Id\" = @Id";
    }
}