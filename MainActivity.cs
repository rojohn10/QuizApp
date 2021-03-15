using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using QuizApp.Activities;
using Android.Support.V4.Widget;
using Android.Views;

namespace QuizApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        //Instantiate toolbar
        Android.Support.V7.Widget.Toolbar toolbar;
        Android.Support.V4.Widget.DrawerLayout drawerLayout;
        Android.Support.Design.Widget.NavigationView navigationView;

        //Instantiate Layouts
        LinearLayout historyLayout;
        LinearLayout engineeringLayout;
        LinearLayout programmingLayout;
        LinearLayout spaceLayout;
        LinearLayout businessLayout;
        LinearLayout geographyLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            toolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.toolbar);
            drawerLayout = (Android.Support.V4.Widget.DrawerLayout)FindViewById(Resource.Id.drawerLayout);
            navigationView = (Android.Support.Design.Widget.NavigationView)FindViewById(Resource.Id.navView);

            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            //Setup toolbar
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Topics";
            Android.Support.V7.App.ActionBar actionBar = SupportActionBar;
            actionBar.SetHomeAsUpIndicator(Resource.Drawable.menuaction);
            actionBar.SetDisplayHomeAsUpEnabled(true);

            ConnectViews();

            // Click event handlers
            historyLayout.Click += HistoryLayout_Click;
            engineeringLayout.Click += EngineeringLayout_Click;
            programmingLayout.Click += ProgrammingLayout_Click;
            spaceLayout.Click += SpaceLayout_Click;
            businessLayout.Click += BusinessLayout_Click;
            geographyLayout.Click += GeographyLayout_Click;
        }

        private void ConnectViews()
        {
            //View Setups - reference all linear layouts
            historyLayout = (LinearLayout)FindViewById(Resource.Id.historyLayout);
            engineeringLayout = (LinearLayout)FindViewById(Resource.Id.engineeringLayout);
            programmingLayout = (LinearLayout)FindViewById(Resource.Id.programmingLayout);
            spaceLayout = (LinearLayout)FindViewById(Resource.Id.spaceLayout);
            businessLayout = (LinearLayout)FindViewById(Resource.Id.businessLayout);
            geographyLayout = (LinearLayout)FindViewById(Resource.Id.geographyLayout);
        }

        private void NavigationView_NavigationItemSelected(object sender, Android.Support.Design.Widget.NavigationView.NavigationItemSelectedEventArgs e)
        {
            //Intent intent = new Intent(this, typeof(QuizDescriptionActivity));

            switch (e.MenuItem.ItemId)
            {
                case Resource.Id.navHistory:

                    InitHistory();
                    drawerLayout.CloseDrawers();
                    break;

                case Resource.Id.navGeography:

                    InitGeography();
                    drawerLayout.CloseDrawers();
                    break;

                case Resource.Id.navEngineering:

                    InitEngineering();
                    drawerLayout.CloseDrawers();
                    break;

                case Resource.Id.navBusiness:

                    InitBusiness();
                    drawerLayout.CloseDrawers();
                    break;

                case Resource.Id.navProgramming:

                    InitProgramming();
                    drawerLayout.CloseDrawers();
                    break;

                case Resource.Id.navSpace:

                    InitSpace();
                    drawerLayout.CloseDrawers();
                    break;

                default:
                    break;
            }
        }

        private void GeographyLayout_Click(object sender, System.EventArgs e)
        {
            InitGeography();
        }

        private void BusinessLayout_Click(object sender, System.EventArgs e)
        {
            InitBusiness();
        }

        private void SpaceLayout_Click(object sender, System.EventArgs e)
        {
            InitSpace();
        }

        private void ProgrammingLayout_Click(object sender, System.EventArgs e)
        {
            InitProgramming();
        }

        private void EngineeringLayout_Click(object sender, System.EventArgs e)
        {
            InitEngineering();
        }

        private void HistoryLayout_Click(object sender, System.EventArgs e)
        {
            InitHistory();
        }

        void InitHistory()
        {
            Intent intent = new Intent(this, typeof(QuizDescriptionActivity));
            intent.PutExtra("topic", "History");
            StartActivity(intent);
        }

        void InitGeography()
        {
            Intent intent = new Intent(this, typeof(QuizDescriptionActivity));
            intent.PutExtra("topic", "Geography");
            StartActivity(intent);
        }

        void InitBusiness()
        {
            Intent intent = new Intent(this, typeof(QuizDescriptionActivity));
            intent.PutExtra("topic", "Business");
            StartActivity(intent);
        }

        void InitProgramming()
        {
            Intent intent = new Intent(this, typeof(QuizDescriptionActivity));
            intent.PutExtra("topic", "Programming");
            StartActivity(intent);
        }

        void InitSpace()
        {
            Intent intent = new Intent(this, typeof(QuizDescriptionActivity));
            intent.PutExtra("topic", "Space");
            StartActivity(intent);
        }

        void InitEngineering()
        {
            Intent intent = new Intent(this, typeof(QuizDescriptionActivity));
            intent.PutExtra("topic", "Engineering");
            StartActivity(intent);
        }

        //OnOptionsItemSelected is very important because it is the one responsible 
        //in determining what is the menu that was clicked in your app and it's also
        //assigning the commands that will be executed when we click on a specific menu
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {

                //Android.Resource.Id.Home is the hamburger icon in the navigation drawer
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }

        }
    }
}