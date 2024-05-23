using lab_04_03;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace lab_04_03
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }
        private void fMain_Resize(object sender, EventArgs e)
        {
            int buttonsSize = 5 * btnAdd.Width + 2 * tsSeparator1.Width + 30;
            btnExit.Margin = new Padding(Width - buttonsSize, 0, 0, 0);
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            gvTablet.AutoGenerateColumns = false;
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Brand";
            column.Name = "Бренд";
            gvTablet.Columns.Add(column);


            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Model";
            column.Name = "Модель";
            gvTablet.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "ScreenSize";
            column.Name = "Розмір екрану";
            gvTablet.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Resolution";
            column.Name = "роздільна здатність";
            gvTablet.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "RAM";
            column.Name = "RAM";
            gvTablet.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Storage";
            column.Name = "Зберігання";
            gvTablet.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Price";
            column.Name = "Ціна";
            gvTablet.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "OperatingSystem";
            column.Name = "Операційна система";
            gvTablet.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "HasCamera";
            column.Name = "камеру";
            gvTablet.Columns.Add(column);


            bindSrcTablet.Add(new Tablet("Apell", "Ipad Pro 1", 12.9, "Full HD", 32, 64, 1200, "iPadOS 16", true));
            EventArgs args = new EventArgs(); OnResize(args);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tablet tablet = new Tablet();

            ftablet ft = new ftablet(tablet);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcTablet.Add(tablet);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Tablet tablet = (Tablet)bindSrcTablet.List[bindSrcTablet.Position];
            ftablet ft = new ftablet(tablet);
            if (ft.ShowDialog() == DialogResult.OK)
            {
                bindSrcTablet.List[bindSrcTablet.Position] = tablet;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Видалити поточний запит?","Видалення запису",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                bindSrcTablet.RemoveCurrent();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Очистити тиблицю?\n\nВсi данi будуть втраченi", "Очищення даних",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                bindSrcTablet.Clear();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Закрити застосунок?","Вихід з програми",MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
