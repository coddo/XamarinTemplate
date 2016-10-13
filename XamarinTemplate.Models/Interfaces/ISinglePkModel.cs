using System;

namespace XamarinTemplate.Models.Interfaces
{
    public interface ISinglePkModel : IModel
    {
        Guid Id { get; set; }
    }
}
