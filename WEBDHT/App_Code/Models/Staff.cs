using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Staff
/// </summary>
public class Staff
{
    private string id;
    private string firstName;
    private string lastName;
    private string uid;

    public string Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string FirstName
    {
        get
        {
            return firstName;
        }

        set
        {
            firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return lastName;
        }

        set
        {
            lastName = value;
        }
    }

    public string Uid
    {
        get
        {
            return uid;
        }

        set
        {
            uid = value;
        }
    }
}