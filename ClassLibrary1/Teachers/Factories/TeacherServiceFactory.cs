using StudentEvaluation1.Persistanse.EF;
using StudentEvaluation1.Persistanse.EF.Teachers;
using StudentEvaluation1.Services.Teachers;
using StudentEvaluation1.Services.Teachers.Contracts;

namespace Studentevaluation1.TestTools.Teachers.Factories
{
    public static class TeacherServiceFactory
    {
        public static TeacherService Create(EFDataContext context)
        {
            return 
                    new TeacherAppService(
                new EFTeacherRepository(context),
                new EFUnitOfWork(context));
                
        }
    }
}
