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
using RosSharp.RosBridgeClient;
namespace Agvlaser
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(listen);
            thread.Start();
        }

        private void listen()
        {
            RosSocket rosSocket = new RosSocket("ws://192.168.1.125:9090");
            //string subscription_id = rosSocket.Subscribe("odom", "nav_msgs/Odometry", subscriptionHandler);
            string subscription_id = rosSocket.Subscribe("/amcl_pose", "geometry_msgs/PoseWithCovarianceStamped", subscriptionHandler);
                                                                        
            Console.WriteLine("Press any key to close...");

            while (true)
            {
                Thread.Sleep(10);
            }
            // rosSocket.Close();
        }

        private void subscriptionHandler(Message message)
        {
            //NavigationOdometry standardString = (NavigationOdometry)message;
            GeometryPoseWithCovarianceStamped standardString = (GeometryPoseWithCovarianceStamped)message;
            //this.Dispatcher.Invoke(new Action(delegate
            //{
            //    mytextbox.Text = "X:" + standardString.pose.pose.position.x.ToString() + "\r\n";
            //    mytextbox.Text += "Y:" + standardString.pose.pose.position.y.ToString() + "\r\n";
            //    mytextbox.Text += "Z:" + standardString.pose.pose.position.z.ToString() + "\r\n";
            //}));
        }
    }
}
