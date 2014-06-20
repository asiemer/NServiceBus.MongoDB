﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureMongoPersistence.cs" company="SharkByte Software Inc.">
//   Copyright (c) 2014 Carlos Sandoval. All rights reserved.
//   
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU Affero General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//   
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU Affero General Public License for more details.
//   
//   You should have received a copy of the GNU Affero General Public License
//   along with this program.  If not, see http://www.gnu.org/licenses/.
// </copyright>
// <summary>
//   The configure mongo persistence.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NServiceBus.MongoDB
{
    using System;
    using System.Configuration;
    using System.Diagnostics.Contracts;
    using System.Text;
    using global::MongoDB.Driver;
    using NServiceBus.Logging;
    using NServiceBus.MongoDB.SagaPersister;

    /// <summary>
    /// The configure mongo persistence.
    /// </summary>
    public static class ConfigureMongoPersistence
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ConfigureMongoPersistence));

        /// <summary>
        /// The mongo persistence.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        /// <returns>
        /// The <see cref="Configure"/>.
        /// </returns>
        public static Configure MongoPersistence(this Configure config)
        {
            Contract.Requires<ArgumentNullException>(config != null);

            if (Configure.Instance.Configurer.HasComponent<MongoDatabaseFactory>())
            {
                return config;
            }

            var connectionStringSettings = GetConnectionString();

            var connectionString = connectionStringSettings != null
                                       ? connectionStringSettings.ConnectionString
                                       : MongoPersistenceConstants.DefaultUrl;

            return config.InternalMongoPersistence(new MongoClient(connectionString));
        }

        /// <summary>
        /// The mongo persistence.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        /// <param name="connectionString">
        /// The connection string.
        /// </param>
        /// <returns>
        /// The <see cref="Configure"/>.
        /// </returns>
        public static Configure MongoPersistence(this Configure config, string connectionString)
        {
            Contract.Requires<ArgumentNullException>(config != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(connectionString));

            return config.InternalMongoPersistence(new MongoClient(connectionString));
        }

        /// <summary>
        /// The mongo persistence.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        /// <param name="mongoUrl">
        /// The mongo url.
        /// </param>
        /// <returns>
        /// The <see cref="Configure"/>.
        /// </returns>
        public static Configure MongoPersistence(this Configure config, MongoUrl mongoUrl)
        {
            Contract.Requires<ArgumentNullException>(config != null);
            Contract.Requires<ArgumentNullException>(mongoUrl != null);

            return config.InternalMongoPersistence(new MongoClient(mongoUrl));
        }

        internal static Configure InternalMongoPersistence(this Configure config, MongoClient mongoClient)
        {
            return config.InternalMongoPersistence(() =>
            {
                VerifyConnectionToMongoServer(mongoClient);
                return mongoClient;
            });
        }

        internal static Configure InternalMongoPersistence(this Configure config, Func<MongoClient> clientFactory)
        {
            config.Configurer.ConfigureComponent(clientFactory, DependencyLifecycle.SingleInstance);
            config.Configurer.ConfigureComponent<MongoDatabaseFactory>(DependencyLifecycle.SingleInstance);

            //// TODO: probably won't be necessary
            ////config.Configurer.ConfigureComponent<MongoUnitOfWork>(DependencyLifecycle.InstancePerUnitOfWork);

            config.Configurer.ConfigureComponent<MongoSagaPersister>(DependencyLifecycle.SingleInstance);
            ////InfrastructureServices.SetDefaultFor<IPersistTimeouts>(() => Configure.Instance.UseRavenTimeoutPersister());
            ////InfrastructureServices.SetDefaultFor<ISubscriptionStorage>(() => Configure.Instance.RavenSubscriptionStorage());

            return config;
        }

        internal static void VerifyConnectionToMongoServer(MongoClient mongoClient)
        {
            Contract.Requires(mongoClient != null);

            var server = mongoClient.GetServer();

            try
            {
                server.Ping();
            }
            catch (Exception ex)
            {
                ShowUncontactableMongoWarning(mongoClient, ex);
                return;
            }

            //// TODO: check to see if database is valid on this server using
            //// server.DatabaseExists(name);

            Logger.InfoFormat("Connection to MongoDB at {0} verified.", mongoClient.Settings.Server);
        }

        internal static void ShowUncontactableMongoWarning(MongoClient mongoClient, Exception exception)
        {
            Contract.Requires(mongoClient != null);
            Contract.Requires(exception != null);

            var serverSettings = mongoClient.Settings.Server;

            var sb = new StringBuilder();
            sb.AppendFormat("Mongo could not be contacted using: {0}.", serverSettings);
            sb.AppendLine();
            sb.AppendFormat("Please ensure that there is a Mongo instance at {0}:{1}.", serverSettings.Host, serverSettings.Port);
            sb.AppendLine();
            sb.AppendLine(
                @"To configure NServiceBus to use a different connection string add a connection string named ""NServiceBus/Persistence"" in your config file.");
            sb.AppendLine("Reason: " + exception);

            Logger.Warn(sb.ToString());
        }

        private static ConnectionStringSettings GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["NServiceBus.Persistence"]
                                        ?? ConfigurationManager.ConnectionStrings["NServiceBus/Persistence"];
        }
    }
}
