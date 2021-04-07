using System;
using System.Collections.Generic;
using System.Text;

namespace LayeredArchitecture.Services.Contracts
{
    public interface IDateTimeProvider
    {
        DateTime GetDateTime();
    }
}
