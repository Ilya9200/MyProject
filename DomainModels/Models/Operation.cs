using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.Models
{
    [Table("Operation")]
    public class Operation
    {
        public long Id { get; set; }

        public Guid Uid { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public virtual ICollection<OperationResult> OperationResults { get; set; }
    }
}
