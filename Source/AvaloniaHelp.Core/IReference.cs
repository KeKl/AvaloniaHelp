namespace AvaloniaHelp.Core
{
    public interface IReference
    {
        bool ContainsString(string s);

        string LinkForString(string s);
    }
}