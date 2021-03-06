using System.Drawing;
using TaskLinker.View.Components;

namespace TaskLinker.View
{
    public interface ICommandLineEditView
    {
        CommandLine ShowPrompt(string commandLine, Image image);
    }
}
