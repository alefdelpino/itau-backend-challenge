using System.Collections.Generic;
using EnterpriseBusinessRules.Entities;

namespace TestCases
{
    public class ValidatePasswordTestCase
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public PasswordEntity Value { get; set; }
        public static readonly List<ValidatePasswordTestCase> TestCases = new List<ValidatePasswordTestCase> 
        {
            new ValidatePasswordTestCase {
                Type = "Error",
                Description = "Password is required",
                Value = PasswordEntity.Create("")
            },
            new ValidatePasswordTestCase {
                Type = "Error",
                Description =  "Password should be at least 9 characters",
                Value = PasswordEntity.Create("Ag0Th@9q")
            },
            new ValidatePasswordTestCase {
                Type = "Error",
                Description = "Password should be at least 1 digit character",
                Value = PasswordEntity.Create("Ag!Th@&q#F") 
            },
            new ValidatePasswordTestCase {
                Type = "Error",
                Description = "Password should be at least 1 lowercase letter",
                Value = PasswordEntity.Create("A50TZ@91#")
            },
            new ValidatePasswordTestCase {
                Type = "Error",
                Description = "Password should be at least 1 uppercase letter",
                Value = PasswordEntity.Create("g0xh@9q1#")
            },            
            new ValidatePasswordTestCase {
                Type = "Error",
                Description = "Password should be at least 1 special character",
                Value = PasswordEntity.Create("Ag0Th29q1")
            },
            new ValidatePasswordTestCase {
                Type = "Success",
                Description = "Password should be at least 1 special character",
                Value = PasswordEntity.Create("Ag0Th@9q1#") 
            },
        };
    }
}