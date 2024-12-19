using StudentEvaluation1.Persistanse.EF;
using StudentEvaluation1.Persistanse.EF.Courses;
using StudentEvaluation1.Persistanse.EF.Teachers;
using StudentEvaluation1.Services.Courses;
using StudentEvaluation1.Services.Courses.contracts;

namespace StudentEvaluation1.TestTools.Courses.Factories
{
    public static class CourseServiceFactory
    {
        public static CourseService Create(EFDataContext context)
        {
            return
                  new CourseAppServic(
                      new EFUnitOfWork(context),
                      new EFCourseRepository(context),
                      new EFTeacherRepository(context));
        }
    }
}
