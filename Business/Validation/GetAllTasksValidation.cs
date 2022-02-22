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
    public class GetAllTasksValidation : AbstractValidator<TaskFilterDto>
    {
        private readonly TaskTrackerContext _context;

        public GetAllTasksValidation(TaskTrackerContext context)
        {
            this._context = context;

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("Description cannot be empty.");

            RuleFor(p => p.Priority)
                .NotEmpty()
                .WithMessage("Priority cannot be empty.");

            RuleFor(p => p.Status)
                .NotEmpty()
                .WithMessage("Status cannot be empty")
                .IsInEnum();


        }
    }
}
