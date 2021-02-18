using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.Action;

namespace WcfAlarmData
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertAndUpdateAlarmPointAction insertAction = new InsertAndUpdateAlarmPointAction();

            int[] resultAlarmForPointAction = insertAction.InsertAndUpdateAlarmPoint();

            int nRowInsert = resultAlarmForPointAction[0];
            int nRowUpdate = resultAlarmForPointAction[1];

            Console.WriteLine($"The Rows Insert is: {nRowInsert}");
            Console.WriteLine($"The Rows Update is: {nRowUpdate}");

            //InsertAndUpdateAlarmForLoggerAction insertAndUpdateAlarmForLoggerAction = new InsertAndUpdateAlarmForLoggerAction();

            //int[] resultAlarmForLoggerAction = insertAndUpdateAlarmForLoggerAction.InsertAndUpdateAlarmForLogger();

            //int nRowInsertForLogger = resultAlarmForLoggerAction[0];
            //int nRowUpdateForLogger = resultAlarmForLoggerAction[1];

            //Console.WriteLine($"The Rows Insert For Logger is: {nRowInsertForLogger}");
            //Console.WriteLine($"The Rows Update For Logger is: {nRowUpdateForLogger}");
        }
    }
}