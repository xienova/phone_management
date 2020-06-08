using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Runtime.InteropServices;   //for printer



/*
TSC打印使用 
 
 */

public class TSCLIB_DLL
{
    [DllImport("TSCLIB.dll",EntryPoint="openport")]
    public static extern int openport(string printername);

    [DllImport("TSCLIB.dll", EntryPoint = "setup")]
    public static extern int setup(string width, string height,
              string speed, string density,
              string sensor, string vertical,
              string offset);

    [DllImport("TSCLIB.dll", EntryPoint = "clearbuffer")]
    public static extern int clearbuffer();

    [DllImport("TSCLIB.dll", EntryPoint = "windowsfont")]
    public static extern int windowsfont(int x, int y, int fontheight,
     int rotation, int fontstyle, int fontunderline,
                    string szFaceName, string content);

    [DllImport("TSCLIB.dll", EntryPoint = "printlabel")]
    public static extern int printlabel(string set, string copy);

    [DllImport("TSCLIB.dll", EntryPoint = "closeport")]
    public static extern int closeport();



}




namespace PhoneSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            //Application.Run(new TCPIn());
            //Application.Run(new AdminForm());
            //Application.Run(new try1());
            //Application.Run(new UserForm());
            //Application.Run(new PhoneInfoForm());
        }
    }
}
