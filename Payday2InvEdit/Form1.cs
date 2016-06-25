using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payday2InvEdit
{
    public partial class Form1 : Form
    {
        List<Itemek> itemki;
        DataTable itemSchemas;
        public Form1()
        {
            InitializeComponent();
            itemki = new List<Itemek>();
            itemSchemas = new DataTable();
            itemSchemas.Columns.Add("Key");
            itemSchemas.Columns.Add("Value");
            dataGridView1.AutoGenerateColumns = false;
        }

        private void buttonOpenInv_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                label1.Text = openFileDialog1.FileName;
                itemki = new List<Itemek>();
                itemki = LoadItemsfromFile(openFileDialog1);
                DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                comboCol.HeaderText = "Item";
                comboCol.Name = "itemCombo";
                comboCol.DataPropertyName = "itemHexID";
                comboCol.DataSource = itemSchemas;
                comboCol.DisplayMember = "Value";
                comboCol.ValueMember = "Key";
                dataGridView1.Columns.Add(comboCol);
                //dataGridView1.Columns.Add("itemHexID", "Item Hex ID");
                dataGridView1.Columns.Add("itemQty", "Item Quanity");
                dataGridView1.Columns.Add("itemOther", "Item Other");
                //dataGridView1.Columns["itemHexID"].DataPropertyName = "itemHexID";
                dataGridView1.Columns["itemQty"].DataPropertyName = "itemQty";
                dataGridView1.Columns["itemOther"].DataPropertyName = "itemOther";
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = itemki;
            }
        }

        private List<Itemek> LoadItemsfromFile(OpenFileDialog oFD)
        {
            
            string itemID;
            int qty;
            string oth;
            using (var stream = new FileStream(oFD.FileName, FileMode.Open, FileAccess.Read))
            {
                stream.Position = 0x08;
                int itemsQty = stream.ReadByte();
                textItemsQty.Text = itemsQty.ToString();
                for (int i = 1; i <= itemsQty; i++) {
                    stream.Position = Convert.ToInt32(i.ToString("X") + "4",16);
                    stream.Position -= 8;
                    oth = stream.ReadByte().ToString("X2") + " ";
                    oth += stream.ReadByte().ToString("X2") + " ";
                    oth += stream.ReadByte().ToString("X2") + " ";
                    oth += stream.ReadByte().ToString("X2");

                    stream.Position = Convert.ToInt32(i.ToString("X") + "4", 16);
                    itemID = stream.ReadByte().ToString("X2") + " ";
                    itemID += stream.ReadByte().ToString("X2") + " ";
                    itemID += stream.ReadByte().ToString("X2") + " ";
                    itemID += stream.ReadByte().ToString("X2");
                    qty = stream.ReadByte();
                    itemki.Add(new Itemek(itemID, qty, oth));
                }
            }
            return itemki;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (var stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite))
            {
                stream.Position = 0x08;
                stream.WriteByte(Convert.ToByte(textItemsQty.Text));
                FillZeros(stream, 3);
                for(int h = 0; h < dataGridView1.RowCount; h++)
                {
                    AddItemToFile(stream, h);
                }
                stream.SetLength(stream.Position);
            }
        }

        private void FillZeros(FileStream stream, int byts)
        {
            for(int j = 0; j < byts; j++)
            {
                stream.WriteByte(0x0);
            }
        }

        private void AddItemToFile(FileStream stream, int row)
        {
            DataGridViewRow roww = dataGridView1.Rows[row];
            string other = roww.Cells[2].Value.ToString();
            WriteBytesFromString(stream, other);
            FillZeros(stream, 4);
            string itemID = roww.Cells[0].Value.ToString();
            WriteBytesFromString(stream, itemID);
            byte itemQty = Convert.ToByte(roww.Cells[1].Value.ToString(), 16);
            stream.WriteByte(itemQty);
            FillZeros(stream, 3);
        }

        private void WriteBytesFromString(Stream stream, string str)
        {
            byte[] strBytes = DivideIntoBytes(str);
            for (int x = 0; x < strBytes.Length; x++)
            {
                stream.WriteByte(strBytes[x]);
            }
        }

        private byte[] DivideIntoBytes(string str)
        {
            
            string[] strBytes = str.Split(new string[] {" "},StringSplitOptions.RemoveEmptyEntries);
            byte[] bytes = new byte[strBytes.Length];
            for (int g = 0; g < strBytes.Length; g++)
            {
                bytes[g] = Convert.ToByte(strBytes[g], 16);
            }
            return bytes;
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            itemki.Add(new Itemek(comboBoxItems.SelectedValue.ToString(), 1, "76 63 95 A6"));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = itemki;
            textItemsQty.Text = dataGridView1.RowCount.ToString();
        }

        private void buttonRemItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            foreach(DataGridViewRow row in rows)
            {
                Itemek founditem = itemki.Find(x => x.ItemHexId == row.Cells[0].Value.ToString() && x.ItemQty == Convert.ToInt32(row.Cells[1].Value) && x.ItemOther == row.Cells[2].Value.ToString());
                itemki.Remove(founditem);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = itemki;
            textItemsQty.Text = dataGridView1.RowCount.ToString();
        }

        private void buttonLoadSchema_Click(object sender, EventArgs e)
        {
            if (openFileDialogSchema.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                itemSchemas = LoadItemSchemas(openFileDialogSchema);
                comboBoxItems.DataSource = itemSchemas;
                comboBoxItems.DisplayMember = "Value";
                comboBoxItems.ValueMember = "Key";
            }
        }

        private DataTable LoadItemSchemas(OpenFileDialog oFD)
        {
            DataTable itemSchems = new DataTable();
            itemSchems.Columns.Add("Key");
            itemSchems.Columns.Add("Value");
            string itemID;
            string itemName;
            using (var stream = new FileStream(oFD.FileName, FileMode.Open, FileAccess.Read))
            {
                itemID = "50 C3 00 00";
                itemName = "Completely OVERKILL Safe ";
                itemSchems.Rows.Add(itemID, itemName); //adding first safe mannually as it doesn have true or false at start;
                for (long p = 0; p < stream.Length; p++)
                {
                    int byt = stream.ReadByte();
                    if (byt == 0x66)
                    {
                        p++;
                        byt = stream.ReadByte();
                        if (byt == 0x61)
                        {
                            p++;
                            byt = stream.ReadByte();
                            if (byt == 0x6c)
                            {
                                p++;
                                byt = stream.ReadByte();
                                if (byt == 0x73)
                                {
                                    p++;
                                    byt = stream.ReadByte();
                                    if (byt == 0x65)
                                    {
                                        p++;
                                        byt = stream.ReadByte();
                                        if (byt == 0x00)
                                        {
                                            //Found "false "
                                            itemID = stream.ReadByte().ToString("X2") + " ";
                                            itemID += stream.ReadByte().ToString("X2") + " ";
                                            itemID += stream.ReadByte().ToString("X2") + " ";
                                            itemID += stream.ReadByte().ToString("X2");
                                            p += 4;
                                            while (true)
                                            {
                                                p++;
                                                byt = stream.ReadByte();
                                                if (byt == 0x6E)
                                                {
                                                    p++;
                                                    byt = stream.ReadByte();
                                                    if (byt == 0x61)
                                                    {
                                                        p++;
                                                        byt = stream.ReadByte();
                                                        if (byt == 0x6D)
                                                        {
                                                            p++;
                                                            byt = stream.ReadByte();
                                                            if (byt == 0x65)
                                                            {
                                                                //Found "name"
                                                                p++;
                                                                stream.Position += 4;
                                                                itemName = Convert.ToChar(stream.ReadByte()).ToString();
                                                                while (true)
                                                                {
                                                                    p++;
                                                                    byt = stream.ReadByte();
                                                                    
                                                                    if (byt == 0x0B)
                                                                    {
                                                                        break;
                                                                    }
                                                                    if (byt == 0x08)
                                                                    {
                                                                        break;
                                                                    }
                                                                    itemName += Convert.ToChar(byt).ToString();
                                                                }
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            itemSchems.Rows.Add(itemID, itemName);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (byt == 0x74)
                    {
                        p++;
                        byt = stream.ReadByte();
                        if (byt == 0x72)
                        {
                            p++;
                            byt = stream.ReadByte();
                            if (byt == 0x75)
                            {
                                p++;
                                byt = stream.ReadByte();
                                if (byt == 0x65)
                                {
                                    p++;
                                    byt = stream.ReadByte();
                                    if (byt == 0x00)
                                    {
                                        //Found "true "
                                        itemID = stream.ReadByte().ToString("X2") + " ";
                                        itemID += stream.ReadByte().ToString("X2") + " ";
                                        itemID += stream.ReadByte().ToString("X2") + " ";
                                        itemID += stream.ReadByte().ToString("X2");
                                        p += 4;
                                        while (true)
                                        {
                                            p++;
                                            byt = stream.ReadByte();
                                            if (byt == 0x6E)
                                            {
                                                p++;
                                                byt = stream.ReadByte();
                                                if (byt == 0x61)
                                                {
                                                    p++;
                                                    byt = stream.ReadByte();
                                                    if (byt == 0x6D)
                                                    {
                                                        p++;
                                                        byt = stream.ReadByte();
                                                        if (byt == 0x65)
                                                        {
                                                            //Found "name"
                                                            p++;
                                                            stream.Position += 4;
                                                            itemName = Convert.ToChar(stream.ReadByte()).ToString();
                                                            while (true)
                                                            {
                                                                p++;
                                                                byt = stream.ReadByte();
                                                                
                                                                if (byt == 0x0B)
                                                                {
                                                                    break;
                                                                }
                                                                if (byt == 0x08)
                                                                {
                                                                    break;
                                                                }
                                                                itemName += Convert.ToChar(byt).ToString();
                                                            }
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        itemSchems.Rows.Add(itemID, itemName);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return itemSchems;
        }
    }
}
