using FluentValidation.Results;
using EnterpriseBusinessRules.Validators;
using EnterpriseBusinessRules.Interfaces;

namespace EnterpriseBusinessRules.Entities
{
    public class PasswordEntity: IEntity
    {
        public string Password  { get; set; }


        public static PasswordEntity Create(string password)
        {
            return new PasswordEntity {
                Password = password
            };
        }
        
        public ValidationResult Validate() 
        {
            PasswordValidator validator = new PasswordValidator();
            return validator.Validate(this);
        }
    }
}