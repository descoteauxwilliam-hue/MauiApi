using ApiQuiz.Logic.ApiService;
using ApiQuiz.ViewModel;

namespace ApiQuiz
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            FillPicker();
            BindingContext = vm;
           
        }


        public async void StartQuiz(object? sender, EventArgs args)
        {
           
        }

        void FillPicker()
        {
            foreach (var category in Enum.GetValues(typeof(Category)))
            {
                PickerCategory.Items.Add(category.ToString());
            }
        }
    }
}
