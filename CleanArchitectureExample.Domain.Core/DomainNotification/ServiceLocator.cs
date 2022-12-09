namespace TestingOnly.Domain.Core.DomainNotification
{
    public static class ServiceLocator
    {
        public static IContainer Container { get; private set; }

        public static void Initialize(IContainer container)
        {
            Container = container;
        }
    }
}
