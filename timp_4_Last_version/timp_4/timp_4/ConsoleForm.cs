using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timp_4
{
    public partial class ConsoleForm : Form
    {
        public ConsoleForm()
        {
            InitializeComponent();
        }

        private void ConsoleForm_Load(object sender, EventArgs e)
        {
            SinglyLinkedList < Flat > DF = new SinglyLinkedList<Flat>();
            DF.Add(new Flat());
            DF.Add(new Flat(12));
            DF.Add(new Flat(122));

            DF.Insert(0, new Flat(333));
            DF.RemoveAt(2);
            richTextBox1.Text = DF[3].ToString();
        }
    }
}
