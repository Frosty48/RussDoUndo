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
            return random.Next(1, 6); // Generates a random number between 1 and 5
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


            }
        }

        private void btnAdRandomNumber_Click(object sender, RoutedEventArgs e)
        {
            
                string itemName = txbItemName.Text;
                if (!string.IsNullOrEmpty(itemName))
                {
                    // Create a new inventory item
                    InventoryItem newItem = new InventoryItem(itemName);

                    // Assuming you have a method to generate a random number of items (Replace GenerateRandomNumber() with your method)
                    int numberOfItemsToAdd = GenerateRandomNumber();

                    // Instantiate AddMultipleCommand object with the new inventory item and inventoryItems list
                    AddMultipleCommand addMultipleCommand = new AddMultipleCommand(  numberOfItemsToAdd,newItem);

                    // Execute the command's Do method to add a random number of items
                    addMultipleCommand.Do();

                    // Add the command to the commands list
                    commands.Add(addMultipleCommand);
                }
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
                if (commands.Count > 0)
                {
                    int lastIndex = commands.Count - 1;
                    commands[lastIndex].Undo();
                    commands.RemoveAt(lastIndex);

                IInventoryCommand lastCommand = commands.Last();

                //// Call the Undo method for the last command
                lastCommand.Undo();

                //// Remove the last command from the commands list
                commands.Remove(lastCommand);
                }
         }

        
    }
}
