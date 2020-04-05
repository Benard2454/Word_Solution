using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Word_Solution
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentView
    {
        public About()
        {
            InitializeComponent();
            
        }

        private void ContentView_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width < 800)
            {
                head.FontSize = this.Width / 18;
            }
            else
            {
                head.FontSize = 30;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.IsVisible = false;
            Application.Current.Properties["status"] = "done";
        }
    }
}