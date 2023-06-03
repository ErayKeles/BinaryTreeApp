using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryTreeApp
{
    public partial class BinaryTreeView : Form
    {
        private RedBlackTree _tree;
        private const int CircleRadius = 30;
        private const int HorizontalSpace = 50;
        private const int VerticalSpace = 80;

        public BinaryTreeView()
        {
            InitializeComponent();
            _tree = new RedBlackTree();
            _tree.TreeChanged += OnTreeChanged;

            this.DoubleBuffered = true;
        }

        private void OnTreeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawTree(e.Graphics, _tree.Root, this.Width / 2, 50, this.Width / 4);
        }

        private void DrawTree(Graphics g, RedBlackTree.Node node, int x, int y, int offsetX)
        {
            if (node == null) return;

            SolidBrush brush = new SolidBrush(node.Color == RedBlackTree.NodeColor.Red ? Color.Red : Color.Black);
            g.FillEllipse(brush, x - CircleRadius / 2, y - CircleRadius / 2, CircleRadius, CircleRadius);
            g.DrawEllipse(Pens.Black, x - CircleRadius / 2, y - CircleRadius / 2, CircleRadius, CircleRadius);
            brush.Dispose();

            g.DrawString(node.Data.ToString(), new Font("Arial", 12), Brushes.White, x - CircleRadius / 4, y - CircleRadius / 4);

            if (node.Left != null)
            {
                int leftX = x - offsetX;
                int leftY = y + VerticalSpace;
                g.DrawLine(Pens.Black, x, y + CircleRadius / 2, leftX + CircleRadius / 2, leftY - CircleRadius / 2);
                DrawTree(g, node.Left, leftX, leftY, offsetX / 2);
            }

            if (node.Right != null)
            {
                int rightX = x + offsetX;
                int rightY = y + VerticalSpace;
                g.DrawLine(Pens.Black, x + CircleRadius / 2, y + CircleRadius / 2, rightX + CircleRadius / 2, rightY - CircleRadius / 2);
                DrawTree(g, node.Right, rightX, rightY, offsetX / 2);
            }
        }



        private void insertButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(valueTextBox.Text, out int value))
            {
                _tree.Insert(value);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(valueTextBox.Text, out int value))
            {
                _tree.Delete(value);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(valueTextBox.Text, out int value))
            {
                if (_tree.Search(value))
                {
                    MessageBox.Show($"Bulunan değer: {value}");
                }
                else
                {
                    MessageBox.Show("Değer bulunamadı.");
                }
            }
        }

        private void preorderButton_Click(object sender, EventArgs e)
        {
            traversalListBox.Items.Clear(); 
            _tree.PreorderTraversal(value => traversalListBox.Items.Add(value.ToString())); 
        }

        private void inorderButton_Click(object sender, EventArgs e)
        {
            traversalListBox.Items.Clear(); 
            _tree.InorderTraversal(value => traversalListBox.Items.Add(value.ToString())); 
        }

        private void postorderButton_Click(object sender, EventArgs e)
        {
            traversalListBox.Items.Clear(); // ListBox'ı temizle
            _tree.PostorderTraversal(value => traversalListBox.Items.Add(value.ToString())); // Değerleri ListBox'a ekle
        }


    }
}
