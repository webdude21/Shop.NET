namespace Shop.Net.Web.Models
{
    public class ViewModelWithPager<T>
    {
        public ViewModelWithPager(T viewModel, PagerViewModel pager)
        {
            this.ViewModel = viewModel;
            this.Pager = pager;
        }

        public T ViewModel { get; set; }

        public PagerViewModel Pager {get; set; }
    }
}