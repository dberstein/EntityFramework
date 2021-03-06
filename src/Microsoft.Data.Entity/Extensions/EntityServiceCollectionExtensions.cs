// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Entity.ChangeTracking;
using Microsoft.Data.Entity.Identity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Storage;
using Microsoft.Data.Entity.Utilities;

namespace Microsoft.Framework.DependencyInjection
{
    public static class EntityServiceCollectionExtensions
    {
        public static EntityServicesBuilder AddEntityFramework([NotNull] this IServiceCollection serviceCollection)
        {
            Check.NotNull(serviceCollection, "serviceCollection");

            serviceCollection
                .AddSingleton<IModelSource, DefaultModelSource>()
                .AddSingleton<IdentityGeneratorFactory, DefaultIdentityGeneratorFactory>()
                .AddSingleton<ActiveIdentityGenerators, ActiveIdentityGenerators>()
                .AddSingleton<DbSetFinder, DbSetFinder>()
                .AddSingleton<DbSetInitializer, DbSetInitializer>()
                .AddSingleton<EntityKeyFactorySource, EntityKeyFactorySource>()
                .AddSingleton<ClrPropertyGetterSource, ClrPropertyGetterSource>()
                .AddSingleton<ClrPropertySetterSource, ClrPropertySetterSource>()
                .AddSingleton<ClrCollectionAccessorSource, ClrCollectionAccessorSource>()
                .AddSingleton<EntityMaterializerSource, EntityMaterializerSource>()
                .AddSingleton<CompositeEntityKeyFactory, CompositeEntityKeyFactory>()
                .AddSingleton<MemberMapper, MemberMapper>()
                .AddSingleton<StateEntrySubscriber, StateEntrySubscriber>()
                .AddSingleton<FieldMatcher, FieldMatcher>()
                .AddSingleton<OriginalValuesFactory, OriginalValuesFactory>()
                .AddSingleton<StoreGeneratedValuesFactory, StoreGeneratedValuesFactory>()
                .AddSingleton<DataStoreSelector, DataStoreSelector>()
                .AddScoped<StateEntryFactory, StateEntryFactory>()
                .AddScoped<IEntityStateListener, NavigationFixer>()
                .AddScoped<StateEntryNotifier, StateEntryNotifier>()
                .AddScoped<DbContextConfiguration, DbContextConfiguration>()
                .AddScoped<ContextSets, ContextSets>()
                .AddScoped<StateManager, StateManager>()
                .AddScoped<Database, Database>();

            return new EntityServicesBuilder(serviceCollection);
        }
    }
}
