namespace EntityWithIdGenerator
{
    using System;

    public class BaseEntity
    {
        public BaseEntity(object id)
        {
            this.Id = id;
        }

        public object Id { get; protected set; }
    }
}
