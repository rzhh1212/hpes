using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPES.Model
{
    public class Hospital
    {

        public int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string hcode;

        public string Hcode
        {
            get { return hcode; }
            set { hcode = value; }
        }

        public string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}
