using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.Model;
using WcfAlarmData.ULT;
using WcfLoggerData.Action;

namespace WcfAlarmData.Action
{
    class InsertAndUpdateAlarmForLoggerAction
    {
        public int[] InsertAndUpdateAlarmForLogger()
        {
            int nRowInsert = 0;
            int nRowUpdate = 0;

            List<AlarmForLoggerViewModel> list = new List<AlarmForLoggerViewModel>();

            CheckAccreditationLoggerAction checkAccreditationLoggerAction = new CheckAccreditationLoggerAction();
            CheckYearBatteryAction checkYearBatteryAction = new CheckYearBatteryAction();

            InsertAlarmLoggerDBAction insertAlarmLoggerDBAction = new InsertAlarmLoggerDBAction();
            UpdateAlarmForLoggerDBAction updateAlarmForLoggerDBAction = new UpdateAlarmForLoggerDBAction();

            GetAllAlarmLoggerAction getAllAlarmLoggerAction = new GetAllAlarmLoggerAction();
            GetDeviceLoggerAction getDeviceLoggerAction = new GetDeviceLoggerAction();
            BinarySearch binarySearch = new BinarySearch();

            List<LoggerViewModel> listLoggers = getDeviceLoggerAction.GetLogger();
            List<AlarmForLoggerViewModel> listAlarm = getAllAlarmLoggerAction.GetAllAlarmForLogger();

            foreach(var item in listLoggers)
            {
                int resultForAccreditation = -1;
                int resultForBatteryYear = -1;
                if (item.DateAccreditation != null)
                {
                    resultForAccreditation = checkAccreditationLoggerAction.CheckAccreditationLogger(item.DateAccreditation.Value);
                    if(resultForAccreditation != -1)
                    {
                        if(resultForAccreditation == 0)
                        {
                            nRowUpdate += updateAlarmForLoggerDBAction.Update(item.Serial, 1);
                        }
                        else if(resultForAccreditation == 1)
                        {
                            AlarmForLoggerViewModel el = new AlarmForLoggerViewModel();
                            el.Serial = item.Serial;
                            el.Type = 1;
                            el.StartDate = DateTime.Now;
                            el.EndDate = null;
                            el.IsFinish = false;
                            el.Content = $"Logger {item.Serial} sắp đến hạn kiểm định";

                            int isFind = binarySearch.BinarySearchInterativeForLogger(listAlarm, el.StartDate.Value);

                            if(isFind == -1)
                            {
                                list.Add(el);
                            }
                        }
                        else if(resultForAccreditation == 2)
                        {
                            AlarmForLoggerViewModel el = new AlarmForLoggerViewModel();
                            el.Serial = item.Serial;
                            el.Type = 1;
                            el.StartDate = DateTime.Now;
                            el.EndDate = null;
                            el.IsFinish = false;
                            el.Content = $"Logger {item.Serial} quá hạn kiểm định";

                            int isFind = binarySearch.BinarySearchInterativeForLogger(listAlarm, el.StartDate.Value);

                            if (isFind == -1)
                            {
                                list.Add(el);
                            }
                        }
                    }
                }
                if(item.DateInstallBattery != null && item.YearBattery != null)
                {
                    resultForBatteryYear = checkYearBatteryAction.CheckYearBattery(item.DateInstallBattery.Value, item.YearBattery.Value);

                    if(resultForBatteryYear != -1)
                    {
                        if(resultForBatteryYear == 0)
                        {
                            nRowUpdate += updateAlarmForLoggerDBAction.Update(item.Serial, 2);
                        }
                        else if(resultForBatteryYear == 1)
                        {
                            AlarmForLoggerViewModel el = new AlarmForLoggerViewModel();
                            el.Serial = item.Serial;
                            el.Type = 2;
                            el.StartDate = DateTime.Now;
                            el.EndDate = null;
                            el.IsFinish = false;
                            el.Content = $"Logger {item.Serial} sắp đến hạn kiểm định pin";

                            int isFind = binarySearch.BinarySearchInterativeForLogger(listAlarm, el.StartDate.Value);

                            if (isFind == -1)
                            {
                                list.Add(el);
                            }
                        }
                        else if(resultForBatteryYear == 2)
                        {
                            AlarmForLoggerViewModel el = new AlarmForLoggerViewModel();
                            el.Serial = item.Serial;
                            el.Type = 2;
                            el.StartDate = DateTime.Now;
                            el.EndDate = null;
                            el.IsFinish = false;
                            el.Content = $"Logger {item.Serial} quá hạn kiểm định pin";

                            int isFind = binarySearch.BinarySearchInterativeForLogger(listAlarm, el.StartDate.Value);

                            if (isFind == -1)
                            {
                                list.Add(el);
                            }
                        }
                    }
                }
                Console.WriteLine(item.Serial);
            }

            if(list.Count != 0 )
            {
                nRowInsert = insertAlarmLoggerDBAction.Insert(list);
            }

            return new int[] { nRowInsert, nRowUpdate };
        }
    }
}
