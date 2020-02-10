using Band_Scheduler.Models;
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
using System.Web;

namespace Band_Scheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int amountOfTabs = 0;
        
        
        // Get the already existing controls in the form
        public MainWindow()
        {
            InitializeComponent();
            

            RenderDayTabs();
        } 
        /// <summary>
        /// This function calculates how many tabs need to be rendered
        /// </summary>
        public int CalculateDayTabAmount()
        {
            // get the data
            Stage[] stages = new Stage[5];
            Performer[] performers = new Performer[5];
            Performance[] performances = new Performance[5];
            for (int i = 0; i < stages.Length; i++)
            {
                stages[i] = new Stage
                {
                    Id = i,
                    Name = "stage" + i
                };
                performers[i] = new Performer
                {
                    Id = i,
                    Name = "performer " + i,
                    Description = "very good band" + i
                };
                performances[i] = new Performance
                {
                    Id = 1,
                    Performer = performers[i],
                    Stage = stages[i],
                    StartDateTime = DateTime.UtcNow.AddHours(i),
                    EndDateTime = DateTime.UtcNow.AddHours(i + 1)
                };
            }
            DayOfWeek lastTabDay = performances[0].EndDateTime.DayOfWeek;
            foreach (Performance performance in performances)
            {
                if (performance.EndDateTime.DayOfWeek != lastTabDay)
                {
                    amountOfTabs++;
                    lastTabDay = performance.EndDateTime.DayOfWeek;
                }
            }
            // calculate the amount of tabs
            return amountOfTabs;
        }
        /// <summary>
        /// This function renders all stages
        /// </summary>
        public void RenderStages()
        {

        }
        /// <summary>
        /// This function renders the day tabs
        /// </summary>
        public void RenderDayTabs()
        {
            TabControl tabControl = (TabControl)FindName("TabDays");
            Console.WriteLine(tabControl.Items.Count);

            TabItem[] tabItems = new TabItem[5];
            int amountOfTabs = CalculateDayTabAmount();
            // render the tabs for the amount of tabs
            for (int i = 0; i <= amountOfTabs; i++)
            {
                tabItems[i] = new TabItem {
                    Name = "dag" + i,
                    Header = "dag " + i,
                };
                tabControl.Items.Add(tabItems[i]);
                tabItems[i].Content = "test";
            }
        }
    }
}
