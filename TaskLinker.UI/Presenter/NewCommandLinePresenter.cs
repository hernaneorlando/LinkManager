using TaskLinker.UI.View;

namespace TaskLinker.UI.Presenter
{
    public class NewCommandLinePresenter
    {
        private INewCommandLineView _view;

        public void AttachView(INewCommandLineView view)
        {
            _view = view;
        }
    }
}
