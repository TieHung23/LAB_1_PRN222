using System;
using Dapper;
using EVDMS.DAL.Database;
using EVDMS.DAL.Repositories.Abstractions;
using EVDMS.DAL.Response;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DAL.Repositories.Abstractions;

public interface IRawSQL
{
    Task<List<RevenueDataDTOs>> ExecRawSQLAsync(string sql);
}
