using MdcArchiveBrowse.Manager.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MdcArchiveBrowse.Manager
{
    public partial class frmMain : Form
    {
        private CtrlHospitalInfo _ctrlHospitalInfo;
        private CtrlApplyDept _ctrlApplyDept;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this._ctrlHospitalInfo = new CtrlHospitalInfo();
            this._ctrlHospitalInfo.Dock = DockStyle.Fill;

            this._ctrlApplyDept = new CtrlApplyDept();
            this._ctrlApplyDept.Dock = DockStyle.Fill;

            this.tabPage1.Controls.Add(this._ctrlHospitalInfo);
            this.tabPage2.Controls.Add(this._ctrlApplyDept);
        }
    }
}
