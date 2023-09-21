namespace Game
{
    public class Bootstrap
    {
        public static bool IsInitiated { get; private set; }
        
        public static void Initiate(ContainerData data)
        {
            IsInitiated = true;
            MonoLoop.Initiate();
            Container.Initiate(data);
        }

        public static void Dispose()
        {
            Container.Dispose();
            MonoLoop.Dispose();
            IsInitiated = false;
        }
    }
}