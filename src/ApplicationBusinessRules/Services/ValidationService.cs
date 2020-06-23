using FluentValidation.Results;
using EnterpriseBusinessRules.Entities;
using ApplicationBusinessRules.Interfaces;
using ApplicationBusinessRules.UseCases;

namespace ApplicationBusinessRules.Services
{
    public class ValidationService : IValidationService
    {
        private ValidatePasswordUseCase _validatePasswordUseCase;

        public ValidationService()
        {
            this._validatePasswordUseCase = new ValidatePasswordUseCase();
        }
        
        public ResponseEntity ValidatePassword(PasswordEntity password) 
        {
            return this
                ._validatePasswordUseCase
                .ValidatePassword(password);
        }
    }
}