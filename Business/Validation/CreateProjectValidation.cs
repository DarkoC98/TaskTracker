using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTO;
using DataAccess;
using FluentValidation;

namespace Business.Validation
{
    public class CreateProjectValidation : AbstractValidator<ProjectDto>
    {
        private readonly TaskTrackerContext _context;

        public CreateProjectValidation(TaskTrackerContext context)
        {
            this._context = context;

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty.");

            RuleFor(p => p.StartDate)
                .NotEmpty()
                .WithMessage("Start date cannot be empty");

            When(p => p.EndDate != null, () => RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate)
                .WithMessage(p => $"Starting date must be before ({p.EndDate}) end date."));

            RuleFor(p => p.Priority)
                .NotEmpty()
                .WithMessage("Priority is required.");

            RuleFor(p => p.Status)
                .IsInEnum();
        }
    }
}
