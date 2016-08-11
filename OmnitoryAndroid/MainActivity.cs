using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net;
using ZXing.Mobile;

namespace OmnitoryAndroid {
    [Activity(Label = "OmnitoryAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity {

        Omnitory.Model.Container CurrentContainer;

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button addToContainerButton = FindViewById<Button>(Resource.Id.AddToContainer);
            Button switchContainerButton = FindViewById<Button>(Resource.Id.SwitchContainer);
    
          

            addToContainerButton.Click += OnAddItem;
            switchContainerButton.Click += OnSwitchContainer;

        }

        public int Port;
        private Omnitory.Model.Container QueryContainer(string id) {
            WebClient client = new WebClient();
            var text = client.DownloadString($"http://localhost:{Port}?Id={id}");
            var item =Newtonsoft.Json.JsonConvert.DeserializeObject(text);
            return item as Omnitory.Model.Container;  
        }

        private async void OnSwitchContainer(object sender, EventArgs e) {
            #if __ANDROID__
                        MobileBarcodeScanner.Initialize(Application);
            #endif
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            var result = await scanner.Scan();

            if (result != null) {
                var container = QueryContainer(result.Text);
                if (container != null) {
                    CurrentContainer = container;
                    UpdateListView();
                }
            }    
        }

        private void UpdateListView() {
            TextView currentContianerNameTextView = FindViewById<TextView>(Resource.Id.ContainerName);
            TextView currentContainerDescriptionTextView = FindViewById<TextView>(Resource.Id.ContainerDescription);
            ListView itemListView = FindViewById<ListView>(Resource.Id.ItemListView);

            currentContianerNameTextView.Text = CurrentContainer.Name;
            currentContainerDescriptionTextView.Text = CurrentContainer.Description;
        

        }

        private void OnAddItem(object sender, EventArgs e) {
            throw new NotImplementedException();
        }
    }
}

