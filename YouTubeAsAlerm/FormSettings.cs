using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using AlermTiming = YouTubeAsAlerm.AlermSettings.AlermData.AlermTiming;

namespace YouTubeAsAlerm
{
    public partial class FormSettings : Form
    {
        private string SettingsPath = "settings.json";

        private List<ApiManager.PlaylistData> Playlists;        // yokunai
        private AlermSettings Settings;

        private DateTime PreviousTick = DateTime.Now;
        private Random Random = new Random();



        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            Settings = AlermSettings.Load(SettingsPath);
            UpdateSettings();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ButtonUpdatePlaylist.Enabled = false;

            try
            {
                if (!ApiManager.I.IsAuthenticated)
                    await ApiManager.I.Authenticate();

                Playlists = await ApiManager.I.GetPlaylists();

                UpdatePlaylists();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ButtonUpdatePlaylist.Enabled = true;
            }
        }


        private void UpdatePlaylists()
        {
            PlaylistSelector.Items.Clear();
            PlaylistSelector.Items.AddRange(Playlists.Select(p => p.Playlist.Snippet.Title).ToArray());

            if (PlaylistSelector.Items.Count > 0)
                PlaylistSelector.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridPlaylistItems.Rows.Clear();

            if (PlaylistSelector.SelectedIndex < 0 || Playlists == null)
                return;

            var playlist = Playlists[PlaylistSelector.SelectedIndex];

            var rows = new DataGridViewRow[playlist.PlaylistItems.Count];
            foreach ((var item, int index) in playlist.PlaylistItems.Select((x, i) => (x, i)))
            {
                var row = new DataGridViewRow();
                row.CreateCells(GridPlaylistItems);

                row.SetValues(item.Snippet.ResourceId.VideoId, item.Snippet.Title);
                rows[index] = row;
            }

            GridPlaylistItems.Rows.AddRange(rows);
        }



        private void UpdateSettings()
        {
            GridAlermSettings.Rows.Clear();

            var rows = new DataGridViewRow[Settings.Alerms.Count];

            foreach ((var item, int index) in Settings.Alerms.Select((s, i) => (s, i)))
            {
                var row = new DataGridViewRow();
                row.CreateCells(GridAlermSettings);
                row.SetValues(Settings.Alerms[index], null);

                rows[index] = row;
            }

            GridAlermSettings.Rows.AddRange(rows);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((uint)e.RowIndex >= GridAlermSettings.RowCount)
                return;

            if (e.ColumnIndex == 1)
            {
                bool isNewColumn = e.RowIndex >= Settings.Alerms.Count;

                if (Playlists == null)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    return;
                }

                using (var settingForm = new FormAlermSetting(Playlists.Select(p => p.Playlist.Snippet.Title), isNewColumn ? null : Settings.Alerms[e.RowIndex]))
                {
                    if (settingForm.ShowDialog(this) == DialogResult.OK)
                    {
                        if (isNewColumn)
                            Settings.Alerms.Add(settingForm.Result);
                        else
                            Settings.Alerms[e.RowIndex] = settingForm.Result;

                        UpdateSettings();
                    }
                }
            }
            else if (e.ColumnIndex == 2)
            {
                Settings.Alerms.RemoveAt(e.RowIndex);
                UpdateSettings();
            }
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            AlermSettings.Save(SettingsPath, Settings);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        private void showSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        private void FormSettings_Shown(object sender, EventArgs e)
        {
            if (!ApiManager.I.IsAuthenticated)
                ButtonUpdatePlaylist.PerformClick();
        }




        private void AlermTimer_Tick(object sender, EventArgs e)
        {
            if (Playlists == null)
                return;

            var current = DateTime.Now;

            foreach (var alerm in Settings.Alerms)
            {
                if (!alerm.IsEnabled)
                    continue;

                if (alerm.Timing == AlermTiming.Once)
                {
                    if (PreviousTick > alerm.Time || alerm.Time > current)
                        continue;
                }
                else
                {
                    bool enabled = false;
                    for (int i = 0; i < 7; i++)
                    {
                        if ((alerm.Timing & (AlermTiming)(1 << i)) != 0 && current.DayOfWeek == (DayOfWeek)i)
                            enabled |= true;
                    }

                    if (!enabled)
                        continue;

                    var target = PreviousTick.Date + alerm.Time.TimeOfDay;
                    if (target < PreviousTick)
                        target = target.AddDays(1);

                    if (target > current)
                        continue;


                    var nextDay = current.Date + alerm.Time.TimeOfDay;
                    if (nextDay < current)
                        nextDay = nextDay.AddDays(1);

                    alerm.Time = nextDay;
                }



                // invoke!
                var playlistItems = Playlists.Where(p => alerm.PlaylistNames.Contains(p.Playlist.Snippet.Title)).SelectMany(p => p.PlaylistItems);
                if (!playlistItems.Any())
                    playlistItems = Playlists.SelectMany(p => p.PlaylistItems);

                var item = playlistItems.ElementAt(Random.Next(playlistItems.Count()));


                //MessageBox.Show("https://youtube.com/watch?v=" + item.Snippet.ResourceId.VideoId);
                AlermTimer.Stop();
                Process.Start("https://youtube.com/watch?v=" + item.Snippet.ResourceId.VideoId);
                AlermTimer.Start();

                break;
            }

            PreviousTick = current;
        }

        private void GridPlaylistItems_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((uint)e.RowIndex >= GridPlaylistItems.RowCount)
                return;

            Process.Start("https://youtube.com/watch?v=" + GridPlaylistItems.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Visible = true;
        }
    }
}
