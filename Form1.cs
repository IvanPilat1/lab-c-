using lab_04_03;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;




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
            int buttonsSize = 9 * btnAdd.Width + 3 * tsSeparator1.Width;
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

        private void btnSaveAsText_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Зберегти дані у текстовому форматі";
            StreamWriter sw;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                sw = new StreamWriter(saveFileDialog.FileName,false,Encoding.UTF8);
                try
                {
                    foreach(Tablet tablet in bindSrcTablet.List)
                    {
                        sw.Write(tablet.Brand + "\t" + tablet.Model + "\t" +
                          tablet.ScreenSize + "\t" + tablet.Resolution + "\t"
                          + tablet.RAM + "\t" + tablet.Storage + "\t" +
                          tablet.Price + "\t" + tablet.OperatingSystem + "\t" +
                          tablet.HasCamera + "\t\n");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cталася помилка: \n{0}",ex.Message,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { sw.Close(); }
            }
        }

        private void btnSaveAsBinary_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Файли даних (*.Tablet)|*.Tablet|All files (*.*)|*.*";
            saveFileDialog.Title = "Зберегти дані у бінарному форматі";
            BinaryWriter bw;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                bw = new BinaryWriter(saveFileDialog.OpenFile());
                try
                {
                    foreach (Tablet tablet in bindSrcTablet.List)
                    {
                        bw.Write(tablet.Brand);
                        bw.Write(tablet.Model);
                        bw.Write(tablet.ScreenSize);
                        bw.Write(tablet.Resolution);
                        bw.Write(tablet.RAM);
                        bw.Write(tablet.Storage);
                        bw.Write(tablet.OperatingSystem);
                        bw.Write(tablet.Price);
                        bw.Write(tablet.HasCamera);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cталась помилка: \n{0}", ex.Message,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { bw.Close(); }
            }
        }

        private void btnOpenFromText_Click(object sender, EventArgs e)
        {
           OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстові файли (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Прoчитати дані у тукстовому форматі";
            openFileDialog.InitialDirectory = Application.StartupPath;
            StreamReader sr;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bindSrcTablet.Clear(); sr = new StreamReader(openFileDialog.FileName,Encoding.UTF8);
                string s;
                try
                {
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] split = s.Split('\t');
                        Tablet tablet = new Tablet(
                            split[0],
                            split[1],
                            double.Parse(split[2]),
                            (split[3]),
                            int.Parse(split[4]),
                            int.Parse(split[5]),
                            int.Parse(split[6]),
                            split[7],
                            bool.Parse(split[8]));
                        bindSrcTablet.Add(tablet);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cталась помилка: \n{0}", ex.Message,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { sr.Close(); }
            }
        }

        private void btnOpenFromBinary_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файли даних (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Прoчитати дані у тукстовому форматі";
            openFileDialog.InitialDirectory = Application.StartupPath;
            BinaryReader br;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bindSrcTablet.Clear(); br = new BinaryReader(openFileDialog.OpenFile());
                string s;
                try
                {
                    Tablet tablet; while(br.BaseStream.Position < br.BaseStream.Length)
                    {
                        tablet = new Tablet();
                        for(int i = 1; i <= 9; i++)
                        {
                            switch(i)
                            {
                                case 1:
                                    tablet.Brand = br.ReadString();
                                    break;
                                case 2:
                                    tablet.Model = br.ReadString();
                                    break;
                                case 3:
                                    tablet.ScreenSize = br.ReadDouble();
                                    break;
                                case 4:
                                    tablet.Resolution = br.ReadString();
                                    break;
                                case 5:
                                    tablet.RAM = br.ReadInt32();
                                    break;
                                case 6:
                                    tablet.Storage = br.ReadInt32();
                                    break;
                                case 7:
                                    tablet.Price = br.ReadInt32();
                                    break;
                                case 8:
                                    tablet.OperatingSystem = br.ReadString();
                                    break;
                                case 9:
                                    tablet.HasCamera = br.ReadBoolean();
                                    break;

                            }
                        }
                        bindSrcTablet.Add(tablet);
                    } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cталась помилка: \n{0}", ex.Message,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { br.Close(); }
            }
        }
    }
}
