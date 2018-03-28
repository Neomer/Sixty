using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sixty.Helpers
{
    public static class TR
    {
        public static string T(string key)
        {
            return key;
        }

        public static string T(string key, string arg)
        {
            return key.Replace("%1", arg);
        }

        public static string T(string key, string arg1, string arg2)
        {
            return key.Replace("%1", arg1).Replace("%2", arg2);
        }

        public static string T(string key, string arg1, string arg2, string arg3)
        {
            return key.Replace("%1", arg1).Replace("%2", arg2).Replace("%3", arg3);
        }
    }
}