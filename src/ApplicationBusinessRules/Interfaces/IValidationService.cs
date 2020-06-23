using FluentValidation.Results;
using EnterpriseBusinessRules.Entities;

namespace ApplicationBusinessRules.Interfaces
{
    public interface IValidationService
    {
        public ResponseEntity ValidatePassword(PasswordEntity password);
    }
}
