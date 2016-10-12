using System;

namespace CounterMetrics.Infrastructure
{
    public class NoWcfSessionContextHelper : ISessionContext, ISessionContextHelper
    {
        private static readonly Lazy<ISessionContext> ObjInstance =
            new Lazy<ISessionContext>(() => new NoWcfSessionContextHelper());

        public Guid? SessionGuid { get; set; }

        public int UserId { get; set; }


        public ISessionContext Instance => ObjInstance.Value;
    }
}