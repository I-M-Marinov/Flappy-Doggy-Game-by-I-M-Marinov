using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Floppy_Game_by_I_M_Marinov.Methods
{
    public class ScoreManipulation
    {

        static readonly string Path = "HighScores.txt"; 
        private readonly Form1 _form1;
        public List<string> UsernameList = new();

        public ScoreManipulation(Form1 form)
        {
            _form1 = form;
        }

  
        public void SaveTheScore(string name, int score, int level, DateTime date)
        {
            string formattedScore = $"Name: {name} ----- Score: {score} ----- Level: {level} ----- Saved on: {date}";

            using (StreamWriter writer = new StreamWriter(Path, true))
            {
                writer.WriteLine(formattedScore);
            }
        }
        public void RemoveScoreFromFile(string name)
        {
            string tempFile = System.IO.Path.GetTempFileName();
            using (var reader = new StreamReader(Path))
            using (var writer = new StreamWriter(tempFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    if (!line.Contains($"Name: {name} ----- "))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            File.Delete(Path);
            File.Move(tempFile, Path);
        }
        public void DeleteScores()
        {
            if (File.Exists(Path))
            {
                File.WriteAllText(Path, string.Empty);

                _form1.StatusTextLabel.Text = "All scores deleted successfully !";

            }
            else
            {
                _form1.StatusTextLabel.Text = "There are no scores saved as of now !";
            }
        }
        public int GetHighestScoreForUser(string name)
        {

            int highestScore = 0;

            using (StreamReader reader = new StreamReader(Path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains($"Name: {name} ----- Score: "))
                    {
                        string[] tokens = line.Split(new string[] { "-----" }, 0);
                        foreach (string part in tokens)
                        {
                            if (part.Trim().StartsWith("Score:"))
                            {
                                int score = int.Parse(part.Trim().Substring(7));

                                if (score > highestScore)
                                {
                                    highestScore = score;
                                }
                            }
                        }
                    }
                }
            }

            return highestScore;
        }
        public string ExtractNameFromLine(string line)
        {
            string namePrefix = "Name: ";
            string nameSuffix = " ----- Score: ";

            int nameStartIndex = line.IndexOf(namePrefix) + namePrefix.Length;
            int nameEndIndex = line.IndexOf(nameSuffix);

            if (nameStartIndex >= 0 && nameEndIndex > nameStartIndex)
            {
                return line.Substring(nameStartIndex, nameEndIndex - nameStartIndex);
            }

            return null;
        }
        public void LoadNamesFromFile()
        {
            if (File.Exists(Path))
            {
                using (StreamReader reader = new StreamReader(Path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string name = ExtractNameFromLine(line);
                        if (!string.IsNullOrEmpty(name) && !UsernameList.Contains(name))
                        {
                            UsernameList.Add(name);
                        }
                    }
                }
            }
        }
        public void HighScoresShow()
        {
            _form1.StatusTextLabel.Visible = true;
            _form1.SaveScoresLabel.Visible = true;
            _form1.NameLabel.Visible = true;
            _form1.ScoresTextBox.Visible = true;
            _form1.SubmitScoresButton.Visible = true;
            _form1.ResetAllScoresButton.Visible = true;
        }
        public void HighScoresHide()
        {
            _form1.StatusTextLabel.Visible = false;
            _form1.SaveScoresLabel.Visible = false;
            _form1.NameLabel.Visible = false;
            _form1.ScoresTextBox.Visible = false;
            _form1.SubmitScoresButton.Visible = false;
            _form1.ResetAllScoresButton.Visible = false;
        }

    }
}
