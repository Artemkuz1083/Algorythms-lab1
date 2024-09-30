using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using AlgorytmsLibrary;

namespace Algorythms
{
    public partial class MainWindow : Window
    {
        public static NoPowWindow NoPow;

        public static PowWindow Pow;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPow_Click(object sender, RoutedEventArgs e)
        {
            if (Pow == null)
            {
                Pow = new PowWindow();
                Pow.Show();
            }
            else
            {
                Pow.Activate();
            }
        }

        private void BtnNoPow_Click(object sender, RoutedEventArgs e)
        {
            if (NoPow == null)
            {
                NoPow = new NoPowWindow();
                NoPow.Show();
            }
            else
            {
                NoPow.Activate();
            }

        }
    }
}