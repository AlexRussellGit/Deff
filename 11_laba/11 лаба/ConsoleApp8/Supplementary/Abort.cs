using System;
using System.Runtime.InteropServices;

namespace ConsoleApp8
{
    class Abort
    {
        public static void CatchAbort()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);
        }

        protected static void myHandler(object sender, ConsoleCancelEventArgs args)
        {
            args.Cancel = true;
            if (Program.current_login != string.Empty)
            {
                Logs.LogOut(Program.current_login, Program.user_id, " (CLOSED APP)");
            }
            args.Cancel = false;
        }
    }
}
