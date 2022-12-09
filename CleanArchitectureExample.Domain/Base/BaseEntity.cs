using System;

namespace TestingOnly.Domain.Base
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {

        }

        public DateTime DateCreated { get; private set; } = DateTime.Now;
        public bool IsActive { get; private set; } = true;
    }
}
