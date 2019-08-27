using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SQLConnTst
{
    public enum AuthenticationType
    {[Display(Name ="Active Directory Password")]
        ActiveDirectoryPassword,
        [Display(Name = "SQL Credentials")]
        SQLCredentials
    }


}

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()
                        .GetName();
    }
}