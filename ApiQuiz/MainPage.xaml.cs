using ApiQuiz.Logic.ApiService;
using static Android.Graphics.Paint;


namespace ApiQuiz
{
    public partial class MainPage : ContentPage
    {
        
       

        public MainPage()
        {
            InitializeComponent();
            FillPicker();
            Routing.RegisterRoute("quizPage", typeof(QuizPage));
        }
        public async void StartQuiz()
        {
            Category category = GetPickerItem();
            int amount        = GetAmount(); 
            await Shell.Current.GoToAsync($"QuizPage?category={category}&amount={amount}");
        }

        void FillPicker()
        {
            foreach (var category in Enum.GetValues(typeof(Category)))
            {
                PickerCategory.Items.Add(category.ToString());
            }
        }

        Category GetPickerItem()
        {
            var Item = PickerCategory.SelectedItem.ToString();
            if(Enum.TryParse(Item, out Category cat))
            {
                return cat;
            }
            throw new Exception();
        }
        int GetAmount()
        {
            if(int.TryParse(AmountQuestion.Text, out int amount))
            {
                return amount;
            }
            throw new Exception();
        }
    }
}
