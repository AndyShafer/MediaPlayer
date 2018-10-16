namespace BearPlayer
{
    partial class Bear_Player
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Drawing.Color text_color = System.Drawing.Color.Red;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Artists");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Albums");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Songs");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Queue");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("New Playlist");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Playlists", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bear_Player));
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artistViewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.albumViewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.songViewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.queueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.playbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scrubForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scrubBackwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.shuffleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noRepeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repeatOneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repeatAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.volumeUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volumeDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SideBar = new System.Windows.Forms.TreeView();
            this.searchBar = new System.Windows.Forms.TextBox();
            this.volumeSlider = new System.Windows.Forms.TrackBar();
            this.scrubBar = new System.Windows.Forms.TrackBar();
            this.Albums_View = new System.Windows.Forms.FlowLayoutPanel();
            this.Album_List = new System.Windows.Forms.ListView();
            this.Artwork_List = new System.Windows.Forms.ImageList(this.components);
            this.Songs_View = new System.Windows.Forms.FlowLayoutPanel();
            this.Song_List = new System.Windows.Forms.ListView();
            this.TitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AlbumColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArtistColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LengthColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Queue_View = new System.Windows.Forms.FlowLayoutPanel();
            this.Queue_List = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Playlists_View = new System.Windows.Forms.FlowLayoutPanel();
            this.Playlist_List = new System.Windows.Forms.ListView();
            this.PlaylistList = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Current_position_label = new System.Windows.Forms.Label();
            this.Song_length_label = new System.Windows.Forms.Label();
            this.Artist_View = new System.Windows.Forms.FlowLayoutPanel();
            this.Artist_List = new System.Windows.Forms.ListView();
            this.ArtistList = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Artist_Song_List = new System.Windows.Forms.ListView();
            this.ArtistList_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArtistList_Album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArtistList_Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArtistList_Duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.artistLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.curAlbumLabel = new System.Windows.Forms.Label();
            this.Artist_Song_View = new System.Windows.Forms.FlowLayoutPanel();
            this.Album_Song_View = new System.Windows.Forms.FlowLayoutPanel();
            this.Album_Song_List = new System.Windows.Forms.ListView();
            this.AlbumSong_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AlbumSong_Album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AlbumSong_Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AlbumSong_Duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Search_View = new System.Windows.Forms.FlowLayoutPanel();
            this.Search_List = new System.Windows.Forms.ListView();
            this.SearchTitleColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SearchArtistColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SearchAlbumColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SearchDurationColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NewPlaylist_Panel = new System.Windows.Forms.Panel();
            this.NewPlaylist_Label = new System.Windows.Forms.Label();
            this.NewPlaylist_CancelButton = new System.Windows.Forms.Button();
            this.NewPlaylist_EnterButton = new System.Windows.Forms.Button();
            this.NewPlaylist_TextBox = new System.Windows.Forms.TextBox();
            this.sidebar_color_dialog = new System.Windows.Forms.ColorDialog();
            this.bottom_panel = new System.Windows.Forms.Panel();
            this.Options_Panel = new System.Windows.Forms.Panel();
            this.delete_folder_paths_button = new System.Windows.Forms.Button();
            this.delete_users_button = new System.Windows.Forms.Button();
            this.delete_playlists = new System.Windows.Forms.Button();
            this.Bottom_Color_Select = new System.Windows.Forms.Button();
            this.Center_Color_Select = new System.Windows.Forms.Button();
            this.Sidebar_Color_Button = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.View_Label = new System.Windows.Forms.Label();
            this.Playlist_Song_Panel = new System.Windows.Forms.FlowLayoutPanel();
            this.Playlist_Song_List = new System.Windows.Forms.ListView();
            this.Playlist_Song_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Playlist_Song_Album = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Playlist_Song_Artist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Playlist_Song_Length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BackButton = new System.Windows.Forms.PictureBox();
            this.bear_logo = new System.Windows.Forms.PictureBox();
            this.shuffle_toggle = new System.Windows.Forms.PictureBox();
            this.playButton = new System.Windows.Forms.PictureBox();
            this.repeat_button = new System.Windows.Forms.PictureBox();
            this.next_button = new System.Windows.Forms.PictureBox();
            this.previous_button = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.MenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrubBar)).BeginInit();
            this.Albums_View.SuspendLayout();
            this.Songs_View.SuspendLayout();
            this.Queue_View.SuspendLayout();
            this.Playlists_View.SuspendLayout();
            this.Artist_View.SuspendLayout();
            this.Artist_Song_View.SuspendLayout();
            this.Album_Song_View.SuspendLayout();
            this.Search_View.SuspendLayout();
            this.NewPlaylist_Panel.SuspendLayout();
            this.bottom_panel.SuspendLayout();
            this.Options_Panel.SuspendLayout();
            this.Playlist_Song_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bear_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shuffle_toggle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeat_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.next_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previous_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.BackColor = System.Drawing.Color.DodgerBlue;
            this.MenuBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MenuBar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.playbackToolStripMenuItem,
            this.accountToolStripMenuItem});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(1048, 25);
            this.MenuBar.TabIndex = 0;
            this.MenuBar.Text = "MenuBar";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPlaylistToolStripMenuItem,
            this.addToPlaylistToolStripMenuItem,
            this.toolStripSeparator3,
            this.importToolStripMenuItem,
            this.importSongToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newPlaylistToolStripMenuItem
            // 
            this.newPlaylistToolStripMenuItem.Name = "newPlaylistToolStripMenuItem";
            this.newPlaylistToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.newPlaylistToolStripMenuItem.Text = "New Playlist";
            this.newPlaylistToolStripMenuItem.Click += new System.EventHandler(this.newPlaylistToolStripMenuItem_Click);
            // 
            // addToPlaylistToolStripMenuItem
            // 
            this.addToPlaylistToolStripMenuItem.Name = "addToPlaylistToolStripMenuItem";
            this.addToPlaylistToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addToPlaylistToolStripMenuItem.Text = "Add to Playlist";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.importToolStripMenuItem.Text = "Import Folder";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // importSongToolStripMenuItem
            // 
            this.importSongToolStripMenuItem.Name = "importSongToolStripMenuItem";
            this.importSongToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.importSongToolStripMenuItem.Text = "Import Song";
            this.importSongToolStripMenuItem.Click += new System.EventHandler(this.importSongToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.changeAppearanceToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.artistViewToolStripMenuItem1,
            this.albumViewToolStripMenuItem1,
            this.songViewToolStripMenuItem1,
            this.queueToolStripMenuItem1,
            this.playlistsToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // artistViewToolStripMenuItem1
            // 
            this.artistViewToolStripMenuItem1.Name = "artistViewToolStripMenuItem1";
            this.artistViewToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.artistViewToolStripMenuItem1.Text = "Artist View";
            this.artistViewToolStripMenuItem1.Click += new System.EventHandler(this.ArtistViewToolStripMenuItem_Click);
            // 
            // albumViewToolStripMenuItem1
            // 
            this.albumViewToolStripMenuItem1.Name = "albumViewToolStripMenuItem1";
            this.albumViewToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.albumViewToolStripMenuItem1.Text = "Album View";
            this.albumViewToolStripMenuItem1.Click += new System.EventHandler(this.albumViewToolStripMenuItem_Click);
            // 
            // songViewToolStripMenuItem1
            // 
            this.songViewToolStripMenuItem1.Name = "songViewToolStripMenuItem1";
            this.songViewToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.songViewToolStripMenuItem1.Text = "Song View";
            this.songViewToolStripMenuItem1.Click += new System.EventHandler(this.songViewToolStripMenuItem_Click);
            // 
            // queueToolStripMenuItem1
            // 
            this.queueToolStripMenuItem1.Name = "queueToolStripMenuItem1";
            this.queueToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.queueToolStripMenuItem1.Text = "Queue";
            this.queueToolStripMenuItem1.Click += new System.EventHandler(this.QueueToolStripMenuItem_Click);
            // 
            // playlistsToolStripMenuItem1
            // 
            this.playlistsToolStripMenuItem1.Name = "playlistsToolStripMenuItem1";
            this.playlistsToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.playlistsToolStripMenuItem1.Text = "Playlists";
            this.playlistsToolStripMenuItem1.Click += new System.EventHandler(this.PlaylistViewToolStripMenuItem_Click);
            // 
            // playbackToolStripMenuItem
            // 
            this.playbackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextToolStripMenuItem,
            this.previousToolStripMenuItem,
            this.scrubForwardToolStripMenuItem,
            this.scrubBackwardToolStripMenuItem,
            this.toolStripSeparator1,
            this.shuffleToolStripMenuItem,
            this.repeatToolStripMenuItem,
            this.toolStripSeparator2,
            this.volumeUpToolStripMenuItem,
            this.volumeDownToolStripMenuItem});
            this.playbackToolStripMenuItem.Name = "playbackToolStripMenuItem";
            this.playbackToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.playbackToolStripMenuItem.Text = "Playback";
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.nextToolStripMenuItem.Text = "Next";
            this.nextToolStripMenuItem.Click += new System.EventHandler(this.nextToolStripMenuItem_Click);
            // 
            // previousToolStripMenuItem
            // 
            this.previousToolStripMenuItem.Name = "previousToolStripMenuItem";
            this.previousToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.previousToolStripMenuItem.Text = "Previous";
            this.previousToolStripMenuItem.Click += new System.EventHandler(this.previousToolStripMenuItem_Click);
            // 
            // scrubForwardToolStripMenuItem
            // 
            this.scrubForwardToolStripMenuItem.Name = "scrubForwardToolStripMenuItem";
            this.scrubForwardToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.scrubForwardToolStripMenuItem.Text = "Scrub Forward";
            this.scrubForwardToolStripMenuItem.Click += new System.EventHandler(this.scrubForwardToolStripMenuItem_Click);
            // 
            // scrubBackwardToolStripMenuItem
            // 
            this.scrubBackwardToolStripMenuItem.Name = "scrubBackwardToolStripMenuItem";
            this.scrubBackwardToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.scrubBackwardToolStripMenuItem.Text = "Scrub Backward";
            this.scrubBackwardToolStripMenuItem.Click += new System.EventHandler(this.scrubBackwardToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // shuffleToolStripMenuItem
            // 
            this.shuffleToolStripMenuItem.Name = "shuffleToolStripMenuItem";
            this.shuffleToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.shuffleToolStripMenuItem.Text = "Shuffle";
            this.shuffleToolStripMenuItem.Click += new System.EventHandler(this.shuffleToolStripMenuItem_Click);
            // 
            // repeatToolStripMenuItem
            // 
            this.repeatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noRepeatToolStripMenuItem,
            this.repeatOneToolStripMenuItem,
            this.repeatAllToolStripMenuItem});
            this.repeatToolStripMenuItem.Name = "repeatToolStripMenuItem";
            this.repeatToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.repeatToolStripMenuItem.Text = "Repeat";
            // 
            // noRepeatToolStripMenuItem
            // 
            this.noRepeatToolStripMenuItem.Name = "noRepeatToolStripMenuItem";
            this.noRepeatToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.noRepeatToolStripMenuItem.Text = "No Repeat";
            this.noRepeatToolStripMenuItem.Click += new System.EventHandler(this.noRepeatToolStripMenuItem_Click);
            // 
            // repeatOneToolStripMenuItem
            // 
            this.repeatOneToolStripMenuItem.Name = "repeatOneToolStripMenuItem";
            this.repeatOneToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.repeatOneToolStripMenuItem.Text = "Repeat One";
            this.repeatOneToolStripMenuItem.Click += new System.EventHandler(this.repeatOneToolStripMenuItem_Click);
            // 
            // repeatAllToolStripMenuItem
            // 
            this.repeatAllToolStripMenuItem.Name = "repeatAllToolStripMenuItem";
            this.repeatAllToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.repeatAllToolStripMenuItem.Text = "Repeat All";
            this.repeatAllToolStripMenuItem.Click += new System.EventHandler(this.repeatAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // volumeUpToolStripMenuItem
            // 
            this.volumeUpToolStripMenuItem.Name = "volumeUpToolStripMenuItem";
            this.volumeUpToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.volumeUpToolStripMenuItem.Text = "Volume Up ";
            this.volumeUpToolStripMenuItem.Click += new System.EventHandler(this.volumeUpToolStripMenuItem_Click);
            // 
            // volumeDownToolStripMenuItem
            // 
            this.volumeDownToolStripMenuItem.Name = "volumeDownToolStripMenuItem";
            this.volumeDownToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.volumeDownToolStripMenuItem.Text = "Volume Down";
            this.volumeDownToolStripMenuItem.Click += new System.EventHandler(this.volumeDownToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchUserToolStripMenuItem,
            this.createUserToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // switchUserToolStripMenuItem
            // 
            this.switchUserToolStripMenuItem.Name = "switchUserToolStripMenuItem";
            this.switchUserToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.switchUserToolStripMenuItem.Text = "Switch User";
            this.switchUserToolStripMenuItem.Click += new System.EventHandler(this.switchUserToolStripMenuItem_Click);
            // 
            // createUserToolStripMenuItem
            // 
            this.createUserToolStripMenuItem.Name = "createUserToolStripMenuItem";
            this.createUserToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.createUserToolStripMenuItem.Text = "Create User";
            this.createUserToolStripMenuItem.Click += new System.EventHandler(this.createUserToolStripMenuItem_Click);
            // 
            // SideBar
            // 
            this.SideBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SideBar.BackColor = System.Drawing.Color.DodgerBlue;
            this.SideBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SideBar.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.SideBar.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SideBar.HotTracking = true;
            this.SideBar.Indent = 7;
            this.SideBar.ItemHeight = 30;
            this.SideBar.Location = new System.Drawing.Point(0, 25);
            this.SideBar.Name = "SideBar";
            treeNode1.Name = "Artists";
            treeNode1.NodeFont = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.Text = "Artists";
            treeNode2.Name = "Albums";
            treeNode2.NodeFont = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode2.Text = "Albums";
            treeNode3.Name = "Songs";
            treeNode3.NodeFont = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode3.Text = "Songs";
            treeNode4.Name = "Queue";
            treeNode4.NodeFont = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode4.Text = "Queue";
            treeNode5.Name = "New Playlist";
            treeNode5.NodeFont = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode5.Text = "New Playlist";
            treeNode6.Name = "Playlists";
            treeNode6.NodeFont = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode6.Text = "Playlists";
            this.SideBar.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode6});
            this.SideBar.PathSeparator = "";
            this.SideBar.ShowLines = false;
            this.SideBar.ShowPlusMinus = false;
            this.SideBar.Size = new System.Drawing.Size(193, 411);
            this.SideBar.TabIndex = 1;
            this.SideBar.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.SideBar_DrawNode);
            this.SideBar.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.SideBar_MouseClick);
            // 
            // searchBar
            // 
            this.searchBar.AcceptsReturn = true;
            this.searchBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBar.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.searchBar.Location = new System.Drawing.Point(875, 28);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(161, 23);
            this.searchBar.TabIndex = 7;
            this.searchBar.Text = "Search ";
            this.searchBar.Enter += new System.EventHandler(this.searchBar_Enter);
            this.searchBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBar_KeyDown);
            this.searchBar.Leave += new System.EventHandler(this.searchBar_Leave);
            // 
            // volumeSlider
            // 
            this.volumeSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeSlider.AutoSize = false;
            this.volumeSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.volumeSlider.Location = new System.Drawing.Point(582, 71);
            this.volumeSlider.Maximum = 100;
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(195, 28);
            this.volumeSlider.SmallChange = 5;
            this.volumeSlider.TabIndex = 0;
            this.volumeSlider.TickFrequency = 0;
            this.volumeSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeSlider.Value = 25;
            this.volumeSlider.Scroll += new System.EventHandler(this.volumeSlider_Scroll_1);
            // 
            // scrubBar
            // 
            this.scrubBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.scrubBar.AutoSize = false;
            this.scrubBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scrubBar.Enabled = false;
            this.scrubBar.LargeChange = 0;
            this.scrubBar.Location = new System.Drawing.Point(53, 28);
            this.scrubBar.Maximum = 100;
            this.scrubBar.Name = "scrubBar";
            this.scrubBar.Size = new System.Drawing.Size(765, 24);
            this.scrubBar.SmallChange = 0;
            this.scrubBar.TabIndex = 8;
            this.scrubBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.scrubBar.Scroll += new System.EventHandler(this.scrubBar_Scroll);
            this.scrubBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrubBar_MouseDown);
            this.scrubBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrubBar_MouseUp);
            // 
            // Albums_View
            // 
            this.Albums_View.AutoScroll = true;
            this.Albums_View.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Albums_View.Controls.Add(this.Album_List);
            this.Albums_View.Location = new System.Drawing.Point(190, 75);
            this.Albums_View.Name = "Albums_View";
            this.Albums_View.Size = new System.Drawing.Size(821, 416);
            this.Albums_View.TabIndex = 10;
            this.Albums_View.Visible = false;
            // 
            // Album_List
            // 
            this.Album_List.LargeImageList = this.Artwork_List;
            this.Album_List.Location = new System.Drawing.Point(3, 3);
            this.Album_List.Name = "Album_List";
            this.Album_List.Size = new System.Drawing.Size(798, 410);
            this.Album_List.SmallImageList = this.Artwork_List;
            this.Album_List.TabIndex = 0;
            this.Album_List.UseCompatibleStateImageBehavior = false;
            this.Album_List.View = System.Windows.Forms.View.Details;
            this.Album_List.DoubleClick += new System.EventHandler(this.Album_List_SelectedIndexChanged);
            // 
            // Artwork_List
            // 
            this.Artwork_List.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.Artwork_List.ImageSize = new System.Drawing.Size(16, 16);
            this.Artwork_List.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Songs_View
            // 
            this.Songs_View.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Songs_View.Controls.Add(this.Song_List);
            this.Songs_View.Location = new System.Drawing.Point(190, 75);
            this.Songs_View.Name = "Songs_View";
            this.Songs_View.Size = new System.Drawing.Size(821, 416);
            this.Songs_View.TabIndex = 11;
            this.Songs_View.Visible = false;
            // 
            // Song_List
            // 
            this.Song_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TitleColumn,
            this.AlbumColumn,
            this.ArtistColumn,
            this.LengthColumn});
            this.Songs_View.SetFlowBreak(this.Song_List, true);
            this.Song_List.FullRowSelect = true;
            this.Song_List.Location = new System.Drawing.Point(3, 3);
            this.Song_List.Name = "Song_List";
            this.Song_List.Size = new System.Drawing.Size(818, 413);
            this.Song_List.TabIndex = 0;
            this.Song_List.UseCompatibleStateImageBehavior = false;
            this.Song_List.View = System.Windows.Forms.View.Details;
            this.Song_List.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.Song_List_ColumnClick);
            this.Song_List.Click += new System.EventHandler(this.Song_List_Click);
            this.Song_List.DoubleClick += new System.EventHandler(this.Song_List_SelectedIndexChanged);
            this.Song_List.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Song_List_MouseDown);
            // 
            // TitleColumn
            // 
            this.TitleColumn.Text = "Title";
            this.TitleColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TitleColumn.Width = 265;
            // 
            // AlbumColumn
            // 
            this.AlbumColumn.Text = "Album";
            this.AlbumColumn.Width = 195;
            // 
            // ArtistColumn
            // 
            this.ArtistColumn.Text = "Artist";
            this.ArtistColumn.Width = 195;
            // 
            // LengthColumn
            // 
            this.LengthColumn.Text = "Length";
            this.LengthColumn.Width = 142;
            // 
            // Queue_View
            // 
            this.Queue_View.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Queue_View.Controls.Add(this.Queue_List);
            this.Queue_View.Location = new System.Drawing.Point(190, 75);
            this.Queue_View.Margin = new System.Windows.Forms.Padding(0);
            this.Queue_View.Name = "Queue_View";
            this.Queue_View.Size = new System.Drawing.Size(821, 416);
            this.Queue_View.TabIndex = 14;
            this.Queue_View.Visible = false;
            this.Queue_View.DoubleClick += new System.EventHandler(this.Song_List_SelectedIndexChanged);
            // 
            // Queue_List
            // 
            this.Queue_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.Queue_View.SetFlowBreak(this.Queue_List, true);
            this.Queue_List.FullRowSelect = true;
            this.Queue_List.Location = new System.Drawing.Point(3, 3);
            this.Queue_List.Name = "Queue_List";
            this.Queue_List.Size = new System.Drawing.Size(818, 413);
            this.Queue_List.TabIndex = 1;
            this.Queue_List.UseCompatibleStateImageBehavior = false;
            this.Queue_List.View = System.Windows.Forms.View.Details;
            this.Queue_List.DoubleClick += new System.EventHandler(this.Queue_List_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 265;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Album";
            this.columnHeader2.Width = 195;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Artist";
            this.columnHeader3.Width = 194;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Length";
            this.columnHeader4.Width = 143;
            // 
            // Playlists_View
            // 
            this.Playlists_View.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Playlists_View.Controls.Add(this.Playlist_List);
            this.Playlists_View.Controls.Add(this.flowLayoutPanel1);
            this.Playlists_View.Location = new System.Drawing.Point(190, 75);
            this.Playlists_View.Name = "Playlists_View";
            this.Playlists_View.Size = new System.Drawing.Size(821, 416);
            this.Playlists_View.TabIndex = 0;
            this.Playlists_View.Visible = false;
            // 
            // Playlist_List
            // 
            this.Playlist_List.BackColor = System.Drawing.SystemColors.Window;
            this.Playlist_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PlaylistList});
            this.Playlist_List.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Playlist_List.FullRowSelect = true;
            this.Playlist_List.Location = new System.Drawing.Point(3, 3);
            this.Playlist_List.Name = "Playlist_List";
            this.Playlist_List.Size = new System.Drawing.Size(818, 413);
            this.Playlist_List.TabIndex = 0;
            this.Playlist_List.UseCompatibleStateImageBehavior = false;
            this.Playlist_List.View = System.Windows.Forms.View.Details;
            this.Playlist_List.SelectedIndexChanged += new System.EventHandler(this.Playlist_List_SelectedIndexChanged);
            // 
            // PlaylistList
            // 
            this.PlaylistList.Text = "Playlists";
            this.PlaylistList.Width = 792;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 422);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // Current_position_label
            // 
            this.Current_position_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Current_position_label.AutoSize = true;
            this.Current_position_label.Location = new System.Drawing.Point(13, 31);
            this.Current_position_label.Name = "Current_position_label";
            this.Current_position_label.Size = new System.Drawing.Size(22, 13);
            this.Current_position_label.TabIndex = 12;
            this.Current_position_label.Text = "--:--";
            // 
            // Song_length_label
            // 
            this.Song_length_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Song_length_label.AutoSize = true;
            this.Song_length_label.Location = new System.Drawing.Point(829, 31);
            this.Song_length_label.Name = "Song_length_label";
            this.Song_length_label.Size = new System.Drawing.Size(22, 13);
            this.Song_length_label.TabIndex = 13;
            this.Song_length_label.Text = "--:--";
            // 
            // Artist_View
            // 
            this.Artist_View.Controls.Add(this.Artist_List);
            this.Artist_View.Location = new System.Drawing.Point(190, 75);
            this.Artist_View.Name = "Artist_View";
            this.Artist_View.Size = new System.Drawing.Size(821, 416);
            this.Artist_View.TabIndex = 15;
            // 
            // Artist_List
            // 
            this.Artist_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ArtistList});
            this.Artist_List.FullRowSelect = true;
            this.Artist_List.Location = new System.Drawing.Point(3, 3);
            this.Artist_List.Name = "Artist_List";
            this.Artist_List.Size = new System.Drawing.Size(818, 413);
            this.Artist_List.TabIndex = 0;
            this.Artist_List.UseCompatibleStateImageBehavior = false;
            this.Artist_List.View = System.Windows.Forms.View.Details;
            this.Artist_List.DoubleClick += new System.EventHandler(this.Artist_List_SelectedIndexChanged);
            // 
            // ArtistList
            // 
            this.ArtistList.Text = "Artist";
            this.ArtistList.Width = 795;
            // 
            // Artist_Song_List
            // 
            this.Artist_Song_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ArtistList_Title,
            this.ArtistList_Album,
            this.ArtistList_Artist,
            this.ArtistList_Duration});
            this.Artist_Song_List.FullRowSelect = true;
            this.Artist_Song_List.Location = new System.Drawing.Point(3, 3);
            this.Artist_Song_List.Name = "Artist_Song_List";
            this.Artist_Song_List.Size = new System.Drawing.Size(818, 413);
            this.Artist_Song_List.TabIndex = 1;
            this.Artist_Song_List.UseCompatibleStateImageBehavior = false;
            this.Artist_Song_List.View = System.Windows.Forms.View.Details;
            this.Artist_Song_List.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.Song_List_ColumnClick);
            this.Artist_Song_List.Click += new System.EventHandler(this.Artist_Song_List_Click);
            this.Artist_Song_List.DoubleClick += new System.EventHandler(this.Artist_Song_List_SelectedIndexChanged);
            this.Artist_Song_List.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Artist_Song_List_MouseDown);
            // 
            // ArtistList_Title
            // 
            this.ArtistList_Title.Text = "Title";
            this.ArtistList_Title.Width = 265;
            // 
            // ArtistList_Album
            // 
            this.ArtistList_Album.Text = "Album";
            this.ArtistList_Album.Width = 195;
            // 
            // ArtistList_Artist
            // 
            this.ArtistList_Artist.Text = "Artist";
            this.ArtistList_Artist.Width = 194;
            // 
            // ArtistList_Duration
            // 
            this.ArtistList_Duration.Text = "Length";
            this.ArtistList_Duration.Width = 143;
            // 
            // artistLabel
            // 
            this.artistLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.artistLabel.AutoEllipsis = true;
            this.artistLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistLabel.Location = new System.Drawing.Point(7, 98);
            this.artistLabel.MaximumSize = new System.Drawing.Size(195, 21);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(195, 21);
            this.artistLabel.TabIndex = 17;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.titleLabel.AutoEllipsis = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(7, 57);
            this.titleLabel.MaximumSize = new System.Drawing.Size(195, 21);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(195, 21);
            this.titleLabel.TabIndex = 18;
            // 
            // curAlbumLabel
            // 
            this.curAlbumLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.curAlbumLabel.AutoEllipsis = true;
            this.curAlbumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curAlbumLabel.Location = new System.Drawing.Point(7, 77);
            this.curAlbumLabel.MaximumSize = new System.Drawing.Size(195, 21);
            this.curAlbumLabel.Name = "curAlbumLabel";
            this.curAlbumLabel.Size = new System.Drawing.Size(195, 21);
            this.curAlbumLabel.TabIndex = 19;
            // 
            // Artist_Song_View
            // 
            this.Artist_Song_View.Controls.Add(this.Artist_Song_List);
            this.Artist_Song_View.Location = new System.Drawing.Point(190, 75);
            this.Artist_Song_View.Name = "Artist_Song_View";
            this.Artist_Song_View.Size = new System.Drawing.Size(821, 416);
            this.Artist_Song_View.TabIndex = 16;
            // 
            // Album_Song_View
            // 
            this.Album_Song_View.Controls.Add(this.Album_Song_List);
            this.Album_Song_View.Location = new System.Drawing.Point(190, 75);
            this.Album_Song_View.Name = "Album_Song_View";
            this.Album_Song_View.Size = new System.Drawing.Size(821, 416);
            this.Album_Song_View.TabIndex = 20;
            this.Album_Song_View.Visible = false;
            // 
            // Album_Song_List
            // 
            this.Album_Song_List.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Album_Song_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AlbumSong_Title,
            this.AlbumSong_Album,
            this.AlbumSong_Artist,
            this.AlbumSong_Duration});
            this.Album_Song_List.FullRowSelect = true;
            this.Album_Song_List.Location = new System.Drawing.Point(3, 3);
            this.Album_Song_List.Name = "Album_Song_List";
            this.Album_Song_List.Size = new System.Drawing.Size(818, 413);
            this.Album_Song_List.TabIndex = 0;
            this.Album_Song_List.UseCompatibleStateImageBehavior = false;
            this.Album_Song_List.View = System.Windows.Forms.View.Details;
            this.Album_Song_List.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.Song_List_ColumnClick);
            this.Album_Song_List.Click += new System.EventHandler(this.Album_Song_List_Click);
            this.Album_Song_List.DoubleClick += new System.EventHandler(this.Album_Song_List_SelectedIndexChanged);
            this.Album_Song_List.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Album_Song_List_MouseDown);
            // 
            // AlbumSong_Title
            // 
            this.AlbumSong_Title.Text = "Title";
            this.AlbumSong_Title.Width = 265;
            // 
            // AlbumSong_Album
            // 
            this.AlbumSong_Album.Text = "Album";
            this.AlbumSong_Album.Width = 195;
            // 
            // AlbumSong_Artist
            // 
            this.AlbumSong_Artist.Text = "Artist";
            this.AlbumSong_Artist.Width = 194;
            // 
            // AlbumSong_Duration
            // 
            this.AlbumSong_Duration.Text = "Length";
            this.AlbumSong_Duration.Width = 143;
            // 
            // Search_View
            // 
            this.Search_View.Controls.Add(this.Search_List);
            this.Search_View.Location = new System.Drawing.Point(190, 75);
            this.Search_View.Name = "Search_View";
            this.Search_View.Size = new System.Drawing.Size(821, 416);
            this.Search_View.TabIndex = 21;
            // 
            // Search_List
            // 
            this.Search_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SearchTitleColumn,
            this.SearchArtistColumn,
            this.SearchAlbumColumn,
            this.SearchDurationColumn});
            this.Search_List.FullRowSelect = true;
            this.Search_List.Location = new System.Drawing.Point(3, 3);
            this.Search_List.MultiSelect = false;
            this.Search_List.Name = "Search_List";
            this.Search_List.Size = new System.Drawing.Size(818, 413);
            this.Search_List.TabIndex = 0;
            this.Search_List.UseCompatibleStateImageBehavior = false;
            this.Search_List.View = System.Windows.Forms.View.Details;
            this.Search_List.SelectedIndexChanged += new System.EventHandler(this.Search_List_SelectedIndexChanged);
            this.Search_List.Click += new System.EventHandler(this.Search_List_Click);
            // 
            // SearchTitleColumn
            // 
            this.SearchTitleColumn.Text = "Title";
            this.SearchTitleColumn.Width = 265;
            // 
            // SearchArtistColumn
            // 
            this.SearchArtistColumn.Text = "Artist";
            this.SearchArtistColumn.Width = 195;
            // 
            // SearchAlbumColumn
            // 
            this.SearchAlbumColumn.Text = "Album";
            this.SearchAlbumColumn.Width = 195;
            // 
            // SearchDurationColumn
            // 
            this.SearchDurationColumn.Text = "Length";
            this.SearchDurationColumn.Width = 140;
            // 
            // NewPlaylist_Panel
            // 
            this.NewPlaylist_Panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NewPlaylist_Panel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.NewPlaylist_Panel.Controls.Add(this.NewPlaylist_Label);
            this.NewPlaylist_Panel.Controls.Add(this.NewPlaylist_CancelButton);
            this.NewPlaylist_Panel.Controls.Add(this.NewPlaylist_EnterButton);
            this.NewPlaylist_Panel.Controls.Add(this.NewPlaylist_TextBox);
            this.NewPlaylist_Panel.Location = new System.Drawing.Point(359, 206);
            this.NewPlaylist_Panel.Name = "NewPlaylist_Panel";
            this.NewPlaylist_Panel.Size = new System.Drawing.Size(366, 134);
            this.NewPlaylist_Panel.TabIndex = 22;
            this.NewPlaylist_Panel.Visible = false;
            // 
            // NewPlaylist_Label
            // 
            this.NewPlaylist_Label.AutoSize = true;
            this.NewPlaylist_Label.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPlaylist_Label.Location = new System.Drawing.Point(21, 18);
            this.NewPlaylist_Label.Name = "NewPlaylist_Label";
            this.NewPlaylist_Label.Size = new System.Drawing.Size(110, 20);
            this.NewPlaylist_Label.TabIndex = 3;
            this.NewPlaylist_Label.Text = "New Playlist";
            // 
            // NewPlaylist_CancelButton
            // 
            this.NewPlaylist_CancelButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.NewPlaylist_CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewPlaylist_CancelButton.Location = new System.Drawing.Point(257, 87);
            this.NewPlaylist_CancelButton.Name = "NewPlaylist_CancelButton";
            this.NewPlaylist_CancelButton.Size = new System.Drawing.Size(84, 30);
            this.NewPlaylist_CancelButton.TabIndex = 2;
            this.NewPlaylist_CancelButton.Text = "Cancel";
            this.NewPlaylist_CancelButton.UseVisualStyleBackColor = false;
            this.NewPlaylist_CancelButton.Click += new System.EventHandler(this.NewPlaylist_CancelButton_Click);
            // 
            // NewPlaylist_EnterButton
            // 
            this.NewPlaylist_EnterButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.NewPlaylist_EnterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewPlaylist_EnterButton.Location = new System.Drawing.Point(25, 87);
            this.NewPlaylist_EnterButton.Name = "NewPlaylist_EnterButton";
            this.NewPlaylist_EnterButton.Size = new System.Drawing.Size(84, 30);
            this.NewPlaylist_EnterButton.TabIndex = 1;
            this.NewPlaylist_EnterButton.Text = "Create";
            this.NewPlaylist_EnterButton.UseVisualStyleBackColor = false;
            this.NewPlaylist_EnterButton.Click += new System.EventHandler(this.NewPlaylist_EnterButton_Click);
            // 
            // NewPlaylist_TextBox
            // 
            this.NewPlaylist_TextBox.AcceptsReturn = true;
            this.NewPlaylist_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewPlaylist_TextBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPlaylist_TextBox.Location = new System.Drawing.Point(92, 50);
            this.NewPlaylist_TextBox.MaxLength = 50;
            this.NewPlaylist_TextBox.Name = "NewPlaylist_TextBox";
            this.NewPlaylist_TextBox.Size = new System.Drawing.Size(185, 23);
            this.NewPlaylist_TextBox.TabIndex = 7;
            this.NewPlaylist_TextBox.Text = "Name New Playlist";
            this.NewPlaylist_TextBox.Enter += new System.EventHandler(this.NewPlaylist_TextBox_Enter);
            this.NewPlaylist_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewPlaylist_TextBox_KeyDown);
            this.NewPlaylist_TextBox.Leave += new System.EventHandler(this.NewPlaylist_TextBox_Leave);
            // 
            // bottom_panel
            // 
            this.bottom_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottom_panel.BackColor = System.Drawing.Color.White;
            this.bottom_panel.Controls.Add(this.shuffle_toggle);
            this.bottom_panel.Controls.Add(this.scrubBar);
            this.bottom_panel.Controls.Add(this.artistLabel);
            this.bottom_panel.Controls.Add(this.Current_position_label);
            this.bottom_panel.Controls.Add(this.playButton);
            this.bottom_panel.Controls.Add(this.titleLabel);
            this.bottom_panel.Controls.Add(this.Song_length_label);
            this.bottom_panel.Controls.Add(this.curAlbumLabel);
            this.bottom_panel.Controls.Add(this.volumeSlider);
            this.bottom_panel.Controls.Add(this.repeat_button);
            this.bottom_panel.Controls.Add(this.next_button);
            this.bottom_panel.Controls.Add(this.previous_button);
            this.bottom_panel.Location = new System.Drawing.Point(185, 490);
            this.bottom_panel.Name = "bottom_panel";
            this.bottom_panel.Size = new System.Drawing.Size(863, 127);
            this.bottom_panel.TabIndex = 24;
            // 
            // Options_Panel
            // 
            this.Options_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Options_Panel.Controls.Add(this.delete_folder_paths_button);
            this.Options_Panel.Controls.Add(this.delete_users_button);
            this.Options_Panel.Controls.Add(this.delete_playlists);
            this.Options_Panel.Controls.Add(this.Bottom_Color_Select);
            this.Options_Panel.Controls.Add(this.Center_Color_Select);
            this.Options_Panel.Controls.Add(this.Sidebar_Color_Button);
            this.Options_Panel.Location = new System.Drawing.Point(193, 75);
            this.Options_Panel.Name = "Options_Panel";
            this.Options_Panel.Size = new System.Drawing.Size(846, 413);
            this.Options_Panel.TabIndex = 3;
            // 
            // delete_folder_paths_button
            // 
            this.delete_folder_paths_button.Location = new System.Drawing.Point(525, 352);
            this.delete_folder_paths_button.Name = "delete_folder_paths_button";
            this.delete_folder_paths_button.Size = new System.Drawing.Size(167, 23);
            this.delete_folder_paths_button.TabIndex = 5;
            this.delete_folder_paths_button.Text = "Delete all saved Folder Paths";
            this.delete_folder_paths_button.UseVisualStyleBackColor = true;
            this.delete_folder_paths_button.Click += new System.EventHandler(this.delete_folder_paths_button_Click);
            // 
            // delete_users_button
            // 
            this.delete_users_button.Location = new System.Drawing.Point(525, 199);
            this.delete_users_button.Name = "delete_users_button";
            this.delete_users_button.Size = new System.Drawing.Size(167, 23);
            this.delete_users_button.TabIndex = 4;
            this.delete_users_button.Text = "Delete all Users";
            this.delete_users_button.UseVisualStyleBackColor = true;
            this.delete_users_button.Click += new System.EventHandler(this.delete_users_button_Click);
            // 
            // delete_playlists
            // 
            this.delete_playlists.Location = new System.Drawing.Point(525, 45);
            this.delete_playlists.Name = "delete_playlists";
            this.delete_playlists.Size = new System.Drawing.Size(167, 23);
            this.delete_playlists.TabIndex = 3;
            this.delete_playlists.Text = "Delete all Playlists";
            this.delete_playlists.UseVisualStyleBackColor = true;
            this.delete_playlists.Click += new System.EventHandler(this.delete_playlists_Click);
            // 
            // Bottom_Color_Select
            // 
            this.Bottom_Color_Select.Location = new System.Drawing.Point(150, 352);
            this.Bottom_Color_Select.Name = "Bottom_Color_Select";
            this.Bottom_Color_Select.Size = new System.Drawing.Size(167, 23);
            this.Bottom_Color_Select.TabIndex = 2;
            this.Bottom_Color_Select.Text = "Bottom Color Select";
            this.Bottom_Color_Select.UseVisualStyleBackColor = true;
            this.Bottom_Color_Select.Click += new System.EventHandler(this.buttom_color_button_Click);
            // 
            // Center_Color_Select
            // 
            this.Center_Color_Select.Location = new System.Drawing.Point(150, 199);
            this.Center_Color_Select.Name = "Center_Color_Select";
            this.Center_Color_Select.Size = new System.Drawing.Size(167, 23);
            this.Center_Color_Select.TabIndex = 1;
            this.Center_Color_Select.Text = "Center Color Select";
            this.Center_Color_Select.UseVisualStyleBackColor = true;
            this.Center_Color_Select.Click += new System.EventHandler(this.center_color_button_Click);
            // 
            // Sidebar_Color_Button
            // 
            this.Sidebar_Color_Button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Sidebar_Color_Button.Location = new System.Drawing.Point(150, 44);
            this.Sidebar_Color_Button.Name = "Sidebar_Color_Button";
            this.Sidebar_Color_Button.Size = new System.Drawing.Size(167, 23);
            this.Sidebar_Color_Button.TabIndex = 0;
            this.Sidebar_Color_Button.Text = "Sidebar Color Select";
            this.Sidebar_Color_Button.UseVisualStyleBackColor = true;
            this.Sidebar_Color_Button.Click += new System.EventHandler(this.sidebar_color_button_Click);
            // 
            // View_Label
            // 
            this.View_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.View_Label.AutoSize = true;
            this.View_Label.Font = new System.Drawing.Font("MS Reference Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.View_Label.Location = new System.Drawing.Point(502, 32);
            this.View_Label.Name = "View_Label";
            this.View_Label.Size = new System.Drawing.Size(109, 35);
            this.View_Label.TabIndex = 23;
            this.View_Label.Text = "Songs";
            this.View_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Playlist_Song_Panel
            // 
            this.Playlist_Song_Panel.Controls.Add(this.Playlist_Song_List);
            this.Playlist_Song_Panel.Location = new System.Drawing.Point(190, 75);
            this.Playlist_Song_Panel.Name = "Playlist_Song_Panel";
            this.Playlist_Song_Panel.Size = new System.Drawing.Size(821, 416);
            this.Playlist_Song_Panel.TabIndex = 24;
            this.Playlist_Song_Panel.Visible = false;
            // 
            // Playlist_Song_List
            // 
            this.Playlist_Song_List.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Playlist_Song_Title,
            this.Playlist_Song_Album,
            this.Playlist_Song_Artist,
            this.Playlist_Song_Length});
            this.Playlist_Song_List.FullRowSelect = true;
            this.Playlist_Song_List.Location = new System.Drawing.Point(3, 3);
            this.Playlist_Song_List.Name = "Playlist_Song_List";
            this.Playlist_Song_List.Size = new System.Drawing.Size(818, 413);
            this.Playlist_Song_List.TabIndex = 0;
            this.Playlist_Song_List.UseCompatibleStateImageBehavior = false;
            this.Playlist_Song_List.View = System.Windows.Forms.View.Details;
            this.Playlist_Song_List.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.Song_List_ColumnClick);
            this.Playlist_Song_List.DoubleClick += new System.EventHandler(this.Playlist_Song_List_DoubleClick);
            this.Playlist_Song_List.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Playlist_Song_List_MouseDown);
            // 
            // Playlist_Song_Title
            // 
            this.Playlist_Song_Title.Text = "Title";
            this.Playlist_Song_Title.Width = 265;
            // 
            // Playlist_Song_Album
            // 
            this.Playlist_Song_Album.Text = "Album";
            this.Playlist_Song_Album.Width = 195;
            // 
            // Playlist_Song_Artist
            // 
            this.Playlist_Song_Artist.Text = "Artist";
            this.Playlist_Song_Artist.Width = 195;
            // 
            // Playlist_Song_Length
            // 
            this.Playlist_Song_Length.Text = "Length";
            this.Playlist_Song_Length.Width = 142;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(0, 430);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 193);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.Transparent;
            this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
            this.BackButton.Location = new System.Drawing.Point(193, 29);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(72, 43);
            this.BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BackButton.TabIndex = 25;
            this.BackButton.TabStop = false;
            this.BackButton.Visible = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            this.BackButton.MouseEnter += new System.EventHandler(this.BackButton_MouseEnter);
            this.BackButton.MouseLeave += new System.EventHandler(this.BackButton_MouseLeave);
            // 
            // bear_logo
            // 
            this.bear_logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bear_logo.BackColor = System.Drawing.Color.DodgerBlue;
            this.bear_logo.Image = global::BearPlayer.Properties.Resources.bear;
            this.bear_logo.Location = new System.Drawing.Point(27, 294);
            this.bear_logo.Name = "bear_logo";
            this.bear_logo.Size = new System.Drawing.Size(136, 136);
            this.bear_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bear_logo.TabIndex = 0;
            this.bear_logo.TabStop = false;
            // 
            // shuffle_toggle
            // 
            this.shuffle_toggle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.shuffle_toggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shuffle_toggle.Image = global::BearPlayer.Properties.Resources.shuffleButtonOff;
            this.shuffle_toggle.Location = new System.Drawing.Point(206, 58);
            this.shuffle_toggle.Name = "shuffle_toggle";
            this.shuffle_toggle.Size = new System.Drawing.Size(61, 50);
            this.shuffle_toggle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.shuffle_toggle.TabIndex = 6;
            this.shuffle_toggle.TabStop = false;
            this.shuffle_toggle.Click += new System.EventHandler(this.Shuffle_Toggle_Click);
            this.shuffle_toggle.MouseEnter += new System.EventHandler(this.shuffle_toggle_MouseEnter);
            this.shuffle_toggle.MouseLeave += new System.EventHandler(this.shuffle_toggle_MouseLeave);
            // 
            // playButton
            // 
            this.playButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playButton.Image = global::BearPlayer.Properties.Resources.playButton;
            this.playButton.Location = new System.Drawing.Point(367, 58);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(56, 49);
            this.playButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playButton.TabIndex = 2;
            this.playButton.TabStop = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            this.playButton.MouseEnter += new System.EventHandler(this.playButton_MouseEnter);
            this.playButton.MouseLeave += new System.EventHandler(this.playButton_MouseLeave);
            // 
            // repeat_button
            // 
            this.repeat_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.repeat_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.repeat_button.Image = global::BearPlayer.Properties.Resources.Repeat;
            this.repeat_button.Location = new System.Drawing.Point(527, 58);
            this.repeat_button.Name = "repeat_button";
            this.repeat_button.Size = new System.Drawing.Size(45, 45);
            this.repeat_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.repeat_button.TabIndex = 5;
            this.repeat_button.TabStop = false;
            this.repeat_button.Click += new System.EventHandler(this.Repeat_Button_Click);
            this.repeat_button.MouseEnter += new System.EventHandler(this.repeat_button_MouseEnter);
            this.repeat_button.MouseLeave += new System.EventHandler(this.repeat_button_MouseLeave);
            // 
            // next_button
            // 
            this.next_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.next_button.BackColor = System.Drawing.Color.Transparent;
            this.next_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next_button.Image = global::BearPlayer.Properties.Resources.Next_Previous;
            this.next_button.Location = new System.Drawing.Point(429, 67);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(32, 32);
            this.next_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.next_button.TabIndex = 3;
            this.next_button.TabStop = false;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            this.next_button.MouseEnter += new System.EventHandler(this.next_button_MouseEnter);
            this.next_button.MouseLeave += new System.EventHandler(this.next_button_MouseLeave);
            // 
            // previous_button
            // 
            this.previous_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.previous_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.previous_button.Image = global::BearPlayer.Properties.Resources.Previous_Button;
            this.previous_button.Location = new System.Drawing.Point(329, 67);
            this.previous_button.Name = "previous_button";
            this.previous_button.Size = new System.Drawing.Size(32, 32);
            this.previous_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previous_button.TabIndex = 4;
            this.previous_button.TabStop = false;
            this.previous_button.Click += new System.EventHandler(this.previous_button_Click);
            this.previous_button.MouseEnter += new System.EventHandler(this.previous_button_MouseEnter);
            this.previous_button.MouseLeave += new System.EventHandler(this.previous_button_MouseLeave);
            // 
            // Bear_Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1048, 617);
            this.Controls.Add(this.Options_Panel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.View_Label);
            this.Controls.Add(this.NewPlaylist_Panel);
            this.Controls.Add(this.bear_logo);
            this.Controls.Add(this.searchBar);
            this.Controls.Add(this.MenuBar);
            this.Controls.Add(this.SideBar);
            this.Controls.Add(this.Queue_View);
            this.Controls.Add(this.Artist_View);
            this.Controls.Add(this.Album_Song_View);
            this.Controls.Add(this.Artist_Song_View);
            this.Controls.Add(this.Search_View);
            this.Controls.Add(this.Songs_View);
            this.Controls.Add(this.bottom_panel);
            this.Controls.Add(this.Playlist_Song_Panel);
            this.Controls.Add(this.Albums_View);
            this.Controls.Add(this.Playlists_View);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuBar;
            this.Name = "Bear_Player";
            this.Text = "Bear Player";
            this.Load += new System.EventHandler(this.BearPlayer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Bear_Player_KeyDown);
            this.MouseHover += new System.EventHandler(this.BearPlayer_Load);
            this.Resize += new System.EventHandler(this.Bear_Player_Resize);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrubBar)).EndInit();
            this.Albums_View.ResumeLayout(false);
            this.Songs_View.ResumeLayout(false);
            this.Queue_View.ResumeLayout(false);
            this.Playlists_View.ResumeLayout(false);
            this.Artist_View.ResumeLayout(false);
            this.Artist_Song_View.ResumeLayout(false);
            this.Album_Song_View.ResumeLayout(false);
            this.Search_View.ResumeLayout(false);
            this.NewPlaylist_Panel.ResumeLayout(false);
            this.NewPlaylist_Panel.PerformLayout();
            this.bottom_panel.ResumeLayout(false);
            this.bottom_panel.PerformLayout();
            this.Options_Panel.ResumeLayout(false);
            this.Playlist_Song_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bear_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shuffle_toggle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeat_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.next_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previous_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scrubForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scrubBackwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shuffleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repeatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volumeUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volumeDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchUserToolStripMenuItem;
        private System.Windows.Forms.TreeView SideBar;
        private System.Windows.Forms.PictureBox playButton;
        private System.Windows.Forms.PictureBox next_button;
        private System.Windows.Forms.PictureBox previous_button;
        private System.Windows.Forms.PictureBox repeat_button;
        private System.Windows.Forms.PictureBox shuffle_toggle;
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.TrackBar volumeSlider;
        private System.Windows.Forms.TrackBar scrubBar;
        private System.Windows.Forms.FlowLayoutPanel Albums_View;
        private System.Windows.Forms.FlowLayoutPanel Songs_View;
        private System.Windows.Forms.FlowLayoutPanel Playlists_View;
        private System.Windows.Forms.ListView Song_List;
        private System.Windows.Forms.ColumnHeader TitleColumn;
        private System.Windows.Forms.ColumnHeader AlbumColumn;
        private System.Windows.Forms.ColumnHeader ArtistColumn;
        private System.Windows.Forms.ColumnHeader LengthColumn;
        private System.Windows.Forms.Label Current_position_label;
        private System.Windows.Forms.Label Song_length_label;
        private System.Windows.Forms.FlowLayoutPanel Queue_View;
        private System.Windows.Forms.ListView Queue_List;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.FlowLayoutPanel Artist_View;
        private System.Windows.Forms.ListView Artist_List;
        private System.Windows.Forms.ColumnHeader ArtistList;
        private System.Windows.Forms.ListView Artist_Song_List;
        private System.Windows.Forms.ColumnHeader ArtistList_Title;
        private System.Windows.Forms.ColumnHeader ArtistList_Album;
        private System.Windows.Forms.ColumnHeader ArtistList_Duration;
        private System.Windows.Forms.ColumnHeader ArtistList_Artist;
        private System.Windows.Forms.PictureBox bear_logo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label artistLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label curAlbumLabel;
        private System.Windows.Forms.FlowLayoutPanel Artist_Song_View;
        private System.Windows.Forms.ImageList Artwork_List;
        private System.Windows.Forms.ListView Album_List;
        private System.Windows.Forms.FlowLayoutPanel Album_Song_View;
        private System.Windows.Forms.ListView Album_Song_List;
        private System.Windows.Forms.ColumnHeader AlbumSong_Title;
        private System.Windows.Forms.ColumnHeader AlbumSong_Album;
        private System.Windows.Forms.ColumnHeader AlbumSong_Artist;
        private System.Windows.Forms.ColumnHeader AlbumSong_Duration;
        private System.Windows.Forms.FlowLayoutPanel Search_View;
        private System.Windows.Forms.ListView Search_List;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ColumnHeader SearchTitleColumn;
        private System.Windows.Forms.ColumnHeader SearchArtistColumn;
        private System.Windows.Forms.ColumnHeader SearchAlbumColumn;
        private System.Windows.Forms.ColumnHeader SearchDurationColumn;
        
        private System.Windows.Forms.Panel NewPlaylist_Panel;
        private System.Windows.Forms.TextBox NewPlaylist_TextBox;
        private System.Windows.Forms.Label NewPlaylist_Label;
        private System.Windows.Forms.Button NewPlaylist_CancelButton;
        private System.Windows.Forms.Button NewPlaylist_EnterButton;
        private System.Windows.Forms.ListView Playlist_List;
        private System.Windows.Forms.ColumnHeader PlaylistList;
        public System.Windows.Forms.Label View_Label;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel Playlist_Song_Panel;
        private System.Windows.Forms.ListView Playlist_Song_List;
        private System.Windows.Forms.ColumnHeader Playlist_Song_Title;
        private System.Windows.Forms.ColumnHeader Playlist_Song_Album;
        private System.Windows.Forms.ColumnHeader Playlist_Song_Artist;
        private System.Windows.Forms.ColumnHeader Playlist_Song_Length;
        private System.Windows.Forms.ColumnHeader Playlist_Title;
        private System.Windows.Forms.ColumnHeader Playlist_Album;
        private System.Windows.Forms.ColumnHeader Playlist_Artist;
        private System.Windows.Forms.ColumnHeader Playlist_Length;
        private System.Windows.Forms.ColorDialog sidebar_color_dialog;
        private System.Windows.Forms.Panel bottom_panel;
        private System.Windows.Forms.Panel Options_Panel;
        private System.Windows.Forms.Button Sidebar_Color_Button;
        private System.Windows.Forms.Button Center_Color_Select;
        private System.Windows.Forms.Button Bottom_Color_Select;
        private System.Windows.Forms.ToolStripMenuItem createUserToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        private System.Windows.Forms.ToolStripMenuItem addToPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem noRepeatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repeatOneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repeatAllToolStripMenuItem;
        private System.Windows.Forms.PictureBox BackButton;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem artistViewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem albumViewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem songViewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem queueToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem playlistsToolStripMenuItem1;
        private System.Windows.Forms.Button delete_playlists;
        private System.Windows.Forms.Button delete_users_button;
        private System.Windows.Forms.Button delete_folder_paths_button;
    }
}

