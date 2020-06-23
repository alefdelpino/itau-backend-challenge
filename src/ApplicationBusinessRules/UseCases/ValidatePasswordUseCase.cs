using System.Linq;
using EnterpriseBusinessRules.Entities;

namespace ApplicationBusinessRules.UseCases
{
    public class ValidatePasswordUseCase
    {
        public ResponseEntity ValidatePassword(PasswordEntity password) 
        {           
            var validate = password.Validate();
            if(validate.IsValid) {
                return new ResponseEntity()
                    .SetSuccess(true)
                    .SetResponse(true);
            }
            return new ResponseEntity()
                    .SetSuccess(false)
                    .SetResponse(false)
                    .SetMessages(validate);
        }
    }
}
