using Autofac;
using Moelyrics.Services.Metadata.Domain.AggregatesModel.TrackAggregate;
using Moelyrics.Services.Metadata.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moelyrics.Services.Metadata.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Module
    {
        public ApplicationModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TrackRepository>()
                .As<ITrackRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
