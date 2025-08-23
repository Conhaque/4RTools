using _4RTools.Utils;
using _4RTools.Model;
using System.Windows.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace _4RTools.Forms
{
    public partial class ClientUpdaterForm : Form
    {
        private System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();

        public ClientUpdaterForm()
        {
            var requestAccepts = httpClient.DefaultRequestHeaders.Accept;
            requestAccepts.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request"); //Set the User Agent to "request"
            InitializeComponent();
            StartUpdate();
        }

        private async void StartUpdate()
        {
            List<ClientDTO> clients = new List<ClientDTO>();


            /**
             * Load local servers only - no remote fetching
             */
            try
            {
                clients.AddRange(LocalServerManager.GetLocalClients()); //Load Local Servers First
                // Skip remote fetching - working offline only
                clients.AddRange(JsonConvert.DeserializeObject<List<ClientDTO>>(LoadResourceServerFile()));

            }
            catch(Exception ex)
            {
                //If catch some exception while loading, load resource file.
                clients.AddRange(JsonConvert.DeserializeObject<List<ClientDTO>>(LoadResourceServerFile()));
            }
            finally
            {
                LoadServers(clients);
                new Container().Show();
                Hide();
            }
        }

        private string LoadResourceServerFile()
        {
            return Resources._4RTools.ETCResource.supported_servers;
        }

        private void LoadServers(List<ClientDTO> clients)
        {
            foreach (ClientDTO clientDTO in clients)
            {
                try
                {
                    ClientListSingleton.AddClient(new Client(clientDTO));
                    pbSupportedServer.Increment(1);
                }
                catch { }
                
            }
        }
    }
}
