using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSrepro
{
    public partial class Form1 : Form
    {
        List<string> songNames;
        List<string> songPaths;    

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;

            if (dialog.ShowDialog()== DialogResult.OK)
            {
                AddsongTolist( dialog.SafeFileNames.ToList(), dialog.FileNames.ToList());
               
            }
            

        }
       
        private void AddsongTolist(List<string> names, List<string> paths)
        {
            if (songNames == null)
                songNames = new List<string>(); 
            
            if (songPaths==null)
                songPaths = new List<string>();

            foreach (var item in names)
            {
                if (!ExistonList(item))
                {
                    songNames.Add(item);
                    songPaths.Add(GetPath(item, paths));
                }

            }

            listSong.DataSource  = songNames;
        }

        private bool ExistonList(string song)
        {
            bool exist = false;
            foreach (var item in songNames)
            {
                
                if (item == song)
               
                    exist = true;
                   
            }
            return exist;
        }

        private string  GetPath(string filename, List <string> songsPath = null)
        {
            string actualPath = string.Empty;
            if (songsPath == null)
               songsPath = songPaths;


            foreach (var path in songsPath)
            {
                if (path.Contains(filename))

                    actualPath = path;                               
            }
            return actualPath;
        }       
                
 
        private void listSong_DoubleClick(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = GetPath(listSong.Text);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if(songNames=!null)
            songNames.Remove(listSong.Text);
            if (songPaths = !null)
                songPaths.Remove(listSong.Text);
        }
        private void RefreshList()
        {

        }

    }

       

}
