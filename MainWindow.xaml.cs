using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using FeladatokKezelese.Data.Class;

namespace FeladatokKezelese
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Tasks> TaskList = new ObservableCollection<Tasks>();
        public MainWindow()
        {
            InitializeComponent();

            TaskList.Add(new Tasks() {StartYear = 2020, StartMonth = 04, StartDay = 12, StartHour = 11, TaskPeriod = 7, 
                TaskName = "Garden Management", TaskDescription = "Managing my garden" });
            TaskList.Add(new Tasks() {StartYear = 2020, StartMonth = 04, StartDay = 12, StartHour = 11, TaskPeriod = 7, 
                TaskName = "Emptying the attic", TaskDescription = "Litter removal and preparation" });
            TaskList.Add(new Tasks() {StartYear = 2020, StartMonth = 04, StartDay = 12, StartHour = 11, TaskPeriod = 7, 
                TaskName = "Empty cellar", TaskDescription = "Dismantling and preparation of the cellar" });
            TaskList.Add(new Tasks() {StartYear = 2020, StartMonth = 04, StartDay = 12, StartHour = 11, TaskPeriod = 7, 
                TaskName = "Blender", TaskDescription = "Learning Blender, preparing for Unity" });
            TaskList.Add(new Tasks() {StartYear = 2020, StartMonth = 04, StartDay = 12, StartHour = 11, TaskPeriod = 7, 
                TaskName = "Flowchart Designing", TaskDescription = "Planning for ''Darwin's Mistake''" });

            LBO_TaskList.ItemsSource = TaskList;

            SP_10.Visibility = Visibility.Hidden;

        }

        private void BTN_NewTask_Click(object sender, RoutedEventArgs e)
        {
            if (LBO_TaskList.SelectedItem != null)
            {
                LBO_TaskList.SelectedItem = null;
            }
            SP_10.Visibility = Visibility.Visible;
            SP_10.DataContext = new Data.Class.Tasks();
        }

        private void BTN_EditTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_DeleteTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            NewTask();
            LBO_TaskList.ItemsSource = TaskList;
        }

        private void BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            TBO_StartYear.Text = null;
            TBO_StartMonth.Text = null;
            TBO_StartDay.Text = null;
            TBO_StartHour.Text = null;    
            TBO_TaskPeriod.Text = null;
            TBO_TaskName.Text = null;
            TBO_TaskDescription.Text = null;
            SP_10.Visibility= Visibility.Hidden;
        }

        public void  NewTask()
        {


            if (string.IsNullOrEmpty(TBO_StartYear.Text))
            {
                TBO_StartYear.Text = DateTime.Now.Year.ToString();
            }
            else
            {
                if (string.IsNullOrEmpty(TBO_StartMonth.Text))
                {
                    TBO_StartMonth.Text = DateTime.Now.Month.ToString();
                }
                else
                {
                    if (string.IsNullOrEmpty(TBO_StartDay.Text))
                    {
                        TBO_StartDay.Text = DateTime.Now.Day.ToString();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(TBO_StartHour.Text))
                        {
                            TBO_StartHour.Text = DateTime.Now.Hour.ToString();
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(TBO_TaskPeriod.Text))
                            {
                                TBO_TaskPeriod.Foreground = Brushes.Red;
                                TBO_TaskPeriod.Text= "Kötelező Kitölteni";
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(TBO_TaskName.Text))
                                {
                                    TBO_TaskPeriod.Foreground = Brushes.Red;
                                    TBO_TaskPeriod.Text = "Kötelező Kitölteni";
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(TBO_TaskDescription.Text))
                                    {
                                        TBO_TaskPeriod.Foreground = Brushes.Red;
                                        TBO_TaskPeriod.Text = "Kötelező Kitölteni";
                                    }
                                    else
                                    {
                                        TaskList.Add(new Tasks()
                                        { 
                                            StartYear = Convert.ToInt32(TBO_StartYear.Text),
                                            StartMonth = Convert.ToInt32(TBO_StartMonth.Text),
                                            StartDay = Convert.ToInt32(TBO_StartDay.Text),
                                            StartHour = Convert.ToInt32(TBO_StartHour.Text),
                                            TaskPeriod = Convert.ToInt32(TBO_TaskPeriod.Text),
                                            TaskName = TBO_TaskName.Text,
                                            TaskDescription = TBO_TaskDescription.Text,
                                        });
                                        LBO_TaskList.ItemsSource = TaskList;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
