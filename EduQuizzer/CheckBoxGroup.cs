using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace EduQuizzer
{
    public enum CheckBoxGroupBehavior { SINGLE_SELECTION, MULTI_SELECTION }

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

        private int old_selection;

        public CheckBoxGroup(int checkboxes, CheckBoxGroupBehavior behavior)
        {
            CheckBoxes = new List <GroupedCheckBox> (checkboxes);
            SelectedIndices = new List <int> (checkboxes);

            Behavior = behavior;

            for (int i = 0; i < checkboxes; i++)
            {
                CheckBoxes.Add(new GroupedCheckBox(i));

                if(Behavior == CheckBoxGroupBehavior.SINGLE_SELECTION)
                {
                    CheckBoxes[i].CheckedChanged += SingleSelectionChanged;
                    old_selection = -1;
                }
                
                if (Behavior == CheckBoxGroupBehavior.MULTI_SELECTION)
                    CheckBoxes[i].CheckedChanged += MultiSelectionChanged;
            }
        }

        public CheckBoxGroup(int checkboxes, List <int> default_checked, CheckBoxGroupBehavior behavior)
        {
            CheckBoxes = new List <GroupedCheckBox> (checkboxes);
            SelectedIndices = default_checked;

            Behavior = behavior;

            for (int i = 0; i < checkboxes; i++)
            {
                CheckBoxes.Add(new GroupedCheckBox(i));

                if (Behavior == CheckBoxGroupBehavior.SINGLE_SELECTION)
                {
                    CheckBoxes[i].CheckedChanged += SingleSelectionChanged;
                    old_selection = -1;
                }

                if (Behavior == CheckBoxGroupBehavior.MULTI_SELECTION)
                    CheckBoxes[i].CheckedChanged += MultiSelectionChanged;
            }
        }

        private void MultiSelectionChanged(object sender, EventArgs e)
        {

            foreach (GroupedCheckBox g in CheckBoxes)
                if (g.Checked)
                    if(!SelectedIndices.Contains(g.Index))
                        SelectedIndices.Add(g.Index);
                    
            //Debug.Write("multi selected indices: ");
            //foreach (int i in SelectedIndices)
            //    Debug.Write(string.Format("{0} ", i));
            //Debug.WriteLine("");
        }

        private void SingleSelectionChanged(object sender, EventArgs e)
        {
            SelectedIndices.Clear();

            bool none_checked = true;
            foreach (GroupedCheckBox g in CheckBoxes)
                if (g.Checked)
                {
                    none_checked = false;
                    break;
                }

            if (none_checked)
            {
                old_selection = -1;
                return;
            }

            if(old_selection != -1)
            {
                CheckBoxes[old_selection].Checked = false;
                CheckBoxes[old_selection].Enabled = true;
            }
            
            foreach(GroupedCheckBox g in CheckBoxes)
                if (g.Checked)
                {
                    g.Enabled = false;
                    old_selection = g.Index;

                    SelectedIndices.Add(g.Index);
                }

            //Debug.Write("single selected indices: ");
            //foreach (int i in SelectedIndices)
            //    Debug.Write(string.Format("{0} ", i));
            //Debug.WriteLine("");
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

                    if(Behavior == CheckBoxGroupBehavior.SINGLE_SELECTION)
                        g.Enabled = false;
                }

                p.Controls.Add(g);
            }
        }
    }
}
