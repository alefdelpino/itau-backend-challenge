using FluentValidation;
using EnterpriseBusinessRules.Entities;

namespace EnterpriseBusinessRules.Validators
{
    public class PasswordValidator : AbstractValidator<PasswordEntity>
    {
        public PasswordValidator()
        {
            RuleFor(c => c.Password).Password();  
        }
    }
}