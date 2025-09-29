using System;
using Dapper;
using EVDMS.BLL.DTOs.Response;
using EVDMS.DAL.Database;
using EVDMS.DAL.Repositories.Abstractions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DAL.Repositories.Implementations;

public class RawSQL : IRawSQL
{
    private readonly ApplicationDbContext _context;
    private readonly string _connectionString;

    public RawSQL(ApplicationDbContext context)
    {
        _context = context;
        _connectionString = "Server=localhost,1433;Database=EVDMS.Database;User Id=sa;Password=Strong@123;TrustServerCertificate=True;";
    }

    public async Task<List<BranchRevenueDTO>> GetBranchRevenueRawSQL(string sql)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var branchDict = new Dictionary<string, BranchRevenueDTO>();

        var result = await connection.QueryAsync<BranchRevenueDTO, EmployeeRevenueDTO, BranchRevenueDTO>(
            sql,
            (branch, employee) =>
            {
                if (!branchDict.TryGetValue(branch.DealerName, out var currentBranch))
                {
                    currentBranch = branch;
                    currentBranch.Employees = new List<EmployeeRevenueDTO>();
                    branchDict.Add(currentBranch.DealerName, currentBranch);
                }

                if (employee != null)
                {
                    currentBranch.Employees.Add(employee);
                }

                return currentBranch;
            }
        );

        return branchDict.Values.ToList();
    }

    public async Task<List<EmployeeRevenueDTO>> GetEmployeeRevenueRawSQL(string sql)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        return (await connection.QueryAsync<EmployeeRevenueDTO>(sql)).ToList();
    }
}
