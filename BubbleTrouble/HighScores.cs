using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleTrouble
{
    [Serializable]
    public partial class HighScores : Form
    {
        public List<Player> Players { get; set; } = new List<Player>() {  };
        String FileName = "HighScores";
        
        public HighScores()
        {
            InitializeComponent();
           
            openFile();
            Players = Players.OrderByDescending(x => x.Points).ToList();
           

               
              
                for (int i = 0; i < Players.Count; i++)
                {
                    playerList.Items.Add(Players.ElementAt(i));

                }
            }
        public void AddPlayer(int points)
        {

            
            AddPlayer form = new AddPlayer(points);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Players.Add(form.newPlayer);
                playerList.Items.Add(form.newPlayer);
            }
            Players = Players.OrderByDescending(x => x.Points).ToList();
            saveFile();

        }





        private void saveFile()
        {
            if (FileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "High scores file (*.hsf)|*.hsf";
                saveFileDialog.Title = "Save HighScores";
                saveFileDialog.FileName = FileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
                }
            }


            try
            {
                using (FileStream stream = new FileStream(FileName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
              
                    formatter.Serialize(stream, Players);
             
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("Unable to complete saving");
            }
            Invalidate(true);
        }

        private void openFile()
        {
          /*  if (FileName == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "High scores file (*.hsf)|*.hsf";
                openFileDialog.Title = "Open High Scores";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = openFileDialog.FileName;

                }
            }

    */
            try
            {
                using (FileStream stream = new FileStream(FileName, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                   Players = (List<Player>)formatter.Deserialize(stream);
                   
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("Unable to complete opening");
            }
           // FileName = null;
            Invalidate(true);

        }

    }
    }
    

