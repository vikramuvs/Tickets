using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class InjectionClass
{
    public InjectionClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string convert(string str)
    {

        str = Regex.Replace(str, "select", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "insert", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "delete", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "update", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "drop", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "grant", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "script", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "truncate", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "javascript", "", RegexOptions.IgnoreCase);
        str = str.Replace("!", "");
        str = str.Replace("@", "");
        str = str.Replace("~", "");
        str = str.Replace("`", "");
        str = str.Replace("#", "");
        str = str.Replace("$", "");
        str = str.Replace("%", "");
        str = str.Replace("^", "");
        str = str.Replace("&", "");
        str = str.Replace("*", "");
        str = str.Replace("(", "");
        str = str.Replace(")", "");
        str = str.Replace("_", "");
        str = str.Replace("-", "");
        str = str.Replace("+", "");
        str = str.Replace("=", "");
        str = str.Replace("{", "");
        str = str.Replace("}", "");
        str = str.Replace("[", "");
        str = str.Replace("]", "");
        str = str.Replace("'", "");
        str = str.Replace(":", "");
        str = str.Replace(";", "");
        str = str.Replace("|", "");
        str = str.Replace("?", "");
        str = str.Replace(">", "");
        str = str.Replace("<", "");
        str = str.Replace(",", "");
        str = str.Replace("/", "");
        str = str.Replace(".", "");
        str = str.Replace("'", "");
        str = str.Replace("\"", "");
        str = str.Replace("<>", "");
        return str;
    }

    
    public string convertfilename(string str)
    {

        str = Regex.Replace(str, "select", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "insert", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "delete", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "update", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "drop", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "grant", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "script", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "truncate", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "javascript", "", RegexOptions.IgnoreCase);
        str = str.Replace("!", "");
        str = str.Replace("@", "");
        str = str.Replace("~", "");
        str = str.Replace("`", "");
        str = str.Replace("#", "");
        str = str.Replace("$", "");
        str = str.Replace("%", "");
        str = str.Replace("^", "");
        str = str.Replace("&", "");
        str = str.Replace("*", "");
        //str = str.Replace("(", "");
        //str = str.Replace(")", "");
        str = str.Replace("_", "");
        str = str.Replace("-", "");
        str = str.Replace("+", "");
        str = str.Replace("=", "");
        str = str.Replace("{", "");
        str = str.Replace("}", "");
        str = str.Replace("[", "");
        str = str.Replace("]", "");
        str = str.Replace("'", "");
        str = str.Replace(":", "");
        str = str.Replace(";", "");
        str = str.Replace("|", "");
        str = str.Replace("?", "");
        str = str.Replace(">", "");
        str = str.Replace("<", "");
        str = str.Replace(",", "");
       // str = str.Replace("/", "");
        //str = str.Replace(".", "");
        str = str.Replace("'", "");
        str = str.Replace("\"", "");
        str = str.Replace("<>", "");
        return str;
    }

    
    public string convertDate(string str)
    {

        str = Regex.Replace(str, "select", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "insert", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "delete", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "update", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "drop", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "grant", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "script", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "truncate", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "javascript", "", RegexOptions.IgnoreCase);
        str = str.Replace("!", "");
        str = str.Replace("@", "");
        str = str.Replace("~", "");
        str = str.Replace("`", "");
        str = str.Replace("#", "");
        str = str.Replace("$", "");
        str = str.Replace("%", "");
        str = str.Replace("^", "");
        str = str.Replace("&", "");
        str = str.Replace("*", "");
        str = str.Replace("(", "");
        str = str.Replace(")", "");
        str = str.Replace("_", "");
        str = str.Replace("-", "");
        str = str.Replace("+", "");
        str = str.Replace("=", "");
        str = str.Replace("{", "");
        str = str.Replace("}", "");
        str = str.Replace("[", "");
        str = str.Replace("]", "");
        str = str.Replace("'", "");
        str = str.Replace(":", "");
        str = str.Replace(";", "");
        str = str.Replace("|", "");
        str = str.Replace("?", "");
        str = str.Replace(">", "");
        str = str.Replace("<", "");
        str = str.Replace(",", "");
        str = str.Replace(".", "");
        str = str.Replace("'", "");
        str = str.Replace("\"", "");
        str = str.Replace("<>", "");
        return str;
    }

    public string fbMsg(string str)
    {
        str = Regex.Replace(str, "select", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "insert", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "delete", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "update", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "drop", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "grant", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "script", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "truncate", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "javascript", "", RegexOptions.IgnoreCase);
        str = str.Replace("!", "");
        str = str.Replace("~", "");
        str = str.Replace("`", "");
        str = str.Replace("#", "");
        str = str.Replace("$", "");
        str = str.Replace("%", "");
        str = str.Replace("^", "");
        str = str.Replace("&", "");
        str = str.Replace("*", "");
        //str = str.Replace("(", "");
        //str = str.Replace(")", "");
        str = str.Replace("_", "");
        str = str.Replace("-", "");
        str = str.Replace("+", "");
        str = str.Replace("=", "");
        str = str.Replace("{", "");
        str = str.Replace("}", "");
        str = str.Replace("[", "");
        str = str.Replace("]", "");
        str = str.Replace("'", "");
        str = str.Replace(":", "");
        //str = str.Replace(";", "");
        str = str.Replace("|", "");
        //str = str.Replace("?", "");
        str = str.Replace(">", "");
        str = str.Replace("<", "");
        //str = str.Replace(",", "");
        str = str.Replace("/", "");
        //str = str.Replace(".", "");
        //str = str.Replace("'", "");
        str = str.Replace("\"", "");
        str = str.Replace("<>", "");
        return str;
    }

    public string convertEmail(string str)
    {
        str = Regex.Replace(str, "select", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "insert", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "delete", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "update", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "drop", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "grant", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "script", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "truncate", "", RegexOptions.IgnoreCase);
        str = Regex.Replace(str, "javascript", "", RegexOptions.IgnoreCase);
        str = str.Replace("!", "");
        //str = str.Replace("@", "");
        str = str.Replace("~", "");
        str = str.Replace("`", "");
        str = str.Replace("#", "");
        str = str.Replace("$", "");
        str = str.Replace("%", "");
        str = str.Replace("^", "");
        str = str.Replace("&", "");
        str = str.Replace("*", "");
        str = str.Replace("(", "");
        str = str.Replace(")", "");
        str = str.Replace("_", "");
        str = str.Replace("-", "");
        str = str.Replace("+", "");
        str = str.Replace("=", "");
        str = str.Replace("{", "");
        str = str.Replace("}", "");
        str = str.Replace("[", "");
        str = str.Replace("]", "");
        str = str.Replace("'", "");
        str = str.Replace(":", "");
        str = str.Replace(";", "");
        str = str.Replace("|", "");
        str = str.Replace("?", "");
        str = str.Replace(">", "");
        str = str.Replace("<", "");
        str = str.Replace(",", "");
        //str = str.Replace(".", "");
        str = str.Replace("'", "");
        str = str.Replace("\"", "");
        str = str.Replace("<>", "");
        return str;
    }
}
