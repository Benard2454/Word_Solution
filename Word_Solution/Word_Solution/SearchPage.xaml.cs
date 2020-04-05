using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dictionary;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Word_Solution
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        int count;
        List<string> three, four, five, six, seven, eight, nine, ten;

        private void ContentPage_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width <800)
            {
                Label.FontSize = this.Width / 18;
                Label1.FontSize = this.Width / 20;
            }
            else
            {
                Label.FontSize = 30;
                Label1.FontSize = 24;
            }
        }

        permutate permutate;
        public SearchPage()
        {
            InitializeComponent();
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    NavigationPage.SetHasNavigationBar(this, true);
                    break;
                case Device.UWP:
                    NavigationPage.SetHasNavigationBar(this, false);
                    break;
                default:
                    break;
            }
           
                if (Application.Current.Properties.ContainsKey("status"))
                {
                    About.IsVisible = false;
                }
            
            permutate = new permutate();
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            About.IsVisible = true;
            //bool close = await DisplayAlert("","Do you want to close application","YES" ,"NO");
            //if (close)
            //{
            //    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            //    base.OnBackButtonPressed();
            //}
            
            //await Navigation.PopModalAsync(true);
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            this.IsEnabled = false;
            act.IsVisible = true;
            await Task.Delay(50);
            count = 0;
            three = new List<string>();
            four = new List<string>();
            five = new List<string>();
            six = new List<string>();
            seven =new List<string>();
            eight =new List<string>();
            nine = new List<string>();
            ten = new List<string>();
            await Task.Run(()=> permutate.start(Keyword.Text.ToLower().Trim()));
            foreach (var item in permutate.NumberOfPerms)
            {
                if (item != null)
                {
                    count++;
                    switch (item.Length)
                    {
                        case 3:
                            if (!three.Contains(item))
                            {
                                three.Add(item);
                            }
                            break;
                        case 4:
                            if (!four.Contains(item))
                            {
                                four.Add(item);
                            }
                            break;
                        case 5:
                            if (!five.Contains(item))
                            {
                                five.Add(item);
                            }
                            break;
                        case 6:
                            if (!six.Contains(item))
                            {
                                six.Add(item);
                            }
                            break;
                        case 7:
                            if (!seven.Contains(item))
                            {
                                seven.Add(item);
                            }
                            break;
                        case 8:
                            if (!eight.Contains(item))
                            {
                                eight.Add(item);
                            }
                            break;
                        case 9:
                            if (!nine.Contains(item))
                            {
                                nine.Add(item);
                            }
                            break;
                        case 10:
                            if (!ten.Contains(item))
                            {
                                ten.Add(item);
                            }
                            break;
                        default:
                            break;
                    }
                    
                }
                
            }
            sort();
            R0C0.Text = Word(ten).ToString();
            R0C1.Text = Word(nine).ToString();
            R0C2.Text = Word(eight).ToString();
            R1C0.Text = Word(seven).ToString();
            R1C1.Text = Word(six).ToString();
            R1C2.Text = Word(five).ToString();
            R2C1.Text = Word(three).ToString();
            R2C0.Text = Word(four).ToString();
            result.Text = "Result: Found " + count.ToString() + "  words";
            await Task.Delay(50);
            this.act.IsVisible = false;
            this.IsEnabled = true;
        }
        private void sort()
        {
            three.Sort();
            four.Sort();
            five.Sort();
            six.Sort();
            seven.Sort();
            eight.Sort();
            nine.Sort();
            ten.Sort();

        }
        private StringBuilder Word(List<string> words)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string item in words)
            {
                builder.Append(item);
                builder.Append("\n");
            }
            return builder;
        }

        private async void Keyword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Keyword.Text.Length > 10)
            {
                Keyword.Text = Keyword.Text.Substring(0, 10);
                await DisplayAlert("","Reach max limit of characters","OK");
            }
            if (Keyword.Text.Length != 0 && !Char.IsLetter(  Convert.ToChar(Keyword.Text.Substring(Keyword.Text.Length-1,1))))
            {
                Keyword.Text = Keyword.Text.Substring(0, Keyword.Text.Length-1);
            }
        }
    }
}