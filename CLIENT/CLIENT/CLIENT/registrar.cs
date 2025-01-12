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
    public partial class registrar : Form
    {
        Socket server;
        Thread attend;

        delegate void DelegateToWrite(string mensaje);
        delegate void DelegateToDataGrid(string mensaje,int rockets);

        List<Form1> forms = new List<Form1>();
        public registrar()
        {
            InitializeComponent();
        }

        private void ServerServe()
        {
            while (true)
            {
                byte[] msg2 = new byte[2024];
                server.Receive(msg2);
                string[] pieces = Encoding.ASCII.GetString(msg2).Split('/');
                
                int code = Convert.ToInt32(pieces[0]);
                string mensaje;
                string query;
                string respuesta;
                int numForm;
                switch (code)
                {
                    case 5: //PETICIÓN 5 REGISTER
                        respuesta = pieces[1].Split('\0')[0];
                        MessageBox.Show(respuesta);
                        break;

                    case 14: //PETICION 14 DARSE DE BAJA
                        respuesta = pieces[1].Split('\0')[0];
                        MessageBox.Show(respuesta);
                        break;

                    case 6: //PETICIÓN 6 LOG IN
                        respuesta = pieces[1].Split('\0')[0];
                        MessageBox.Show(respuesta);

                        break;


                    case 7: //LISTA PLAYERS
                        respuesta = pieces[1].Split('\0')[0];
                        DelegateToWrite delegado1 = new DelegateToWrite(PonConnected);
                        Connectedlbl.Invoke(delegado1, new object[] { respuesta });
                        break;
                    
                    case 10: //CREAR UN MATCH
                        respuesta = pieces[1].Split('\0')[0];
                        MessageBox.Show(respuesta);
                        //numForm = Convert.ToInt32(pieces[2]);
                        string[] GetID = pieces[1].Split(':');
						//DelegateToWrite delegado2 = new DelegateToWrite(forms[numForm].PonID);
						//this.Invoke(delegado2, new object[] { GetID[1] });
						currentMatchID = Convert.ToInt32(GetID[1]);
                        HandleMatchIDUpdate(currentMatchID);

                        break;
                   

                    case 12:
                        respuesta = pieces[1];

                        string[] parts = pieces[1].Split(':');
                        string receiver = parts[1];
                        string username = parts[3];
                        int ID_Match = Convert.ToInt32(parts[5]);

                        if (usernamebox.Text == username)
                        {
                            invitacionForm invitacionForm = new invitacionForm(respuesta);
                            DialogResult result = invitacionForm.ShowDialog();
                            RespondToInvitation(result, username, receiver, ID_Match);
                        }

                        break;

                    case 13: //RESPUESTA A LA INVITACIÓN
                       
                        respuesta = pieces[1].Split('\0')[0];
                        string[] GetCurrentID = pieces[1].Split(':');
                        int newMatchID = Convert.ToInt32(GetCurrentID[1]);
                        MessageBox.Show(respuesta);
                        HandleMatchIDUpdate(newMatchID);
                        break;

                    case 15: // query 5

                        string queryResult = pieces[1].Split('\0')[0];
                        MessageBox.Show(queryResult);
                        if (query5_response.InvokeRequired)
                        {
                            query5_response.BeginInvoke(new Action(() => query5_response.Text = queryResult));
                        }
                        else
                        {
                            query5_response.Text = queryResult;
                        }
                        break;
                    case 16: // query 6
                        string query6Result = pieces[1].Split('\0')[0];
                        MessageBox.Show(query6Result);
                        if (query6_response.InvokeRequired)
                        {
                            query6_response.BeginInvoke(new Action(() => query6_response.Text = query6Result));
                        }
                        else
                        {
                            query6_response.Text = query6Result;
                        }
                        break;

                    // form1
                    case 8: // CELDAS
                        numForm = Convert.ToInt32(pieces[1]);
                        respuesta = pieces[2].Split('\0')[0];
                        forms[numForm].ShowRespuesta(respuesta);
						username = pieces[3].Split('\0')[0];
                        int rocketsLeft = Convert.ToInt32(pieces[4].Split('\0')[0]);
						DelegateToDataGrid delegado5 = new DelegateToDataGrid(forms[numForm].PonDataGrid);
						this.Invoke(delegado5, new object[] { username, rocketsLeft });
						


						break;
                    case 9: //CHAT 
                       
                        numForm = Convert.ToInt32(pieces[1].Split('\0')[0]);
						mensaje = pieces[2];
						DelegateToWrite delegado3 = new DelegateToWrite(forms[numForm].PonChat);
                        this.Invoke(delegado3, new object[] { mensaje });
                        break;
                    
                    case 11: //ROCKET o NO ROCKET
                        numForm = Convert.ToInt32(pieces[1]);
                        respuesta = pieces[2].Split('\0')[0];

                        string[] positionParts = pieces[3].Split('.');

                        if (positionParts.Length == 2) // Asegurarse de que tenemos ambas partes
                        {
                            int positionX = Convert.ToInt32(positionParts[0]);
                            int positionY = (Convert.ToInt32(positionParts[1]) / 100000);

                            MessageBox.Show($"Respuesta: {respuesta}\nPosición X: {positionX}\nPosición Y: {positionY}");

                            
                            forms[numForm].pintar(respuesta, positionX, positionY);
                        }

						List<string> winnerUsernames = new List<string>(); 
						
						for (int i = 4; i < pieces.Length; i += 2)
						{
							username = pieces[i];
							int rocketsLeft1 = Convert.ToInt32(pieces[i + 1]);

							
							if (rocketsLeft1 == 0)
							{
								MessageBox.Show($"Player {username} has been eliminated.");
								winnerUsernames.Remove(username);  
							}
							else
							{
								
								if (!winnerUsernames.Contains(username))
								{
									winnerUsernames.Add(username);
								}
							}

							DelegateToDataGrid delegado4 = new DelegateToDataGrid(forms[numForm].PonDataGrid);
							this.Invoke(delegado4, new object[] { username, rocketsLeft1 });
						}

						
						if (winnerUsernames.Count == 1)
						{
							MessageBox.Show($"THE WINNER IS PLAYER {winnerUsernames[0]}");
						}
						break;



				}
            }
        }


        public void HandleMatchIDUpdate(int newMatchID)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Form1)
                {
                    ((Form1)form).UpdateMatchID(newMatchID);
                }
            }
        }

        private void registrar_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("..\\..\\images\\galaxia.jpg");
        }
		

        private void connectbtn_Click(object sender, EventArgs e)
        {
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9100);
            
            //IPAddress direc = IPAddress.Parse("10.4.119.5");
            //IPEndPoint ipep = new IPEndPoint(direc, 50067);
            
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


            disconnectbtn.BackColor = Color.Red;
            connectbtn.BackColor = Color.LightGray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            attend.Abort();
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
        private void unregisterbtn_Click(object sender, EventArgs e)
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
                // Petición: 14/username/password
                string query = "14/" + username + "/" + password;
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

        private void usernamebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void StartFormInvitaciones()
        {
            string username = usernamebox.Text;
            int cont = forms.Count;
            Form1 f = new Form1(cont, server, username, currentMatchID);
            forms.Add(f);
            f.ShowDialog();
            
        }

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

            ThreadStart ts = delegate { StartFormInvitaciones(); };
            Thread t = new Thread(ts);
            t.Start();

            string query = "10/" + usernamebox.Text + "/" + ID_match;
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


        private static int ID_match = 1;
        private int currentMatchID = -1;
        public void SetVariable(int currentMatchID)
        {
            this.currentMatchID = currentMatchID;
        }
		

		private void RespondToInvitation(DialogResult result, string username, string receiver, int ID_Match)
        {

            int responseCode = 0;
            if (string.IsNullOrEmpty(receiver))
            {
                MessageBox.Show("Receiver name is missing.");
                return;
            }

            if (result == DialogResult.Yes) // Ha aceptado jugar
            {
                //MessageBox.Show("Player:" + invitation_receiver + "has accepted your invitation.");
                responseCode = 0;

                ThreadStart ts = delegate { StartFormInvitaciones(); };
                Thread t = new Thread(ts);
                t.Start();


            }
            else if (result == DialogResult.No) // NO ha aceptado jugar
            {
                //MessageBox.Show("Player:" + invitation_receiver + "has rejected your invitation.");
                responseCode = 1;
            }

            // Petición: 13/sender_username/reciver_username/responseCode
            string query = "13/"  + username + "/" + receiver + "/" + responseCode + "/" + ID_Match;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
            server.Send(msg);
        }
        public void PonConnected(string connected)
        {
            Connectedlbl.Text = connected;
        }

        private void InvitePlayer_Click_1(object sender, EventArgs e)
        {
            string password = passwordbox.Text;
            string username = usernamebox.Text;
            string receiver = PlayerName.Text;
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
            if (string.IsNullOrEmpty(receiver))
            {
                MessageBox.Show("Write the name of the user you want to invite, please.");
                return;
            }

            // Petition: 12/sender_username/receiver_username/IDmatch
            string query = "12/" + username + "/" + receiver + "/" + currentMatchID;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
            server.Send(msg);
        }

        private void button_query5_Click(object sender, EventArgs e)
        {

            string password = passwordbox.Text;
            string username = usernamebox.Text;
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


            string query = "15/" + username;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
            server.Send(msg);

        }

        private void query6_Click(object sender, EventArgs e)
        {
            string start = start_time.Text;
            string finish = finish_time.Text;
            if (server == null || !server.Connected)
            {
                MessageBox.Show("Connect to server first, please");
                return;
            }
            if (string.IsNullOrEmpty(start) || string.IsNullOrEmpty(finish))
            {
                MessageBox.Show("Complete all fields, please");
                return;
            }
            string query = "16/" + start + "/" + finish;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(query);
            server.Send(msg);
        }
    }
}



