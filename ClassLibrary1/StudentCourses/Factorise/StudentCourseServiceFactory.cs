using StudentEvaluation1.Persistanse.EF;
using StudentEvaluation1.Persistanse.EF.Courses;
using StudentEvaluation1.Persistanse.EF.StudentCourses;
using StudentEvaluation1.Persistanse.EF.Students;
using StudentEvaluation1.Services.StudentCourses;
using StudentEvaluation1.Services.StudentCourses.Contracts;

namespace Studentevaluation1.TestTools.StudentCourses.Factorise
{
    public static class StudentCourseServiceFactory
    {
        public static StudentCourseService Create(EFDataContext context)
        {
            return
                new StudentCourseAppService(
                    new EFStudentCourseRepository(context),
                    new EFStudentRepository(context),
                    new EFCourseRepository(context),
                    new EFUnitOfWork(context));
        }
    }
}
