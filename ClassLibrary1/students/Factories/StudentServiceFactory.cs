using StudentEvaluation1.Persistanse.EF;
using StudentEvaluation1.Persistanse.EF.Students;
using StudentEvaluation1.Services.Students;
using StudentEvaluation1.Services.Students.Contracts;

namespace Studentevaluation1.TestTools.students.Factories
{
    public static class StudentServiceFactory
    {
        public static StudentService Create(EFDataContext context)
        {
            return
                new StudentAppService(
                    new EFStudentRepository(context),
                    new EFUnitOfWork(context));
        }
    }
}
