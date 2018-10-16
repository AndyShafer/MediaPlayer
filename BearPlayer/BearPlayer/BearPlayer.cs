using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BearPlayer.Properties;


namespace BearPlayer
{
    public partial class Bear_Player : Form
    {
        /* --- DATA MEMBERS --- */
        WMPLib.WindowsMediaPlayer Player;   // Player object from WMP library
        public bool play;   // Global variable for controling play/pause state
        public Timer song_time;
        public string curr_song;
        public bool song_selected;
        public int blink_count;
        public string songName;
        public int songctr;
        public string curr_playlist;
        public string promptValue = ""; //for playlist creation
        bool in_search_bar = false;

        //current directory is bin folder
        string curr_directory;

        // Hashmaps to song directory address
        public Dictionary<string, string> song_map = new Dictionary<string,string>();
        public Dictionary<string, List<string> > artist_map = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string> > album_map = new Dictionary<string, List<string>>();

        public Dequeue queue = new Dequeue();   // Dequeue for play queue
        public Stack<string> prev_songs = new Stack<string>();   // Stack for previous songs

        // Variables for current view
        public ListView curr_list_box;
        public view curr_view;
        public string selected_artist, selected_album;

        public bool shuffle;   // Shuffle toggle 
        public Repeat_Type repeat_type;   // Repeat toggle

        // Variables for searching
        public string search_entry;
        public bool found;
        public bool cancel;

        public List<string> Playlist_Names = new List<string>();    // List of all playlist names

        //users, goes in order name, sidebar, center, top
        public int fields = 4;
        public Color default_side_color = Color.DodgerBlue;
        public Color default_center_color = Color.White;
        public Color default_bottom_color = Color.White;
        string user_file_loc;// = @"C:\BearPlayer\Resources\Users.txt";
        string playlist_file_loc;// = @"C:\BearPlayer\Resources\Playlists.txt";
        string playlist_loc;// = @"C:\BearPlayer\Resources\";
        string user = "";

        public ContextMenu cm;
        public MenuItem addToPlaylistCM;

        //saving folder paths
        public string folder_path_file_loc;// = @"C:\BearPlayer\Resources\Folder_Paths.txt";

        private List<string> added_nodes = new List<string>();

        /* --- CONSTRUCTOR --- */
        public Bear_Player()
        {
            play = true;   // Begin program with play button

            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;   // Opens application maximized
            InitializeComponent();
            Player = new WMPLib.WindowsMediaPlayer();
            Player.settings.volume = 25;
            song_time = new Timer();     // Timer that will update the scrub bar when the location in the song changes
            song_time.Interval = 10;
            song_time.Tick += new EventHandler(song_time_Elapsed);            // Causes the event to go whenever the timer elapses

            // Begin in song view
            Artist_View.Visible = false;
            Albums_View.Visible = false;
            Search_View.Visible = false;
            Songs_View.Visible = true;
            Playlists_View.Visible = false;
            Artist_Song_View.Visible = false;
            Queue_View.Visible = false;
            Options_Panel.Visible = false;
            curr_view = view.Songs;
            curr_list_box = Song_List;

            curr_playlist = null;
            curr_song = null;
            song_selected = false;
            blink_count = 0;
            selected_artist = "";
            search_entry = "";
            shuffle = false;
            repeat_type = Repeat_Type.Off;
            found = false;

            cm = new ContextMenu();
            cm.MenuItems.Add("Play", new EventHandler(Song_List_SelectedIndexChanged));
            cm.MenuItems.Add("Play Next", new EventHandler(right_click_play_next));
            cm.MenuItems.Add("Enqueue", new EventHandler(right_click_enqueue));
            cm.MenuItems.Add("Get Tags", new EventHandler(Get_Tags_Request));
            addToPlaylistCM = new MenuItem("Add to Playlist");
            cm.MenuItems.Add(addToPlaylistCM);
            cm.MenuItems.Add("Add To New Playlist", new EventHandler(add_to_new_playlist_right_click));

            //directory vars
            curr_directory = Directory.GetCurrentDirectory() + @"\";
            user_file_loc = curr_directory + "Users.txt";
            playlist_file_loc = curr_directory + "Playlists.txt";
            playlist_loc = curr_directory;
            folder_path_file_loc = curr_directory + "Folder_Paths.txt";

            KeyPreview = true;
            this.MinimumSize = new Size(1064, 656);

            //imports
            import_saved_folders();
            import_saved_playlists();
            check_bad_user_file();
        }
        /* --- METHODS --- */

        /* USER INTERFACE EVENTS */
        private void BearPlayer_Load(object sender, EventArgs e)
        {         
            
        }

        private void right_click_enqueue(object sender, EventArgs e)
        {
            if (curr_list_box.SelectedIndices.Count <= 0) return;
            int i = curr_list_box.SelectedIndices[0];
            string text;
            if (i >= 0 && i < curr_list_box.Items.Count)
            {
                text = curr_list_box.Items[i].Text;
            }
            else
            {
                return;
            }
            queue.Push_Back(text);
        }

        private void right_click_play_next(object sender, EventArgs e)
        {
            if (curr_list_box.SelectedIndices.Count <= 0) return;
            int i = curr_list_box.SelectedIndices[0];
            string text;
            if (i >= 0 && i < curr_list_box.Items.Count)
            {
                text = curr_list_box.Items[i].Text;
            }
            else
            {
                return;
            }
            queue.Push_Front(text);
        }

        private void Get_Tags_Request(object sender, EventArgs e)
        {
            if (curr_list_box.SelectedIndices.Count <= 0) return;
            int i = curr_list_box.SelectedIndices[0];
            string text;
            if (i >= 0 && i < curr_list_box.Items.Count)
            {
                text = curr_list_box.Items[i].Text;
            }
            else
            {
                return;
            }
                
            TagLib.File f = TagLib.File.Create(song_map[text]);
            string[] tags = Tag_List.ShowDialog(f);
            if (tags.Length == 1) return;

            f.Tag.Title = tags[0];

            if(f.Tag.Performers.Length != 0)
            {
                f.Tag.Performers[0] = tags[1];
            }
            else
            {
                f.Tag.Performers = new string[] { tags[1] };
            }
            
            f.Tag.Album = tags[2];

            if (f.Tag.Genres.Length != 0)
            {
                f.Tag.Genres[0] = tags[3];
            }
            else
            {
                f.Tag.Genres = new string[] { tags[3] };
            }

        }

        public void check_bad_user_file()
        {
            //MessageBox.Show("" + get_all_user_lines().Length);
            if( get_all_user_lines().Length == 1 || get_all_user_lines().Length % 4 != 0)
            {
                clear_users();
            }
        }
        
        public void import_saved_playlists()
        {
            if (!File.Exists(playlist_file_loc)) return;
            string[] playlist_names = System.IO.File.ReadAllLines(playlist_file_loc);
            List<string> plays = new List<string>(playlist_names);
            foreach (string playlist in playlist_names)
            {
                if (!File.Exists(playlist_loc + playlist + ".txt"))
                {
                    plays.Remove(playlist);
                }
                else
                {
                    create_playlist_node(playlist);
                }
            }

            System.IO.File.WriteAllLines(playlist_file_loc, plays.ToArray<string>());
            Playlist_Names = plays;
        }

        public void import_saved_folders()
        {
            if (!File.Exists(folder_path_file_loc)) return;
            string[] paths_array = System.IO.File.ReadAllLines(folder_path_file_loc);
            List<string> paths = new List<string>(paths_array);
            foreach (string path in paths_array)
            {
                try
                {
                    int imports = import_folder(path);
                    if (imports == 0) paths.Remove(path);
                }
                catch (Exception e)
                {
                    paths.Remove(path);
                }
            }

            System.IO.File.WriteAllLines(folder_path_file_loc, paths.ToArray<string>());
        }


        // PLAY BAR BUTTONS:

        // Method for mouse click on play button
        public void playButton_Click(object sender, EventArgs e)
        {
            play_pause_toggle();
        }

        // Method for skipping to next song by clicking on next button
        private void next_button_Click(object sender, EventArgs e)
        {
            play_next_song();   // Call function to play next song
            if (curr_view == view.Queue) update_list_disp();   // Update display after adjusting play queue
        }

        // Method for skipping to previous song by clicking on previous button
        private void previous_button_Click(object sender, EventArgs e)
        {
            // If scrub bar is less than 5 seconds into song, go to previous song
            if (scrubBar.Value <= 5)
            {
                play_prev_song();
                if (curr_view == view.Queue) update_list_disp();
            }
            // Else, if scrub bar is more than 5 seconds into song, restart song
            else
                play_song(song_map[curr_song]);
        }

        // Method for mouse click on shuffle button
        private void Shuffle_Toggle_Click(object sender, EventArgs e)
        {
            shuffle = !shuffle;   // Adjust toggle
            // Change shuffle picture based on toggle
            if (shuffle) shuffle_toggle.Image = Resources.shuffleButtonOn;
            else shuffle_toggle.Image = Resources.shuffleButtonOff;
        }

        // Method for mouse click on repeat button
        private void Repeat_Button_Click(object sender, EventArgs e)
        {
            // If no repeat is toggled...
            if (repeat_type == Repeat_Type.Off)
            {
                repeat_type = Repeat_Type.Repeat_All;   // ... toggle to all repeat
                repeat_button.Image = Resources.Repeat_All;  // Adjust image

                // Adjust play queue to repeat entire queue
                Dequeue temp = new Dequeue();
                int c = prev_songs.Count();
                for (int i = 0; i < c; i++)
                {
                    temp.Push_Back(prev_songs.Pop());
                }
                for (int i = 0; i < c; i++)
                {
                    queue.Push_Back(temp.Pop_Back());
                }
                if (c == 0 && queue.Count() == 0 && curr_song != null)
                {
                    queue.Push_Back(curr_song);
                }
            }
            // If all repeat is toggled...
            else if (repeat_type == Repeat_Type.Repeat_All)
            {
                repeat_type = Repeat_Type.Repeat_One;   // ... toggle to one repeat
                repeat_button.Image = Resources.Repeat_One;   // Adjust image

                // Adjust play queue to repeat one song
                if (curr_song != null)
                {
                    prev_songs.Clear();
                    queue.Clear();
                    queue.Push_Front(curr_song);
                }
            }
            // Else, if one repeat is toggled...
            else
            {
                repeat_type = Repeat_Type.Off;   // ... turn off repeat
                repeat_button.Image = Resources.Repeat;  // Adjust image
            }

            if (curr_view == view.Queue) update_list_disp();
        }

        // Function for clicking on back button
        private void BackButton_Click(object sender, EventArgs e)
        {
            // If on artist song view, return to artist view
            if (curr_view.ToString().Equals("Artist_Song"))
                Change_ArtistView();

            // If on album song view, return to album view
            if (curr_view.ToString().Equals("Album_Song"))
                Change_AlbumView();

            // If on user playlist view, return to playlist view
            if (curr_view.ToString().Equals("Playlists_Song"))
                Change_PlaylistView();
        }


        // IMPORTING SONGS:

        // Method for importing folder 
        public void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string folder_path = "";   //initializes the folder path
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(folder_path_file_loc, true))
                    {
                        file.WriteLine(folderDialog.SelectedPath);
                    }
                    import_folder(folderDialog.SelectedPath);
                }
            }
        }
        public int import_folder(string path)
        {
            int songs = getSongs(path);   // Add all songs to map
            songs += getAlbums(path);   // Add all albums to map
            update_list_disp();
            return songs;
        }

        // Method for importing single song
        private void importSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();   // Creates a new file dialog each time the inport song button is clicked
            openFileDialog1.Filter = "Music Files| *.mp3";               // Sets the filter to only show mp3 files
            openFileDialog1.Title = "Select a Song";
            string file_path = "";   // Initializes the file path
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file_path = openFileDialog1.FileName;   // Get song name from file
                add_new_song(file_path);     // Set the path that is saved to be the text for the textbox in the gui
                update_list_disp();    // Update list display with new song added
            }
        }


        // MENU BAR:

        // Method for creating new playlist from menu bar
        private void newPlaylistToolStripMenuItem_Click(object sender, EventArgs e) { Change_NewPlaylistView();   }

        // Method for searching for file in application from menu bar
        private void searchToolStripMenuItem_Click(object sender, EventArgs e) {  searchBar.Focus();   }

        // Method for changing to artist view from menu bar
        private void ArtistViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_ArtistView();
        }

        // Method for switching to album view using menu bar
        private void albumViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_AlbumView();
        }

        // Method for switching to list view on menu bar
        private void songViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_SongView();
        }

        // Method for changing to queue view from menu bar
        private void QueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_QueueView();
        }

        // Method for changing to playlist view from menu bar
        private void PlaylistViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_PlaylistView();
        }

        // Method for changing application appearance from menu bar
        private void changeAppearanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_OptionsView();
        }

        // Method for moving to next song in play queue from menu bar
        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            play_next_song();
            if (curr_view == view.Queue) update_list_disp();
        }

        // Method for moving to previous song in play queue from menu bar
        private void previousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If scrub bar is less than 5 seconds into song, go to previous song
            if (scrubBar.Value <= 5)
            {
                play_prev_song();
                if (curr_view == view.Queue) update_list_disp();
            }
            // Else, if scrub bar is more than 5 seconds into song, restart song
            else
                play_song(song_map[curr_song]);
        }

        // Shuffle play queue from menu bar
        private void shuffleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shuffle = !shuffle;   // Adjust toggle
            // Change shuffle picture based on toggle
            if (shuffle) shuffle_toggle.Image = Resources.shuffleButtonOn;
            else shuffle_toggle.Image = Resources.shuffleButtonOff;

            update_list_disp();
        }

        // Method for changing repeat toggle to no repeat from menu bar
        private void noRepeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repeat_type = Repeat_Type.Off;   // ... turn off repeat
            repeat_button.Image = Resources.Repeat; // Adjust image

            if (curr_view == view.Queue) update_list_disp();
        }


        // Method for changing repeat toggle to repeat one from menu bar
        private void repeatOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repeat_type = Repeat_Type.Repeat_One;   // ... toggle to one repeat
            repeat_button.Image = Resources.Repeat_One;   // Adjust image

            // Adjust play queue to repeat one song
            if (curr_song != null)
            {
                prev_songs.Clear();
                queue.Clear();
                queue.Push_Front(curr_song);
            }

            if (curr_view == view.Queue) update_list_disp();
        }

        // Method for changing repeat toggle to repeat all from menu bar
        private void repeatAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            repeat_type = Repeat_Type.Repeat_All;   // ... toggle to all repeat
            repeat_button.Image = Resources.Repeat_All;   // Adjust image

            // Adjust play queue to repeat entire queue
            Dequeue temp = new Dequeue();
            int c = prev_songs.Count();
            for (int i = 0; i < c; i++)
            {
                temp.Push_Back(prev_songs.Pop());
            }
            for (int i = 0; i < c; i++)
            {
                queue.Push_Back(temp.Pop_Back());
            }
            if (c == 0 && queue.Count() == 0)
            {
                queue.Push_Back(curr_song);
            }

            if (curr_view == view.Queue) update_list_disp();
        }

        // Method for exiting program from menu bar (*IMPORTANT! NEVER, EVER REMOVE*)
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {  this.Close();   }



        // VOLUME: 

        // Method for adjusting volume using volume slider
        private void volumeSlider_Scroll_1(object sender, EventArgs e)
        {
            Player.settings.volume = volumeSlider.Value;
        }

        // Method for increasing volume slider using menu bar
        private void volumeUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if volume can still be increased
            if (Player.settings.volume < 90)
                Player.settings.volume = Player.settings.volume + 10;     // If the volume can be increased by 10 then it adds ten to volume
            // Else, volume is at maximum
            else
                Player.settings.volume = 100;                   // If volume is greater than 90 already sets the volume to 100

            volumeSlider.Value = Player.settings.volume;  // Set volume slider to new value
        }

        // Method for decreasing volume slider using menu bar
        private void volumeDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if volume can still be decreased
            if (Player.settings.volume > 10)
                Player.settings.volume = Player.settings.volume - 10;    // If the volume can be decreased by 10 then it subtracts ten from the volume
            // Else, volume is at minimum
            else
                Player.settings.volume = 0;   // If volume is less than 10 already sets the volume to 0

            volumeSlider.Value = Player.settings.volume;    // Set volume slider to new value
        }

        // SCRUB BAR: 

        // Method for scrubbing through song using scrub bar
        private void scrubBar_Scroll(object sender, EventArgs e)
        {
            Player.controls.currentPosition = scrubBar.Value;   // Move song location to new scrub bar value
            this.bear_logo.Image = Resources.bear_headphone;
            //add clicking onto the slide bar to change to the location
            //maybe add functionality to change to parts of the song using number keys

        }

        // Method for moving scrub bar tick along scrub bar as song progresses
        private void song_time_Elapsed(object sender, EventArgs e)
        {
            scrubBar.Value = (int)Player.controls.currentPosition;   // Makes the scrub bar follow the song as it plays

            // Add addition 0 in front if number of seconds is less than 10
            if (scrubBar.Value % 60 >= 10)
                Current_position_label.Text = (scrubBar.Value / 60).ToString() + ":" + (scrubBar.Value % 60).ToString();
            else
                Current_position_label.Text = (scrubBar.Value / 60).ToString() + ":0" + (scrubBar.Value % 60).ToString();

            // Move to next song is scrub bar reaches end
            if (scrubBar.Value >= scrubBar.Maximum)
            {
                play_next_song();
                if (curr_view == view.Queue) update_list_disp();
            }

            // Algorithm for blinking bear
            if (!play)
            {

                if (scrubBar.Value % 8 == 5)
                {
                    if (blink_count < 20)
                    {
                        this.bear_logo.Image = Resources.bear_headphone_blink;
                        blink_count++;
                    }
                }
                else
                {
                    blink_count = 0;
                }
                if (blink_count == 20)
                {
                    this.bear_logo.Image = Resources.bear_headphone;
                }
            }
            else
            {
                this.bear_logo.Height = 136;
                bear_logo.Location = new Point(27, 294);
                this.bear_logo.Image = Resources.bear;
            }
        }

        private void scrubBar_MouseDown(object sender, MouseEventArgs e)
        {
            if(song_selected || curr_song != null)
                song_time.Enabled = false;
        }

        private void scrubBar_MouseUp(object sender, MouseEventArgs e)
        {
            song_time.Enabled = true;
        }

        // Method for scrubbing forward using the toolbar
        private void scrubForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!play)
            {
                if (scrubBar.Maximum - scrubBar.Value <= 10)
                {
                    scrubBar.Value = scrubBar.Maximum - 1;
                }
                else
                {
                    scrubBar.Value += 10;
                }

                Player.controls.currentPosition = scrubBar.Value;
            }
        }

        // Method for scrubbing back using the toolbar
        private void scrubBackwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!play)
            {
                if (scrubBar.Value <= 10)
                {
                    scrubBar.Value = 0;
                }
                else
                {
                    scrubBar.Value -= 10;
                }
                Player.controls.currentPosition = scrubBar.Value;
            }
        }
        // VIEWS:

        void SideBar_MouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Clicking on artist view
            if (e.Node.Text.Equals("Artists"))
                Change_ArtistView();

            // Clicking on album view
            else if (e.Node.Text.Equals("Albums"))
                Change_AlbumView();

            // Clicking on song view
            else if (e.Node.Text.Equals("Songs"))
                Change_SongView();

            // Clicking on play queue view
            else if (e.Node.Text.Equals("Queue"))
                Change_QueueView();

            // Clicking on playlist view
            else if (e.Node.Text.Equals("New Playlist"))
                Change_NewPlaylistView();

            else if(e.Node.Text.Equals("Playlists"))
            {
                Change_PlaylistView();
            }

            // Clicking on created playlist
            else
                Change_UserPlaylistView(e.Node.Text);
        }


        // Method for switching to song list within artist view 
        private void Artist_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            Change_ArtistSongView(); // Change view to artist's song list
        }

        // Method for switching to song list within album list
        private void Album_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            Change_AlbumSongView();   // Change view to album's song list
        }

        // Method for selecting a song within the artist view
        private void Artist_Song_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_item_selected();
            play_next_song();
        }

        // Method for selecting a song within the album view
        private void Album_Song_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_item_selected();
            play_next_song();
        }

        // Method for selecting a song within the song view
        private void Song_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_item_selected();
            play_next_song();
        }

        // Method for selecting a song within the queue view
        private void Queue_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_item_selected();
            play_next_song();
        }

        // Method for selecting a song from the search view
        private void Search_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (found) {
                list_item_selected();
                play_next_song();
            }
        }

        // Method for special hover when over side bar
        private void SideBar_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if ((e.State & TreeNodeStates.Hot) != 0)
            {
                using (Brush b = new SolidBrush(Color.FromArgb(unchecked((int)0xFFB3D7F3))))
                    e.Graphics.FillRectangle(b, e.Bounds);
                using (Pen p = new Pen(new SolidBrush(Color.FromArgb(unchecked((int)0xFF0078D7)))))
                {
                    Rectangle border_bounds = e.Bounds;
                    border_bounds.Width -= 1;
                    border_bounds.Height -= 1;
                    e.Graphics.DrawRectangle(p, border_bounds);
                }
                e.Graphics.DrawString(e.Node.Text, e.Node.NodeFont, Brushes.Black, e.Bounds);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void Search_List_Click(object sender, EventArgs e)
        {
            if (song_selected == false)
                list_item_selected();
        }

        private void Song_List_Click(object sender, EventArgs e)
        {
            if (song_selected == false)
                list_item_selected();
        }

        private void Album_Song_List_Click(object sender, EventArgs e)
        {
            if (song_selected == false)
                list_item_selected();
        }

        private void Artist_Song_List_Click(object sender, EventArgs e)
        {
            if (song_selected == false)
                list_item_selected();
        }

        private void Song_List_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (curr_list_box.Sorting == SortOrder.None || curr_list_box.Sorting == SortOrder.Descending)
                curr_list_box.Sorting = SortOrder.Ascending;
            else if (curr_list_box.Sorting == SortOrder.Ascending)
                curr_list_box.Sorting = SortOrder.Descending;

            list_item_selected();
                        // Change back color of every list except for albums
            if(!curr_view.ToString().Equals("Albums"))
                for (int i = 1; i <= curr_list_box.Items.Count-1; i = (i + 2))
                    curr_list_box.Items[i].BackColor = Color.Gainsboro;    // Loop through every element in the list and alternate background colors
            for (int i = 0; i <= curr_list_box.Items.Count - 1; i = (i + 2))
                curr_list_box.Items[i].BackColor = Color.Transparent;    // Loop through every element in the list and alternate background colors
        }


        // SEARCH BAR:

        // Method for key press in search bar
        private void SearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if key pressed is ENTER key
            if (e.KeyCode == Keys.Enter)
            {
                search_entry = searchBar.Text.Split('\n')[0].ToUpper();
                Change_SearchView();                
            }
        }

        // Method for reseting search bar text 
        private void searchBar_Leave(object sender, EventArgs e)
        {
            searchBar.Text = "Search";
            in_search_bar = false;
        }

        private void searchBar_Enter(object sender, EventArgs e)
        {
            searchBar.Text = "";
            in_search_bar = true;
        }


        // NEW PLAYLIST 

        private void Playlist_Song_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_item_selected();
            play_next_song();
        }

        private void Playlist_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            Change_UserPlaylistView(curr_list_box.SelectedItems[0].Text);
        }

        private void NewPlaylist_TextBox_Enter(object sender, EventArgs e)
        {
            NewPlaylist_TextBox.Text = "";
        }

        private void NewPlaylist_TextBox_Leave(object sender, EventArgs e)
        {
            NewPlaylist_TextBox.Text = "Name New Playlist";
        }

        private void NewPlaylist_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Add_New_Playlist(NewPlaylist_TextBox.Text);
                NewPlaylist_Panel.Visible = false;
            }
        }


        // Method for pressing cancel button when creating new playlist
        private void NewPlaylist_CancelButton_Click(object sender, EventArgs e)
        {
            NewPlaylist_Panel.Visible = false;
        }


        // Method for pressing enter button when creating new playlist
        private void NewPlaylist_EnterButton_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(NewPlaylist_TextBox.Text);
            Add_New_Playlist(NewPlaylist_TextBox.Text);
            NewPlaylist_Panel.Visible = false;
        }
    

        // HOT KEYS:

        // Method for hotkeys within the program
        private void Bear_Player_KeyDown(object sender, KeyEventArgs e)
        {
            // Play/Pause using SPACE BAR
            if (e.KeyCode == Keys.MediaPlayPause || (e.KeyCode == Keys.Space && !in_search_bar))
            {
                play_pause_toggle();
            }

            // Next using CTRL+RIGHT
            else if (e.KeyCode == Keys.MediaNextTrack || (e.KeyCode == Keys.Right && e.Modifiers == Keys.Control))
            {
                play_next_song();
                if (curr_view == view.Queue) update_list_disp();
            }

            // Previous using CTRL+LEFT
            else if (e.KeyCode == Keys.MediaPreviousTrack || (e.KeyCode == Keys.Left && e.Modifiers == Keys.Control))
            {
                // Move to previous song if song is less than 5 seconds in
                if (scrubBar.Value <= 5)
                {
                    play_prev_song();
                    if (curr_view == view.Queue) update_list_disp();
                }

                // Replay song is song is more than 5 seconds in
                else
                {
                    play_song(song_map[curr_song]);
                }
            }
        }

        //add to playlist menu button
        private void addToPlaylist(object sender, EventArgs e)
        {
            addSongToPlaylist(songName, sender.ToString());
        }

        private void add_to_playlist_right_click(object sender, EventArgs e)
        {

            MenuItem mi = sender as MenuItem;
            string text = mi.Text;
            addSongToPlaylist(songName, text);
        }

        private void add_to_new_playlist_right_click(object sender, EventArgs e)
        {
            if (Change_NewPlaylistView() == true)
            {
                MenuItem mi = sender as MenuItem;
                string text = mi.Text;
                addSongToPlaylist(songName, promptValue);
            }
            else
            {
                //playlist already exists, song not added to existing playlist
            }
        }

        //RESIZING

        private void Bear_Player_Resize(object sender, EventArgs e)
        //changes the size of views and panels when changing the GUI
        {
            int min_width = this.MinimumSize.Width;
            int min_height = this.MinimumSize.Height;
            //1064, 656

            Album_List.Width = this.Width - min_width + 798;
            Album_List.Height = this.Height - min_height + 410;
            Album_Song_List.Width = this.Width - min_width + 801;
            Album_Song_List.Height = this.Height - min_height + 413;
            Album_Song_View.Width = this.Width - min_width + 804;
            Album_Song_View.Height = this.Height - min_height + 416;
            Albums_View.Width = this.Width - min_width + 804;
            Albums_View.Height = this.Height - min_height + 416;

            Artist_List.Width = this.Width - min_width + 801;
            Artist_List.Height = this.Height - min_height + 413;
            Artist_Song_List.Width = this.Width - min_width + 801;
            Artist_Song_List.Height = this.Height - min_height + 413;
            Artist_Song_View.Width = this.Width - min_width + 804;
            Artist_Song_View.Height = this.Height - min_height + 416;
            Artist_View.Width = this.Width - min_width + 804;
            Artist_View.Height = this.Height - min_height + 416;

            Playlist_List.Width = this.Width - min_width + 801;
            Playlist_List.Height = this.Height - min_height + 413;
            Playlists_View.Width = this.Width - min_width + 804;
            Playlists_View.Height = this.Height - min_height + 416;

            Playlist_Song_List.Width = this.Width - min_width + 801;
            Playlist_Song_List.Height = this.Height - min_height + 413;
            Playlist_Song_Panel.Width = this.Width - min_width + 804;
            Playlist_Song_Panel.Height = this.Height - min_height + 416;

            Queue_List.Width = this.Width - min_width + 801;
            Queue_List.Height = this.Height - min_height + 413;
            Queue_View.Width = this.Width - min_width + 804;
            Queue_View.Height = this.Height - min_height + 416;

            Search_List.Width = this.Width - min_width + 801;
            Search_List.Height = this.Height - min_height + 413;
            Search_View.Width = this.Width - min_width + 804;
            Search_View.Height = this.Height - min_height + 416;

            Song_List.Width = this.Width - min_width + 801;
            Song_List.Height = this.Height - min_height + 413;
            Songs_View.Width = this.Width - min_width + 804;
            Songs_View.Height = this.Height - min_height + 416;

            Album_List.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            Album_List.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            Album_Song_List.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            Album_Song_List.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            Artist_List.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            Artist_List.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            Search_List.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            Search_List.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            Search_List.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            Search_List.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            // Search_List.Refresh();
            if (!play)
            {
                this.bear_logo.Image = Resources.bear_headphone;
            }
            else
            {
                this.bear_logo.Image = Resources.bear;
            }
        }

        //RIGHT CLICK FUNCTIONALITY:

        private void Song_List_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //MessageBox.Show("Right click");
                Song_List.ContextMenu = cm;
            }

        }
        private void Album_Song_List_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //MessageBox.Show("Right click");
                Album_Song_List.ContextMenu = cm;
            }
        }

        private void Artist_Song_List_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                Artist_Song_List.ContextMenu = cm;
            }
        }


        /* BACKEND METHODS */

        // PLAY SONG:

        public void play_pause_toggle()
        {
            if (play)
            {
                //curr_list_box.SelectedIndex = playing_index;
                //string curr_song = curr_list_box.Items[playing_index].ToString();
                if (!song_selected)
                {
                                //for case where nothing is selected and they try to click play
                    /*int i = curr_list_box.SelectedIndices[0];
                    if (i >= 0 && i < curr_list_box.Items.Count)
                    {
                        fill_unshuffled_queue(curr_list_box.Items[i].Text.ToString());
                        play_next_song();
                        //playing_index = i;
                    }*/
                    if (queue.Count() > 0)
                    {
                        play_next_song();
                        play = false;
                    }
                }
                else
                {
                    this.playButton.Image = Resources.pauseButton;   // Change picture to pause button
                    Player.controls.play();
                    play = false;
                    this.bear_logo.Height = 169;
                    bear_logo.Location = new Point(27,261);
                    this.bear_logo.Image = Resources.bear_headphone;
                }

            }
            else
            {
                this.playButton.Image = Resources.playButton; // Change picture to play button
                Player.controls.pause(); // SHOULD BE CHANGED TO PAUSE EVENTUALLY BUT CURRENTLY PAUSE CAUSES IT TO REPEAT IMMEDIATELY
                play = true;
                this.bear_logo.Height = 136;
                bear_logo.Location = new Point(27,294);
                this.bear_logo.Image = Resources.bear;
            }
            
        }


        // Method for playing next song in play queue
        public void play_next_song()
        {
            // Check if repeat one toggle is on
            if(repeat_type == Repeat_Type.Repeat_One)
            {
                if( curr_song != null || queue.Count() != 0 )
                {
                    if (curr_song == null)
                    {
                        curr_song = queue.Pop_Front();
                    }
                    prev_songs.Clear();
                    queue.Clear();
                    queue.Push_Front(curr_song);
                    play_song(song_map[curr_song]);
                    currentAlbumDisplay();
                    return;
                }
            }

            // Check if repeat all toggle is on
            if( repeat_type == Repeat_Type.Repeat_All)
            {
                if(queue.Count() == 0 && curr_song != null)
                {
                    queue.Push_Front(curr_song);
                }
            }
            
            // Else, play next song in queue
            if(queue.Count() > 0)
            {
                string removed = queue.Pop_Front();
                if (song_map.ContainsKey(removed))
                {
                    play_song(song_map[removed]);
                }

                if(curr_song != null)
                {
                    if( repeat_type == Repeat_Type.Repeat_All)
                    {
                        queue.Push_Back(curr_song);
                    }
                    else
                    {
                        prev_songs.Push(curr_song);
                    }
                }

                curr_song = removed;
                currentAlbumDisplay();
                //sets the URL for the player as the file path

                //plays the file that is currently set as the URL
            }
            

        }

        // Return false if only resuming takes a URL
        public bool play_song(string url)
        {
            bool new_song = false;
            song_selected = true;
            scrubBar.Enabled = true;
            if (Player.URL != url)
            {
                Player.URL = url;
                new_song = true;
            }
            else
            {
                Player.controls.currentPosition = 0;
                new_song = false;
            }
            Current_position_label.Text = "0:00";
            scrubBar.Value = 0;
            Player.controls.play();
            this.playButton.Image = Resources.pauseButton;
            play = false;
            TagLib.File song_file = TagLib.File.Create(url);
            //creates a file to get the duration for the scrub bar
            if (song_file.Properties.Duration.Seconds >= 10)
                //checks the amount of digits in seconds
            {
                Song_length_label.Text = song_file.Properties.Duration.Minutes.ToString() + ":" + song_file.Properties.Duration.Seconds.ToString();
            }
            else
            {
                Song_length_label.Text = song_file.Properties.Duration.Minutes.ToString() + ":0" + song_file.Properties.Duration.Seconds.ToString();
            }
            scrubBar.Maximum = song_file.Properties.Duration.Seconds + (song_file.Properties.Duration.Minutes * 60);
            //sets the starting position to the current label and the scrub bar
            song_time.Start();

            return new_song;
        }


        //pushes cure song to the front of queue, make curr song the pop of the stack 
        public void play_prev_song() 
        {
            if( repeat_type == Repeat_Type.Repeat_One)
            {
                if (curr_song != null)
                {
                    play_song(song_map[curr_song]);
                }
            }
            if (repeat_type == Repeat_Type.Repeat_All)
            {
                if(queue.Count() != 0)
                {
                    prev_songs.Push(queue.Pop_Back());
                }
            }
            if (prev_songs.Count != 0)
            {
                //prevCurrentAlbumDisplay();
                string removed = prev_songs.Pop();
                play_song(song_map[removed]);

                queue.Push_Front(curr_song);
                curr_song = removed;
                currentAlbumDisplay();
                //sets the URL for the player as the file path
                //plays the file that is currently set as the URL
            }
        }

        public int getAlbums(string folder_path)
        {
            int num_songs = 0;
            string[] albums = Directory.GetDirectories(@folder_path);
            foreach (string s in albums)
            {
                num_songs += getSongs(s);
                num_songs += getAlbums(s);
            }
            return num_songs;
        }

        public int getSongs(string folder_path)
        {
            int song_num = 0;
            string[] songs = Directory.GetFiles(@folder_path, "*.mp3");
            foreach (string s in songs)
            {
                try
                {
                    TagLib.File file = TagLib.File.Create(s);

                    add_new_song(s);
                    song_num++;
                }
                catch (TagLib.CorruptFileException e)
                {
                    MessageBox.Show(s + "is corrupt");
                }
            }
            return song_num;
        }


        //adds a song to the maps 
        public void add_new_song(string path)
        {
            try
            {
                TagLib.File file = TagLib.File.Create(path);
                try
                {
                    if (!song_map.ContainsKey(getSongName(file))) //if not in map add it
                    {
                        song_map.Add(getSongName(file), path);
                    }
                    else
                    {
                         song_map[getSongName(file)] = path;      //if in map make update its url to the new one
                    }
                }
                catch (ArgumentNullException e)
                {
                    /*
                    file.Tag.Title = "Unknown Song" + songctr++.ToString();
                    if (!song_map.ContainsKey(path)) //if not in map add it
                    {
                        song_map.Add(path, path);
                    }
                    else
                    {
                        song_map[path] = path;      //if in map make update its url to the new one
                    }
                    */
                    return;

                }


                try
                {
                    if (!album_map.ContainsKey(getAlbumName(file))) //if album not in map, make that key and assign it to a new list containing added song
                    {
                        List<string> new_list = new List<string>();
                        new_list.Add(path);
                        album_map.Add(getAlbumName(file), new_list);
                        Store_AlbumArtwork(file);   // Add image artwork to image list
                    }
                    else
                    {
                        album_map[file.Tag.Album].Add(path);   //if album already in map, add song to the assigned list
                    }
                }
                catch (ArgumentNullException ex)
                {
                    //code specifically for a ArgumentNullException
                    if (!album_map.ContainsKey("Unknown Album")) //if album not in map, make that key and assign it to a new list containing added song
                    {
                        List<string> new_list = new List<string>();
                        new_list.Add(path);
                        album_map.Add("Unknown Album", new_list);
                        Store_AlbumArtwork(file);   // Add image artwork to image list
                    }
                    else
                    {
                        album_map["Unknown Album"].Add(path);   //if album already in map, add song to the assigned list
                    }
                }
                try
                {
                    foreach (string art in file.Tag.Performers)
                    {

                        if (!artist_map.ContainsKey(art))
                        {
                            List<string> new_list = new List<string>();
                            new_list.Add(path);
                            artist_map.Add(art, new_list);
                        }
                        else
                        {
                            artist_map[art].Add(path);
                        }
                    }
                }
                catch (ArgumentNullException ex)
                {
                    //code specifically for a ArgumentNullException
                    /* if (!artist_map.ContainsKey("Unknown Artist"))
                     {
                         List<string> new_list = new List<string>();
                         new_list.Add(path);
                         artist_map.Add("Unknown Artist", new_list);
                     }
                     else
                     {
                         artist_map["Unknown Artist"].Add(path);
                     }*/

                }
            }
            catch (TagLib.CorruptFileException e)
            {

            }
        }


        //method that gets album artwork of file
        public void Store_AlbumArtwork(TagLib.File file)
        {
            try
            {
                MemoryStream ms = new MemoryStream(file.Tag.Pictures[0].Data.Data);
                System.Drawing.Image artwork = System.Drawing.Image.FromStream(ms);
                Artwork_List.ImageSize = new Size(200, 200);
                Artwork_List.Images.Add(artwork);
            }
            catch (ArgumentNullException ex)
            {
                //code specifically for a ArgumentNullException
                Artwork_List.Images.Add(Resources.bear_pirate);
            }
            catch (IndexOutOfRangeException ex)
            {
                //code specifically for a IndexOutOfRangeException
                Artwork_List.Images.Add(Resources.bear_pirate);
            }
        }
        
        //gets song name of file
        public string getSongName(TagLib.File file)
        {
            return file.Tag.Title;
        }

        //gets the album name
        public string getAlbumName(TagLib.File file)
        {
            return file.Tag.Album;
        }
        
        //gets the album artist
        public string getAlbumArtist(TagLib.File file)
        {
            return file.Tag.FirstAlbumArtist;
        }
        
        //displays album during playback
        public void currentAlbumDisplay()
        {
            string curr = curr_song;
            if (song_map.ContainsKey(curr))
            {
                TagLib.File file = TagLib.File.Create(song_map[curr]);
                try
                {
                    MemoryStream ms = new MemoryStream(file.Tag.Pictures[0].Data.Data);
                    System.Drawing.Image artwork = System.Drawing.Image.FromStream(ms);
                    pictureBox1.Image = artwork;
                }
                catch (IndexOutOfRangeException e)
                {
                    pictureBox1.Image = Resources.bear_pirate;
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                artistLabel.Text = file.Tag.Performers[0];
                titleLabel.Text = file.Tag.Title;
                curAlbumLabel.Text = file.Tag.Album;
            }
        }
                

        //updates whatever list box is currently being viewed with the current map information 
        public void update_list_disp()
        {
            curr_list_box.SelectedIndexChanged += new EventHandler(song_list_ItemActivate);  //this works for some reason,please leave in here
            curr_list_box.Items.Clear();

            // Artist Display 
            if (curr_view == view.Artists)
            {
                foreach (string s in artist_map.Keys)
                {
                    curr_list_box.Items.Add(s);
                }
            }

            // Album Display
            else if (curr_view == view.Albums)
            {
                int album_count = 0;
                foreach (string s in album_map.Keys)
                {
                    string temp = album_map[s][0];
                    TagLib.File file = TagLib.File.Create(temp);

                    Album_List.View = View.LargeIcon;
                    Album_List.LargeImageList = Artwork_List;
                    
                    Album_List.Items.Add(new ListViewItem { ImageIndex = album_count, Text = getAlbumName(file) + "\n" + getAlbumArtist(file) });
                    ++album_count;
                }
            }

            // Song Display
            else if (curr_view == view.Songs)
            {
                foreach (string s in song_map.Keys)
                {
                    TagLib.File file = TagLib.File.Create(song_map[s]);
                    curr_list_box.Items.Add(List_Column_Info(ref file));   // Fill row with song tag information
                }
            }

            // Queue Display
            else if (curr_view == view.Queue)
            {
                int size = queue.Count();
                // Parse through every element in the queue
                for (int i = 0; i < size; ++i)
                {
                    string dequeue = queue.ElementAt(i);   // Retrieve each element in queue
                    if (song_map.ContainsKey(dequeue))
                    {
                        TagLib.File file = TagLib.File.Create(song_map[dequeue]);   // Map song in queue to file address
                        curr_list_box.Items.Add(List_Column_Info(ref file));    // Fill row with song tag information
                    }
                }
            }
            // Artist Song Display
            else if (curr_view == view.Artist_Song)
            {
                List<string> song_list = artist_map[selected_artist];
                foreach (string s in song_list)
                {
                    TagLib.File file = TagLib.File.Create(s);
                    curr_list_box.Items.Add(List_Column_Info(ref file));   // Fill row with song tag information   
                }
            }
            // Album Song Display
            else if (curr_view == view.Album_Song)
            {
                List<string> song_list = album_map[selected_album];
                foreach (string s in song_list)
                {
                    TagLib.File file = TagLib.File.Create(s);
                    curr_list_box.Items.Add(List_Column_Info(ref file));   // Fill row with song tag information   
                }
            }

            // Playlist List Display
            else if (curr_view == view.Playlists)
            {
                foreach(string name in Playlist_Names)
                { 
                    curr_list_box.Items.Add(name);
                }
            }

            // Playlist Song Display
            else if (curr_view == view.Playlists_Song)
            {
                if (File.Exists(playlist_loc + curr_playlist + ".txt"))
                {
                    string[] lines = System.IO.File.ReadAllLines(playlist_loc + curr_playlist + ".txt");
                    foreach (string line in lines)
                    {
                        TagLib.File file = TagLib.File.Create(line);
                        curr_list_box.Items.Add(List_Column_Info(ref file));   // Fill row with song tag information
                    }
                }
                
            }

            // Seach Display
            else if (curr_view == view.Search)
            {
                HashSet<string> song_set = new HashSet<string>();
                foreach (string s in song_map.Keys)
                {
                    if (s.ToUpper().Contains(search_entry))
                    {
                        song_set.Add(song_map[s]);
                    }
                }
                foreach (string s in album_map.Keys)
                {
                    if (s.ToUpper().Contains(search_entry))
                    {
                        foreach (string song in album_map[s])
                        {
                            song_set.Add(song);
                        }
                    }
                }
                foreach (string s in artist_map.Keys)
                {
                    if (s.ToUpper().Contains(search_entry))
                    {
                        foreach (string song in artist_map[s])
                        {
                            song_set.Add(song);
                        }
                    }
                }

                if (song_set.Count == 0)
                {
                    curr_list_box.Items.Add("No results found");
                    found = false;
                }
                else
                {
                    found = true;
                    foreach (string found in song_set)
                    {
                        TagLib.File file = TagLib.File.Create(found);
                        curr_list_box.Items.Add(List_Column_Info(ref file));   // Fill row with song tag information   
                    }
                }
            }
            
            // Change back color of every list except for albums
            if(!curr_view.ToString().Equals("Albums"))
                for (int i = 1; i <= curr_list_box.Items.Count-1; i = (i + 2))
                    curr_list_box.Items[i].BackColor = Color.Gainsboro;    // Loop through every element in the list and alternate background colors

        }


        // Method to retrieve the title, album, artist, and duration information from a song, and add it to a list row
        public ListViewItem List_Column_Info(ref TagLib.File file)
        {
            // Create new entry into list table
            ListViewItem item = new ListViewItem();
            item.Text =getSongName(file);   // Add title 
            item.SubItems.Add(getAlbumName(file));   // Add album
            item.SubItems.Add(file.Tag.FirstPerformer);   // Add artist

            // Parse minutes and seconds together for duration
            string duration = file.Properties.Duration.Minutes.ToString();
            string seconds = ":" + file.Properties.Duration.Seconds.ToString();

            // If seconds is less than 10, add an additional 0 in front
            if (file.Properties.Duration.Seconds < 10)
                seconds = ":0" + file.Properties.Duration.Seconds.ToString();

            duration = duration + seconds;
            item.SubItems.Add(duration);   // Add time

            return item;
        }


        public void list_item_selected()
        {
            if (curr_list_box.SelectedIndices.Count <= 0) return;
            int i = curr_list_box.SelectedIndices[0];
            if (i >= 0 && i < curr_list_box.Items.Count)
            {
                if( shuffle )
                {
                    fill_shuffled_queue(curr_list_box.Items[i].Text.ToString());
                }
                else
                {
                    fill_unshuffled_queue(curr_list_box.Items[i].Text.ToString());
                }
            }
        }


        public void fill_shuffled_queue(string start_name)
        {
            queue.Clear();
            prev_songs.Clear();
            curr_song = null;
            bool found = false;

            queue.Push_Back(start_name);

            List<string> songs_arr = new List<string>();
            for (int i = 0; i < curr_list_box.Items.Count; ++i)
            {
                if (!curr_list_box.Items[i].Text.ToString().Equals(start_name))
                {
                    songs_arr.Add(curr_list_box.Items[i].Text.ToString());
                }
            }

            for (int i = songs_arr.Count - 1; i > 0; i--)
            {
                Random ran = new Random();
                int j = ran.Next() % (i + 1);
                string temp = songs_arr[i];
                songs_arr[i] = songs_arr[j];
                songs_arr[j] = temp;
            }

            foreach( string s in songs_arr)
            {
                queue.Push_Back(s);
            }
        }


        //fills queue with selected song and all following songs, takes a song name
        public void fill_unshuffled_queue(string start_name)
        {
            queue.Clear();
            prev_songs.Clear();
            curr_song = null;
            bool found = false;
            Dequeue temp_deq = new Dequeue();

            for (int i = 0; i < curr_list_box.Items.Count; ++i)
            {
                string s = curr_list_box.Items[i].Text.ToString();
                if (s.Equals(start_name))
                {
                    found = true;
                    queue.Push_Back(s);
                }
                else if (found)
                {
                    queue.Push_Back(s);
                }
                else
                {
                    temp_deq.Push_Front(s);
                }
            }
            if (repeat_type == Repeat_Type.Repeat_All)
            {
                int c = temp_deq.Count();
                for (int i = 0; i < c; i++)
                {
                    queue.Push_Back(temp_deq.Pop_Back());
                }
            }
            else
            {
                int c = temp_deq.Count();
                for (int i = 0; i < c; i++)
                {
                    prev_songs.Push(temp_deq.Pop_Back());
                }

            }
        }


        // Backend function for adding a new playlist to the program. It inputs the name of the new playlist to be created
        public bool Add_New_Playlist(string new_playlist)
        {
            // Check thruogh list of playlist names to see if name already exists
            foreach (string s in Playlist_Names)
                if (s.Equals(new_playlist))
                {
                    MessageBox.Show("Error - playlist already exists");
                    return false;
                }

            Playlist_Names.Add(new_playlist);   // Add new name to playlist list

            create_playlist_node(new_playlist);

            //add playlist as text file
            using (StreamWriter w = File.CreateText(playlist_loc + new_playlist + ".txt"))

            //add playlist name to playlist text file
            using (var tw = new StreamWriter(playlist_file_loc, true))
            {
                tw.WriteLine(new_playlist);
                tw.Close();
            }
            update_list_disp();
            return true;
        }
        
        //adds node for a playlist to the sidebar
        public void create_playlist_node(string name)
        {
            if (added_nodes.Contains(name))
            {
                return;
            }
            else
            {
                added_nodes.Add(name);
            }
            // Create new node for side bar
            TreeNode child = new TreeNode();
            child.Text = name;
            child.Name = name;
            child.NodeFont = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            // Find Playlists branch in side bar
            TreeNode[] nodes = SideBar.Nodes.Find("Playlists", false);
            nodes[0].Nodes.Add(child);   // Add new playlist name under Playlist branch

            //add to playlist to menu bar
            ToolStripItem subItem = new ToolStripMenuItem(name);
            addToPlaylistToolStripMenuItem.DropDownItems.Add(subItem);
            subItem.Click += new EventHandler(addToPlaylist);
                
            addToPlaylistCM.MenuItems.Add(name, new EventHandler(add_to_playlist_right_click));
            
        }

        public void delete_playlist_nodes()
        {
            TreeNode[] nodes = SideBar.Nodes.Find("Playlists", false);
            int side_nodes = nodes[0].Nodes.Count;
            for ( int i = 1; i < side_nodes; i++)
            {
                nodes[0].Nodes.RemoveAt(1);
            }
            addToPlaylistToolStripMenuItem.DropDownItems.Clear();
            addToPlaylistCM.MenuItems.Clear();
            added_nodes.Clear();
        }
        
        //Add songs to playlist
        public void addSongToPlaylist(string fileName, string playListName) //takes in the file name of the song
        {
            if(fileName != null) //make sure user has a song selected
            {
                try //make sure the song still exists in map
                {
                    string songUrl = song_map[fileName];
                    Console.WriteLine(songUrl);
                    if (File.Exists(playlist_loc + playListName + ".txt"))
                    {
                        using (var tw = new StreamWriter(playlist_loc + playListName + ".txt", true))
                        {
                            tw.WriteLine(songUrl);
                            tw.Close();
                        }
                    }
                    else
                    {
                        StreamWriter sw = new StreamWriter(playlist_loc + playListName + ".txt");
                        sw.WriteLine(songUrl);
                        sw.Close();
                    }
                }
                catch (System.Collections.Generic.KeyNotFoundException)
                {
                    MessageBox.Show("File does not Exist");
                }
            }
            else
            {
                //ingore
            }
        }

        private void song_list_ItemActivate(Object sender, EventArgs e)
        {
            if (curr_list_box.SelectedIndices.Count <= 0) return;
            int i = curr_list_box.SelectedIndices[0];
            songName = curr_list_box.Items[i].Text.ToString();
            //songName = curr_list_box.SelectedItems.ToString();
            Console.WriteLine(songName);
            bear_logo.Image = Resources.bear_headphone;
            this.bear_logo.Height = 169;
            bear_logo.Location = new Point(27, 261);
        }

        // Method for changing display to artist view
        public void Change_ArtistView()
        {
            View_Label.Text = "Artists";
            
            Artist_View.Visible = true;
            Albums_View.Visible = false;
            Album_Song_View.Visible = false;
            Songs_View.Visible = false;
            Playlists_View.Visible = false;
            Search_View.Visible = false;
            Artist_Song_View.Visible = false;
            Queue_View.Visible = false;
            NewPlaylist_Panel.Visible = false;
            Playlist_Song_Panel.Visible = false;
            Options_Panel.Visible = false;

            BackButton.Visible = false;   // Remove back button

            curr_view = view.Artists;
            curr_list_box = Artist_List;   // Change to artist list box

            update_list_disp();
        }

        // Method for changing display to album view
        public void Change_AlbumView()
        {
            View_Label.Text = "Albums";

            Artist_View.Visible = false;
            Albums_View.Visible = true;
            Album_Song_View.Visible = false;
            Songs_View.Visible = false;
            Playlists_View.Visible = false;
            Search_View.Visible = false;
            Artist_Song_View.Visible = false;
            Queue_View.Visible = false;
            NewPlaylist_Panel.Visible = false;
            Playlist_Song_Panel.Visible = false;
            Options_Panel.Visible = false;

            BackButton.Visible = false;   // Remove back button

            curr_view = view.Albums;
            curr_list_box = Album_List;  // Change to album list box

            update_list_disp();
        }

        // Method for changing display to song view
        public void Change_SongView()
        {
            // Clicking on song view
            View_Label.Text = "Songs";

            Artist_View.Visible = false;
            Albums_View.Visible = false;
            Album_Song_View.Visible = false;
            Songs_View.Visible = true;
            Search_View.Visible = false;
            Playlists_View.Visible = false;
            Artist_Song_View.Visible = false;
            Queue_View.Visible = false;
            NewPlaylist_Panel.Visible = false;
            Playlist_Song_Panel.Visible = false;
            Options_Panel.Visible = false;

            BackButton.Visible = false;   // Remove back button

            curr_view = view.Songs;
            curr_list_box = Song_List;   // Change to song list box

            update_list_disp();
        }

        // Method for changing display to queue view
        public void Change_QueueView()
        {
            View_Label.Text = "Queue";

            Artist_View.Visible = false;
            Albums_View.Visible = false;
            Songs_View.Visible = false;
            Playlists_View.Visible = false;
            Search_View.Visible = false;
            Artist_Song_View.Visible = false;
            Album_Song_View.Visible = false;
            Queue_View.Visible = true;
            NewPlaylist_Panel.Visible = false;
            Playlist_Song_Panel.Visible = false;
            Options_Panel.Visible = false;

            BackButton.Visible = false;   // Remove back button

            curr_view = view.Queue;
            curr_list_box = Queue_List;   // Change to queue list box

            update_list_disp();
        }

        // Method for changing display to playlist view
        public void Change_PlaylistView()
        {
            View_Label.Text = "Playlists";

            Artist_View.Visible = false;
            Albums_View.Visible = false;
            Album_Song_View.Visible = false;
            Songs_View.Visible = false;
            Playlists_View.Visible = true;
            Artist_Song_View.Visible = false;
            Search_View.Visible = false;
            Queue_View.Visible = false;
            NewPlaylist_Panel.Visible = false;
            Playlist_Song_Panel.Visible = false;
            Options_Panel.Visible = false;

            BackButton.Visible = false;   // Remove back button

            curr_view = view.Playlists;
            curr_list_box = Playlist_List;

            update_list_disp();
        }

        // Method for changing display to create new playlist view
        public bool Change_NewPlaylistView()
        {
            //NewPlaylist_Panel.Visible = true;

            promptValue = Prompt.ShowDialog("Please input new playlist name", "New Playlist");
            if (!promptValue.Equals(""))
            {
                if (Add_New_Playlist(promptValue) == true)
                {
                    return true;
                }
            }
            return false;

        }

        // Method for changing display to user-created playlist view. 
        public void Change_UserPlaylistView(string playlist_name)
        {
            // Searches for name in list of playlists already created
            foreach (string s in Playlist_Names)
                if (s.Equals(playlist_name))
                {
                    View_Label.Text = s;
                    curr_playlist = s;
                }

            Artist_View.Visible = false;
            Albums_View.Visible = false;
            Album_Song_View.Visible = false;
            Songs_View.Visible = false;
            Playlists_View.Visible = false;
            Artist_Song_View.Visible = false;
            Search_View.Visible = false;
            Queue_View.Visible = false;
            NewPlaylist_Panel.Visible = false;
            Playlist_Song_Panel.Visible = true;
            Options_Panel.Visible = false;

            BackButton.Visible = true;   // Place back button

            curr_view = view.Playlists_Song;
            curr_list_box = Playlist_Song_List;

            update_list_disp();
        }

        // Method for changing view to artist view
        public void Change_ArtistSongView()
        {
            Artist_View.Visible = false;
            Albums_View.Visible = false;
            Songs_View.Visible = false;
            Search_View.Visible = false;
            Playlists_View.Visible = false;
            Queue_View.Visible = false;
            Artist_Song_View.Visible = true;
            Album_Song_View.Visible = false;
            Options_Panel.Visible = false;

            BackButton.Visible = true;   // Place back button

            selected_artist = curr_list_box.SelectedItems[0].Text;
            curr_view = view.Artist_Song;
            curr_list_box = Artist_Song_List;
            SideBar.SelectedNode = null;
            update_list_disp();
        }

        // Method for changing view to album song view
        public void Change_AlbumSongView()
        {   
            Artist_View.Visible = false;
            Albums_View.Visible = false;
            Search_View.Visible = false;
            Songs_View.Visible = false;
            Playlists_View.Visible = false;
            Queue_View.Visible = false;
            Artist_Song_View.Visible = false;
            Album_Song_View.Visible = true;
            Options_Panel.Visible = false;

            BackButton.Visible = true;   // Place back button

            selected_album = curr_list_box.SelectedItems[0].Text.Split('\n')[0];
            curr_view = view.Album_Song;
            curr_list_box = Album_Song_List;
            SideBar.SelectedNode = null;
            update_list_disp();
        }

        public void Change_SearchView()
        {
            // Change to search view
            Artist_View.Visible = false;
            Albums_View.Visible = false;
            Search_View.Visible = true;
            Songs_View.Visible = false;
            Playlists_View.Visible = false;
            Queue_View.Visible = false;
            Artist_Song_View.Visible = false;
            Album_Song_View.Visible = false;
            Options_Panel.Visible = false;

            BackButton.Visible = false;   // Removed back button

            curr_view = view.Search;
            curr_list_box = Search_List;
            SideBar.SelectedNode = null;
            update_list_disp();
        }

        public void Change_OptionsView()
        {
            Artist_View.Visible = false;
            Albums_View.Visible = false;
            Search_View.Visible = false;
            Songs_View.Visible = false;
            Playlists_View.Visible = false;
            Queue_View.Visible = false;
            Artist_Song_View.Visible = false;
            Album_Song_View.Visible = false;
            Options_Panel.Visible = true;

            BackButton.Visible = false;   // Removed back button

            View_Label.Text = "Options";
        }


        public enum view { Albums, Artists, Songs, Playlists, Playlists_Song, Queue, Artist_Song, Album_Song, Search };

        public enum Repeat_Type { Off, Repeat_All, Repeat_One };


        private void sidebar_color_button_Click(object sender, EventArgs e) {
            if (sidebar_color_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                set_sidebar_color(sidebar_color_dialog.Color);

                if (user.Equals("")) return;

                string[] lines = get_all_user_lines();
                string[] users = get_all_users(lines);

                int index = 0;
                for (int i = 0; i < users.Length; i++)
                {
                    if (user.Equals(users[i]))
                    {
                        index = i * fields;
                        break;
                    }
                }
                lines[index + 1] = sidebar_color_dialog.Color.ToArgb().ToString();
                System.IO.File.WriteAllLines(user_file_loc, lines);
            }
        }
        
        private void center_color_button_Click(object sender, EventArgs e)
        {
            if (sidebar_color_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                set_center_color(sidebar_color_dialog.Color);

                if (user.Equals("")) return;

                string[] lines = get_all_user_lines();
                string[] users = get_all_users(lines);

                int index = 0;
                for (int i = 0; i < users.Length; i++)
                {
                    if (user.Equals(users[i]))
                    {
                        index = i * fields;
                        break;
                    }
                }
                lines[index + 2] = sidebar_color_dialog.Color.ToArgb().ToString();
                System.IO.File.WriteAllLines(user_file_loc, lines);
            }
        }

        private void buttom_color_button_Click(object sender, EventArgs e)
        {
            if (sidebar_color_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                set_bottom_color(sidebar_color_dialog.Color);

                if (user.Equals("")) return;

                string[] lines = get_all_user_lines();
                string[] users = get_all_users(lines);

                int index = 0;
                for (int i = 0; i < users.Length; i++)
                {
                    if (user.Equals(users[i]))
                    {
                        index = i * fields;
                        break;
                    }
                }
                lines[index + 3] = sidebar_color_dialog.Color.ToArgb().ToString();
                System.IO.File.WriteAllLines(user_file_loc, lines);
            }
        }

        private void set_sidebar_color(Color c)
        {
            SideBar.BackColor = c;
            MenuBar.BackColor = c;
            text_color = c;
            bear_logo.BackColor = c;
        }

        private void set_center_color(Color c)
        {
            Artist_View.BackColor = c;
            Albums_View.BackColor = c;
            Search_View.BackColor = c;
            Songs_View.BackColor = c;
            Playlists_View.BackColor = c;
            Queue_View.BackColor = c;
            Artist_Song_View.BackColor = c;
            Album_Song_View.BackColor = c;
            Options_Panel.BackColor = c;
            BackButton.BackColor = c;

            Album_List.BackColor = c;
            Album_Song_List.BackColor = c;
            Artist_List.BackColor = c;
            Artist_Song_List.BackColor = c;
            Playlist_List.BackColor = c;
            Playlist_Song_List.BackColor = c;
            Queue_List.BackColor = c;
            Song_List.BackColor = c;

            this.BackColor = c;
        }

        private void set_bottom_color(Color c)
        {
            bottom_panel.BackColor = c;
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool dup = true;
            string promptValue = "";
            while (dup)
            {
                promptValue = Prompt.ShowDialog("Please input new User Name", "New User");
                if (promptValue.Equals(""))
                    return;
                dup = false;
                if(File.Exists(user_file_loc))
                {
                    string[] lines = System.IO.File.ReadAllLines(user_file_loc);
                    int num_users = lines.Length / fields;
                    string[] user_names = new String[num_users];
                    for (int i = 0; i < num_users && !dup; i++)
                    {
                        if (promptValue.Equals(lines[i * fields]))
                        {
                            dup = true;
                            MessageBox.Show("User Name already taken", "Error");
                            break;
                        }
                    }
                }
            }
            create_new_user(promptValue);           
        }

        public void create_new_user( string user_name)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(user_file_loc, true))
            {
                file.WriteLine(user_name);
                file.WriteLine(default_side_color.ToArgb());
                file.WriteLine(default_center_color.ToArgb());
                file.WriteLine(default_bottom_color.ToArgb());
            }
            switch_to_user(user_name);
        }

        public string get_user()
        {
            return user;
        }

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 300,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
                TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 240, Text = "" };
                Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 80, Top = 80, DialogResult = DialogResult.OK };
                Button cancel = new Button() { Text = "Cancel", Left = 170, Width = 80, Top = 80, DialogResult = DialogResult.Cancel };
                confirmation.Click += (sender, e) => { if (textBox.Text.Equals("")) { MessageBox.Show("Not Valid Name: Empty", "Error"); }  prompt.Close();  };
                cancel.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancel);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }

        }

        public static class Yes_No_Prompt
        {
            public static bool ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 400,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
                Button confirmation = new Button() { Text = "Yes", Left = 50, Width = 80, Top = 80, DialogResult = DialogResult.OK };
                Button cancel = new Button() { Text = "Cancel", Left = 170, Width = 80, Top = 80, DialogResult = DialogResult.Cancel };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                cancel.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancel);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? true : false;
            }

        }

        public static class Radio_Prompt
        {
            static RadioButton selectedrb = null;
            public static string ShowDialog(string text, string caption, string[] options)
            {
                Form prompt = new Form()
                {
                    Width = 300,
                    Height = 300,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };

                int len = options.Length;
                prompt.Height = 150 + len * 20;
                RadioButton[] rads = new RadioButton[len];
                for (int i = 0; i < len; i++)
                {
                    rads[i] = new RadioButton() { Left = 20, Top = 50 + 20 * i, AutoSize = true, Text = options[i], Checked = false };
                    rads[i].CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
                }
                rads[0].Checked = true;
                Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 100, Top = 70 + 20 * len, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                foreach( RadioButton r in rads)
                {
                    prompt.Controls.Add(r);
                }
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? getSelectedRB() : "";
            }

            public static void RadioButton_CheckedChanged(object sender, EventArgs e)
            {
                RadioButton rb = sender as RadioButton;

                if (rb == null)
                {
                    MessageBox.Show("Sender is not a RadioButton");
                    return;
                }

                // Ensure that the RadioButton.Checked property
                // changed to true.
                if (rb.Checked)
                {
                    // Keep track of the selected RadioButton by saving a reference
                    // to it.
                    selectedrb = rb;
                }
            }

            public static string getSelectedRB()
            {
                return selectedrb.Text;
            }
        }

        public static class Tag_List
        {
            //return in order title, artist, album, genre
            public static string[] ShowDialog(TagLib.File song_file)
            {
                Form tags = new Form()
                {
                    Width = 300,
                    Height = 300,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = "Tags",
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label Title = new Label() { Left = 20, Top = 20, Text = "Title:", AutoSize = true };
                TextBox Title_text = new TextBox() { Left = 60, Top = 20, Width = 200, Text = song_file.Tag.Title, AutoSize = true };
                Label Artist = new Label() { Left = 20, Top = 60, Text = "Artist:", AutoSize = true };
                TextBox Artist_text = new TextBox() { Left = 60, Top = 60, Width = 200, Text = song_file.Tag.FirstPerformer, AutoSize = true };
                Label Album = new Label() { Left = 20, Top = 100, Text = "Album:", AutoSize = true };
                TextBox Album_text = new TextBox() { Left = 60, Top = 100, Width = 200, Text = song_file.Tag.Album, AutoSize = true };
                Label Genre = new Label() { Left = 20, Top = 140, Text = "Genre:", AutoSize = true };
                TextBox Genre_text = new TextBox() { Left = 60, Top = 140, Width = 200, Text = song_file.Tag.Genres.Length == 0 ? "" : song_file.Tag.Genres[0], AutoSize = true };
                Label Duration = new Label() { Left = 20, Top = 180, Text = "Duration: " + song_file.Properties.Duration.Minutes.ToString() + ":" + song_file.Properties.Duration.Seconds.ToString(), AutoSize = true };
                Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 80, Top = 220, DialogResult = DialogResult.OK };
                Button cancel = new Button() { Text = "Cancel", Left = 170, Width = 80, Top = 220, DialogResult = DialogResult.Cancel };
                confirmation.Click += (sender, e) => { tags.Close(); };
                cancel.Click += (sender, e) => { tags.Close(); };
                tags.Controls.Add(Title);
                tags.Controls.Add(Title_text);
                tags.Controls.Add(Album);
                tags.Controls.Add(Album_text);
                tags.Controls.Add(Artist);
                tags.Controls.Add(Artist_text);
                tags.Controls.Add(Genre);
                tags.Controls.Add(Genre_text);
                tags.Controls.Add(Duration);
                tags.Controls.Add(confirmation);
                tags.Controls.Add(cancel);
                tags.AcceptButton = confirmation;

                return tags.ShowDialog() == DialogResult.OK ? new string[] { Title_text.Text, Artist_text.Text, Album_text.Text, Genre_text.Text } : new string[] {null};
            }

        }

        private void switchUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] lines = get_all_user_lines();
            string[] user_names = get_all_users(lines);
            if( user_names.Length == 0)
            {
                MessageBox.Show("No Users", "Error");
                return;
            }
            switch_to_user(Radio_Prompt.ShowDialog("Please select a user", "User Select", user_names), lines, user_names);
        }

        public bool switch_to_user(string name, string[] all_lines, string[] all_users)
        {
            bool found = false;
            foreach( string s in all_users)
            {
                if (s.Equals(name))
                {
                    found = true;
                }
            }
            if (!found) return false;
            user = name;
            open_user_settings(all_lines, all_users);
            return true;
        }
        public bool switch_to_user(string name)
        {
            string[] lines = get_all_user_lines();
            string[] users = get_all_users(lines);
            bool found = false;
            foreach (string s in users)
            {
                if (s.Equals(name))
                {
                    found = true;
                }
            }
            if (!found) return false;
            user = name;
            open_user_settings(lines, users);
            return true;
        }


        public void open_user_settings(string[] all_lines, string[] all_users)
        {
            int index = 0;
            for( int i = 0; i < all_users.Length; i++)
            {
                if (user.Equals(all_users[i]))
                {
                    index = i * fields;
                    break;
                }
            }
            set_sidebar_color( Color.FromArgb(Int32.Parse(all_lines[index + 1]) ) );
            set_center_color(Color.FromArgb(Int32.Parse(all_lines[index + 2] )));
            set_bottom_color(Color.FromArgb(Int32.Parse(all_lines[index + 3])));
        }

        public string[] get_all_user_lines()
        {
            if (!File.Exists(user_file_loc)) return new string[0];
            return System.IO.File.ReadAllLines(user_file_loc);
        }

        public string[] get_all_users(string[] all_lines)
        {
            int num_users = all_lines.Length / fields;
            string[] user_names = new String[num_users];
            for (int i = 0; i < num_users; i++)
            {
                user_names[i] = all_lines[i * fields];
            }
            return user_names;
        }

        private void shuffle_toggle_MouseEnter(object sender, EventArgs e)
        {
            if (!shuffle)
                shuffle_toggle.Image = Resources.shuffleButtonOn;
            else
                shuffle_toggle.Image = Resources.shuffleButtonOff;
        }

        private void shuffle_toggle_MouseLeave(object sender, EventArgs e)
        {
            if (!shuffle)
                shuffle_toggle.Image = Resources.shuffleButtonOff;
            else
                shuffle_toggle.Image = Resources.shuffleButtonOn;
        }

        private void repeat_button_MouseEnter(object sender, EventArgs e)
        {
            if (repeat_type == Repeat_Type.Off)
            {
                repeat_button.Image = Resources.Repeat_All;
            }
            else if (repeat_type == Repeat_Type.Repeat_All)
            {
                repeat_button.Image = Resources.Repeat_One;
            }
            else
            {
                repeat_button.Image = Resources.Repeat;
            }
        }

        private void repeat_button_MouseLeave(object sender, EventArgs e)
        {
            if (repeat_type == Repeat_Type.Off)
            {
                repeat_button.Image = Resources.Repeat;
            }
            else if (repeat_type == Repeat_Type.Repeat_All)
            {
                repeat_button.Image = Resources.Repeat_All;
            }
            else
            {
                repeat_button.Image = Resources.Repeat_One;
            }
        }

        private void playButton_MouseEnter(object sender, EventArgs e)
        {
            if (play)
            {
                playButton.Image = Resources.playButton3;
            }
            else
            {
                playButton.Image = Resources.pauseButton2;
            }
        }

        private void playButton_MouseLeave(object sender, EventArgs e)
        {
            if (play)
            {
                playButton.Image = Resources.playButton;
            }
            else
            {
                playButton.Image = Resources.pauseButton;
            }
        }

        private void next_button_MouseEnter(object sender, EventArgs e)
        {
            next_button.Image = Resources.Next_Previous2;
        }

        private void next_button_MouseLeave(object sender, EventArgs e)
        {
            next_button.Image = Resources.Next_Previous;
        }

        private void previous_button_MouseEnter(object sender, EventArgs e)
        {
            previous_button.Image = Resources.Previous_Button2;
        }

        private void previous_button_MouseLeave(object sender, EventArgs e)
        {
            previous_button.Image = Resources.Previous_Button;
        }
        
        public void clear_users()
        {
            System.IO.File.Delete(user_file_loc);
        }
        
    
        private void BackButton_MouseEnter(object sender, EventArgs e)
        {
            BackButton.Image = Resources.BackButtonHover;
        }

        private void BackButton_MouseLeave(object sender, EventArgs e)
        {
            BackButton.Image = Resources.BackButton;
        }

        private void Song_List_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (curr_list_box.Items.Count > 0)
                {
                    Point point = curr_list_box.PointToClient(Cursor.Position);
                    ListViewItem item = curr_list_box.GetItemAt(point.X, point.Y);
                    int size = item.Index;
                    int size1 = curr_list_box.Items.Count;
                    if (item.Index < curr_list_box.Items.Count)
                        item.BackColor = Color.Aqua;
                }
            }
            catch (Exception ex) { }
        }

        private void Song_List_MouseLeave(object sender, EventArgs e)
        {
            // Change back color of every list except for albums
            if (!curr_view.ToString().Equals("Albums"))
                for (int i = 0; i <= curr_list_box.Items.Count - 1; ++i)
                {
                    if (i % 2 == 0)
                        curr_list_box.Items[i].BackColor = Color.White;
                    else
                        curr_list_box.Items[i].BackColor = Color.Gainsboro;    // Loop through every element in the list and alternate background colors
                }


        }

        private void Playlist_Song_List_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //MessageBox.Show("Right click");
                Playlist_Song_List.ContextMenu = cm;
            }
        }

        private void Playlist_Song_List_DoubleClick(object sender, EventArgs e)
        {
            list_item_selected();
            play_next_song();
        }

        private void delete_playlists_Click(object sender, EventArgs e)
        {
            if ( !Yes_No_Prompt.ShowDialog( "Are you sure you'd like to delete all playlists? Cannot be undone.", "Warning")) return;
            foreach (string s in Playlist_Names)
            {
                System.IO.File.Delete(playlist_loc + s + ".txt" );
            }
            Playlist_Names.Clear();
            System.IO.File.Delete(playlist_file_loc);
            delete_playlist_nodes();
        }

        private void delete_users_button_Click(object sender, EventArgs e)
        {
            if (!Yes_No_Prompt.ShowDialog("Are you sure you'd like to delete all users? Cannot be undone.", "Warning")) return;
            clear_users();
        }

        private void delete_folder_paths_button_Click(object sender, EventArgs e)
        {
            if (!Yes_No_Prompt.ShowDialog("Are you sure you'd like to delete all saved folder paths? Cannot be undone.", "Warning")) return;
            System.IO.File.Delete(folder_path_file_loc);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //dequeue for queue
        public class Dequeue
        {
            private List<string> dequeue;
            public Dequeue()
            {
                dequeue = new List<string>();
            }

            public int Count()
            {
                return dequeue.Count;
            }

            public void Push_Front(string s)
            {
                dequeue.Insert(0, s);
            }

            public string Pop_Front()
            {
                if (this.Count() > 0)
                {
                    string ret = dequeue[0];
                    dequeue.RemoveAt(0);
                    return ret;
                }
                else
                    return null;
            }
            public string view_Top()
            {
                return (this.Count() > 0 ? dequeue[0] : null);
            }
            public void Push_Back(string s)
            {
                dequeue.Add(s);
            }

            public string Pop_Back()
            {
                if (this.Count() > 0)
                {
                    string ret = dequeue[dequeue.Count - 1];
                    dequeue.RemoveAt(dequeue.Count - 1);
                    return ret;
                }
                else
                    return null;
            }

            public void Clear()
            {
                dequeue.Clear();
            }

            public string ElementAt(int i)
            {
                if (this.Count() > 0 && i < this.Count() && i >= 0)
                    return dequeue.ElementAt(i);
                else
                    return null;
            }

            public void Remove_Element(string s)
            {
                dequeue.Remove(s);
            }

            public string[] ToArray()
            {
                return dequeue.ToArray();
            }
        }
    }
}
