using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmetics.Contracts
{
    interface ICream : IProduct
    {
        Scent Scent
        {
            get;
        }
    }
}
