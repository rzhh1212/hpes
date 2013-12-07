using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPES.Model
{
   public  class Equipment
    {

        public int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string equipcode;

        public string Equipcode
        {
            get { return equipcode; }
            set { equipcode = value; }
        }




        public string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string hospitalname;

        public string Hospitalname
        {
            get { return hospitalname; }
            set { hospitalname = value; }
        }
        public string timename;

        public string Timename
        {
            get { return timename; }
            set { timename = value; }
        }
        public string factory;

        public string Factory
        {
            get { return factory; }
            set { factory = value; }
        }
        public string company;

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public int bid;
        public int Bid
        {
            get { return bid; }
            set { bid = value; }
        }


    }
}
