using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduQuizzer
{
    public partial class RunQuizForm : Form
    {
        public Quiz RunQuiz { get; set; }

        public RunQuizForm(Quiz q)
        {
            InitializeComponent();

            RunQuiz = q;
        }

        private void RunQuizForm_Load(object sender, EventArgs e)
        {

        }
    }
}
