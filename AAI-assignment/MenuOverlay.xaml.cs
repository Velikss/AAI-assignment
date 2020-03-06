using AAI_assignment.behaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AAI_assignment
{
    /// <summary>
    /// Interaction logic for MenuOverlay.xaml
    /// </summary>
    partial class MenuOverlay : UserControl
    {
        World world;
        public MenuOverlay(World world)
        {
            this.world = world;
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                string type = (String)((CheckBox)sender).Content;

                switch (type)
                {
                    case "Alignment":
                        return;
                    default:
                        return;

                }
            }

            

        }

    }
}
