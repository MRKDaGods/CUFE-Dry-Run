namespace MRK.Views
{
    public interface IView
    {
        string ViewName { get; }

        void OnViewHide();

        void OnViewShow();

        bool CanHideView();
    }
}
