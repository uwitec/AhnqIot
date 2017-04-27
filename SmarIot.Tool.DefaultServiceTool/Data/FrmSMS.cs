using System.Windows.Forms;

namespace SmartIot.Tool.DefaultServiceTool.Data
{
    public partial class FrmSMS : Form
    {
        public FrmSMS()
        {
            InitializeComponent();
            InitSMS();
        }

        /// <summary>
        /// 初始化历史记录列表
        /// </summary>
        private void InitSMS()
        {
            //this.listView1.Items.Clear();
            //List<SMS> list = SMS.FindAll();
            //foreach (SMS sms in list)
            //{
            //    string[] strings = new string[] { sms.Mobile, sms.Message, sms.CreateTime.ToString() };
            //    ListViewItem listViewItem = new ListViewItem(strings);
            //    listViewItem.Tag = sms;
            //    this.listView1.Items.Add(listViewItem);
            //}
        }
    }
}