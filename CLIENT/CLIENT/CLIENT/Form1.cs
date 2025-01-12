using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CLIENT
{
	public partial class Form1 : Form
	{

		int numForm;
		Socket server;
		string username;
        int currentMatchID;


        delegate void DelegateToWrite (string mensaje);
        public Form1(int numForm, Socket server, string userename, int currentMatchID)
		{
			InitializeComponent();
			this.numForm = numForm;
			this.server = server;
			this.username = userename;
            this.currentMatchID=currentMatchID;
            CheckForIllegalCrossThreadCalls = false;

            CheckForIllegalCrossThreadCalls = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            dataGridView1.CellPainting += dataGridView1_CellPainting;
			dataGridView2.CellPainting += dataGridView2_CellPainting;
			this.BackgroundImage = Image.FromFile("..\\..\\images\\tierra.jpg");
			this.BackgroundImageLayout = ImageLayout.Stretch;

            UpdateMatchIDLabel();
        }

        private void UpdateMatchIDLabel()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateMatchIDLabel));
            }
            else
            {
                IDLBL.Text = currentMatchID.ToString();
            }
        }
        public void UpdateMatchID(int newMatchID)
        {
            currentMatchID = newMatchID;
            UpdateMatchIDLabel();
        }

        private void Form1_Load(object sender, EventArgs e)
		{
			ConfigDataGridView1();
			ConfigDataGridView2();
		}
        


        public void pintar(string respuesta, int positionX, int positionY)
		{
			int targetColumn = positionY;
			int targetRow = positionX;

			

			if (respuesta == "There is a rocket in this position")
			{
				string imagePath = "..\\..\\images\\fuego.png";
				Image fireImage = Image.FromFile(imagePath);

				
				Image scaledImage = new Bitmap(fireImage, dataGridView2.Columns[targetColumn].Width, dataGridView2.Rows[targetRow].Height);

				if (!(dataGridView2.Rows[targetRow].Cells[targetColumn] is DataGridViewImageCell))
				{
					dataGridView2.Rows[targetRow].Cells[targetColumn] = new DataGridViewImageCell();
				}

			
				dataGridView2.Rows[targetRow].Cells[targetColumn].Value = scaledImage;
				dataGridView2.Rows[targetRow].Cells[targetColumn].Style.BackColor = Color.White;
				dataGridView2.InvalidateCell(dataGridView2.Rows[targetRow].Cells[targetColumn]);

				
			}
			else if (respuesta == "No rocket found in this position")
			{
				string imagePath = "..\\..\\images\\bomba.png";
				Image bombImage = Image.FromFile(imagePath);

				
				Image scaledImage = new Bitmap(bombImage, dataGridView2.Columns[targetColumn].Width, dataGridView2.Rows[targetRow].Height);

				
				if (!(dataGridView2.Rows[targetRow].Cells[targetColumn] is DataGridViewImageCell))
				{
					dataGridView2.Rows[targetRow].Cells[targetColumn] = new DataGridViewImageCell();
				}

				
				dataGridView2.Rows[targetRow].Cells[targetColumn].Value = scaledImage;
				dataGridView2.Rows[targetRow].Cells[targetColumn].Style.BackColor = Color.White;
				dataGridView2.InvalidateCell(dataGridView2.Rows[targetRow].Cells[targetColumn]);

			}
		}

        public void ConfigDataGridView2()
        {
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.ColumnCount = 10;
            int cellSize = 30;

            for (int i = 0; i < 10; i++)
            {
                dataGridView2.Columns[i].Name = (i).ToString();
                dataGridView2.Columns[i].Width = cellSize;
            }

            for (int j = 0; j < 10; j++)
            {
                 dataGridView2.Rows.Add();
                 dataGridView2.Rows[j].HeaderCell.Value = (j).ToString();
                 dataGridView2.Rows[j].Height = cellSize;
            }

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView2.RowHeadersWidth = 50;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView2.MultiSelect = true;

            dataGridView2.ScrollBars = ScrollBars.None;

            dataGridView2.Width = (cellSize * 10) + dataGridView2.RowHeadersWidth + 2;
            dataGridView2.Height = (cellSize * 10) + dataGridView2.ColumnHeadersHeight + 2;
        }

        public void ConfigDataGridView1()
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnCount = 10;
            int cellSize = 30; 

            for (int i = 0; i < 10; i++)
            {
               dataGridView1.Columns[i].Name = (i).ToString();
               dataGridView1.Columns[i].Width = cellSize; 
            }

            for (int j = 0; j < 10; j++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[j].HeaderCell.Value = (j).ToString();
                dataGridView1.Rows[j].Height = cellSize; 
            }
          
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.RowHeadersWidth = 50; 
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.MultiSelect = true;
            
            dataGridView1.ScrollBars = ScrollBars.None;

            dataGridView1.Width = (cellSize * 10) + dataGridView1.RowHeadersWidth + 2; 
            dataGridView1.Height = (cellSize * 10) + dataGridView1.ColumnHeadersHeight + 2; 
        }

        public void SendSelectedCells_Click(object sender, EventArgs e)
        {
            if (server == null || !server.Connected)
            {
                MessageBox.Show("Connect to server first, please");
                return;
            }

            List<string> ListSelectedCells = new List<string>();

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                int rowIndex = cell.RowIndex; 
                int columnIndex = cell.ColumnIndex;
                string cellAsFloat = $"{rowIndex}.{columnIndex}";
                ListSelectedCells.Add(cellAsFloat);

                if (ListSelectedCells.Count == 3)
                    break;
            }

            string query = $"8/{numForm}/{username}/" + IDLBL.Text + "/" + string.Join("/", ListSelectedCells);
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
            server.Send(msg);

            ListSelectedCells.Clear();
        }

        public void SendBombCells_Click(object sender, EventArgs e)
        {
            if (server == null || !server.Connected)
            {
                MessageBox.Show("Connect to server first, please");
                return;
            }


            List<string> ListSelectedCells = new List<string>();

            foreach (DataGridViewCell cell in dataGridView2.SelectedCells)
            {
                int rowIndex = cell.RowIndex;
                int columnIndex = cell.ColumnIndex;
                ListSelectedCells.Add($"{rowIndex}.{columnIndex}");

                if (ListSelectedCells.Count == 1)
                    break;
            }
            string query = $"11/{numForm}/{username}/" + IDLBL.Text + "/"+ string.Join("/", ListSelectedCells);
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
            server.Send(msg);

            ListSelectedCells.Clear();
        }

        public void bttn_CeldasSeleccionadas_Click(object sender, EventArgs e)
        {
            SendSelectedCells_Click(sender, e);

            string imagePath = "..\\..\\images\\cohete.png";

            if (System.IO.File.Exists(imagePath))
            {
                Image cell_image = Image.FromFile(imagePath);

                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    cell.Tag = cell_image;
                    dataGridView1.InvalidateCell(cell);
                }
            }
            else
            {
                MessageBox.Show("Image not found. Please check the path.");
            }
        }

        public void bttn_BombSeleccionadas_Click(object sender, EventArgs e)
        {
            SendBombCells_Click(sender, e);
        }

        public void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Tag is Image cellImage)
                {
                    e.Graphics.DrawImage(cellImage, e.CellBounds);
                    e.Handled = true;
                }
            }
        }

        public void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Tag is Image cellImage)
                {
                    e.Graphics.DrawImage(cellImage, e.CellBounds);
                    e.Handled = true;
                }
            }
        }


        public void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e) //VER QUIEN ESTA CONECTADO
		{
			string query = "7/"+ numForm +"/";
			byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
			server.Send(msg);
		}

        public void sendMessage_Click(object sender, EventArgs e)
		{
			

			string chat_message = MessageChatBox.Text;
			

			// Petición: 9/username/message
			string query = "9/" + numForm + "/" + username + "/" + chat_message + "/" + IDLBL.Text;
			byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
			server.Send(msg);


		}
        public void PonChat (string chat)
		{
			ChatBox.Items.Add(chat);
			MessageChatBox.Clear();
		}
		public void PonDataGrid(string username, int rockets)
		{
			bool userFound = false;

			foreach (DataGridViewRow row in datagridRockets.Rows)
			{
				if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == username)
				{
					row.Cells[1].Value = rockets;
					userFound = true;
					break;
				}
			}

			if (!userFound)
			{
				datagridRockets.Rows.Add(username, rockets);
			}
		}

		public void ShowRespuesta(string respuesta)
        {
            MessageBox.Show(respuesta);
        }

        public void Form1_Load_1(object sender, EventArgs e)
        {
            LBLnumForm.Text = numForm.ToString();
            IDLBL.Text = currentMatchID.ToString();
        }

		private void ChatBox_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void LBLnumForm_Click(object sender, EventArgs e)
		{

		}

		private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}