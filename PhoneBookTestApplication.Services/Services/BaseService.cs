using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PhoneBookTestApplication.Services.Services
{
    public class BaseService
    {
        public async Task<string> RequestRemoteAsync(Action requestAsync)
        {
            if (requestAsync == null)
                throw new ArgumentNullException(nameof(requestAsync));
            try
            {
                await Task.Run(requestAsync);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
