using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeBookKeepAPI.Models
{
    public interface IAuditableEntity
    {
        Guid Id { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        DateTime? DeletedAt { get; set; }
        string UpdatedBy { get; set; }
        bool IsDeleted { get; set; }
    }
}