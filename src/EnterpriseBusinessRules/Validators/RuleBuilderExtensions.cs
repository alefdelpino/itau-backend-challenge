using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

public static class RuleBuilderExtensions
{
    public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder,
        int minimumLength = 14)
    {
        var options = ruleBuilder
            .NotEmpty()
                .WithMessage("{PropertyName} is required")
            .MinimumLength(9)
                .WithMessage("{PropertyName} should be at least {MinLength} characters")
            .Matches("[0-9]")
                .WithMessage("{PropertyName} should be at least 1 digit character") 
            .Matches("[a-z]")
                .WithMessage("{PropertyName} should be at least 1 lowercase letter")
            .Matches("[A-Z]")
                .WithMessage("{PropertyName} should be at least 1 uppercase letter")
            .Matches("[^a-zA-Z0-9]")
                .WithMessage("{PropertyName} should be at least 1 special character")
            .Must(password => {
                var passwordList = password.ToList();
                var defaultCount = password.Count();
                var uniqueCount = passwordList.Distinct().Count();
                return defaultCount == uniqueCount;
            })
                .WithMessage("{PropertyName} should be different characters");
        return options;
    }
}