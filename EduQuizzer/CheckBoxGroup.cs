using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace EduQuizzer
{
    public enum CheckBoxGroupBehavior { SingleSelection, MultiSelection }

    public class CheckedBoxesChangedEventArgs : EventArgs
    {
        public List<int> Selections { get; private set; }

        public CheckedBoxesChangedEventArgs(List <int> selections) : base()
        {
            Selections = selections;
        }
    }

    public class GroupedCheckBox : CheckBox
    {
        private int _index;
        public int Index
        {
            get
            {
                return _index;
            }
            private set
            {
                if (value > -1)
                    _index = value;
                else
                    _index = 0;
            }
        }

        public GroupedCheckBox(int checkbox_index) : base()
        {
            Index = checkbox_index;
        }
    }

    public class CheckBoxGroup
    {
        public List <GroupedCheckBox> CheckBoxes;
        public List <int> SelectedIndices;

        public CheckBoxGroupBehavior Behavior { get; private set; }

        public event EventHandler <CheckedBoxesChangedEventArgs> CheckedBoxesChangedEvent;
        public delegate void CheckedBoxesChangedDelegate(object sender, CheckedBoxesChangedEventArgs e);

        public CheckBoxGroup(int checkboxes, CheckBoxGroupBehavior behavior)
        {
            CheckBoxes = new List <GroupedCheckBox> (checkboxes);
            SelectedIndices = new List <int> (checkboxes);

            Behavior = behavior;

            for (int i = 0; i < checkboxes; i++)
            {
                CheckBoxes.Add(new GroupedCheckBox(i));
                CheckBoxes[i].CheckedChanged += SelectionChanged;
            }

            CheckedBoxesChangedEvent += PrintIndices;
        }

        public CheckBoxGroup(int checkboxes, List <int> selected_indices, CheckBoxGroupBehavior behavior)
        {
            CheckBoxes = new List <GroupedCheckBox> (checkboxes);
            SelectedIndices = selected_indices;

            Behavior = behavior;

            for (int i = 0; i < checkboxes; i++)
            {
                CheckBoxes.Add(new GroupedCheckBox(i));

                if (SelectedIndices.Contains(i))
                    CheckBoxes[i].Checked = true;

                CheckBoxes[i].CheckedChanged += SelectionChanged;
            }

            CheckedBoxesChangedEvent += PrintIndices;
        }

        // Debug
        public void PrintIndices(object sender, CheckedBoxesChangedEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Debug.Write("Selected indices:");
                foreach (int i in SelectedIndices)
                {
                    Debug.Write(string.Format(" {0} ", i));
                }
                Debug.WriteLine("");
            }
        }

        public void SelectionChanged(object sender, EventArgs e)
        {
            GroupedCheckBox g = sender as GroupedCheckBox;

            if (Behavior == CheckBoxGroupBehavior.SingleSelection)
            {
                if (g.Checked)
                {
                    foreach (GroupedCheckBox checkBox in CheckBoxes)
                    {
                        if (checkBox.Index != g.Index)
                        {
                            checkBox.Checked = false;
                            checkBox.Enabled = true;
                        }
                    }
                    g.Enabled = false;
                    SelectedIndices.Clear();
                    SelectedIndices.Add(g.Index);
                }
            }

            if(Behavior == CheckBoxGroupBehavior.MultiSelection)
            {
                if(g.Checked)
                {
                    if (!SelectedIndices.Contains(g.Index))
                    {
                        SelectedIndices.Add(g.Index);
                    }
                }
                else
                {
                    int selection_index = -1;

                    for(int i = 0; i < SelectedIndices.Count; i++)
                    {
                        if(SelectedIndices[i] == g.Index)
                        {
                            selection_index = i;
                            break;
                        }
                    }

                    if(selection_index > -1)
                    {
                        SelectedIndices.RemoveAt(selection_index);
                    }
                }
            }

            if(CheckedBoxesChangedEvent != null)
            {
                CheckedBoxesChangedEvent.Invoke(this, new CheckedBoxesChangedEventArgs(SelectedIndices));
            }
        }

        public void AddToPanel(Panel p, int left, int top, int offset)
        {
            foreach(GroupedCheckBox g in CheckBoxes)
            {
                g.Left = left;
                g.Top = (top += offset);

                if (SelectedIndices.Contains(g.Index))
                {
                    g.Checked = true;

                    if(Behavior == CheckBoxGroupBehavior.SingleSelection)
                        g.Enabled = false;
                }

                p.Controls.Add(g);
            }
        }
    }
}
