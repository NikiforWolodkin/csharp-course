using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    [AttributeUsage(AttributeTargets.Property |
  AttributeTargets.Field, AllowMultiple = false)]
    sealed public class UDCAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string UDC)
            {
                string[] codes = UDC.Split(".");

                if (codes.Length != 2)
                {
                    return false;
                }

                int firstCode = 0;
                int secondCode = 0;
                try
                {
                    firstCode = Convert.ToInt32(codes[0]);
                    secondCode = Convert.ToInt32(codes[1]);
                }
                catch
                {
                    return false;
                }

                if (firstCode < 0 || firstCode > 999)
                {
                    return false;
                }
                if (secondCode < 0 || secondCode > 999)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}
