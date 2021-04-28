using System;
using System.Collections.Generic;
using System.Text;

namespace Deliverit.Models.Contracts
{
    public interface IEntity
    {
        public Guid Id { get; }

        public DateTime CreatedOn { get; }
        public DateTime? ModifiedOn { get; }

        public bool IsDeleted { get; }
        public DateTime? DeletedOn { get; }
    }
}
