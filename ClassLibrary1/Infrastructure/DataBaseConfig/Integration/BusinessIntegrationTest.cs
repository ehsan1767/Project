
using Studentevaluation1.TestTools.Infrastructure.DataBaseConfig;
using Studentevaluation1.TestTools.Infrastructure.DataBaseConfig.Integration.Fixtures;
using StudentEvaluation1.Persistanse.EF;



public class BusinessIntegrationTest : EFDataContextDatabaseFixture
{
    protected EFDataContext Context { get; init; }
    protected EFDataContext SetupContext { get; init; }
    protected EFDataContext ReadContext { get; init; }
    protected string TenantId { get; } = "Tenant_Id";
    
    protected BusinessIntegrationTest(string? tenantId = null)
    {
        if (tenantId != null)
        {
            TenantId = tenantId;
        }

        SetupContext = CreateDataContext(TenantId);
        Context = CreateDataContext(TenantId);
        ReadContext = CreateDataContext(TenantId);
    }
    protected void Save<T>(T entity)
        where T : class
    {
        Context.Manipulate(_ => _.Add(entity));
    }

    protected void Save<T>(params T[] entities) 
        where T : class
    {
        foreach (var entity in entities)
        {
            Context.Save(entity);
        }
    }
}