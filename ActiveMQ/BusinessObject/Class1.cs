using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [Serializable]
    public class Class1
    {
        string shortcode;

        public string Shortcode
        {
            get
            {
                return shortcode;
            }

            set
            {
                shortcode = value;
            }
        }
    }
}
