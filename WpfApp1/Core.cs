using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Controls;


namespace WpfApp1
{
    public  class CoreCalc
    {
        /// <summary>
        /// Char 类型数组转化类byte数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public byte[] CharToByte(char[] str)
        {
            int tmp = 0x00;
            byte byteTmp = 0x00;
            int iTmp = (str.Length)/8;
            byte[] byteLast = new byte[iTmp];
            for (int i = 0; i < iTmp; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    byteTmp = (byte)(str[i * 8 + j] - '0');
                    byteTmp <<= (7 - j);
                    tmp = (byte)tmp | byteTmp;
                }
                byteLast[i] = (byte)tmp;
                byteTmp = 0x00;
                tmp = 0x00;
            }
            return byteLast;
        }
        /// <summary>
        /// 0xae00cf => "AE00CF " 字符串的长度可变
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public  string ToHexString(byte[] bytes) 
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }
    }

}
