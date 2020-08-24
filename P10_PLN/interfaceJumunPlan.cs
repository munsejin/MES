using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.Controls;
using System.Data;
namespace MES.P10_PLN
{
    interface interfaceJumunPlan
    {

        //void save(DataGridView dgv);
        //void formLoad(DataGridView dgv);
        //void update(DataGridView dgv);
        //void delete(DataGridView dgv);

        //void save(conDataGridView dgv);
        //void formLoad(conDataGridView dgv);
        //void update(conDataGridView dgv);
        //void delete(conDataGridView dgv); 

        JumunPlanDTO save(JumunPlanDTO dto, StringBuilder sbTemp);
        JumunPlanDTO formLoad();
        JumunPlanDTO update();
        JumunPlanDTO delete();
        JumunPlanDTO plan(JumunPlanDTO dto);
        JumunPlanDTO plan2(JumunPlanDTO dto);
        decimal totalMoney(decimal amt, decimal price);
        decimal price(decimal amt, decimal money);


    }
}
