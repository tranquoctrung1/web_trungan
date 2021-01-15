using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for District
/// </summary>
public class District
{
    string idDistrict;
    string name;
    string description;

    public District()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string IdDistrict
    {
        get
        {
            return idDistrict;
        }

        set
        {
            idDistrict = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }

        set
        {
            description = value;
        }
    }
}