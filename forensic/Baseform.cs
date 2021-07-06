using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forensic
{
    public partial class Baseform : Form
    {
        public Baseform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadImage obj = new LoadImage();
            Form ob = Form.ActiveForm;
            Form ob1 = ob.ActiveMdiChild;
            if (ob1 != null)
                ob1.Dispose();
            obj.Show();
      
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* Registration obj = new Registration();
            Form ob = Form.ActiveForm;
            Form ob1 = ob.ActiveMdiChild;
            if (ob1 != null)
                ob1.Dispose();
            obj.Show();*/
        }
    }
}
