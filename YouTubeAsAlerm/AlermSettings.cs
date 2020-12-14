using System;
using System.Collections.Generic;
using System.IO;

namespace YouTubeAsAlerm
{
    [Serializable]
    public class AlermSettings
    {
        [Serializable]
        public class AlermData
        {
            [Flags]
            public enum AlermTiming
            {
                Once = 0,

                Sunday = 0x1,
                Monday = 0x2,
                Tuesday = 0x4,
                Wednesday = 0x8,
                Thursday = 0x10,
                Friday = 0x20,
                Saturday = 0x40,

                Weekdays = 0x3e,
                Everyday = 0x7f,
            }


            public bool IsEnabled = true;
            public AlermTiming Timing = AlermTiming.Once;
            public DateTime Time = DateTime.Now;
            public List<string> PlaylistNames = new List<string>();


            public override string ToString()
            {
                var time = Timing == AlermTiming.Once ? Time.ToString("yyyy/MM/dd HH:mm:ss") : Time.ToString("HH:mm:ss");
                return $"{(IsEnabled ? "" : "[Disabled] ")}{time}, {Timing} [{string.Join(", ", PlaylistNames)}]";
            }
        }


        public List<AlermData> Alerms = new List<AlermData>();



        public static AlermSettings Load(string path)
        {
            try
            {
                using (var reader = new StreamReader(path))
                {
                    var deserializer = new Newtonsoft.Json.JsonSerializer();
                    return (AlermSettings)deserializer.Deserialize(reader, typeof(AlermSettings));
                }
            }
            catch (Exception)
            {
                return new AlermSettings();
            }

        }

        public static void Save(string path, AlermSettings settings)
        {
            using (var writer = new StreamWriter(path))
            {
                var serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(writer, settings);
            }
        }
    }
}
