using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YouTubeAsAlerm
{
    public class ApiManager
    {
        private static ApiManager instance = null;
        public static ApiManager I => instance ?? (instance = new ApiManager());


        private YouTubeService youtubeService;



        public bool IsAuthenticated => youtubeService != null;

        public async Task Authenticate()
        {
            // authentication

            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { YouTubeService.Scope.YoutubeReadonly },
                        "user", CancellationToken.None);     // user?
            }


            youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "DesktopForm",
            });
        }


        public async Task<List<PlaylistData>> GetPlaylists()
        {
            var result = new List<PlaylistData>();


            var channelsListRequest = youtubeService.Channels.List("snippet");
            channelsListRequest.Mine = true;

            var channelsListResponse = await channelsListRequest.ExecuteAsync();


            foreach (var channel in channelsListResponse.Items)
            {
                System.Diagnostics.Debug.WriteLine($"channel {channel.Snippet.Title}");

                var playlistRequest = youtubeService.Playlists.List("snippet");
                playlistRequest.ChannelId = channel.Id;

                var playlistResponse = await playlistRequest.ExecuteAsync();


                foreach (var playlist in playlistResponse.Items)
                {
                    System.Diagnostics.Debug.WriteLine($"{playlist.Id}: {playlist.Snippet.Title}");

                    var playlistData = new PlaylistData { Playlist = playlist };

                    string nextPageToken = string.Empty;
                    while (nextPageToken != null)
                    {
                        var playlistItemsRequest = youtubeService.PlaylistItems.List("snippet");
                        playlistItemsRequest.PlaylistId = playlist.Id;
                        playlistItemsRequest.MaxResults = 50;
                        playlistItemsRequest.PageToken = nextPageToken;

                        var playlistItemsResponse = await playlistItemsRequest.ExecuteAsync();

                        foreach (var items in playlistItemsResponse.Items)
                        {
                            System.Diagnostics.Debug.WriteLine($"  {items.Snippet.ResourceId?.VideoId} : {items.Snippet.Title}");
                        }

                        // skip "private video"
                        playlistData.PlaylistItems.AddRange(playlistItemsResponse.Items.Where(item => item.Snippet.Thumbnails.Standard != null));

                        nextPageToken = playlistItemsResponse.NextPageToken;
                    }

                    result.Add(playlistData);
                }
            }


            return result;
        }



        public class PlaylistData
        {
            public Playlist Playlist = null;
            public List<PlaylistItem> PlaylistItems = new List<PlaylistItem>();
        }

    }
}
