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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        //public static void show(string message)  
        //{  
        //    MessageBox.Show(message);
        //} 
        private void Cac_Click(object sender, RoutedEventArgs e)
        {
            this.Calc_Address();
        }
        public bool Calc_Address()
        {
            char[] adList = new char[16];
            byte[] byteArray = new byte[1];
            CoreCalc coreCalcInt = new CoreCalc();

            adList[0] = (A15_ComboBox.Text.ToCharArray()[0]);
            adList[1] = (A14_ComboBox.Text.ToCharArray()[0]);
            adList[2] = (A13_ComboBox.Text.ToCharArray()[0]);
            adList[14] = (A1_ComboBox.Text.ToCharArray()[0]);
            adList[15] = (A0_ComboBox.Text.ToCharArray()[0]);


            SetClrA12_A3('0', adList);
            byteArray = coreCalcInt.CharToByte(adList);
            string First = coreCalcInt.ToHexString(byteArray);

            SetClrA12_A3('1', adList);
            byteArray = coreCalcInt.CharToByte(adList);
            string Last = coreCalcInt.ToHexString(byteArray);

            First_Text.Text = First;
            Last_Text.Text = Last;
            return true;
        }

        public void SetClrA12_A3(char flag, char[] str)
        {
            for (int i = 0; i < 11; i++)
            {
                str[3 + i] = flag;
            }
        }
    }
}
