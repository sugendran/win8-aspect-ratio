using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace AspectRatio
{

    public enum AspectRatioType
    {
        ratio_16_9,
        ratio_16_10,
        ratio_4_3
    }

    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : AspectRatio.Common.LayoutAwarePage
    {
        AspectRatioType currentRatio;
        Brush selectedBrush;
        Brush unselectedBrush;

        public MainPage()
        {
            this.InitializeComponent();
            currentRatio = AspectRatioType.ratio_4_3;
            selectedBrush = new SolidColorBrush(Windows.UI.Colors.CadetBlue);
            unselectedBrush = new SolidColorBrush(Windows.UI.Colors.DarkGray);
            updateButtons();
            updateRightText();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }


        private void onKeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (sender == this.txtFirst)
            {
                updateRightText();
            }
            else
            {
                updateLeftText();
            }
        }

        private void onClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (sender == this.ratio_4_3)
            {
                currentRatio = AspectRatioType.ratio_4_3;
            }
            else if (sender == this.ratio_16_9)
            {
                currentRatio = AspectRatioType.ratio_16_9;
            }
            else if (sender == this.ratio_16_10)
            {
                currentRatio = AspectRatioType.ratio_16_10;
            }
            updateButtons();
            updateRightText();
        }


        private void updateButtons()
        {
            this.ratio_4_3.Background = currentRatio == AspectRatioType.ratio_4_3 ? selectedBrush : unselectedBrush;
            this.ratio_16_9.Background = currentRatio == AspectRatioType.ratio_16_9 ? selectedBrush : unselectedBrush;
            this.ratio_16_10.Background = currentRatio == AspectRatioType.ratio_16_10 ? selectedBrush : unselectedBrush;
        }

        private void updateRightText()
        {
            try
            {

                double multiplier = 1.0f;
                switch (currentRatio)
                {
                    case AspectRatioType.ratio_4_3:
                        multiplier = 4.0f / 3.0f;
                        break;
                    case AspectRatioType.ratio_16_10:
                        multiplier = 16.0f / 10.0f;
                        break;
                    case AspectRatioType.ratio_16_9:
                        multiplier = 16.0f / 9.0f;
                        break;
                }
                double firstVal = Convert.ToDouble(this.txtFirst.Text);
                double secondVal = firstVal / multiplier;
                int val = Convert.ToInt32(secondVal);
                this.txtSecond.Text = val.ToString();
            }
            catch
            {
            }
        }

        // x/y = 4/3
        // x = y(4/3)
        private void updateLeftText()
        {
            try
            {
                double multiplier = 1;
                switch (currentRatio)
                {
                    case AspectRatioType.ratio_4_3:
                        multiplier = 4.0f / 3.0f;
                        break;
                    case AspectRatioType.ratio_16_10:
                        multiplier = 16.0f / 10.0f;
                        break;
                    case AspectRatioType.ratio_16_9:
                        multiplier = 16.0f / 9.0f;
                        break;
                }
                double secondVal = Convert.ToDouble(this.txtSecond.Text);
                double firstVal = secondVal * multiplier;
                int val = Convert.ToInt32(firstVal);
                this.txtFirst.Text = val.ToString();
            }
            catch
            {
            }
        }
		
    }
}
