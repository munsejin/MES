using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace MES.P10_PLN
{
    class JumunPlanDTO
    {
        private DataTable jumundt; 
        private DataTable plandt;
        private int succer;
        public DataTable Jumundt { get { return jumundt; } set { jumundt = value; } }
        public DataTable Plandt { get { return plandt; } set { plandt = value; } }
        public int Succer { get { return succer; } set { succer = value; } }
    }   
}
