using MES.CLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MES.Controls
{
    public class myDataGridView : DataGridView
    {

        protected override void OnClick(EventArgs e)
        {

            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            base.OnClick(e);
        }

        protected override void OnCellDoubleClick(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            base.OnCellDoubleClick(e);
        }

        protected override void OnCellContentClick(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            base.OnCellContentClick(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            int currentMouseOverRow = this.HitTest(e.X, e.Y).RowIndex;
            int currentMouseOverColumn = this.HitTest(e.X, e.Y).ColumnIndex;

            if (currentMouseOverRow == -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    EventHandler eh = new EventHandler(MenuClick);
                    ContextMenu m = new ContextMenu();
                    m.MenuItems.Add(new MenuItem("열 크기 재정렬", eh));
                    //this.CurrentCell = this.Rows[currentMouseOverRow].Cells[currentMouseOverColumn];
                    m.Show(this, new System.Drawing.Point(e.X, e.Y));
                }
            }
            base.OnMouseClick(e);
        }

        void MenuClick(object obj, EventArgs ea)
        {
            MenuItem mI = (MenuItem)obj;
            String str = mI.Text;

            switch (str)
            {
                case "열 크기 재정렬":
                    try
                    {
                        foreach (DataGridViewColumn i in this.Columns)
                        {
                            i.FillWeight = i.Width;
                            i.MinimumWidth = 10;
                        }
                        this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        foreach (DataGridViewColumn i in this.Columns)
                        {
                            i.MinimumWidth = i.Width;
                        }

                        if (this.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed) >= this.Width - 15)
                        {
                            foreach (DataGridViewColumn i in this.Columns)
                            {
                                i.MinimumWidth = 10;
                            }
                        }
                        this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                    catch (Exception ex)
                    {

                    }
                    break;
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    this.AllowDrop = false;
                    this.AllowUserToOrderColumns = false;
                    foreach (DataGridViewColumn i in this.Columns)
                    {
                        i.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                        i.SortMode = DataGridViewColumnSortMode.NotSortable;
                        i.Resizable = DataGridViewTriState.True;
                        i.FillWeight = i.Width;
                    }

                    this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                    foreach (DataGridViewColumn i in this.Columns)
                    {
                        i.MinimumWidth = i.Width;
                    }

                    if (this.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed) >= this.Width)
                    {
                        foreach (DataGridViewColumn i in this.Columns)
                        {
                            i.MinimumWidth = 10;
                        }
                    }

                    this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                else
                {
                    foreach (DataGridViewColumn i in this.Columns)
                    {
                        i.MinimumWidth = 50;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            base.OnVisibleChanged(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            try
            {
                foreach (DataGridViewColumn i in this.Columns)
                {
                    i.FillWeight = i.Width;
                    i.MinimumWidth = 10;
                }
                this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                foreach (DataGridViewColumn i in this.Columns)
                {
                    i.MinimumWidth = i.Width;
                }

                if (this.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed) >= this.Width - 15)
                {
                    foreach (DataGridViewColumn i in this.Columns)
                    {
                        i.MinimumWidth = 10;
                    }
                }
                this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {

            }
            base.OnSizeChanged(e);
        }
    }
}
