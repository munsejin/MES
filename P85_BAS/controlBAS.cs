using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES.CLS;

namespace MES.P85_BAS
{
    class controlBAS
    {
        public wnDm setItemWnDm()
        {
            switch (Common.p_saupNo)
            {
                case "6091692803":
                    return new wnDmPlus();
                default:
                    return new wnDm();

            }
        }


    }
}
