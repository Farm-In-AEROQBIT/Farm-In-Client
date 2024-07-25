using System;
using System.Windows.Forms;

namespace Farm_In_Client
{
    static class Program
    {
        [MTAThread]
        static void Main()
        {
            Application.Run(new LoginForm());
        }
    }
}
