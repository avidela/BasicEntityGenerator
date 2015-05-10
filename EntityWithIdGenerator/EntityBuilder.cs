namespace EntityWithIdGenerator
{
    using System;

    public class EntityBuilder : IEntityBuilder
    {
        public BaseEntity Build()
        {
            var id = Guid.NewGuid();
            var resultEntity = new BaseEntity(id);
            return resultEntity;
        }
    }
}