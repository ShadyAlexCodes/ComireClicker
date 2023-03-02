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

namespace ComireClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Multiplier> multipliers = new List<Multiplier>();
        List<Multiplier> activeMultipliers = new List<Multiplier>();

        public MainWindow()
        {
            InitializeComponent();

            CreateMultipliersInstances();
        }

        private void btnMultiplier_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateMultipliersInstances()
        {
            // CLEAR THE ARRAY FOR UR MOMS PURPOSES
            multipliers.Clear();
                                            // NAME     IMAGE       MULTIPLIER  STARTING    INCRASES BY
            multipliers.Add(new Multiplier("Maple-Leaf", "MapleLeaf", 0.1, 0, 10, true));
            multipliers.Add(new Multiplier("Shull-er", "", 1, 100, 15, false));
            multipliers.Add(new Multiplier("Cox-ifer", "", 5, 500, 50, false));
            multipliers.Add(new Multiplier("Beardall-er", "", 15, 1000, 100, false));
            multipliers.Add(new Multiplier("Fox-ifyer", "", 25, 1500, 300, false));
            multipliers.Add(new Multiplier("Berk-inator", "", 50, 5000, 600, false));
            multipliers.Add(new Multiplier("Cantera-ina", "", 100, 5000, 600, false));
            multipliers.Add(new Multiplier("Kohler-inator-3000", "", 150, 5000, 600, false));
            multipliers.Add(new Multiplier("Sarah-bella", "", 250, 5000, 600, false));
            multipliers.Add(new Multiplier("Marshall-ina", "", 500, 5000, 600, false));
            multipliers.Add(new Multiplier("Pritchard-nator", "", 1000, 5000, 600, false));
            multipliers.Add(new Multiplier("Parker-Dator", "", 12000, 5000, 600, false));
            multipliers.Add(new Multiplier("Coal-Miner", "", 15000, 5000, 600, false));

            GenerateMultiperButtons();

        }

        private void GenerateMultiperButtons()
        {
           foreach(var multiplier in multipliers)
            {
                Button button = new Button();
                Grid grid = new Grid();

                ColumnDefinition colDilf = new ColumnDefinition();
                colDilf.Width = new GridLength(50);
                ColumnDefinition colDilf2 = new ColumnDefinition();
                
                ColumnDefinition colDilf3 = new ColumnDefinition();   
                colDilf3.Width = new GridLength(50);
                grid.ColumnDefinitions.Add(colDilf);
                grid.ColumnDefinitions.Add(colDilf2);
                grid.ColumnDefinitions.Add(colDilf3);

                Image multiplierImg = new Image();
                multiplierImg.Source = new BitmapImage(new Uri("Resources/Comire.png", System.UriKind.Relative));
                multiplierImg.Height = 30;
                //multiplierImg
                Grid.SetColumn(multiplierImg, 0);

                Label lblMutliName = new Label();
                lblMutliName.Content = multiplier.Name;
                Grid.SetColumn(lblMutliName, 1);

                Label lblPrice = new Label();
                lblPrice.Content = multiplier.GameCurrentAmount;
                Grid.SetColumn(lblPrice, 2);

                grid.Children.Add(multiplierImg);
                grid.Children.Add(lblMutliName);
                grid.Children.Add(lblPrice);

                
                button.Content = grid;
                button.IsEnabled = multiplier.IsUnlocked;
                button.Padding = new Thickness(5);


                listOfMultipliers.Children.Add(button);
            }
        }

        /*
         * 
         * ON CLICK
         * multipler.increaseCurrentAmount();
         */
    }
}
