namespace TaskLinker.UI.View
{
    public interface INewCommandLineView
    {
        string ShowPrompt(string caption = null, string labelText = null, string fieldText = null);
    }
}
