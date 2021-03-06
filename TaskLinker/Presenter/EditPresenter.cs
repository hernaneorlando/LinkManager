using TaskLinker.View;

namespace TaskLinker.Presenter
{
    public class EditPresenter
    {
        private IEditView _view;

        public void AttachView(IEditView view)
        {
            _view = view;
        }
    }
}
