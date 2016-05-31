using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class RegexClass
{
    //n以外の連続して続くアルファベット
    public static readonly string exceptingN = @"([a-mo-z])\1";

    //先頭に文字列"ts"を含むアルファベット
    public static readonly string startStringTs = @"^ts";

    //先頭に文字列"xts"を含むアルファベット
    public static readonly string startStringXts = @"xts";
}
