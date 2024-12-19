
using StudentEvaluation1.Persistanse.EF;
using Xunit;

namespace Studentevaluation1.TestTools.Infrastructure.DataBaseConfig.Integration.Fixtures;

[Collection(nameof(ConfigurationFixture))]
public class EFDataContextDatabaseFixture : DatabaseFixture
{
    public static EFDataContext CreateDataContext(string tenantId)
    {
        var connectionString =
            new ConfigurationFixture().Value.ConnectionString;


        return new EFDataContext(
            $"Server=(localdb)\\MSSQLLocalDB;Database=SchoolTest;Trusted_Connection=True;");
    }
}