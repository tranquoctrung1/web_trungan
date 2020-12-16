using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommandStatus
/// </summary>
public class CommandStatus
{
	public CommandStatus()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string ErrorMessage { get; set; }
    public bool Error { get; set; }
    public bool Inserted { get; set; }
    public bool Updated { get; set; }
    public bool Deleted { get; set; }
}