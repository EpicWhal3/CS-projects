using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Models;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models;
using Npgsql;
using System.Runtime.CompilerServices;

namespace Infrastructure.Repositories;

public class UserRepo : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepo(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public void AddUser(string name, string pinCode)
    {
        const string sql =
            """INSERT INTO users (Username, pincode) VALUES (:name, :pinCode)""";

        ConfiguredTaskAwaitable<NpgsqlConnection> connectionAwaiter = _connectionProvider
            .GetConnectionAsync(CancellationToken.None)
            .AsTask()
            .ConfigureAwait(false);
        NpgsqlConnection connection = connectionAwaiter.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("name", name)
            .AddParameter("pinCode", pinCode);
        command.ExecuteNonQuery();
    }

    public User? GetUser(string name, string pinCode)
    {
        const string sql =
            """
            SELECT AccountId, Username, PinCode, MoneyAmount
            FROM users
            WHERE Username = :username AND PinCode = :pinCode;
            """;

        ConfiguredTaskAwaitable<NpgsqlConnection> connectionAwaiter = _connectionProvider
            .GetConnectionAsync(CancellationToken.None)
            .AsTask()
            .ConfigureAwait(false);
        NpgsqlConnection connection = connectionAwaiter.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("username", name);
        command.AddParameter("pinCode", pinCode);

        using NpgsqlDataReader reader = command.ExecuteReader();

        return !reader.Read()
            ? null
            : new User(
                reader.GetInt64(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetDouble(3));
    }

    public DataBaseOperationResults MoneyExchange(User user, double amount)
    {
        const string sql =
            """
            SELECT MoneyAmount
            FROM users
            WHERE accountid = :accountId AND pincode = :pinCode;
            """;

        ConfiguredTaskAwaitable<NpgsqlConnection> connectionAwaiter = _connectionProvider
            .GetConnectionAsync(CancellationToken.None)
            .AsTask()
            .ConfigureAwait(false);
        NpgsqlConnection connection = connectionAwaiter.GetAwaiter().GetResult();

        double money;
        using (var command = new NpgsqlCommand(sql, connection))
        {
            command.AddParameter("accountId", user.Id)
                .AddParameter("pinCode", user.Pincode);

            using NpgsqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
                return new DataBaseOperationResults.Failure("Account details incorrect");

            money = reader.GetDouble(0);
        }

        if (money + amount < 0)
            return new DataBaseOperationResults.NoFunds(user with { Money = money });

        const string sql2 =
            """
            INSERT INTO operations(accountid, startmoney, moneydiff, date)
            VALUES (:accountId, :startMoney, :moneyDiff, NOW());
            """;

        using (var command2 = new NpgsqlCommand(sql2, connection))
        {
            command2.AddParameter("accountId", user.Id)
                .AddParameter("startMoney", money)
                .AddParameter("moneyDiff", amount);

            command2.ExecuteNonQuery();
        }

        const string sql3 =
            """
            UPDATE users
            SET moneyamount = :money
            WHERE accountid = :accountId;
            """;

        using (var command3 = new NpgsqlCommand(sql3, connection))
        {
            command3.AddParameter("money", money + amount)
                .AddParameter("accountId", user.Id);

            command3.ExecuteNonQuery();
        }

        return new DataBaseOperationResults.Success(user with { Money = money + amount });
    }
}