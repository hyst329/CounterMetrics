using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace CounterMetrics.Infrastructure
{
    public class WcfSessionContextHelper : ISessionContext, ISessionContextHelper
    {
        private static readonly Lazy<ISessionContext> ObjInstance =
            new Lazy<ISessionContext>(() => new WcfSessionContextHelper());

        private const string HeaderNs = "http://tempuri.org";
        private const string SessionIdKey = "SessionId";



        public Guid? SessionGuid
        {
            get { return GetHeader<Guid?>(SessionIdKey); }
            set { SetHeader(SessionIdKey, value); }
        }

        private T GetHeader<T>(string header)
        {
            var messageHeaders = OperationContext.Current.IncomingMessageHeaders;
            var headerIndex = messageHeaders.FindHeader(header, HeaderNs);
            if (headerIndex < 0) return default(T);
            return messageHeaders.GetHeader<T>(headerIndex);
        }

        private void SetHeader<T>(string header, T value)
        {
            var messageHeader = MessageHeader.CreateHeader(header, HeaderNs, value);
            OperationContext.Current.OutgoingMessageHeaders.Add(messageHeader);
        }

        public int UserId { get; set; }


        public ISessionContext Instance => ObjInstance.Value;
    }
}