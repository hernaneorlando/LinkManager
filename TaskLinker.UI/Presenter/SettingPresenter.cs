using TaskLinker.UI.View;

namespace TaskLinker.UI.Presenter
{
    public class SettingPresenter
    {
        private ISettingView _view;

        public void AttachView(ISettingView view)
        {
            _view = view;
        }
    }
}
