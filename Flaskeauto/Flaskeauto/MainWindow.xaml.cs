using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Flaskeauto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Threads

            Thread splitter = new Thread(Splitter.SplitterQ);
            Thread beercons = new Thread(Consumer.BeerConsumer);

            // Thread start

            splitter.Start();
            beercons.Start();





            Console.Read();
        }

        private void DrinkViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            Flaskeauto.ViewModel. studentViewModelObject =
            new MVVMDemo.ViewModel.StudentViewModel();
            studentViewModelObject.LoadStudents();

            StudentViewControl.DataContext = studentViewModelObject;
        }
            
            


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 11; i++)
            {
                Unsorted_lbl.Content = Starter.drinks.Count;
                Beerlbl.Content = Starter.beers.Count;
                Sodalbl.Content = Starter.sodas.Count;
                Thread.Sleep(200);
            }
           
            

            




        }
    }
}
