using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPES.Model
{
    public class Stdpoint
    {
        public int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string stdonename;

        public string Stdonename
        {
            get { return stdonename; }
            set { stdonename = value; }
        }

        public string stdtwoname;

        public string Stdtwoname
        {
            get { return stdtwoname; }
            set { stdtwoname = value; }
        }

        public string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int auto;

        public int Auto
        {
            get { return auto; }
            set { auto = value; }
        }

        private int scoreone;

        public int Scoreone
        {
            get { return scoreone; }
            set { scoreone = value; }
        }

        private int scoretwo;

        public int Scoretwo
        {
            get { return scoretwo; }
            set { scoretwo = value; }
        }


    }
}
