using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.P85_BAS
{
    class itemDS 
    {
        private Controls.conComboBox cmb_mold;

        public void setDesigner(object sender)
        {
            Form item = (Form)sender;
            Panel panel6 = null;
            foreach (object pan in item.Controls)
            {
                Panel pan1 = (Panel)pan;
                foreach (object pan2 in pan1.Controls)
                {
                    panel6 = (Panel)pan2;
                    if (panel6.Tag.ToString() == "panel6")
                        break;
                }
            }

            this.cmb_mold = new MES.Controls.conComboBox();
            this.cmb_mold._BorderColor = System.Drawing.Color.Transparent;
            this.cmb_mold._FocusedBackColor = System.Drawing.Color.White;
            this.cmb_mold.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmb_mold.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmb_mold.FormattingEnabled = true;
            this.cmb_mold.Location = new System.Drawing.Point(104, 624);
            this.cmb_mold.Name = "cmb_mold";
            this.cmb_mold.Size = new System.Drawing.Size(190, 23);
            this.cmb_mold.TabIndex = 512;
            panel6.Controls.Add(this.cmb_mold);
        }
    }
}
