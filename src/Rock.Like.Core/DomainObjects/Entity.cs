using System;
using System.ComponentModel.DataAnnotations;

namespace Rock.Like.Core.DomainObjects
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
