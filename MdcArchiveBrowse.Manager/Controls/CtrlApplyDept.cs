using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MdcArchiveBrowse.Manager.Controls
{
    public partial class CtrlApplyDept : UserControl
    {
        public CtrlApplyDept()
        {
            InitializeComponent();
        }

        #region  表格

        /// <summary>
        /// 新增方法
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        public ListView InsertListView(ListView lv)
        {
            ////创建行对象
            //ListViewItem li = new ListViewItem(_TaskName);
            ////添加同一行的数据
            //li.SubItems.Add(_StepStyle);
            ////将行对象绑定在listview对象中
            //lv.Items.Add(li);
            return lv;
        }

        /// <summary>
        /// 初始化ListView的方法
        /// </summary>
        /// <param name="lv"></param>
        public void InitListView(ListView lv)
        {
            //添加列名
            ColumnHeader c1 = new ColumnHeader();
            c1.Width = 200;
            c1.Text = "编号";
            ColumnHeader c2 = new ColumnHeader();
            c2.Width = 170;
            c2.Text = "申请科室";
            ColumnHeader c3 = new ColumnHeader();
            c3.Width = 225;
            c3.Text = "备注";
            ColumnHeader c4 = new ColumnHeader();
            c4.Width = 170;
            c4.Text = "日期";
            //设置属性
            lv.GridLines = true;  //显示网格线
            lv.FullRowSelect = true;  //显示全行
            lv.MultiSelect = false;  //设置只能单选
            lv.View = View.Details;  //设置显示模式为详细
            lv.HoverSelection = true;  //当鼠标停留数秒后自动选择
            //把列名添加到listview中
            lv.Columns.Add(c1);
            lv.Columns.Add(c2);
            lv.Columns.Add(c3);
            lv.Columns.Add(c4);
        }

        /// <summary>
        /// 修改的方法
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        public ListView UpdateListView(ListView lv)
        {
            if (lv.SelectedItems.Count > 0)
            {
                //把修改后的文本框内容添加到listview中
                //lv.SelectedItems[0].SubItems[0].Text = this.txtTaskName.Text.Trim();
                //lv.SelectedItems[0].SubItems[1].Text = this.cboStepStyle.Text;
                MessageBox.Show("任务修改成功！");
            }
            return lv;
        }

        /// <summary>
        /// 当listview选中状态改变时调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //当有选择行的数据时
            if (this.listView.SelectedItems.Count > 0)
            {
                //把选择的信息显示在相应的文本框中
                //this.txtTaskName.Text = this.listView.SelectedItems[0].SubItems[0].Text;
                //this.cboStepStyle.Text = this.listView.SelectedItems[0].SubItems[1].Text;
            }
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {

            //if (!String.IsNullOrEmpty(txtTaskName.Text))
            //{
            //    if (String.IsNullOrEmpty(cboStepStyle.Text))
            //    {
            //        MessageBox.Show("请填写任务步长类型");
            //        return;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("请填写任务名称");
            //    return;
            //}
            ////获取文本框中的值
            //_TaskName = this.txtTaskName.Text.Trim();
            //_StepStyle = this.cboStepStyle.Text;
            //SelectListView(this.listView);
            //if (_IsExist == false)
            //{
            //    InsertListView(this.listView);
            //}
        }

        public void SelectListView(ListView lv)
        {
            //列表有数据
            if (lv.Items.Count > 0)
            {
                foreach (ListViewItem li in lv.Items)
                {
                    //if (li.SubItems[0].Text == _TaskName)
                    //{
                    //    MessageBox.Show("存在该名称");
                    //    _IsExist = true;
                    //    return;
                    //}
                    //else
                    //{
                    //    _IsExist = false;
                    //}
                }
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, EventArgs e)
        {
            UpdateListView(this.listView);
        }

        /// <summary>
        /// 移除选中行的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelet_Click(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("确认删除？", "温馨提示", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    //移除整一行
                    this.listView.SelectedItems[0].Remove();
                }
                else
                {

                }
            }
        }
        #endregion

        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucApplyDept_Load(object sender, EventArgs e)
        {
            InitListView(listView);
        }
    }
}
