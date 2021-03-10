using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ListViewItem itemSwitch = new ListViewItem("Nintendo Switch", 0);
            itemSwitch.SubItems.Add("600,000");
            itemSwitch.SubItems.Add("10");
            itemSwitch.SubItems.Add("6,000,000");

            ListViewItem itemDS = new ListViewItem("Nintendo DS", 1);
            itemDS.SubItems.Add("300,000");
            itemDS.SubItems.Add("50");
            itemDS.SubItems.Add("15,000,000");

            ListViewItem itemPS4 = new ListViewItem("PlayStation 4", 2);
            itemPS4.SubItems.Add("400,000");
            itemPS4.SubItems.Add("20");
            itemPS4.SubItems.Add("8,000,000");

            ListViewItem itemWii = new ListViewItem("Nintendo Wii", 3);
            itemWii.SubItems.Add("200,000");
            itemWii.SubItems.Add("30");
            itemWii.SubItems.Add("6,000,000");

            ListViewItem itemXBox = new ListViewItem("XBox 360", 4);
            itemXBox.SubItems.Add("700,000");
            itemXBox.SubItems.Add("20");
            itemXBox.SubItems.Add("14,000,000");

            LsvProducts.Items.AddRange(new ListViewItem[] { itemSwitch, itemDS, itemPS4, itemWii, itemXBox });
        }

        private void RbdDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (RbdDetail.Checked) LsvProducts.View = View.Details;
        }

        private void RbdList_CheckedChanged(object sender, EventArgs e)
        {
            if (RbdList.Checked) LsvProducts.View = View.List;
        }

        private void RdbSmallIcon_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbSmallIcon.Checked) LsvProducts.View = View.SmallIcon;
        }

        private void RdbBigIcon_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbBigIcon.Checked) LsvProducts.View = View.LargeIcon;
        }

        private void LsvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtSelected.Text = string.Empty;
            var selected = LsvProducts.SelectedItems;

            foreach (ListViewItem item in selected)
            {
                for (int i = 0; i < 4; i++)
                {
                    TxtSelected.Text += item.SubItems[i].Text + " ";
                }
            }

        }
    }
}
