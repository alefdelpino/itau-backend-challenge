using System.Linq;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace EnterpriseBusinessRules.Entities
{
    public class ResponseEntity 
    {
        public ResponseEntity SetSuccess(bool success)
        {
            this.Success = success;
            return this;
        }

        public ResponseEntity SetResponse(object response)
        {
            this.Response = response;
            return this;
        }

        public ResponseEntity SetMessages(List<string> messages)
        {
            this.Messages = messages;
            return this;
        }

        public ResponseEntity SetMessages(ValidationResult validate)
        {
            return this.SetMessages(
                validate
                    .Errors
                    .Select(x => x.ErrorMessage)
                    .ToList()
            );
        }

        public ResponseEntity AddMessage(string message)
        {
            Messages.Add(message);
            return this;
        }

        public bool IsOk()
        {
            return this.Success;
        }

        public bool HasErrors()
        {
            return !this.Success;
        }

        public object GetResponse()
        {
            return this.Response;
        }

        public List<string> GetMessages()
        {
            return this.Messages;
        }

        [JsonIgnore]
        public bool Success { get; set; } = true;
        public object Response { get; set; } = null;
        public List<string> Messages { get; set; } = new List<string>();
    }
}