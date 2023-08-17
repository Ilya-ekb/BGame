namespace Game
{
    public class Bootstrap
    {
        public static void Initiate(ContainerData data)
        {
            MonoLoop.Initiate();
            Container.Initiate(data);
        }
    }
}