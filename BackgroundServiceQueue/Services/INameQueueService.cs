namespace BackgroundServiceQueue.Services
{
    public interface INameQueueService
    {
        void AddQueue(string name);
        string DeQueue();

        bool HasNext();
    }
}
