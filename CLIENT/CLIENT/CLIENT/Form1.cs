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
		Socket server;
		Thread attend;
		public Form1()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            dataGridView1.CellPainting += dataGridView1_CellPainting;
			dataGridView2.CellPainting += dataGridView2_CellPainting;
            this.BackgroundImage = Image.FromFile("..\\..\\images\\fondo1.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Form1_Load(object sender, EventArgs e)
		{
			ConfigDataGridView1();
			ConfigDataGridView2();
		}

		private void ServerServe()
		{
			while (true)
			{
				byte[] msg2 = new byte[80];
				server.Receive(msg2);
				string [] pieces = Encoding.ASCII.GetString(msg2).Split('/');
				int code =Convert.ToInt32(pieces[0]); 
				string query;
				string respuesta;
				switch (code)
				{
					case 5: //PETICIÓN 5 REGISTER
						respuesta = pieces[1].Split('\0')[0];
						MessageBox.Show(respuesta);
						break;
					case 6: //PETICIÓN 6 LOG IN
						respuesta = pieces[1].Split('\0')[0];
						MessageBox.Show(respuesta);
						break;
					case 7: //LISTA PLAYERS
						respuesta = pieces[1].Split('\0')[0];
						MessageBox.Show(respuesta);
						break;
					case 8: // CELDAS
						respuesta = pieces[1].Split('\0')[0];
						MessageBox.Show(respuesta);
						break; 
					case 9: //CHAT 
						respuesta = pieces[1].Split('\0')[0];
						ChatBox.Items.Add(respuesta);
						MessageChatBox.Clear();
						break;
					case 10:
						respuesta = pieces[1].Split('\0')[0];
						MessageBox.Show(respuesta);
						ID_match++;
						break;
					case 11:
						respuesta = pieces[1];

						
						string[] positionParts = pieces[2].Split('.'); 

						if (positionParts.Length == 2) // Asegurarse de que tenemos ambas partes
						{
							int positionX = Convert.ToInt32(positionParts[0]);
							int positionY = (Convert.ToInt32(positionParts[1]) / 100000);

							MessageBox.Show($"Respuesta: {respuesta}\nPosición X: {positionX}\nPosición Y: {positionY}");

							// Llamar a la función pintar con las coordenadas
							pintar(respuesta, positionX, positionY);
						}
						break;
				}
			}
		}


		void pintar(string respuesta, int positionX, int positionY)
		{
			int targetColumn = positionY;
			int targetRow = positionX;

			MessageBox.Show($"Columna: {targetColumn}\nFila: {targetRow}");

			if (respuesta == "There is a rocket in this position")
			{
				string imagePath = "..\\..\\images\\fuego.png";
				Image fireImage = Image.FromFile(imagePath);

				// Escalar la imagen para que se ajuste al tamaño de la celda
				Image scaledImage = new Bitmap(fireImage, dataGridView2.Columns[targetColumn].Width, dataGridView2.Rows[targetRow].Height);

				// Asegurar que la celda es del tipo DataGridViewImageCell
				if (!(dataGridView2.Rows[targetRow].Cells[targetColumn] is DataGridViewImageCell))
				{
					dataGridView2.Rows[targetRow].Cells[targetColumn] = new DataGridViewImageCell();
				}

				// Asignar la imagen escalada
				dataGridView2.Rows[targetRow].Cells[targetColumn].Value = scaledImage;
				dataGridView2.Rows[targetRow].Cells[targetColumn].Style.BackColor = Color.White;
				dataGridView2.InvalidateCell(dataGridView2.Rows[targetRow].Cells[targetColumn]);

				
			}
			else if (respuesta == "No rocket found in this position")
			{
				string imagePath = "..\\..\\images\\bomba.png";
				Image bombImage = Image.FromFile(imagePath);

				// Escalar la imagen para que se ajuste al tamaño de la celda
				Image scaledImage = new Bitmap(bombImage, dataGridView2.Columns[targetColumn].Width, dataGridView2.Rows[targetRow].Height);

				// Asegurar que la celda es del tipo DataGridViewImageCell
				if (!(dataGridView2.Rows[targetRow].Cells[targetColumn] is DataGridViewImageCell))
				{
					dataGridView2.Rows[targetRow].Cells[targetColumn] = new DataGridViewImageCell();
				}

				// Asignar la imagen escalada
				dataGridView2.Rows[targetRow].Cells[targetColumn].Value = scaledImage;
				dataGridView2.Rows[targetRow].Cells[targetColumn].Style.BackColor = Color.White;
				dataGridView2.InvalidateCell(dataGridView2.Rows[targetRow].Cells[targetColumn]);

			}
		}







		private void connectbtn_Click(object sender, EventArgs e)
		{
            IPAddress direc = IPAddress.Parse("10.4.119.5");
            IPEndPoint ipep = new IPEndPoint(direc, 50067);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			try
			{
				server.Connect(ipep);
				connectbtn.BackColor = Color.LightGreen;
                disconnectbtn.BackColor = Color.LightGray;
                MessageBox.Show("Connected");

			}
			catch (SocketException ex)
			{
				MessageBox.Show("I couldn't connect with the server");
				return;
			}
			ThreadStart ts = delegate { ServerServe(); };
			attend = new Thread(ts);
			attend.Start();
		}

		private void disconnectbtn_Click(object sender, EventArgs e)
		{
			string query = "0/" + usernamebox.Text;
			byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
			server.Send(msg);

			attend.Abort();
            disconnectbtn.BackColor = Color.Red;
            connectbtn.BackColor = Color.LightGray;
            server.Shutdown(SocketShutdown.Both);
			server.Close();
		}

		private void RegisterButton_Click(object sender, EventArgs e)
		{
			if (server == null || !server.Connected)
			{
				MessageBox.Show("Connect to server first, please");
				return;
			}
			string username = usernamebox.Text;
			string password = passwordbox.Text;

			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("Complete all fields, please");
				return;
			}
			else
			{
				// Petición: 5/username/password
				string query = "5/" + username + "/" + password;
				byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
				server.Send(msg);				
			}
		}

		private void LoginButton_Click(object sender, EventArgs e)
		{
			if (server == null || !server.Connected)
			{
				MessageBox.Show("Connect to server first, please");
				return;
			}

			string username = usernamebox.Text;
			string password = passwordbox.Text;

			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("Complete all fields, please");
				return;
			}

			// Petición: 6/username/password
			string query = "6/" + username + "/" + password;
			byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
			server.Send(msg);
		}

		private void LIST_PLAYERS_Click(object sender, EventArgs e)
		{
			// Petición: 7
			string query = "7/";
			byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
			server.Send(msg);
		}

		private void ConfigDataGridView2()
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

        private void ConfigDataGridView1()
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

        private void SendSelectedCells_Click(object sender, EventArgs e)
        {
            if (server == null || !server.Connected)
            {
                MessageBox.Show("Connect to server first, please");
                return;
            }

			string username = usernamebox.Text;

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

            string query = $"8/{username}/" + string.Join("/", ListSelectedCells);
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
            server.Send(msg);

            ListSelectedCells.Clear();
        }

        private void SendBombCells_Click(object sender, EventArgs e)
        {
            if (server == null || !server.Connected)
            {
                MessageBox.Show("Connect to server first, please");
                return;
            }

            string username = usernamebox.Text;

            List<string> ListSelectedCells = new List<string>();

            foreach (DataGridViewCell cell in dataGridView2.SelectedCells)
            {
                int rowIndex = cell.RowIndex;
                int columnIndex = cell.ColumnIndex;
                ListSelectedCells.Add($"{rowIndex}.{columnIndex}");

                if (ListSelectedCells.Count == 1)
                    break;
            }

            string query = $"11/{username}/" + string.Join("/", ListSelectedCells);
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
            server.Send(msg);

            ListSelectedCells.Clear();
        }

        private void bttn_CeldasSeleccionadas_Click(object sender, EventArgs e)
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

        private void bttn_BombSeleccionadas_Click(object sender, EventArgs e)
        {
            SendBombCells_Click(sender, e);
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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


        private void sendMessage_Click(object sender, EventArgs e)
		{
			string password = passwordbox.Text;
			string username = usernamebox.Text;
			string chat_message = MessageChatBox.Text;
			if (server == null || !server.Connected)
			{
				MessageBox.Show("Connect to server first, please");
				return;
			}
			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("Complete all fields, please");
				return;
			}
			if(string.IsNullOrEmpty(chat_message))
			{
				MessageBox.Show("Write something, please");
				return;
			}

			// Petición: 9/username/message
			string query = "9/" + username + "/" + chat_message;
			byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
			server.Send(msg);

			
		}

		private static int ID_match = 1; 

		private void CreateGame_Click(object sender, EventArgs e)
		{
			if (server == null || !server.Connected)
			{
				MessageBox.Show("Connect to server first, please");
				return;
			}
			if (string.IsNullOrEmpty(usernamebox.Text) || string.IsNullOrEmpty(passwordbox.Text))
			{
				MessageBox.Show("Complete all fields, please");
				return;
			}
			string query = "10/" + usernamebox.Text + "/" + ID_match;
			byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
			server.Send(msg);
			
		}
    }
}