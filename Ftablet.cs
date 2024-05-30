using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab_04_03;





namespace lab_04_03
{
    public partial class ftablet : Form
    {
        public Tablet TheTablet;
        public ftablet(Tablet t)
        {
            TheTablet = t;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            TheTablet.Brand = tbBrand.Text.Trim();
            TheTablet.Model = tbModel.Text.Trim();
            TheTablet.ScreenSize = double.Parse(tbScreenSize.Text.Trim());
            TheTablet.Resolution = tbResolution.Text.Trim();
            TheTablet.RAM = int.Parse(tbRAM.Text.Trim());
            TheTablet.Storage = int.Parse(tbStorage.Text.Trim());
            TheTablet.OperatingSystem = tbOP.Text.Trim();
            TheTablet.Price = int.Parse(tbprise.Text.Trim());
            if (TheTablet is HighEndTablet highEndTablet)
            {
                highEndTablet.SupportsStylus = chkSupportsStylus.Checked;
            }
            else if (TheTablet is BudgetTablet budgetTablet)
            {
                budgetTablet.IsKidsFriendly = chkIsKidsFriendly.Checked;
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ftablet_Load(object sender, EventArgs e)
        {
            tbBrand.Text = TheTablet.Brand;
            tbModel.Text = TheTablet.Model;
            tbScreenSize.Text = TheTablet.ScreenSize.ToString();
            tbResolution.Text = TheTablet.Resolution;
            tbRAM.Text = TheTablet.RAM.ToString();
            tbStorage.Text = TheTablet.Storage.ToString();
            tbOP.Text = TheTablet.OperatingSystem;
            tbprise.Text = TheTablet.Price.ToString();
            if (TheTablet is HighEndTablet highEndTablet)
            {
                chkSupportsStylus.Checked = highEndTablet.SupportsStylus;
                chkSupportsStylus.Visible = true;
                chkIsKidsFriendly.Visible = false;
            }
            else if (TheTablet is BudgetTablet budgetTablet)
            {
                chkIsKidsFriendly.Checked = budgetTablet.IsKidsFriendly;
                chkIsKidsFriendly.Visible = true;
                chkSupportsStylus.Visible = false;
            }
        }
    }
}
