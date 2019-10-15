using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApplication3;

namespace IOWindow
{
    public partial class MainForm : Form
    {
        List<Polynomial.Point> Points { get; } = new List<Polynomial.Point>();

        Polynomial PolynomialFunction { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddValuesButton_Click(object sender, EventArgs e)
        {
            double x;
            if (!double.TryParse(xValueTextBox.Text, out x))
            {
                MessageBox.Show(@"Invalid x value!");
                return;
            }

            double y;
            if (!double.TryParse(yValueTextBox.Text, out y))
            {
                MessageBox.Show(@"Invalid y value!");
                return;
            }

            Points.Add(new Polynomial.Point(x,y));

            Render();
        }

        private void Render()
        {
            PointsListBox.Items.Clear();
            foreach (var point in Points)
                PointsListBox.Items.Add(point);

            PolynomialFunction = new Polynomial(Points.Count);
            PolynomialFunction.Fit(Points.ToArray());
            EquationsRichTextBox.Text = PolynomialFunction.PrintEquations(FittedCheckBox.Checked);
            
        }

        private void RemovePointButton_Click(object sender, EventArgs e)
        {
            if (PointsListBox.SelectedIndex == -1)
            {
                MessageBox.Show(@"Select a point to remove");
                return;
            }

            Points.RemoveAt(PointsListBox.SelectedIndex);

            Render();
        }

        private void FittedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Render();
        }
    }
}
