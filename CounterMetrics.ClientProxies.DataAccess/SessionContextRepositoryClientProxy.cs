﻿using System;
using System.ServiceModel;
using System.Transactions;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.Infrastructure;

namespace CounterMetrics.ClientProxies.DataAccess
{
    public class SessionContextRepositoryClientProxy : ClientBase<ISessionContextRepository>, ISessionContextRepository
    {
        public SessionContextRepositoryClientProxy(string endpointConfigurationName) : base(endpointConfigurationName)
        {
        }

        public int? GetUserId(Guid sessionGuid)
        {
            int? userId;
            using (var cf = new ChannelFactory<ISessionContextRepository>())
            {
                var ch = cf.CreateChannel();
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    userId = ch.GetUserId(sessionGuid);
                    scope.Complete();
                }
                cf.Close();
            }
            return userId;
        }

        public Guid Add(int userId)
        {
            Guid guid;
            using (var cf = new ChannelFactory<ISessionContextRepository>())
            {
                var ch = cf.CreateChannel();
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    guid = ch.Add(userId);
                    scope.Complete();
                }
                cf.Close();
            }
            return guid;
        }

        public void Remove(Guid sessionGuid)
        {
            using (var cf = new ChannelFactory<ISessionContextRepository>())
            {
                var ch = cf.CreateChannel();
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    ch.Remove(sessionGuid);
                    scope.Complete();
                }
                cf.Close();
            }
        }
    }
}