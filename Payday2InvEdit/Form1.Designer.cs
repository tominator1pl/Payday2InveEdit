namespace Payday2InvEdit
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenInv = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.buttonRemItem = new System.Windows.Forms.Button();
            this.textItemsQty = new System.Windows.Forms.Label();
            this.openFileDialogSchema = new System.Windows.Forms.OpenFileDialog();
            this.buttonLoadSchema = new System.Windows.Forms.Button();
            this.comboBoxItems = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "inventory.bin";
            // 
            // buttonOpenInv
            // 
            this.buttonOpenInv.Location = new System.Drawing.Point(12, 12);
            this.buttonOpenInv.Name = "buttonOpenInv";
            this.buttonOpenInv.Size = new System.Drawing.Size(130, 23);
            this.buttonOpenInv.TabIndex = 0;
            this.buttonOpenInv.Text = "Select Inventory";
            this.buttonOpenInv.UseVisualStyleBackColor = true;
            this.buttonOpenInv.Click += new System.EventHandler(this.buttonOpenInv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(953, 450);
            this.dataGridView1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(891, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Items:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 41);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddItem.Location = new System.Drawing.Point(786, 41);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(75, 23);
            this.buttonAddItem.TabIndex = 6;
            this.buttonAddItem.Text = "Add Item";
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // buttonRemItem
            // 
            this.buttonRemItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemItem.Location = new System.Drawing.Point(867, 41);
            this.buttonRemItem.Name = "buttonRemItem";
            this.buttonRemItem.Size = new System.Drawing.Size(99, 23);
            this.buttonRemItem.TabIndex = 8;
            this.buttonRemItem.Text = "Remove Item";
            this.buttonRemItem.UseVisualStyleBackColor = true;
            this.buttonRemItem.Click += new System.EventHandler(this.buttonRemItem_Click);
            // 
            // textItemsQty
            // 
            this.textItemsQty.AutoSize = true;
            this.textItemsQty.Location = new System.Drawing.Point(931, 17);
            this.textItemsQty.Name = "textItemsQty";
            this.textItemsQty.Size = new System.Drawing.Size(0, 13);
            this.textItemsQty.TabIndex = 9;
            // 
            // openFileDialogSchema
            // 
            this.openFileDialogSchema.FileName = "item_schema.bin";
            // 
            // buttonLoadSchema
            // 
            this.buttonLoadSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadSchema.Location = new System.Drawing.Point(769, 12);
            this.buttonLoadSchema.Name = "buttonLoadSchema";
            this.buttonLoadSchema.Size = new System.Drawing.Size(116, 23);
            this.buttonLoadSchema.TabIndex = 10;
            this.buttonLoadSchema.Text = "Load Item Schema";
            this.buttonLoadSchema.UseVisualStyleBackColor = true;
            this.buttonLoadSchema.Click += new System.EventHandler(this.buttonLoadSchema_Click);
            // 
            // comboBoxItems
            // 
            this.comboBoxItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxItems.FormattingEnabled = true;
            this.comboBoxItems.Location = new System.Drawing.Point(93, 43);
            this.comboBoxItems.Name = "comboBoxItems";
            this.comboBoxItems.Size = new System.Drawing.Size(687, 21);
            this.comboBoxItems.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 532);
            this.Controls.Add(this.comboBoxItems);
            this.Controls.Add(this.buttonLoadSchema);
            this.Controls.Add(this.textItemsQty);
            this.Controls.Add(this.buttonRemItem);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOpenInv);
            this.Name = "Form1";
            this.Text = "PayDay2 Inventory Editor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonOpenInv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Button buttonRemItem;
        private System.Windows.Forms.Label textItemsQty;
        private System.Windows.Forms.OpenFileDialog openFileDialogSchema;
        private System.Windows.Forms.Button buttonLoadSchema;
        private System.Windows.Forms.ComboBox comboBoxItems;
    }
}

