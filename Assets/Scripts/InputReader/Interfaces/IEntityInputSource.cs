namespace InputReader
{
    public interface IEntityInputSource
    {
        bool Attack { get; }
        float HorizontalDirection { get; }
        float VerticalDirection { get; }
        void ResetOneTimeActions();
    }
}