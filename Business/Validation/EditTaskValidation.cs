using Business.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class EditTaskValidation : AbstractValidator<TaskDto>
    {
        private readonly TaskTrackerContext _context;

        public EditTaskValidation(TaskTrackerContext context, int id)
        {
            this._context = context;

            RuleFor(t => t.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty.");

            RuleFor(t => t.Description)
                .NotEmpty()
                .WithMessage("Description cannot be empty");

            RuleFor(t => t.Status)
                .IsInEnum().WithMessage("Invalid status value.");


            RuleFor(t => t.Priority)
                .NotEmpty()
                .WithMessage("Priority cannot be empty");

            RuleFor(t => t.ProjectId)
                .Must(p => _context.projects.Any(proj => proj.Id == p))
                .WithMessage("There is no project with that Id");
        }
    }
}
