using System;

namespace Burak.Authorization.Models.BaseModel
{
    public interface IAudit
    {
        string UpdatedBy { get; set; }
        DateTime? UpdatedOn { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
    }
}
