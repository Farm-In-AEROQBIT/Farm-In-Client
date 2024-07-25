using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Farm_In_Client
{
    public partial class FarmSelectionForm : Form
    {
        public FarmSelectionForm()
        {
            InitializeComponent();
            LoadFarms();
        }

        private void LoadFarms()
        {
            // 서버와 통신하여 농장 리스트를 불러오는 로직을 추가합니다.
            List<string> farms = GetFarmListFromServer();
            cbFarms.DataSource = farms;
        }

        private List<string> GetFarmListFromServer()
        {
            // 서버와 통신하여 농장 리스트를 불러오는 예시입니다.
            return new List<string> { "Farm1", "Farm2", "Farm3" };
        }

        private void btnSelectFarm_Click(object sender, EventArgs e)
        {
            string selectedFarm = cbFarms.SelectedItem.ToString();

            MainForm mainForm = new MainForm(selectedFarm);
            mainForm.Show();
            this.Hide();
        }
    }
}
