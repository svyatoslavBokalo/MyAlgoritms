namespace GrafAttemptWindowsForm
{
    public partial class Form1 : Form
    {
        private Graph graph;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                graph = new Graph(openFileDialog1.FileName);

                dataGridView1.RowCount = graph.N;
                dataGridView1.ColumnCount = graph.N;
                for(int i = 0; i < graph.N; i++)
                {
                    //dataGridView1.Columns[i].HeaderCell.Value = (i + 1).ToString();
                    //dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    for (int j = 0; j < graph.N; j++)
                    {
                        dataGridView1[j, i].Value = graph.Mas[i, j].ToString();
                    }
                }

                for (int j = 0; j < graph.N; j++)
                {
                    dataGridView1.Columns[j].HeaderCell.Style.BackColor = Color.Red;
                    dataGridView1.Columns[j].HeaderCell.Value = (j+1).ToString();
                    dataGridView1.Rows[j].HeaderCell.Value = (j + 1).ToString();
                    //dataGridView1.Rows[j].HeaderCell.
                }
            }
        }

        private void dijkstraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] res = graph.DijkstraAlgorithm1(4);

            dataGridView2.RowCount = 1;
            dataGridView2.ColumnCount = graph.N;

            //for (int i = 0; i < graph.N; i++)
            //{
            //    //dataGridView1.Columns[i].HeaderCell.Value = (i + 1).ToString();
            //    //dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            //    for (int j = 0; j < graph.N; j++)
            //    {
            //        dataGridView1[j, i].Value = graph.Mas[i, j].ToString();
            //    }
            //}

            for (int j = 0; j < graph.N; j++)
            {
                dataGridView2.Columns[j].HeaderCell.Style.BackColor = Color.Red;
                dataGridView2.Columns[j].HeaderCell.Value = (j + 1).ToString();
                //dataGridView1.Rows[j].HeaderCell.

                dataGridView2[j, 0].Value = res[j].ToString();
            }
        }
    }
}