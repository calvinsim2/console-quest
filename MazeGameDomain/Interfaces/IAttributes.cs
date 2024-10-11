namespace MazeGameDomain.Interfaces
{
    public interface IAttributes
    {
        public void IncreaseHealth(decimal health);
        public void DecreaseHealth(decimal health);
        public void IncreaseMP(decimal mp);
        public void DecreaseMP(decimal mp);
    }
}
