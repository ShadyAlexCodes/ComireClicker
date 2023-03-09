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
using System.Windows.Threading;

namespace ComireClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double cookieCount = 0;
        public double gameMultiplier = 1;

        // A list of multipliers
        List<Multiplier> multipliers = new List<Multiplier>();
        
        // Create the default multiplier (a click!)
        Multiplier multiplyMeBby = new Multiplier("btnClick", "click", "", 1, 0, 1, 1, true);

        // Set the default game multiplier to 1


        public MainWindow()
        {
            InitializeComponent();

            CreateMultipliersInstances();

            lblGameMultiplier.Content = gameMultiplier;


            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }


        //  DispatcherTimer setup
 

    private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            // Reset the game multiplier back to zero
            gameMultiplier = 0;

            // Iterate over all the multipliers
            foreach (var multiplier in multipliers)
            {
                // Store a local multiplier
                double currentMulti = 0;
                // Check if the multiplier is unlocked
                if (multiplier.IsUnlocked)
                {
                    // Increase the multiplier by multiplying the number in game by the game multiplier.
                    currentMulti += (multiplier.NumInGame * multiplier.GameMultiplier);
                }
                // Increase the game multiplier
                gameMultiplier += currentMulti;
            }

            // Update the multiplyer amount

            cookieCount += gameMultiplier;

            // Set the current multiplier
            lblGameMultiplier.Content = gameMultiplier;


            // Increase the cookies by the games current multiplier
            lblCurrentCookies.Content = cookieCount;

            // Updates the button state
            UpdateButtonState();

            

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();

        }

        private void UpdateButtonState()
        {
            foreach (var multiplier in multipliers)
            {
                // Find the button by name
                Button button = (Button) listOfMultipliers.FindName(multiplier.Id);


                if (button != null)
                {
                     MessageBox.Show(button.Name);
                    // Enable/disable the button based on whether the player has enough cookies
                    SetUpgradeButtonState(button, multiplier.GameCurrentAmount);
                }
            }

            GenerateMultiperButtons();
        }

        private void SetUpgradeButtonState(Button button, double upgradeCost)
        {
            if (cookieCount >= upgradeCost)
            {
                button.IsEnabled = true;
            }
            else
            {
                button.IsEnabled = false;
            }
        }




        private void CreateMultipliersInstances()
        {
            // CLEAR THE ARRAY FOR UR MOMS PURPOSES
            multipliers.Clear();
                                         //  id,       name,        imageURI,     gameMultiplier, startCost, costIncrease, numInGame, isUnlocked
            multipliers.Add(new Multiplier("btnMaple", "Maple-Leaf", "Maple", 0.1,             0,        10,             0, true));
            multipliers.Add(new Multiplier("btnShull", "Shull-er", "Shull", 1, 100, 15, 0, false));
            multipliers.Add(new Multiplier("btnCox", "Cox-ifer", "Cox", 5, 500, 50, 0, false));
            multipliers.Add(new Multiplier("btnBear", "Beardall-er", "Beardall", 15, 1000, 100, 0, false));
            multipliers.Add(new Multiplier("btnFox", "Fox-ifyer", "Fox", 25, 1500, 300, 0, false));
            multipliers.Add(new Multiplier("btnBurk", "Burk-inator", "Burk", 50, 5000, 600, 0, false));
            multipliers.Add(new Multiplier("btnCantera", "Cantera-ina", "Cantera", 100, 5000, 600, 0, false));
            multipliers.Add(new Multiplier("btnKohler", "Kohler-inator-3000", "Kohler", 150, 5000, 600, 0, false));
            multipliers.Add(new Multiplier("btnSarah", "Sarah-bella", "Sarah", 250, 5000, 600, 0, false));
            multipliers.Add(new Multiplier("btnMarshall", "Marshall-ina", "Marshall", 500, 5000, 600, 0, false));
            multipliers.Add(new Multiplier("btnPritchard", "Pritchard-nator", "Comire", 1000, 5000, 600, 0, false));
            multipliers.Add(new Multiplier("btnParker", "Parker-Dator", "Comire", 12000, 5000, 600, 0, false));
            multipliers.Add(new Multiplier("btnComireTwo", "Coal-Miner", "Comire", 15000, 5000, 600, 0, false));

            GenerateMultiperButtons();

        }

        private void GenerateMultiperButtons()
        {
            listOfMultipliers.Children.Clear();

           foreach(var multiplier in multipliers)
            {

                Button button = new Button();
                Grid grid = new Grid();

                ColumnDefinition colDilf = new ColumnDefinition();
                colDilf.Width = new GridLength(50);
                ColumnDefinition colDilf2 = new ColumnDefinition();
                
                ColumnDefinition colDilf3 = new ColumnDefinition();   
                colDilf3.Width = new GridLength(70);
                grid.ColumnDefinitions.Add(colDilf);
                grid.ColumnDefinitions.Add(colDilf2);
                grid.ColumnDefinitions.Add(colDilf3);

                Image multiplierImg = new Image();
                multiplierImg.Source = new BitmapImage(new Uri("Resources/" + multiplier.ImageURI + ".png", System.UriKind.Relative));
                multiplierImg.Height = 30;
                //multiplierImg
                Grid.SetColumn(multiplierImg, 0);

                Label lblMutliName = new Label();
                lblMutliName.Content = multiplier.Name;
                Grid.SetColumn(lblMutliName, 1);

                Label lblPrice = new Label();
                lblPrice.Content = multiplier.GameCurrentAmount + " | CA: " + multiplier.NumInGame;
                Grid.SetColumn(lblPrice, 2);

                grid.Children.Add(multiplierImg);
                grid.Children.Add(lblMutliName);
                grid.Children.Add(lblPrice);

                button.Name = multiplier.Id;
                
                button.Content = grid;
                button.IsEnabled = multiplier.IsUnlocked;
                //button.Click += new EventHandler(this.btnMultiplier_Click);
                button.Click += btnMultiplier_Click;
                button.Padding = new Thickness(5);
                listOfMultipliers.Children.Add(button);
            }

            //multiplyMeBby = multipliers[0];/
            

        }

        protected void btnMultiplier_Click(object sender, RoutedEventArgs e)
        {
            // Gets the button clicked
            Button btnSwitch = (Button)sender;

            // Iterates through the multipliers list
            foreach (Multiplier multiplier in multipliers)
            {
                // Checks if the button name matches the multiplier ID
                if (btnSwitch.Name == multiplier.Id)
                {
                    // Increases the number of the multiplier in the game
                    cookieCount -= multiplier.GameCurrentAmount;
                    UpdateButtonState();
                    multiplier.NumInGame += 1;
                    break;
                }
            }           

        }


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //multiplyMeBby.increaseCurrentAmount();


            cookieCount += (int) multiplyMeBby.GameMultiplier;

            lblCurrentCookies.Content = cookieCount;
        }

    }
}
