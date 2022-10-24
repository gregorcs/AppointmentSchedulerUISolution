using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AppointmentSchedulerUILibrary.UIRegex
{
    public class EmailRegex
    {
        public const string Pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    }
}
