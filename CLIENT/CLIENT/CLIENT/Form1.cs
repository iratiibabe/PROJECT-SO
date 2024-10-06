using System;
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

namespace CLIENT
{
	public partial class Form1 : Form
	{
		Socket server; 
		public Form1()
		{
			InitializeComponent();
		}

		private void explicacion1_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void QUERY1_Click(object sender, EventArgs e)
		{
			

				if (int.TryParse(X1.Text, out _))
				{
					X1.BackColor = Color.Green;

					string query = "1/" + X1.Text;
					byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
					server.Send(msg);
					
					byte[] msg2 = new byte[80];
					server.Receive(msg2);
					query = Encoding.ASCII.GetString(msg2).Split('\0')[0];
					MessageBox.Show("The winner of the match  " + X1.Text + "  is: " + query);

				}
				else
				{
					X1.BackColor = Color.Red;
					MessageBox.Show("Only numbers, please");
				}
				
			
			
		}

		private void QUERY2_Click(object sender, EventArgs e)
		{
			if (System.Text.RegularExpressions.Regex.IsMatch(X2.Text, @"^[a-zA-Z]+$"))
			{
				X2.BackColor = Color.Green;
				string query = "2/" + X2.Text;
				byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
				server.Send(msg);
				
				byte[] msg2 = new byte[80];
                server.Receive(msg2);
				query = Encoding.ASCII.GetString(msg2).Split('\0')[0];
				MessageBox.Show("The player " + X2.Text + " has: " + query);
			}
			else
			{
				X2.BackColor = Color.Red;
				MessageBox.Show("Insert the name of the player, please");
			}
			
		}

		private void QUERY3_Click(object sender, EventArgs e)
		{
			if (System.Text.RegularExpressions.Regex.IsMatch(X3.Text, @"^[a-zA-Z]+$"))
			{
				X3.BackColor = Color.Green;
				string query = "3/" + X3.Text;
				byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
				server.Send(msg);
				
				byte[] msg2 = new byte[80];
                server.Receive(msg2);
				query = Encoding.ASCII.GetString(msg2).Split('\0')[0];
				MessageBox.Show("The player  " + X3.Text + "  is playing the following quantitie of matches:  " + query);
			}
			else
			{
				X3.BackColor = Color.Red;
				MessageBox.Show("Insert the name of the player, please");
			}
		}

		private void QUERY4_Click(object sender, EventArgs e)
		{
			string query = "4/" + X4.Text;
			byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
			server.Send(msg);

			byte[] msg2 = new byte[80];
            server.Receive(msg2);
			query = Encoding.ASCII.GetString(msg2).Split('\0')[0];
			MessageBox.Show("In the match  " + X4.Text + "  are playing the following quatitie of players:  " + query);
		}

		private void connectbtn_Click(object sender, EventArgs e)
		{
			IPAddress direc = IPAddress.Parse("192.168.56.101");
			IPEndPoint ipep = new IPEndPoint(direc, 9000);
			server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			try
			{
				server.Connect(ipep);
				this.BackColor = Color.Green;
				MessageBox.Show("Connected");
				
			}
			catch (SocketException ex)

			{
				MessageBox.Show("I couldn't connect with the server");
				return;
			}
		}

		private void disconnectbtn_Click(object sender, EventArgs e)
		{
			string query = "0/";
			byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
			this.BackColor = Color.Gray;
			server.Shutdown(SocketShutdown.Both);
			server.Close();


		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string username = usernamebox.Text;
            string password = passwordbox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }
			else
			{
                // Petición: 5/username/password
                string query = "5/" + username + "/" + password;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
                server.Send(msg);

                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string respuesta = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show(respuesta);

            }
            
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernamebox.Text;
            string password = passwordbox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }

            // Petición: 6/username/password
            string query = "6/" + username + "/" + password;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
            server.Send(msg);

            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            string respuesta = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            MessageBox.Show(respuesta);
        }
    }
}
