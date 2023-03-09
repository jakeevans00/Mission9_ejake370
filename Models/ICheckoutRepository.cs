using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_ejake370.Models
{
    public interface ICheckoutRepository
    {
        IQueryable<Checkout> Checkouts { get; }
        void SaveCheckout(Checkout checkout);
    }
}
