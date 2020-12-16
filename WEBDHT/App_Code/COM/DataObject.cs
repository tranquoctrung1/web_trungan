using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataObject
/// </summary>
/// 
[System.ComponentModel.DataObject]
public class DataObject
{
    public DataObject()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<DOYN> ListYN()
    {
        List<DOYN> list = new List<DOYN>();
        DOYN y = new DOYN();
        y.Display = "Y";
        y.Value = true;
        DOYN n = new DOYN();
        n.Display = "N";
        n.Value = false;
        list.Add(y);
        list.Add(n);
        return list;
    }
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<string> ListAccreditationTypes()
    {
        string[] array = new string[] {
            "Kiểm định đồng hồ",
            "Thay đồng hồ", 
            "Thay bộ hiển thị", 
            "Thay logger", 
            "Thay acquy", 
            "Thay pin bộ hiển thị", 
            "Thay pin logger" };
        return array.ToList();
    }
    [System.ComponentModel.DataObjectMethod
    (System.ComponentModel.DataObjectMethodType.Select, true)]
    public List<string> ListChangeTypes()
    {
        string[] array = new string[] {
            "Thay đồng hồ", 
            "Thay bộ hiển thị", 
            "Thay logger", 
            "Thay acquy", 
            "Thay pin bộ hiển thị", 
            "Thay pin logger" };
        return array.ToList();
    }
}
public class DOYN
{
    public string Display { get; set; }
    public bool Value { get; set; }
}