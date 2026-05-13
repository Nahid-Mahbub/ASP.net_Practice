using Autofac;
using Practice.Web.Codes;

namespace Practice.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        public WebModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<ImprovedMembership>()
            //.As<Membership>()
            //.InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
