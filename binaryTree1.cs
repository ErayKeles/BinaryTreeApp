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
        private BinaryTree _tree;
        private const int CircleRadius = 30;
        private const int HorizontalSpace = 50;
        private const int VerticalSpace = 80;

        public BinaryTreeView()
        {
            InitializeComponent();
            _tree = new BinaryTree();
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

        private void DrawTree(Graphics g, BinaryTree.Node node, int x, int y, int offsetX)
        {
            if (node == null) return;

            SolidBrush brush = new SolidBrush(node.Color);
            g.FillEllipse(brush, x - CircleRadius / 2, y - CircleRadius / 2, CircleRadius, CircleRadius);
            g.DrawEllipse(Pens.Black, x - CircleRadius / 2, y - CircleRadius / 2, CircleRadius, CircleRadius);
            brush.Dispose();

            g.DrawString(node.Data.ToString(), new Font("Arial", 12), Brushes.White, x - CircleRadius / 4, y - CircleRadius / 4);

            if (node.Left != null)
            {
                g.DrawLine(Pens.Black, x, y, x - offsetX, y + VerticalSpace);
                DrawTree(g, node.Left, x - offsetX, y + VerticalSpace, offsetX / 2);
            }

            if (node.Right != null)
            {
                g.DrawLine(Pens.Black, x, y, x + offsetX, y + VerticalSpace);
                DrawTree(g, node.Right, x + offsetX, y + VerticalSpace, offsetX / 2);
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
                var foundNode = _tree.Search(value);
                if (foundNode != null)
                {
                    MessageBox.Show($"Bulunan değer: {foundNode.Data}");
                }
                else
                {
                    MessageBox.Show("Değer bulunamadı.");
                }
            }
        }

        private void preorderButton_Click(object sender, EventArgs e)
        {
            _tree.PreorderTraversal(value => MessageBox.Show(value.ToString()));
        }

        private void inorderButton_Click(object sender, EventArgs e)
        {
            _tree.InorderTraversal(value => MessageBox.Show(value.ToString()));
        }

        private void postorderButton_Click(object sender, EventArgs e)
        {
            _tree.PostorderTraversal(value => MessageBox.Show(value.ToString()));
        }
    }
}


