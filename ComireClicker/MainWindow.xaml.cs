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
        List<Multiplier> multipliers = new List<Multiplier>();
        List<Multiplier> activeMultipliers = new List<Multiplier>();

        Multiplier mutiplyMeBby = new Multiplier("btnClick", "click", "", 1, 0, 1, 1, true);

        double gameMultiplier = 1;


        public MainWindow()
        {
            InitializeComponent();

            CreateMultipliersInstances();

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }


        //  DispatcherTimer setup
 

    private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Updating the Label which displays the current second
            txtMultiplier.Content = gameMultiplier.ToString();


            // Iterate over all the multpliers
            // Get the current multiploer

            
            foreach (var multiplier in multipliers)
            {
                double currentMulti = 0;
                if (multiplier.IsUnlocked)
                {                    
                    for(int i = 0; i < multiplier.NumInGame; i++)
                    {
                        currentMulti += multiplier.GameMultiplier;
                    }
                }

                gameMultiplier += currentMulti;
                
                // Get the current multiplier
              //  multiplier.NumInGame;

            }

            int.TryParse(lblCurrentCookies.Content.ToString(), out int currentAmount);


            lblCurrentCookies.Content = currentAmount * gameMultiplier;

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }


        private void CreateMultipliersInstances()
        {
            // CLEAR THE ARRAY FOR UR MOMS PURPOSES
            multipliers.Clear();
                                         //  id,       name,        imageURI,     gameMultiplier, startCost, costIncrease, numInGame, isUnlocked
            multipliers.Add(new Multiplier("btnMaple", "Maple-Leaf", "MapleLeaf", 0.1,             0,        10,             0, true));
            multipliers.Add(new Multiplier("btnShull", "Shull-er", "", 1, 100, 15, 0, true));
            multipliers.Add(new Multiplier("btnCox", "Cox-ifer", "", 5, 500, 50, 0, false));
            multipliers.Add(new Multiplier("btnBear", "Beardall-er", "", 15, 1000, 100, 0, false));
            multipliers.Add(new Multiplier("btnFox", "Fox-ifyer", "", 25, 1500, 300, 0, false));
            multipliers.Add(new Multiplier("btnBurk", "Berk-inator", "", 50, 5000, 600, 0, false));
            multipliers.Add(new Multiplier("btnCantera", "Cantera-ina", "", 100, 5000, 600, 0, false));
            multipliers.Add(new Multiplier("btnKohler", "Kohler-inator-3000", "", 150, 5000, 600, 0, false));
            multipliers.Add(new Multiplier("btnSarah", "Sarah-bella", "", 250, 5000, 600, 0, false));
            multipliers.Add(new Multiplier("btnMarshall", "Marshall-ina", "", 500, 5000, 600, 0, false));
            multipliers.Add(new Multiplier("btnPritchard", "Pritchard-nator", "", 1000, 5000, 600, 0, false));
            multipliers.Add(new Multiplier("btnParker", "Parker-Dator", "", 12000, 5000, 600, 0, false));
            multipliers.Add(new Multiplier("btnComireTwo", "Coal-Miner", "", 15000, 5000, 600, 0, false));

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

                button.Name = multiplier.Id;
                
                button.Content = grid;
                button.IsEnabled = multiplier.IsUnlocked;
                //button.Click += new EventHandler(this.btnMultiplier_Click);
                button.Click += btnMultiplier_Click;
                button.Padding = new Thickness(5);
                listOfMultipliers.Children.Add(button);
            }

            //mutiplyMeBby = multipliers[0];/
        }

        protected void btnMultiplier_Click(object sender, RoutedEventArgs e)
        {
            Button btnSwitch = (Button)sender;
            //int content = Convert.ToInt32(button.Content);
            
            switch (btnSwitch.Name)
            {
                case "btnMaple":
                    multipliers[0].NumInGame += 1;
                    gameMultiplier += multipliers[0].GameMultiplier;
                    break;
            }

            GenerateMultiperButtons();

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mutiplyMeBby.increaseCurrentAmount();

            int.TryParse(lblCurrentCookies.Content.ToString(), out int currentAmount);


            lblCurrentCookies.Content = currentAmount + 1;

           // lblCurrentCookies.Content = mutiplyMeBby.GameCurrentAmount.ToString();
           // txtMultiplier.Content = mutiplyMeBby.GameCurrentAmount.ToString();
        }

        /*
         * 
         * ON CLICK
         * multipler.increaseCurrentAmount();
         */
    }
}
