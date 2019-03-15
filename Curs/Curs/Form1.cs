using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Management;


namespace Curs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ServiceInfoList.getServices(listView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceListWorker.Start(listView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceListWorker.Stop(listView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServiceListWorker.Pause(listView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ServiceListWorker.Continue(listView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //тип запуска
            ServiceListWorker.SetStartupType(listView1, comboBox1);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ServiceInfoList.getServices(listView1);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    class ServiceInfoList
    {

        public static void Search(ListView listView1, string curr)
        {

            foreach (ServiceController service1 in ServiceController.GetServices())

            {
                string serviceName = service1.ServiceName;
                if (serviceName.Contains(curr))
                {
                    serviceName = service1.ServiceName;
                    string serviceDisplayName = service1.DisplayName;
                    string serviceType = service1.ServiceType.ToString();
                    string status = service1.Status.ToString();
                    string startType = service1.StartType.ToString();
                    ListViewItem lvi = new ListViewItem(serviceName);
                    lvi.SubItems.Add(serviceDisplayName);
                    lvi.SubItems.Add(serviceType);
                    lvi.SubItems.Add(startType);
                    lvi.SubItems.Add(status);
                    listView1.Items.Add(lvi);
                }

            }
        }
        public static void getServices(ListView listView1)
        {
            foreach (ServiceController service in ServiceController.GetServices())

            {

                string serviceName = service.ServiceName;
                string startType = service.StartType.ToString();
                string serviceDisplayName = service.DisplayName;
                string serviceType = service.ServiceType.ToString();
                string status = service.Status.ToString();

                ListViewItem lvi = new ListViewItem(serviceName);
                lvi.SubItems.Add(serviceDisplayName);
                lvi.SubItems.Add(serviceType);
                lvi.SubItems.Add(startType);
                lvi.SubItems.Add(status);
                listView1.Items.Add(lvi);

            }
        }
        public static void RefrList(ListView listView1)
        {
            foreach (ServiceController service in ServiceController.GetServices())

            {

                string serviceName = service.ServiceName;

                string serviceDisplayName = service.DisplayName;
                string serviceType = service.ServiceType.ToString();
                string status = service.Status.ToString();

                ListViewItem lvi = new ListViewItem(serviceName);
                lvi.SubItems.Add(serviceDisplayName);
                lvi.SubItems.Add(serviceType);
                lvi.SubItems.Add(status);
                listView1.Items.Add(lvi);

            }
        }
    }

    class ServiceListWorker
    {
        public static void Start(ListView listView1)
        {
            ServiceController service = new ServiceController(listView1.SelectedItems[0].Text);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(10);

                service.Start();
                MessageBox.Show("Служба :" + listView1.SelectedItems[0].Text + " была запущена");
                listView1.Items.Clear();
                foreach (ServiceController service1 in ServiceController.GetServices())

                {

                    string serviceName = service1.ServiceName;
                    string startType = service1.StartType.ToString();
                    string serviceDisplayName = service1.DisplayName;
                    string serviceType = service1.ServiceType.ToString();
                    string status = service1.Status.ToString();

                    ListViewItem lvi = new ListViewItem(serviceName);
                    lvi.SubItems.Add(serviceDisplayName);
                    lvi.SubItems.Add(serviceType);
                    lvi.SubItems.Add(startType);
                    lvi.SubItems.Add(status);
                    listView1.Items.Add(lvi);

                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(String.Format("{0} {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : String.Empty),
                    "Error Service Controller");
            }
        }
        public static void Stop(ListView listView1)
        {
            string s = listView1.SelectedItems[0].Text;
            ServiceController ser = new ServiceController(s);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(100000);

                ser.Stop();
                ser.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

                string stat = ser.Status.ToString();
                string ifname = ser.ServiceName;
                listView1.Items.Clear();
                foreach (ServiceController service1 in ServiceController.GetServices())

                {


                    string serviceName = service1.ServiceName;
                    string startType = service1.StartType.ToString();
                    string serviceDisplayName = service1.DisplayName;
                    string serviceType = service1.ServiceType.ToString();
                    string status = "";
                    if (ifname == serviceName)
                    {
                        status = stat;
                    }
                    else
                    {
                        status = service1.Status.ToString();
                    }
                    ListViewItem lvi = new ListViewItem(serviceName);
                    lvi.SubItems.Add(serviceDisplayName);
                    lvi.SubItems.Add(serviceType);
                    lvi.SubItems.Add(startType);
                    lvi.SubItems.Add(status);
                    listView1.Items.Add(lvi);

                }


            }

            catch (InvalidOperationException ex)
            {
                MessageBox.Show(String.Format("{0} {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : String.Empty),
                    "Error Service Controller");
            }
        }
        public static void Pause(ListView listView1)
        {
            string s = listView1.SelectedItems[0].Text;
            ServiceController ser = new ServiceController(s);
            if (ser.CanPauseAndContinue == true)
            {
                ser.Pause();
                ser.WaitForStatus(ServiceControllerStatus.Paused, TimeSpan.FromSeconds(10));
                MessageBox.Show("Служба" + ser.DisplayName + "  в режиме 'ПАУЗА'", "Внимание", MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);


            }
            else MessageBox.Show("Служба" + ser.DisplayName + " не может быть в режиме 'ПАУЗА'");
            listView1.Items.Clear();
            foreach (ServiceController service1 in ServiceController.GetServices())

            {
                string serviceName = service1.ServiceName;
                string serviceDisplayName = service1.DisplayName;
                string serviceType = service1.ServiceType.ToString();
                string status = service1.Status.ToString();
                string startType = service1.StartType.ToString();
                ListViewItem lvi = new ListViewItem(serviceName);
                lvi.SubItems.Add(serviceDisplayName);
                lvi.SubItems.Add(serviceType);
                lvi.SubItems.Add(startType);
                lvi.SubItems.Add(status);
                listView1.Items.Add(lvi);

            }
        }
        public static void Continue(ListView listView1)
        {
            string s = listView1.SelectedItems[0].Text;
            ServiceController ser = new ServiceController(s);
            if (ser.CanPauseAndContinue == true)
            {
                ser.Continue();
                ser.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                MessageBox.Show("Служба" + ser.DisplayName + " продолжила выполнение ", "Внимание", MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
            listView1.Items.Clear();
            foreach (ServiceController service1 in ServiceController.GetServices())
            {
                string serviceName = service1.ServiceName;

                string serviceDisplayName = service1.DisplayName;
                string serviceType = service1.ServiceType.ToString();
                string status = service1.Status.ToString();
                string startType = service1.StartType.ToString();
                ListViewItem lvi = new ListViewItem(serviceName);
                lvi.SubItems.Add(serviceDisplayName);
                lvi.SubItems.Add(serviceType);
                lvi.SubItems.Add(startType);
                lvi.SubItems.Add(status);
                listView1.Items.Add(lvi);

            }




        }
        public string GetStartupType(ListView listView1)
        {
            ServiceController service = new ServiceController(listView1.SelectedItems[0].Text);
            if (service.ServiceName != null)
            {
                //construct the management path
                string path = "Win32_Service.Name='" + service.ServiceName + "'";
                ManagementPath p = new ManagementPath(path);
                //construct the management object
                ManagementObject ManagementObj = new ManagementObject(p);
                return ManagementObj["StartMode"].ToString();
            }
            else
            {
                return null;
            }

        }
        public static void SetStartupType(ListView listView,ComboBox comboBox)
        {

            ServiceController service = new ServiceController(listView.SelectedItems[0].Text);
            if (service.ServiceName != null)
            {
                //construct the management path
                string path = "Win32_Service.Name='" + service.ServiceName + "'";
                ManagementPath p = new ManagementPath(path);
                //construct the management object
                ManagementObject ManagementObj = new ManagementObject(p);
                //we will use the invokeMethod method of the ManagementObject class
                object[] parameters = new object[1];
                parameters[0] = comboBox.SelectedItem;
                ManagementObj.InvokeMethod("ChangeStartMode", parameters);
            }

        }
    }
}
        

 
