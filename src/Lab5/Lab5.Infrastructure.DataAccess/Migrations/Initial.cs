using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Infrastructure.Migrations;

[Migration(2)]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider)
    {
        return """
               CREATE TABLE users
               (
                   AccountId BIGSERIAL PRIMARY KEY,
                   Username VARCHAR(50) UNIQUE NOT NULL,
                   PinCode CHAR(4) NOT NULL ,
                   MoneyAmount FLOAT NOT NULL DEFAULT 0.0 CONSTRAINT moneyPositive CHECK ( MoneyAmount >= 0 )
               );

               CREATE TABLE operations
               (
                   OperationID BIGINT PRIMARY KEY GENERATED ALWAYS AS IDENTITY ,
                   AccountId INT REFERENCES users(AccountId) ,
                   StartMoney FLOAT CONSTRAINT startMoneyPositive CHECK ( StartMoney >= 0 ) ,
                   MoneyDiff FLOAT CONSTRAINT operationResultPositive CHECK ( StartMoney + operations.MoneyDiff >= 0 ),
                   Date TIMESTAMP NOT NULL
               );
               """;
    }

    protected override string GetDownSql(IServiceProvider serviceProvider)
    {
        return """
                   DROP TABLE users CASCADE;
                   DROP TABLE operations CASCADE;
               """;
    }
}