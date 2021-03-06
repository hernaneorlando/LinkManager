using TaskLinker.View;

namespace TaskLinker.Presenter
{
    public class NewCommandLinePresenter
    {
        private ICommandLineEditView _view;

        public void AttachView(ICommandLineEditView view)
        {
            _view = view;
        }
    }
}
