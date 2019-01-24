using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace EduQuizzer
{
    public class GroupedButton : Button
    {
        public int Index { get; private set; }

        private bool _selected;
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;

                Repaint();
            }
        }

        public GroupedButton(int index)
        {
            Index = index;
            Selected = false;

            Text = string.Format("{0}", Index);

            MouseHover += OnHover;
            MouseLeave += OnLeave;
        }

        public void OnHover(object sender, EventArgs e)
        {
            ForeColor = Color.Yellow;
            
            // TODO - zmiana koloru Bordera
        }

        public void OnLeave(object sender, EventArgs e)
        {
            Repaint();
        }

        public void Repaint()
        {
            
            ForeColor = Color.White;

            // TODO - tutaj ustawienie domyślnego koloru bordera

            if (Selected)
            {
                BackColor = Color.Blue;
            }
            else
            {
                BackColor = Color.LightBlue;
            }
        }
    }

    public class ButtonGroup
    {
        public List <GroupedButton> Buttons { get; private set; }
        public int ButtonsCount
        {
            get
            {
                return Buttons.Count;
            }
        }

        public int SelectedIndex
        {
            get
            {
                foreach(GroupedButton a in Buttons)
                    if (a.Selected)
                        return a.Index;
                return -1;
            }
        }

        public event EventHandler SelectionChanged;

        public ButtonGroup(int buttons)
        {
            if (buttons < 0)
                throw new ArgumentOutOfRangeException();
            Buttons = new List<GroupedButton>(buttons);
            for(int i = 0; i < buttons; i++)
            {
                Buttons.Add(new GroupedButton(i));
                Buttons[i].Click += ButtonClicked;
            }
            Buttons[0].Selected = true;
        }

        public void ButtonClicked(object sender, EventArgs e)
        {
            GroupedButton g = sender as GroupedButton;

            if(SelectedIndex != g.Index)
                Select(g.Index);
        }

        public void Select(int button)
        {
            if (button < 0 || (button > (ButtonsCount - 1)))
                throw new ArgumentOutOfRangeException();
            int selected = SelectedIndex;
            if(selected > -1)
                Buttons[selected].Selected = false;
            Buttons[button].Selected = true;
            Repaint();
            SelectionChanged.Invoke(this, new EventArgs());
        }

        public void SelectNext()
        {
            int selected = SelectedIndex;
            if(selected < (ButtonsCount - 1))
            {
                if (selected > -1)
                {
                    Buttons[selected].Selected = false;
                    Buttons[selected + 1].Selected = true;
                }
                else
                {
                    Buttons[0].Selected = true;
                }
                Repaint();
                SelectionChanged.Invoke(this, new EventArgs());
            }
        }

        public void SelectPrevious()
        {
            int selected = SelectedIndex;
            if(selected > 0)
            {
                Buttons[selected].Selected = false;
                Buttons[selected - 1].Selected = true;
                Repaint();
                SelectionChanged.Invoke(this, new EventArgs());
            }
        }

        public void Repaint()
        {
            foreach(GroupedButton g in Buttons)
                g.Repaint();
        }

        public void AddToPanel(Panel p, int top, int left, int offset)
        {
            foreach(GroupedButton g in Buttons)
            {
                g.Left = (left += (offset + g.Width));
                g.Top = top;
                p.Controls.Add(g);
            }
            Repaint();
        }
    }
}
