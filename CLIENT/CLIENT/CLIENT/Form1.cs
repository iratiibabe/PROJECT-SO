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
            this.BackgroundImage = Image.FromFile("..\\..\\images\\fondo1.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;


        }

        private void Form1_Load(object sender, EventArgs e)
		{
			ConfigDataGridView1();
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
					case 1: //QUERY 1
						query = pieces[1].Split('\0')[0];
						X1.BackColor = Color.White;
						MessageBox.Show("The winner of match  " + X1.Text + "  is: " + query);
						break;
					case 2://QUERY 2
						query = pieces[1].Split('\0')[0];
						X2.BackColor = Color.White;
						MessageBox.Show("Player " + X2.Text + " has: " + query);
						break;
					case 3: //QUERY 3
						query = pieces[1].Split('\0')[0];
						X3.BackColor = Color.White;
						MessageBox.Show("Player  " + X3.Text + "  is playing in " + query + " matches.");
						
						break;
					case 4: //QUERY 4
						query = pieces[1].Split('\0')[0];
						X4.BackColor = Color.White;
						MessageBox.Show("In match  " + X4.Text + "  there are " + query + " players.");
						break;
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

				}

			}
		}

		private void QUERY1_Click(object sender, EventArgs e)
		{
			if (server == null || !server.Connected)
			{
				MessageBox.Show("Connect to server first, please");
				return;
			}
			if (int.TryParse(X1.Text, out _))
			{
				X1.BackColor = Color.Green;

				string query = "1/" + X1.Text;
				byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
				server.Send(msg);

				
			}
			else
			{
				X1.BackColor = Color.Red;
				MessageBox.Show("Only numbers, please");
			}
		}

		private void QUERY2_Click(object sender, EventArgs e)
		{
			if (server == null || !server.Connected)
			{
				MessageBox.Show("Connect to server first, please");
				return;
			}
			if (System.Text.RegularExpressions.Regex.IsMatch(X2.Text, @"^[a-zA-Z]+$"))
			{
				X2.BackColor = Color.Green;
				string query = "2/" + X2.Text;
				byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
				server.Send(msg);

				
			}
			else
			{
				X2.BackColor = Color.Red;
				MessageBox.Show("Insert the name of the player, please");
			}
		}

		private void QUERY3_Click(object sender, EventArgs e)
		{
			if (server == null || !server.Connected)
			{
				MessageBox.Show("Connect to server first, please");
				return;
			}
			if (System.Text.RegularExpressions.Regex.IsMatch(X3.Text, @"^[a-zA-Z]+$"))
			{
				X3.BackColor = Color.Green;
				string query = "3/" + X3.Text;
				byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
				server.Send(msg);

				
			}
			else
			{
				X3.BackColor = Color.Red;
				MessageBox.Show("Insert the name of the player, please");
			}
		}

		private void QUERY4_Click(object sender, EventArgs e)
		{
			if (server == null || !server.Connected)
			{
				MessageBox.Show("Connect to server first, please");
				return;
			}
			string query = "4/" + X4.Text;
			byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
			server.Send(msg);

			
		}

		private void connectbtn_Click(object sender, EventArgs e)
		{
			IPAddress direc = IPAddress.Parse("192.168.56.102");
			IPEndPoint ipep = new IPEndPoint(direc, 9000);
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

        private void ConfigDataGridView1()
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnCount = 10;
            int cellSize = 30; 

            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Columns[i].Name = (i + 1).ToString();
                dataGridView1.Columns[i].Width = cellSize; 
            }

            for (int j = 0; j < 10; j++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[j].HeaderCell.Value = (j + 1).ToString();
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

            List<string> ListSelectedCells = new List<string>();

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                int rowIndex = cell.RowIndex+1; 
                int columnIndex = cell.ColumnIndex+1;


                ListSelectedCells.Add($"Row:{rowIndex} Column:{columnIndex}");

            }

            string query = "8/" + string.Join(" , ", ListSelectedCells);
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void explicacion1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}