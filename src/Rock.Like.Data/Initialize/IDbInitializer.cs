namespace Rock.Like.Data.Initialize
{
    public interface IDbInitializer
    {
        void Initialize();
        void SeedData();
    }
}
