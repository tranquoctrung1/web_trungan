using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WcfAlarmData.Action;
using System.Runtime.InteropServices;

namespace WcfAlarmData
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static void Main(string[] args)
        {

            const int SW_HIDE = 0;
            const int SW_SHOW = 5;

            var handle = GetConsoleWindow();

            // Hide
            ShowWindow(handle, SW_HIDE);

            // Show
            //ShowWindow(handle, SW_SHOW);

            // Create a Timer object that knows to call our TimerCallback
            // method once every 2000 milliseconds.
            Timer t = new Timer(TimerCallback, null, 0, 1000 * 60 * 120);
            // Wait for the user to hit <Enter>
            Console.ReadLine();

        }

        private static void TimerCallback(Object o)
        {
            // Display the date/time when this method got called.
            Console.WriteLine("Program is running in : " + DateTime.Now);

            //action for alarm
            AlarmForPoint();
            AlarmForLogger();
            AlarmForDMA();

            Console.WriteLine("Running done in : " + DateTime.Now +". Please waiting to next time");


            // Force a garbage collection to occur for this demo.
            GC.Collect();
        }

        static private void AlarmForPoint()
        {
            // alarm for point
            InsertAndUpdateAlarmPointAction insertAction = new InsertAndUpdateAlarmPointAction();

            int[] resultAlarmForPointAction = insertAction.InsertAndUpdateAlarmPoint();

            int nRowInsert = resultAlarmForPointAction[0];
            int nRowUpdate = resultAlarmForPointAction[1];

            Console.WriteLine($"The Rows Insert is: {nRowInsert}");
            Console.WriteLine($"The Rows Update is: {nRowUpdate}");

        }

        static private void AlarmForLogger()
        {
            // alarm for logger
            InsertAndUpdateAlarmForLoggerAction insertAndUpdateAlarmForLoggerAction = new InsertAndUpdateAlarmForLoggerAction();

            int[] resultAlarmForLoggerAction = insertAndUpdateAlarmForLoggerAction.InsertAndUpdateAlarmForLogger();

            int nRowInsertForLogger = resultAlarmForLoggerAction[0];
            int nRowUpdateForLogger = resultAlarmForLoggerAction[1];

            Console.WriteLine($"The Rows Insert For Logger is: {nRowInsertForLogger}");
            Console.WriteLine($"The Rows Update For Logger is: {nRowUpdateForLogger}");
        }

        static private void AlarmForDMA()
        {

            // alarm for dma

            InsertAndUpdateAlrmForDMAAction insertAndUpdateAlrmForDMAAction = new InsertAndUpdateAlrmForDMAAction();

            int[] resultAlarmForDMAAction = insertAndUpdateAlrmForDMAAction.InsertAndUpdateAlarmForDMA();

            int nRowInsertForDMA = resultAlarmForDMAAction[0];
            int nRowUpdateForDMA = resultAlarmForDMAAction[1];


            Console.WriteLine($"The Rows Insert For DMA is: {nRowInsertForDMA}");
            Console.WriteLine($"The Rows Update For DMA is: {nRowUpdateForDMA}");
        }
    }
}
