using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.IO;
using System.Drawing;

namespace Sprint_UnitTests
{
    [TestClass]
    public class BearPlayer_UnitTests
    {
        string file_path1 = @"C:\BearPlayer\Resources\02 - Godspeed.mp3";
        string file_path2 = @"C:\BearPlayer\Resources\04 - A Whisper & A Clamor.mp3";
        string file_path_duplicate = @"C:\BearPlayer\Resources\02 - Godspeed.mp3";
        string TrevSong = @"C:\BearPlayer\Resources\01 Intro.mp3";
        string playlist_loc = @"C:\BearPlayer\Resources\playlists.txt";

        [TestMethod]
        public void Test_Play_Song_New_Song()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            bool result = player.play_song(file_path1);

            // Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Test_Play_Song_Another_New_Songs()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            bool result = player.play_song(file_path1);
            result = player.play_song(file_path2);

            // Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Test_Play_Song_Same_Songs()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            bool result = player.play_song(file_path1);
            result = player.play_song(file_path1);

            // Assert
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void Test_Get_Song_Name()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();
            TagLib.File file = TagLib.File.Create(file_path1);

            // Act
            string song_name = player.getSongName(file);


            // Assert
            Assert.AreEqual(song_name, "Godspeed");
        }


        [TestMethod]
        public void Test_Get_Album_Artist()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();
            TagLib.File file = TagLib.File.Create(file_path1);

            // Act
            string song_name = player.getAlbumArtist(file);


            // Assert
            Assert.AreEqual(song_name, "Anberlin");
        }


        [TestMethod]
        public void Test_Get_Album()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();
            TagLib.File file = TagLib.File.Create(file_path1);

            // Act
            string song_name = player.getAlbumName(file);


            // Assert
            Assert.AreEqual(song_name, "Cities");
        }


        [TestMethod]
        public void Test_List_Column_Info_Title()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();
            TagLib.File file = TagLib.File.Create(file_path1);

            // Act
            ListViewItem item = player.List_Column_Info(ref file);
            string title = item.SubItems[0].Text.ToString();

            // Assert
            Assert.AreEqual(title, "Godspeed");
        }


        [TestMethod]
        public void Test_List_Column_Info_Album()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();
            TagLib.File file = TagLib.File.Create(file_path1);

            // Act
            ListViewItem item = player.List_Column_Info(ref file);
            string album = item.SubItems[1].Text.ToString();

            // Assert
            Assert.AreEqual(album, "Cities");
        }


        [TestMethod]
        public void Test_List_Column_Info_Artist()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();
            TagLib.File file = TagLib.File.Create(file_path1);

            // Act
            ListViewItem item = player.List_Column_Info(ref file);
            string artist = item.SubItems[2].Text.ToString();

            // Assert
            Assert.AreEqual(artist, "Anberlin");
        }


        [TestMethod]
        // Test file where the first seconds digit is 0
        public void Test_List_Column_Info_Duration()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();
            TagLib.File file = TagLib.File.Create(file_path1);

            // Act
            ListViewItem item = player.List_Column_Info(ref file);
            string duration = item.SubItems[3].Text.ToString();

            // Assert
            Assert.AreEqual(duration, "3:02");
        }


        [TestMethod]
        // Test file where the first seconds digit is not 0
        public void Test_List_Column_Info_Duration2()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();
            TagLib.File file = TagLib.File.Create(file_path2);

            // Act
            ListViewItem item = player.List_Column_Info(ref file);
            string duration = item.SubItems[3].Text.ToString();

            // Assert
            Assert.AreEqual(duration, "3:25");   // Test file where the first seconds digit is not 0
        }


        [TestMethod]
        public void Test_Song_Map()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.add_new_song(file_path1);
            player.add_new_song(file_path2);

            // Assert
            Assert.AreEqual(file_path1, player.song_map["Godspeed"]);
            Assert.AreEqual(file_path2, player.song_map["A Whisper & A Clamor"]);
        }

        [TestMethod]
        public void Test_Song_Map_Same_Song_Path()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.add_new_song(file_path1);
            player.add_new_song(file_path1);

            // Assert 
            Assert.AreEqual(file_path1, player.song_map["Godspeed"]);
        }


        [TestMethod]
        public void Test_Song_Map_Same_Song_Different_Path()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.add_new_song(file_path1);
            player.add_new_song(file_path_duplicate);

            // Assert
            Assert.AreEqual(file_path_duplicate, player.song_map["Godspeed"]);
            Assert.AreNotEqual(file_path1, player.song_map["Godspeed"]);
        }


        [TestMethod]
        public void Test_Album_Map()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.add_new_song(file_path1);
            player.add_new_song(file_path2);

            List<string> songs = player.album_map["Cities"];

            // Assert
            Assert.AreEqual(songs[0], file_path1);
            Assert.AreEqual(songs[1], file_path2);
            Assert.IsTrue(songs.Count == 2);
        }


        [TestMethod]
        public void Test_Album_Map_Same_Song()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.add_new_song(file_path1);
            player.add_new_song(file_path1);

            List<string> songs = player.album_map["Cities"];

            // Assert
            Assert.AreEqual(songs[0], file_path1);
            Assert.IsTrue(songs.Count == 1);
        }


        [TestMethod]
        public void Test_Artist_Map()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.add_new_song(file_path1);
            player.add_new_song(file_path2);
            List<string> songs = player.artist_map["Anberlin"];

            // Assert
            Assert.AreEqual(songs[0], file_path1);
            Assert.AreEqual(songs[1], file_path2);
            Assert.IsTrue(songs.Count == 2);
        }


        [TestMethod]
        public void Test_Artist_Map_Same_Song()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.add_new_song(file_path1);
            player.add_new_song(file_path1);
            List<string> songs = player.artist_map["Anberlin"];

            // Assert
            Assert.AreEqual(songs[0], file_path1);
            Assert.IsTrue(songs.Count == 1);
        }

        [TestMethod]
        public void Test_Song_Selected()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.play_song(file_path1);

            // Assert
            Assert.IsTrue(player.song_selected);
        }


        [TestMethod]
        public void Test_Song_Selected_Fail()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act

            // Assert
            Assert.IsFalse(player.song_selected);
            Assert.IsTrue(!player.song_selected);
        }

        [TestMethod]
        public void Test_Dequeue_PushFront()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act
            play_queue.Push_Front("1");
            play_queue.Push_Front("2");
            play_queue.Push_Front("3");

            // Assert
            Assert.IsTrue(play_queue.Count() == 3);
            Assert.AreEqual(play_queue.view_Top(), "3");
        }

        [TestMethod]
        public void Test_Dequeue_PushBack()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act
            play_queue.Push_Back("1");
            play_queue.Push_Back("2");
            play_queue.Push_Back("3");
            play_queue.Push_Back("4");

            // Assert
            Assert.IsTrue(play_queue.Count() == 4);
            Assert.AreEqual(play_queue.view_Top(), "1");
        }

        [TestMethod]
        public void Test_Dequeue_PopFront()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act
            play_queue.Push_Front("1");
            play_queue.Push_Back("2");
            play_queue.Push_Front("3");
            play_queue.Push_Back("4");
            play_queue.Push_Front("5");

            Assert.IsTrue(play_queue.Count() == 5);
            Assert.AreEqual(play_queue.view_Top(), "5");

            string first = play_queue.Pop_Front();
            string second = play_queue.Pop_Front();

            // Assert
            Assert.IsTrue(play_queue.Count() == 3);
            Assert.AreEqual(first, "5");
            Assert.AreEqual(second, "3");
            Assert.AreEqual(play_queue.view_Top(), "1");
        }

        [TestMethod]
        public void Test_Dequeue_PopFront_Empty()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act

            // Assert
            Assert.IsTrue(play_queue.Count() == 0);
            Assert.IsNull(play_queue.Pop_Front());
        }

        [TestMethod]
        public void Test_Dequeue_PopBack()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act
            play_queue.Push_Front("1");
            play_queue.Push_Back("2");
            play_queue.Push_Front("3");
            play_queue.Push_Back("4");
            play_queue.Push_Front("5");

            Assert.IsTrue(play_queue.Count() == 5);
            Assert.AreEqual(play_queue.view_Top(), "5");

            string first = play_queue.Pop_Back();
            string second = play_queue.Pop_Back();
            string third = play_queue.Pop_Back();

            // Assert
            Assert.IsTrue(play_queue.Count() == 2);
            Assert.AreEqual(first, "4");
            Assert.AreEqual(second, "2");
            Assert.AreEqual(third, "1");
            Assert.AreEqual(play_queue.view_Top(), "5");
        }

        [TestMethod]
        public void Test_Dequeue_PopBack_Empty()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act

            // Assert
            Assert.IsTrue(play_queue.Count() == 0);
            Assert.IsNull(play_queue.Pop_Back());
        }

        [TestMethod]
        public void Test_Dequeue_Count()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act

            // Assert
            Assert.IsTrue(play_queue.Count() == 0);

            play_queue.Push_Front("1");
            Assert.IsTrue(play_queue.Count() == 1);

            for (int i = 2; i <= 10; ++i)
                play_queue.Push_Back(i.ToString());

            Assert.IsTrue(play_queue.Count() == 10);

            for (int i = 0; i < 6; ++i)
                play_queue.Pop_Back();

            Assert.IsTrue(play_queue.Count() == 4);
        }

        [TestMethod]
        public void Test_Dequeue_ViewTop()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act

            // Assert
            Assert.IsNull(play_queue.view_Top());

            play_queue.Push_Back("1");
            Assert.AreEqual(play_queue.view_Top(), "1");

            play_queue.Push_Front("2");
            play_queue.Push_Front("3");
            Assert.AreEqual(play_queue.view_Top(), "3");

            play_queue.Pop_Front();
            Assert.AreEqual(play_queue.view_Top(), "2");
        }

        [TestMethod]
        public void Test_Dequeue_Clear()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act
            Assert.IsTrue(play_queue.Count() == 0);

            for (int i = 0; i < 10; ++i)
                play_queue.Push_Back(i.ToString());

            Assert.IsTrue(play_queue.Count() == 10);
            play_queue.Clear();

            // Assert
            Assert.IsTrue(play_queue.Count() == 0);
        }

        [TestMethod]
        public void Test_Dequeue_ElementAt()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act
            for (int i = 0; i < 10; ++i)
                play_queue.Push_Back(i.ToString());

            // Assert
            Assert.AreEqual(play_queue.ElementAt(0), "0");
            Assert.AreEqual(play_queue.ElementAt(5), "5");
            Assert.AreEqual(play_queue.ElementAt(9), "9");
        }

        [TestMethod]
        public void Test_Dequeue_ElementAt_Empty()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act

            // Assert
            Assert.IsNull(play_queue.ElementAt(0));
        }


        [TestMethod]
        public void Test_Dequeue_ElementAt_BeyondRange()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act
            for (int i = 0; i < 4; ++i)
                play_queue.Push_Back(i.ToString());

            // Assert
            Assert.IsNull(play_queue.ElementAt(5));
        }

        [TestMethod]
        public void Test_Dequeue_Remove_Front()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act
            for (int i = 0; i < 5; ++i)
                play_queue.Push_Back(i.ToString());
            Assert.IsTrue(play_queue.Count() == 5);

            // Assert
            play_queue.Remove_Element("0");
            Assert.IsTrue(play_queue.Count() == 4);
            Assert.AreEqual(play_queue.Pop_Front(), "1");
        }

        [TestMethod]
        public void Test_Dequeue_Remove_Back()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act
            for (int i = 0; i < 15; ++i)
                play_queue.Push_Back(i.ToString());
            Assert.IsTrue(play_queue.Count() == 15);

            // Assert
            play_queue.Remove_Element("14");
            Assert.IsTrue(play_queue.Count() == 14);
            Assert.AreEqual(play_queue.Pop_Back(), "13");
        }

        [TestMethod]
        public void Test_Dequeue_Remove_Middle()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act
            for (int i = 0; i < 30; ++i)
                play_queue.Push_Back(i.ToString());
            Assert.IsTrue(play_queue.Count() == 30);

            // Assert
            play_queue.Remove_Element("24");
            Assert.IsTrue(play_queue.Count() == 29);
            Assert.AreEqual(play_queue.ElementAt(24), "25");
        }

        [TestMethod]
        public void Test_Dequeue_Remove_NotFound()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act
            for (int i = 0; i < 10; ++i)
                play_queue.Push_Back(i.ToString());
            Assert.IsTrue(play_queue.Count() == 10);

            // Assert
            play_queue.Remove_Element("50");
            Assert.IsTrue(play_queue.Count() == 10);
        }

        [TestMethod]
        public void Test_Dequeue_ToArray()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act
            for (int i = 0; i < 10; ++i)
                play_queue.Push_Back(i.ToString());
            Assert.IsTrue(play_queue.Count() == 10);

            // Assert
            string[] array = play_queue.ToArray();
            for (int i = 0; i < 10; ++i)
                Assert.AreEqual(play_queue.ElementAt(i), i.ToString());
        }

        // Dan's Unit Test:
        [TestMethod]
        public void Test_Add_User()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();
            player.clear_users();
            string name = "bob";

            // Act
            player.create_new_user(name);

            // Assert
            string[] users = player.get_all_users(player.get_all_user_lines());
            Assert.AreEqual(users[0], name);

        }

        [TestMethod]
        public void Test_Get_All_Users()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();
            player.clear_users();

            // Act
            player.create_new_user("dan");
            player.create_new_user("dan2");
            player.create_new_user("dan3");

            // Assert
            string[] users = player.get_all_users(player.get_all_user_lines());
            Assert.AreEqual(users.Length, 3);

        }

        [TestMethod]
        public void Test_Switch_To_User()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();
            player.clear_users();

            // Act
            player.create_new_user("dan");
            player.create_new_user("dan2");
            player.create_new_user("dan3");

            // Assert
            Assert.AreEqual(player.get_user(), "dan3");
            player.switch_to_user("dan2");
            Assert.AreEqual(player.get_user(), "dan2");
            Assert.AreEqual(player.switch_to_user("not_a_user"), false);


        }

        [TestMethod]
        public void Test_Delete_Users()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();
            player.clear_users();

            // Act
            player.create_new_user("dan");
            player.create_new_user("dan2");
            player.create_new_user("dan3");
            player.clear_users();

            // Assert
            try
            {
                string[] users = player.get_all_users(player.get_all_user_lines());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(true);
            }

        }


        // Andy's Unit Test:
        [TestMethod]
        public void Test_Dequeue_ElementAt_NegativeIndex()
        {
            // Arrange
            var play_queue = new BearPlayer.Bear_Player.Dequeue();

            // Act
            for (int i = 0; i < 3; ++i)
                play_queue.Push_Back(i.ToString());

            // Assert
            Assert.IsNull(play_queue.ElementAt(-1));
        }

        //Trevor's Unit test
        //[
        [TestMethod]
        public void Test_Playlist_File_Created()
        {
            //Arrange
            var playlist = new BearPlayer.Bear_Player();
            string playlistName = "TrevorPlaylist";

            //Act
            playlist.Add_New_Playlist(playlistName);

            //Assert
            Assert.IsTrue(File.Exists((@"C:\BearPlayer\Resources\" + playlistName + ".txt")));
        }

        [TestMethod]
        public void Test_Song_URL_Added_To_Playlist_Text_File()
        {
            //Arrange
            var bearPlayer = new BearPlayer.Bear_Player();
            string playlistName = "TrevorPlaylist";
            bearPlayer.Add_New_Playlist(playlistName);
            bearPlayer.add_new_song(TrevSong);

            //Act
            bearPlayer.addSongToPlaylist("Intro", playlistName);

            //Assert
            string[] line = File.ReadAllLines(@"C:\BearPlayer\Resources\" + playlistName + ".txt");
            Assert.IsTrue(line[0] == @"C:\BearPlayer\Resources\01 Intro.mp3");
        }

        [TestMethod]
        public void Test_File_Does_Not_Exist_To_Playlist()
        {
            //Arrange
            var bearPlayer = new BearPlayer.Bear_Player();
            string playlistName = "TrevorPlaylist";
            bearPlayer.Add_New_Playlist(playlistName);

            //Act
            bearPlayer.addSongToPlaylist("Not_A_Song", playlistName);

            //Assert
            string[] line = File.ReadAllLines(@"C:\BearPlayer\Resources\" + playlistName + ".txt");
            Assert.IsTrue(line.Length == 0); //nothing written to the file
        }

        [TestMethod]
        public void Test_Add_Null_Value_To_Playlist()
        {
            //Arrange
            var bearPlayer = new BearPlayer.Bear_Player();
            string playlistName = "TrevorPlaylist";
            bearPlayer.Add_New_Playlist(playlistName);

            //Act
            bearPlayer.addSongToPlaylist(null, playlistName);

            //Assert
            string[] line = File.ReadAllLines(@"C:\BearPlayer\Resources\" + playlistName + ".txt");
            Assert.IsTrue(line.Length == 0); //nothing written to the file
        }
        //]

        
        //Ryan's Unit Test
        [TestMethod]
        public void Test_Resize_Song_List()
        {
            var player = new BearPlayer.Bear_Player();
            //1064, 656 min size of player

            player.Height = 1065;
            player.Width = 657;
            ListView songs = player.curr_list_box;
            player.Change_ArtistView();
            MessageBox.Show(songs.Height.ToString());
            Assert.IsTrue(songs.Width == 1458);
            Assert.IsTrue(songs.Height == 1201);
        }


        // Cale's Unit Tests:
        // [
        [TestMethod]
        public void Test_Add_One_Playlist()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.Add_New_Playlist("new");

            // Assert
            Assert.AreEqual(player.Playlist_Names[0], "new");
        }


        [TestMethod]
        public void Test_Add_Multiple_Playlist()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            for (int i = 0; i < 5; ++i)
                player.Add_New_Playlist(i.ToString());

            // Assert
            for (int i = 0; i < 5; ++i)
                Assert.AreEqual(player.Playlist_Names[i], i.ToString());
        }


        [TestMethod]
        public void Test_Add_Duplicate_Playlist()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.Add_New_Playlist("playlist");
            player.Add_New_Playlist("playlist");

            // Assert
            Assert.AreEqual(player.Playlist_Names[0], "playlist");
            Assert.IsTrue(player.Playlist_Names.Count == 1);

        }

        [TestMethod]
        public void Test_Change_ArtistView()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.Change_ArtistView();

            // Assert
            Assert.AreEqual(player.curr_view.ToString(), "Artists");
        }

        [TestMethod]
        public void Test_Change_AlbumView()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.Change_AlbumView();

            // Assert
            Assert.AreEqual(player.curr_view.ToString(), "Albums");
        }

        [TestMethod]
        public void Test_Change_SongView()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.Change_SongView();

            // Assert
            Assert.AreEqual(player.curr_view.ToString(), "Songs");
        }


        [TestMethod]
        public void Test_Change_QueueView()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.Change_QueueView();

            // Assert
            Assert.AreEqual(player.curr_view.ToString(), "Queue");
        }


        [TestMethod]
        public void Test_Change_PlaylistView()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.Change_PlaylistView();

            // Assert
            Assert.AreEqual(player.curr_view.ToString(), "Playlists");
        }

        [TestMethod]
        public void Test_Change_PlaylistSongView()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();
            string playlist = "playlist";

            // Act
            player.Change_UserPlaylistView(playlist);

            // Assert
            Assert.AreEqual(player.curr_view.ToString(), "Playlists_Song");
        }

        [TestMethod]
        public void Test_Change_SearchView()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.Change_SearchView();

            // Assert
            Assert.AreEqual(player.curr_view.ToString(), "Search");
        }

        [TestMethod]
        public void Test_ChangeOptions_Label()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.Change_OptionsView();

            // Assert
            Assert.AreEqual(player.View_Label.Text, "Options");
        }

        [TestMethod]
        public void Test_ChangeArtist_Label()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.Change_ArtistView();

            // Assert
            Assert.AreEqual(player.View_Label.Text, "Artists");
        }

        [TestMethod]
        public void Test_ChangeAlbum_Label()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.Change_AlbumView();

            // Assert
            Assert.AreEqual(player.View_Label.Text, "Albums");
        }

        [TestMethod]
        public void Test_ChangeSongs_Label()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.Change_SongView();

            // Assert
            Assert.AreEqual(player.View_Label.Text, "Songs");
        }

        [TestMethod]
        public void Test_ChangeQueue_Label()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.Change_QueueView();

            // Assert
            Assert.AreEqual(player.View_Label.Text, "Queue");
        }

        [TestMethod]
        public void Test_ChangePlaylist_Label()
        {
            // Arrange
            var player = new BearPlayer.Bear_Player();

            // Act
            player.Change_PlaylistView();

            // Assert
            Assert.AreEqual(player.View_Label.Text, "Playlists");
        }

        // ]
    }
}
