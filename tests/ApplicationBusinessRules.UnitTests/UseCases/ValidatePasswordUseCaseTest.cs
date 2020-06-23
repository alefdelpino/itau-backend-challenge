using System.Linq;
using Xunit;
using FluentAssertions;
using TestCases;
using ApplicationBusinessRules.UseCases;

namespace ApplicationBusinessRules.UnitTests.UseCases
{
    public class ValidatePasswordUseCaseTest
    {
        private ValidatePasswordUseCase _validatePasswordUseCase;

        public ValidatePasswordUseCaseTest()
        {
            this._validatePasswordUseCase = new ValidatePasswordUseCase();
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
                            ._validatePasswordUseCase
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
                            ._validatePasswordUseCase
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