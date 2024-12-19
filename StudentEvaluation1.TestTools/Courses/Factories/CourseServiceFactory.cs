using StudentEvaluation1.Persistanse.EF;
using StudentEvaluation1.Persistanse.EF.Courses;
using StudentEvaluation1.Persistanse.EF.Teachers;
using StudentEvaluation1.Services.Courses;
using StudentEvaluation1.Services.Courses.contracts;

namespace StudentEvaluation1.TestTools.Courses.Factories
{
    public static class CourseServiceFactory
    {
        public static CourseService Generate(EFDataContext context)
        {
            var unitOfWork = new EFUnitOfWork(context);
            var courseRepository = new EFCourseRepository(context);
            var teacherRepository = new EFTeacherRepository(context);

            return
                new CourseAppServic(unitOfWork, courseRepository, teacherRepository);
        }
    }
}
