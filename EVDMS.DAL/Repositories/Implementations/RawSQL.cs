using System;
using Dapper;
using EVDMS.DAL.Database;
using EVDMS.DAL.Repositories.Abstractions;
using EVDMS.DAL.Response;
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

    public async Task<List<RevenueDataDTOs>> ExecRawSQLAsync(string sql)
    {
        using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();

        var result = await connection.QueryAsync<RevenueDataDTOs>(sql);
        return result.ToList();
    }
}
