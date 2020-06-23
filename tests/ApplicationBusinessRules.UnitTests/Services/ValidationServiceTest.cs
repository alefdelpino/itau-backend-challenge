using Xunit;
using FluentAssertions;
using System.Linq;
using TestCases;
using ApplicationBusinessRules.Services;

namespace ApplicationBusinessRules.UnitTests.Services
{
    public class ValidationServiceTest
    {        
        private ValidationService _validationService;

        public ValidationServiceTest()
        {
            this._validationService = new ValidationService();
        }
 
        [Fact]
        public void ValidatePasswordTest () 
        {
             ValidatePasswordTestCase
                .TestCases
                .Where(test => test.Type == "Error")
                .Select(
                    test => {
                        return this
                            ._validationService
                            .ValidatePassword(test.Value)
                            .HasErrors()
                            .Should()
                            .BeTrue(test.Description);
                    }
                )
                .ToList();

            ValidatePasswordTestCase
                .TestCases
                .Where(test => test.Type == "Success")
                .Select(
                    test => {
                        return this
                            ._validationService
                            .ValidatePassword(test.Value)
                            .IsOk()
                            .Should()
                            .BeTrue(test.Description);
                    }
                )
                .ToList();
        }
    }
}