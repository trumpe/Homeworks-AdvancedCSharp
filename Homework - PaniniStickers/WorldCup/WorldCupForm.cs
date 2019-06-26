using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WorldCup
{
    public partial class WorldCupForm : Form
    {
        private string selectedTeam;

        public WorldCupForm()
        {
            InitializeComponent();
        }

        private void WorldCupForm_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            string teamsString = wc.DownloadString("https://us-central1-sedc-world-cup.cloudfunctions.net/webApi/team-list");
            var teams = JsonConvert.DeserializeObject<string[]>(teamsString);
            cbxTeams.DataSource = teams;
        }

        private async void cbxTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowPanel.Controls.Clear();
            selectedTeam = cbxTeams.SelectedItem as string;
            lblSelectedTeam.Text = $"You selected {selectedTeam}";
            WebClient wc = new WebClient();
            Uri uri = new Uri($"https://us-central1-sedc-world-cup.cloudfunctions.net/webApi/team/{selectedTeam}");

            string teamString = await wc.DownloadStringTaskAsync(uri);
            var team = JsonConvert.DeserializeObject<Team>(teamString);

            var badgeImageTask = new WebClient().DownloadDataTaskAsync(team.BadgeImageUrl);
            var teamImageTask = new WebClient().DownloadDataTaskAsync(team.TeamImageUrl);

            var results = await Task.WhenAll(badgeImageTask, teamImageTask);

            using (var ms = new MemoryStream(results[0]))
            {
                pboxBadge.Image = Image.FromStream(ms);
            }

            using (var ms = new MemoryStream(results[1]))
            {
                pboxTeam.Image = Image.FromStream(ms);
            }

            foreach (var player in team.Players)
            {
                if (string.IsNullOrEmpty(player.ImageUrl))
                {
                    continue;
                }
              
                PictureBox pb = new PictureBox();
                pb.Size = new Size(296, 319);

                var playerImage = await wc.DownloadDataTaskAsync(player.ImageUrl);
                using (var ms = new MemoryStream(playerImage))
                {
                    pb.Image = Image.FromStream(ms);
                }

                flowPanel.Controls.Add(pb);
            }

        }       
    }
}
