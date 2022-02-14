using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianSyncConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BackgroundService bc = new BackgroundService();
            bc.Star();
        }

    }
}
