using Android.App;
using Android.OS;
using Android.Widget;

namespace phone_word
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]    
    public class MainActivity : Activity
    {
        //AppCompatActivity
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Set your main view here
            SetContentView(Resource.Layout.Main);

            EditText phoneText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TextView translatedText = FindViewById<TextView>(Resource.Id.PhoneNumberTranslated);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);

            translateButton.Click += (sender, e) =>
            {
                string transNumber = PhoneTranslator.ToNumber(phoneText.Text);
                translatedText.Text = (string.IsNullOrWhiteSpace(transNumber) ? string.Empty : transNumber);
            };
        }
    }
}

