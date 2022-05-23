using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class BusinessEntity
    {
        private int _ID;
        private States _State;

        public int ID
        {
            get { return _ID; }
            set{ _ID = value;}
        }

        public States State
        {
            get { return _State; }
            set { _State = value; }
        }

        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified
        }
    }
}
