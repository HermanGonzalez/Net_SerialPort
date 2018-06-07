using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
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

namespace serial_connection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Serial port variable
        private SerialPort _port;
        
        public MainWindow()
        {

            _port = new SerialPort();
            InitializeComponent();
        }

        private void btnGreen_Click(object sender, RoutedEventArgs e)
        {
            SerialMessage("green");
        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            SerialMessage("red");
        }

        private void SerialMessage(string message) {
            //if the port is open the message can be send
            if (_port != null && _port.IsOpen)
            {
                _port.Write(message);
            }
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            //Verify that the port isnt opened yet 
            if (_port != null && !_port.IsOpen) {
                _port.PortName = "com5"; //the port name must be change to the one connected Arduino
                _port.BaudRate = 9600;   
                _port.DataReceived += _port_DataReceived; // Event listener for the message comming from the arduino
                _port.Open();
            }
        }

        private void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            var indata = sp.ReadExisting();
            if (indata == "open") {
                MessageBox.Show("Hello!!!!");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (_port != null && _port.IsOpen) {
                _port.Close();
            }
        }

        private void btnYellow_Click(object sender, RoutedEventArgs e)
        {
            SerialMessage("yellow");
        }

        private void btnOff_Click(object sender, RoutedEventArgs e)
        {
            SerialMessage("off");
        }
    }
}
