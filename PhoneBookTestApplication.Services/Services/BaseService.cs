using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PhoneBookTestApplication.Services.Services
{
    public class BaseService
    {
        public async Task<bool> ExceptionHandlingAsync(Action requestAsync)
        {
            if (requestAsync == null)
                throw new ArgumentNullException(nameof(requestAsync));
            try
            {
                await Task.Run(requestAsync);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tIn the log routine. Caught {ex.GetType()}");
                Console.WriteLine($"\tMessage: {ex.Message}");
                return false;
            }
        }
    }
}
