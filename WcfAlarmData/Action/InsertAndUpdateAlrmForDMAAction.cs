using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.Model;
using WcfAlarmData.ULT;

namespace WcfAlarmData.Action
{
    class InsertAndUpdateAlrmForDMAAction
    {
        public int[] InsertAndUpdateAlarmForDMA()
        {
            int nRowInsert = 0;
            int nRowUpdate = 0;

            List<AlarmForDMAViewModel> list = new List<AlarmForDMAViewModel>();

            GetDMAAction getDMAAction = new GetDMAAction();
            CompareDiffQnetDMAAction compareDiffQnetDMAAction = new CompareDiffQnetDMAAction();
            CompareDiffQnetMonthDMAAction compareDiffQnetMonthDMAAction = new CompareDiffQnetMonthDMAAction();
            BinarySearch binarySearch = new BinarySearch();
            GetAllAlarmForDMAAction getAllAlarmForDMAAction = new GetAllAlarmForDMAAction();
            InsertAlarmForDMADBAction insertAlarmForDMADBAction = new InsertAlarmForDMADBAction();
            UpdateAlarmForDMAAction updateAlarmForDMAAction = new UpdateAlarmForDMAAction();

            List<DMAViewModel> listDMA = getDMAAction.GetDMA();
            List<AlarmForDMAViewModel> listAlarm = getAllAlarmForDMAAction.GetAllAlarmForDMA();

            foreach(var dma in listDMA)
            {
                var diffDMA = compareDiffQnetDMAAction.Compare(dma.Company);
                var diffDMAMonth = compareDiffQnetMonthDMAAction.Compare(dma.Company);

                if(diffDMA != null && diffDMA.Result.Trim() != "")
                {
                    AlarmForDMAViewModel el = new AlarmForDMAViewModel();

                    el.Company = dma.Company;
                    el.Description = dma.Description;
                    el.StartDate = DateTime.Now;
                    el.EndDate = null;
                    el.IsFinish = false;
                    el.Type = 1;
                    el.Content = "Q net theo ngày giá trị hiện taị " + diffDMA .CurrentValue.ToString() + " chênh lệch so với trung bình 3 ngày trước giá trị " + diffDMA.PrevValue.ToString();
                    el.Level = diffDMA.Result;

                    //WcfAlarmData.TA_WebReference.Map push = new TA_WebReference.Map();
                    //push.SubmitNotification(dma.Company, "Q net theo ngày giá trị hiện taị " + diffDMA.CurrentValue.ToString() + " chênh lệch so với trung bình 3 ngày trước giá trị " + diffDMA.PrevValue.ToString());

                    if (el.StartDate != null)
                    {
                        int isFind = -2;

                        isFind = binarySearch.BinarySearchInterativeForDMA(listAlarm, el.StartDate.Value);

                        if(isFind == -1)
                        {
                            list.Add(el);
                        }
                    }
                }
                else
                {
                    nRowUpdate += updateAlarmForDMAAction.Update(dma.Company, 1);
                }
                if(diffDMAMonth != null && diffDMAMonth.Result.Trim() != "")
                {
                    AlarmForDMAViewModel el = new AlarmForDMAViewModel();

                    el.Company = dma.Company;
                    el.Description = dma.Description;
                    el.StartDate = DateTime.Now;
                    el.EndDate = null;
                    el.IsFinish = false;
                    el.Type = 2;
                    el.Content = "Q net theo tháng giá trị hiện tại "+diffDMAMonth.CurrentValue.ToString() + " chênh lệch với trung bình 3 tháng trước giá trị " + diffDMAMonth.PrevValue.ToString();
                    el.Level = diffDMAMonth.Result;

                    //WcfAlarmData.TA_WebReference.Map push = new TA_WebReference.Map();
                    //push.SubmitNotification(dma.Company, "Q net theo tháng giá trị hiện tại " + diffDMAMonth.CurrentValue.ToString() + " chênh lệch với trung bình 3 tháng trước giá trị " + diffDMAMonth.PrevValue.ToString());

                    if (el.StartDate != null)

                    {
                        int isFind = -2;

                        isFind = binarySearch.BinarySearchInterativeForDMA(listAlarm, el.StartDate.Value);

                        if (isFind == -1)
                        {
                            list.Add(el);
                        }
                    }
                }
                else
                {
                    nRowUpdate += updateAlarmForDMAAction.Update(dma.Company, 2);
                }

                Console.WriteLine(dma.Company);

            }

            nRowInsert = insertAlarmForDMADBAction.Insert(list);

            return new[] { nRowInsert, nRowUpdate };

        }
    }
}
