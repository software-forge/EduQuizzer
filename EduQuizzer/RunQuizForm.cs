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

        private QuizProgressBar QuizProgressBar { get; set; }

        public RunQuizForm(Quiz q)
        {
            InitializeComponent();

            QuizProgressBar = new QuizProgressBar(q);
            Controls.Add(QuizProgressBar);
        }

        private void RunQuizFormLoad(object sender, EventArgs e)
        {

        }
    }
}
