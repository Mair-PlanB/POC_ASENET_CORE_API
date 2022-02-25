using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;

namespace FrontendNeu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Call_GetSomethingOther(1, "Yannic");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Call_GetBookById(5);
        }

        private void Call_GetSomethingOther(int id, string firstname)
        {
            MessageBox.Show(HttpHelper.HttpGetRequest(ApiConst.ApiMainRoute + $"/{id}/{firstname}"));
        }

        private void Call_GetBookById(int id)
        {
            MessageBox.Show(HttpHelper.HttpGetRequest(ApiConst.ApiMainRoute + $"/{id}"));
        }
    }
}