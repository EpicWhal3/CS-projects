using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models;
using Npgsql;
using System.Runtime.CompilerServices;

namespace Infrastructure.Repositories;

public class OperationRepo : IOperationRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationRepo(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<Operation> GetAllOperations(long accountId)
    {
        const string sql =
            """
            SELECT StartMoney, MoneyDiff, OperationID, Date
            FROM operations
            WHERE AccountId = :accountId
            ORDER BY Date DESC;
            """;

        ConfiguredTaskAwaitable<NpgsqlConnection> connectionAwaiter = _connectionProvider
            .GetConnectionAsync(CancellationToken.None)
            .AsTask()
            .ConfigureAwait(false);

        NpgsqlConnection connection = connectionAwaiter.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("@accountId", accountId);

        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new Operation(
                reader.GetDouble(0),
                reader.GetDouble(1),
                reader.GetInt32(2),
                reader.GetDateTime(3));
        }
    }
}