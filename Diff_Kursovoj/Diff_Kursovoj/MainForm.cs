using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;

namespace Diff_Kursovoj
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            input.Focus();
        }
        
        string IN = string.Empty;
        string OUT = string.Empty;
        string CopyIN = string.Empty;
        string poland = string.Empty;
        Parsing Pars = new Parsing();

        private void go_Click(object sender, EventArgs e)
        {
            try
            {
                IN = input.Text;
                Pars.GeneralProcess(ref IN, ref CopyIN, ref poland, ref OUT);
                OTVET.Text = OUT;
                materialLabel1.Visible = true;
                OTVET.Visible = true;
                go.Location = new Point(15, 136);
                this.Size = new Size(363, 190);
            }
            catch(InvalidOperationException)
            {
                MessageBox.Show("Проверьте входящую строку", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}