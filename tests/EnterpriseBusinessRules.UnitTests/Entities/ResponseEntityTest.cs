using System.Linq;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using FluentValidation.Results;
using EnterpriseBusinessRules.Entities;

namespace EnterpriseBusinessRules.UnitTests.Entities
{
    public class ResponseEntityTest
    {
        [Fact]
        public void CreateInstanceTest () 
        {
            var responseEntity = new ResponseEntity();
            var messages = new List<string> {
                "message 1",
                "message 2",
                "message 3",
                "message 4",
                "message 5",
            };

            responseEntity
                .GetMessages()
                .Should()
                .HaveCount(0);

            responseEntity
                .AddMessage(messages[0])
                .AddMessage(messages[1])
                .AddMessage(messages[2])
                .GetMessages()
                .Should()
                .HaveCount(3);  

            responseEntity
                .SetMessages(new ValidationResult())
                .GetMessages()
                .Should()
                .HaveCount(0);  

            responseEntity
                .AddMessage(messages[3])
                .GetMessages()
                .Should()
                .HaveCount(1);    

            responseEntity
                .SetMessages(messages)
                .GetMessages()
                .Should()
                .HaveCount(messages.Count());        

            responseEntity
                .SetSuccess(true)
                .IsOk()
                .Should()
                .BeTrue();

            responseEntity
                .SetSuccess(false)
                .HasErrors()
                .Should()
                .BeTrue();    
            
            responseEntity
                .SetResponse(messages)
                .GetResponse()
                .Should()
                .Be(messages);            
        }
    }
}