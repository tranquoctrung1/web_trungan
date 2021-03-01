using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for t_Users
/// </summary>
public class t_Users
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public string StaffId { get; set; }
    public string Role { get; set; }
    public Nullable<bool> Active { get; set; }
    public Nullable<System.DateTime> TimeStamp { get; set; }
    public string Ip { get; set; }
    public Nullable<int> LogCount { get; set; }

    public Nullable<byte> Zoom { get; set; }

    public string Company { get; set; }

    public string Language { get; set; }

}
