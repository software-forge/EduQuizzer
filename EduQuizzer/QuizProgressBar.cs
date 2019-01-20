using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduQuizzer
{
    class QuizProgressBar : Control
    {
        private Quiz q;

        public int SelectedQuestion { get; set; }

        public QuizProgressBar(Quiz q)
        {
            this.q = q;
        }

        private void OnQuestionChanged()
        {

        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(System.Drawing.Brushes.Red, 100, 100, 100, 20);
        }
    }
}
