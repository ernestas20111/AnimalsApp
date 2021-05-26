using System;

namespace AnimalsAppBackend.Domain
{
    public interface IDomainEntity
    {
        Guid Id { get; set; }
    }
}
