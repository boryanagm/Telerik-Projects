using Deliverit.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deliverit.Models.Abstract
{
    /// <summary>
    /// Class Entity.
    /// An abstract class defining the base properties of all models. />
    /// </summary>
    public abstract class Entity : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
