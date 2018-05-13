using Autofac;

namespace AutoFacDemo
{
    class Program
    {
        // http://autofac.readthedocs.io/en/latest/getting-started/index.html

        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TodayWriter>().As<IDateWriter>();
            Container = builder.Build();

            WriteDate();
        }

        public static void WriteDate()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
                
            }
        }
    }
}
