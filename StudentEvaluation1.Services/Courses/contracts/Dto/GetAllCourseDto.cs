namespace StudentEvaluation1.Services.Courses.contracts.Dto
{
    public record GetAllCourseDto(
        int Id,
        string Name,
        int TeacherId,
        string TeacherFullName);
}
