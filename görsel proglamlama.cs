using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneme2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            var btnekle = ttl.Text;
            illera.Items.Add(btnekle);
            ttl.Clear();
            ttl.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnekle_Click(sender, e);
            }
        }

        private void btnaktar_Click(object sender, EventArgs e)
        {
            var seçilenIndeksler = illera.SelectedIndices;
            if (seçilenIndeksler.Count <= 0)
            {
                MessageBox.Show(
                    "aktaracak il seçiniz",
                    "hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            foreach (int item in seçilenIndeksler)
            {
                illerb.Items.Add(illera.Items[item]);
            }

            for (int i = seçilenIndeksler.Count - 1; i >= 0; i--)
            {
                illera.Items.RemoveAt(seçilenIndeksler[i]);
            }
        }

        private void illera_MouseDown(object sender, MouseEventArgs e)
        {
            if (illera.SelectedItems.Count > 0)
            {
                illera.DoDragDrop(illera, DragDropEffects.Move);
            }
        }

        private void illerb_DragOver(object sender, DragEventArgs e)
        {
            var taşınanData = e.Data.GetData(typeof(ListBox).FullName) as ListBox;
            if (taşınanData != null)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void illerb_DragDrop(object sender, DragEventArgs e)
        {
            ListBox kaynakListBox = e.Data.GetData(typeof(ListBox)) as ListBox;

            if (kaynakListBox != null)
            {
                var secilenIndeksler = kaynakListBox.SelectedIndices;

                foreach (int indeks in secilenIndeksler)
                {
                    illerb.Items.Add(kaynakListBox.Items[indeks]);
                }

                for (int i = secilenIndeksler.Count - 1; i >= 0; i--)
                {
                    kaynakListBox.Items.RemoveAt(secilenIndeksler[i]);
                }
            }
        }

        private void btngeri_Click(object sender, EventArgs e)
        {
            var secilenIndeksler = illerb.SelectedIndices;
            if (secilenIndeksler.Count <= 0)
            {
                MessageBox.Show("geri aktarılacak il seçiniz", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (int indeks in secilenIndeksler)
            {
                illera.Items.Add(illerb.Items[indeks]);
            }

            for (int i = secilenIndeksler.Count - 1; i >= 0; i--)
            {
                illerb.Items.RemoveAt(secilenIndeksler[i]);
            }
        }

        private void illerb_MouseDown(object sender, MouseEventArgs e)
        {
            if (illerb.SelectedItems.Count > 0)
            {
                illerb.DoDragDrop(illerb, DragDropEffects.Move);
            }
        }

        private void illera_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListBox)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void illera_DragDrop(object sender, DragEventArgs e)
        {
            ListBox kaynakListBox = e.Data.GetData(typeof(ListBox)) as ListBox;

            if (kaynakListBox != null)
            {
                var secilenIndeksler = kaynakListBox.SelectedIndices;

                foreach (int indeks in secilenIndeksler)
                {
                    illera.Items.Add(kaynakListBox.Items[indeks]);
                }

                for (int i = secilenIndeksler.Count - 1; i >= 0; i--)
                {
                    kaynakListBox.Items.RemoveAt(secilenIndeksler[i]);
                }
            }
        }
    }
}
