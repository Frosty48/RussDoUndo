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
using static RussInventoryCommandPattern.InventoryCommandPattern;

namespace RussInventoryCommandPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        List<InventoryItem> inventoryItems = new List<InventoryItem>();

        List<IInventoryCommand> commands = new List<IInventoryCommand>();


        public MainWindow()
        {
            InitializeComponent();
        }
        private int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(1, 101); // Generates a random number between 1 and 5
        }

        private void btnAddOneItem_Click(object sender, RoutedEventArgs e)
        {
            string itemName = txbItemName.Text;         
            if (!string.IsNullOrEmpty(itemName))
            {
                InventoryItem newItem = new InventoryItem(itemName);
                AddOneCommand addOneCommand = new AddOneCommand(newItem, inventoryItems);
                addOneCommand.Do();
                commands.Add(addOneCommand);

                // Assuming listBoxItems is your ListBox control
                listbInventoryList.Items.Clear(); // Clear existing items in the ListBox

                // Iterate through inventoryItems and add item names to the ListBox
                foreach (InventoryItem item in inventoryItems)
                {
                    listbInventoryList.Items.Add(item.Name); // Add item names to the ListBox
                }
            }

        }

        private void btnAdRandomNumber_Click(object sender, RoutedEventArgs e)
        {

            Random rand = new Random();
            int randomNumber = GenerateRandomNumber(); // Generates a random number between 1 and 100 (adjust the range as needed)

            // Add the random number to the ListBox
            listbInventoryList.Items.Add(randomNumber);
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {

            if (commands.Count > 0)
            {
                int lastIndex = commands.Count - 1;

                // Undo the last command
                IInventoryCommand lastCommand = commands[lastIndex];
                lastCommand.Undo();

                // Remove the last command from the commands list
                commands.RemoveAt(lastIndex);

                // Remove the last item from the ListBox
                if (listbInventoryList.Items.Count > 0)
                {
                    listbInventoryList.Items.RemoveAt(listbInventoryList.Items.Count - 1);
                }
                else
                {
                    Console.WriteLine("No items in the ListBox to undo.");
                    // Handle this case based on your application's requirements
                }
            }
            else
            {
                Console.WriteLine("No commands to undo.");
                // Handle this case based on your application's requirements
            }

    

        }
    }

}     
    
