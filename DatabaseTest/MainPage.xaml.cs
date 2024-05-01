using Microsoft.Maui.Controls.Compatibility;
using StackLayout = Microsoft.Maui.Controls.StackLayout;

namespace DatabaseTest ;

    public partial class MainPage : ContentPage
    {
        private readonly DBContext _dbContext;
        private List<User> users;
        private int count = 0;

        public MainPage(DBContext db)
        {
            InitializeComponent();
            _dbContext = db;
            Task.Run(async()=> users = await _dbContext.GetUsers());

            var Button = new Button { Text = "create" };
            Button.Clicked += async (sender, e) =>
            {
                await _dbContext.Create(new User{name = "asd", email = "ali@gmail.com" });
                users = await _dbContext.GetUsers();
            };

            var b = new Button { Text = "SHOW" };
            b.Clicked += async (sender, e) =>
            {
                // await DisplayAlert("Sdds", users.Count.ToString(), "DSs");
                await DisplayAlert("Sdds", FileSystem.AppDataDirectory, "DSs");
            };
            var sl = new StackLayout{Children = { Button, b }};
            Content = new ScrollView{ Content = sl};
        }

        
    }