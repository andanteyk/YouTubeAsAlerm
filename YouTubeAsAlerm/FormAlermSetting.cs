using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlermTiming = YouTubeAsAlerm.AlermSettings.AlermData.AlermTiming;

namespace YouTubeAsAlerm
{
    public partial class FormAlermSetting : Form
    {
        public AlermSettings.AlermData Result;

        public FormAlermSetting()
        {
            InitializeComponent();
        }

        public FormAlermSetting(IEnumerable<string> playlists, AlermSettings.AlermData alerm) : this()
        {
            alerm = alerm ?? new AlermSettings.AlermData();

            checkBox1.Checked = alerm.IsEnabled;
            dateTimePicker1.Value = alerm.Time;

            for (int i = 0; i < 7; i++)
            {
                TimingList.SetItemChecked(i, ((int)alerm.Timing & (1 << i)) != 0);
            }

            Playlist.Items.AddRange(playlists.ToArray());
            foreach (var name in alerm.PlaylistNames)
            {
                var index = Playlist.Items.IndexOf(name);
                if (index != -1)
                    Playlist.SetItemChecked(index, true);
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Result = new AlermSettings.AlermData
            {
                IsEnabled = checkBox1.Checked,
                Time = dateTimePicker1.Value,
                Timing = CheckedListToTiming(),
                PlaylistNames = Playlist.CheckedItems.OfType<string>().ToList()
            };
            DialogResult = DialogResult.OK;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Result = null;
            DialogResult = DialogResult.Cancel;
        }


        private AlermTiming CheckedListToTiming()
        {
            AlermTiming timing = 0;
            for (int i = 0; i < 7; i++)
                timing |= TimingList.GetItemChecked(i) ? (AlermTiming)(1 << i) : 0;

            return timing;
        }


        private void TimingList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var timing = CheckedListToTiming();
            timing ^= (AlermTiming)(1 << e.Index);

            if (timing == AlermTiming.Once)
            {
                dateTimePicker1.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            }
            else
            {
                dateTimePicker1.CustomFormat = "HH:mm:ss";
            }
        }
    }
}
