using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Drawing;
namespace FolderAnalizer
{

    class Globals
    {

        public static bool IsRunning = false;

        private static string GetAppDir()
        {
            char[] sep = { '\\' };
            string[] elements = Application.ExecutablePath.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            string res = "";

            for (int i = 0; i < elements.Length - 1; i++)
            {
                res += elements[i] + "\\";
            }
            return res;
        }
        private static string ReverseStr(string s)
        {
            string Result = "";
            for (int i = 0; i < s.Length; i++)
            {
                Result = Result + s[s.Length - i - 1];
            }
            return Result;
        }

        public static string Int64ToSepratedForm(string Integer)
        {
            if (Integer.Length == 0) return "Null!";
            if (Integer[0] == '-') return "Negative!";
            string s = ReverseStr(Integer);
            string Result = "";
            for (int i = 0; i < s.Length; i++)
            {
                if ((((i) % 3) == 0) && (i != 0))
                {
                    Result = Result + "," + Convert.ToString(Convert.ToUInt16(s[i].ToString()));
                }
                else
                {
                    Result = Result + Convert.ToString(Convert.ToUInt16(s[i].ToString()));
                }
            }
            return ReverseStr(Result);
        }

        public static string Int64ToSepratedForm(long Integer)
        {
            string s = ReverseStr(Integer.ToString());
            string Result = "";
            for (int i = 0; i < s.Length; i++)
            {
                if ((((i) % 3) == 0) && (i != 0))
                {
                    Result = Result + "," + Convert.ToString(Convert.ToUInt16(s[i].ToString()));
                }
                else
                {
                    Result = Result + Convert.ToString(Convert.ToUInt16(s[i].ToString()));
                }
            }
            return ReverseStr(Result);
        }
        public static string SepratedFormToIntstr(string s)
        {
            string Result = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',')
                {
                }
                else
                {
                    Result = Result + s[i];
                }
            }
            return Result;
        }

        public static string GetRunnigProc()
        {
            System.Diagnostics.Process[] prr = System.Diagnostics.Process.GetProcesses();
            string s = "";
            foreach (System.Diagnostics.Process prrr in prr)
            {
                s += prrr.ProcessName + "\n";
            }
            return s;
        }

        public static Process AddToArchieve(string SourceList, string ArchiveFileName, string Password, string Type)
        {
            if (Type == "7z")
            {
                return Process.Start(@"C:\7za.exe", "a " + ArchiveFileName + " -t7z -mhe -p" + Password + " " + SourceList);
            }
            else if (Type == "zip")
            {
                return Process.Start(@"C:\7za.exe", "a " + ArchiveFileName + " -tzip -p" + Password + " " + SourceList);
            }
            else return null;
        }

        public static string AddZeroToleft(int Number, int DigitsCount)
        {
            string res = Number.ToString();
            for (int i = res.Length; i < DigitsCount; i++)
            {
                res = "0" + res;
            }
            return res;
        }

        public static string AddZeroToleft(string StringNumber, int DigitsCount)
        {

            for (int i = StringNumber.Length; i < DigitsCount; i++)
            {
                StringNumber = "0" + StringNumber;
            }
            return StringNumber;
        }

        public static string[] Split(string InputString, char Seprator)
        {
            char[] sep = new char[1];
            sep[0] = Seprator;
            return InputString.Split(sep, StringSplitOptions.RemoveEmptyEntries);
        }

        public static bool IsDigit(char digit_char)
        {
            return (
                (digit_char == '0') ||
                (digit_char == '1') ||
                (digit_char == '2') ||
                (digit_char == '3') ||
                (digit_char == '4') ||
                (digit_char == '5') ||
                (digit_char == '6') ||
                (digit_char == '7') ||
                (digit_char == '8') ||
                (digit_char == '9')
                );
        }

        public static bool IsInt(string StringInt)
        {
            if (StringInt == "") return false;
            bool res = true;
            for (int i = 0; i < StringInt.Length; i++)
            {
                if (!IsDigit(StringInt[i]))
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        public static bool IsDouble(string StringDouble)
        {
            if (StringDouble == "") return false;
            bool res = true;
            int dot_count = 0;

            for (int i = 0; i < StringDouble.Length; i++)
            {
                if (!IsDigit(StringDouble[i]))
                {
                    if (StringDouble[i] == '.')
                    {
                        dot_count++;
                        if (dot_count > 1) return false;
                        else continue;
                    }
                    res = false;
                    break;
                }
            }
            return res;
        }


        public static Point AbsoluteLocation(Control AControl)
        {
            int x = 0;
            int y = 0;
            Control tmp_ctrl = AControl;

            // All layers except main form.
            while (tmp_ctrl.Parent != null)
            {
                x = x + tmp_ctrl.Left;
                y = y + tmp_ctrl.Top;
                tmp_ctrl = (Control)tmp_ctrl.Parent;
            }
            return new Point(x, y);
        }

        public static Point AbsoluteLocationFull(Control AControl)
        {
            int x = 0;
            int y = 0;
            Control tmp_ctrl = AControl;

            // All layers except main form.
            while (tmp_ctrl != null)
            {
                x = x + tmp_ctrl.Left;
                y = y + tmp_ctrl.Top;
                tmp_ctrl = (Control)tmp_ctrl.Parent;
            }
            return new Point(x, y);
        }


        

        public static string ObjectToString(object AnObject)
        {
            if (AnObject == null) return "";
            return AnObject.ToString();
        }

        public static Int32 ObjectToInt32(object AnObject)
        {
            if (AnObject == null) return 0;
            if (AnObject == DBNull.Value) return 0;
            return Convert.ToInt32(AnObject);
        }

        public static Int64 ObjectToInt64(object AnObject)
        {
            if (AnObject == null) return 0;
            if (AnObject == DBNull.Value) return 0;
            return Convert.ToInt64(AnObject);
        }
        public static Double ObjectToDouble(object AnObject)
        {
            if (AnObject == null) return 0;
            if (AnObject == DBNull.Value) return 0;
            return Convert.ToDouble(AnObject);
        }
        public static bool ObjectToBoolean(object AnObject)
        {
            if (AnObject == null) return false;
            return Convert.ToBoolean(AnObject);
        }

        public static int GetHoure(string OccuranceTime)
        {
            string[] parts = OccuranceTime.Trim().Split(':');
            if (parts.Length != 2) return 0;
            if (!IsInt(parts[0])) return 0;
            int houre = Convert.ToInt32(parts[0]);
            if (houre > 24) return 0;
            if (houre < 0) return 0;
            return houre;
        }

        public static int GetMinute(string OccuranceTime)
        {
            string[] parts = OccuranceTime.Trim().Split(':');
            if (parts.Length != 2) return 0;
            if (!IsInt(parts[0])) return 0;
            int minute = Convert.ToInt32(parts[1]);
            if (minute > 59) return 0;
            if (minute < 0) return 0;
            return minute;
        }


        internal static string GetCurrentTime()
        {
            DateTime dt = DateTime.Now;
            return AddZeroToleft(dt.Hour, 2) + ":" + AddZeroToleft(dt.Minute, 2);
        }

        internal static DateTime ObjectToDateTime(object AnObject)
        {
            if (AnObject == null) return DateTime.MinValue;
            if (AnObject == DBNull.Value) return DateTime.MinValue;;
            return Convert.ToDateTime(AnObject);
        }
    }
}
