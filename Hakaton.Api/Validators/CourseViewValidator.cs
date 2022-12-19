using FluentValidation;
using HakatonApi.Models.CourseDtos;

namespace HakatonApi.Validators;

public class CourseViewValidator : AbstractValidator<CourseView>
{
    public CourseViewValidator()
    {
        RuleFor(c => c.CourseName).NotEmpty();
        RuleFor(c => c.Tasklist).NotEmpty();
    }
    
}