﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace EduQuizzer
{
    public class SelectedButtonChangedEventArgs : EventArgs
    {
        public int Selection { get; private set; }

        public SelectedButtonChangedEventArgs(int selection) : base()
        {
            Selection = selection;
        }
    }

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

            Text = string.Format("{0}", Index + 1);

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

        public event EventHandler<SelectedButtonChangedEventArgs> SelectedButtonChanged;
        public delegate void SelectedButtonChangedDelegate(object sender, SelectedButtonChangedEventArgs e);

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

            SelectedButtonChanged += PrintIndex;
        }

        // Debug
        public void PrintIndex(object sender, SelectedButtonChangedEventArgs e)
        {
            if(Debugger.IsAttached)
            {
                Debug.WriteLine(string.Format("Selected index (ButtonGroup): {0}", e.Selection));
            }
        }

        public void ButtonClicked(object sender, EventArgs e)
        {
            GroupedButton g = sender as GroupedButton;

            if(SelectedIndex != g.Index)
            {
                Select(g.Index);
            }
        }

        public void Select(int button)
        {
            if (button < 0 || (button > (ButtonsCount - 1)))
                throw new ArgumentOutOfRangeException();

            int selected = SelectedIndex;

            if(selected > -1)
            {
                Buttons[selected].Selected = false;
            }
            Buttons[button].Selected = true;

            Repaint();

            if(SelectedButtonChanged != null)
            {
                SelectedButtonChanged.Invoke(this, new SelectedButtonChangedEventArgs(SelectedIndex));
            }
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

                if(SelectedButtonChanged != null)
                {
                    SelectedButtonChanged.Invoke(this, new SelectedButtonChangedEventArgs(SelectedIndex));
                }
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

                if(SelectedButtonChanged != null)
                {
                    SelectedButtonChanged.Invoke(this, new SelectedButtonChangedEventArgs(SelectedIndex));
                }
            }
        }

        public void Repaint()
        {
            foreach(GroupedButton g in Buttons)
                g.Repaint();
        }

        public void AddToPanel(Panel p, int top)
        {
            const int button_w = 30;
            const int button_h = 30;
            const int offset = 1;

            int group_w = (ButtonsCount * button_w) + (offset * (ButtonsCount - 1));
            int left = ((p.Width / 2) - (group_w / 2));

            foreach(GroupedButton g in Buttons)
            {
                g.Top = top;
                g.Left = left;
                left += button_w + offset;
                g.Width = button_w;
                g.Height = button_h;
                p.Controls.Add(g);
            }
            Repaint();
        }
    }
}
