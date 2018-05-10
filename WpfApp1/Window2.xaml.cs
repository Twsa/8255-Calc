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
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        public bool Calc_ControlWord()
        {
            char[] cnWordList = new char[8];
            byte[] byteArray = new byte[1];
            CoreCalc coreCalcInt = new CoreCalc();

            cnWordList[0] = (D7_ComboBox.Text.ToCharArray()[0]);
            cnWordList[1] = (D6_ComboBox.Text.ToCharArray()[0]);
            cnWordList[2] = (D5_ComboBox.Text.ToCharArray()[0]);
            cnWordList[3] = (D4_ComboBox.Text.ToCharArray()[0]);
            cnWordList[4] = (D3_ComboBox.Text.ToCharArray()[0]);
            cnWordList[5] = (D2_ComboBox.Text.ToCharArray()[0]);
            cnWordList[6] = (D1_ComboBox.Text.ToCharArray()[0]);
            cnWordList[7] = (D0_ComboBox.Text.ToCharArray()[0]);


            byteArray = coreCalcInt.CharToByte(cnWordList);
            string calcResult = coreCalcInt.ToHexString(byteArray);
            Control_Word.Text = calcResult;
            return true;
        }
        private  void Control_Word_Click(object sender, RoutedEventArgs e)
        {
            this.Calc_ControlWord();
        }       
    }
}
