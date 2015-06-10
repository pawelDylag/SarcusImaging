﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SarcusImaging
{
    public partial class SequenceForm : Form
    {
        private static SequenceForm openedWindow = null;

        public SequenceForm()
        {
            InitializeComponent();
            initList();
        }

        /// <summary>
        /// This method ensures that only one dialog is opened at given time
        /// </summary>
        public static void ShowForm(SarcusImaging parentForm)
        {
            if (openedWindow != null)
            {
                openedWindow.BringToFront();
            }
            else
            {
                openedWindow = new SequenceForm();
                openedWindow.MdiParent = parentForm;
                openedWindow.Show();
            }
        }

        private void initList()
        {
            ArrayList row = new ArrayList();
            DataGridViewComboBoxColumn col1 = new DataGridViewComboBoxColumn();
            col1.HeaderText = "Type";
            col1.Name = "2";
            row.Add("Bias");
            row.Add("Sequence");
            row.Add("Probe");
            row.Add("Background");
            col1.Items.AddRange(row.ToArray());
            col1.SortMode = DataGridViewColumnSortMode.NotSortable;
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Exposure";
            col2.Name = "2";
            col2.SortMode = DataGridViewColumnSortMode.NotSortable;
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "Images";
            col3.Name = "3";
            col3.SortMode = DataGridViewColumnSortMode.NotSortable;
            DataGridViewComboBoxColumn col4 = new DataGridViewComboBoxColumn();
            row = new ArrayList();
            col4.HeaderText = "Trigger";
            col4.Name = "4";
            row.Add("No trigger");
            row.Add("Each image");
            row.Add("Whole group");
            col4.Items.AddRange(row.ToArray());
            col4.SortMode = DataGridViewColumnSortMode.NotSortable;
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Filename";
            col5.Name = "5";
            col5.SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridViewSequence.Columns.Add(col1);
            dataGridViewSequence.Columns.Add(col2);
            dataGridViewSequence.Columns.Add(col3);
            dataGridViewSequence.Columns.Add(col4);
            dataGridViewSequence.Columns.Add(col5);

            dataGridViewSequence.RowHeadersVisible = false;

        }

        private void dataGridViewSequence_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void sequenceForm_FormClosed(object sender, EventArgs e)
        {
            openedWindow = null;
        }

        private SequencePlan generateSequencePlan()
        {
            Debug.WriteLine("generateSequencePlan() : start");
            SequencePlan result = new SequencePlan();
            // get list items
            DataGridViewRowCollection rows = dataGridViewSequence.Rows;
            // loop for each item
            for (int i = 0; i < rows.Count; i++)
            {
                DataGridViewRow row = rows[i];
                int type, images, trigger;
                double exposure;
                String filename;
                // get type
                String typeValue = (String) row.Cells[0].Value;
                switch (typeValue)
                {
                    case "Bias":
                        type = (int)SequenceItem.types.TYPE_BIAS;
                        break;
                    case "Background":
                        type = (int)SequenceItem.types.TYPE_BACKGROUND;
                        break;
                    case "Sequence":
                        type = (int)SequenceItem.types.TYPE_SEQUENCE;
                        break;
                    case "Probe":
                        type = (int)SequenceItem.types.TYPE_PROBE;
                        break;
                    default:
                        type = (int)SequenceItem.types.TYPE_SEQUENCE;
                        break;
                }
                // check exposure time value
                String exposureValue = (String)row.Cells[1].Value;
                if (!Double.TryParse(exposureValue, out exposure))
                {
                    Debug.WriteLine("generateSequencePlan() : double.TryParse error for value: " + exposureValue);
                }
                // check image count value
                String imagesValue = (String)row.Cells[2].Value;
                if (int.TryParse(imagesValue, out images))
                {
                    if (i < 0 || i > 65535)
                    {
                        Debug.WriteLine("generateSequencePlan() : image count is invalid");
                    }
                }
                else Debug.WriteLine("generateSequencePlan() : images.TryParse error for input: " + imagesValue );
                // check trigger
                String triggerValue = (String)row.Cells[3].Value;
                switch (triggerValue)
                {
                    case "No trigger":
                        trigger = (int)SequenceItem.triggerTypes.TRIGGER_NONE;
                        break;
                    case "Each image":
                        trigger = (int)SequenceItem.triggerTypes.TRIGGER_EACH;
                        break;
                    case "Whole group":
                        trigger = (int)SequenceItem.triggerTypes.TRIGGER_WHOLE;
                        break;
                    default:
                        trigger = (int)SequenceItem.triggerTypes.TRIGGER_NONE;
                        break;
                }
                // get filename
                filename = (String) row.Cells[4].Value;
                result.addItem(new SequenceItem(i, type, exposure, images, trigger, filename));
                Debug.WriteLine("generateSequencePlan() : new item (id = " + i + ", type =  " + type + ", exposure = " + exposure + ", images = " + images + ", trigger = " + trigger + ", filename = " + filename + ")");
            }
            return result;
        }
        

        /// <summary>
        /// Adds new sequence item to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            dataGridViewSequence.Rows.Add("Sequence","1,0", "1", "No trigger", "img");
        }

        /// <summary>
        /// Removes selected sequence items from list 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGridViewSequence.SelectedRows;
            foreach (DataGridViewRow row in selectedRows)
            {
                dataGridViewSequence.Rows.Remove(row);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            SequencePlan sequencePlan = generateSequencePlan();
            openedWindow.Invoke((MethodInvoker)delegate ()
            {
                SingleImageForm.ShowForm((SarcusImaging)this.MdiParent);
            });
            CameraManager.Instance.executeSequencePlan(sequencePlan);
        }


    }
}