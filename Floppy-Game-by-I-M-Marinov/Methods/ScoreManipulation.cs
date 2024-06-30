using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Floppy_Game_by_I_M_Marinov.Methods
{
    public class ScoreManipulation
    {

        static readonly string path = "HighScores.txt";
        public static Form1 _form1;
        public static List<string> usernameList = new();

        private readonly Label _saveScoresLabel = _form1.SaveScoresLabel;
        private readonly Label _nameLabel = _form1.NameLabel;
        private readonly Label _statusTextLabel = _form1.StatusTextLabel;
        private readonly TextBox _scoresTextBox = _form1.ScoresTextBox;
        private readonly Button _submitScoresButton = _form1.SubmitScoresButton;
        private readonly Button _resetAllScoresButton = _form1.ResetAllScoresButton;


        public ScoreManipulation(Form1 form)
        {
            _form1 = form;
        }


        public static void SaveTheScore(string name, int score, int level, DateTime date)
        {
            string formattedScore = $"Name: {name} ----- Score: {score} ----- Level: {level} ----- Saved on: {date}";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(formattedScore);
            }
        }
        public static void RemoveScoreFromFile(string name)
        {
            string tempFile = Path.GetTempFileName();
            using (var reader = new StreamReader(path))
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
            File.Delete(path);
            File.Move(tempFile, path);
        }
        public static void DeleteScores()
        {
            if (File.Exists(path))
            {
                File.WriteAllText(path, string.Empty);

                _form1.StatusTextLabel.Text = "All scores deleted successfully !";

            }
            else
            {
                _form1.StatusTextLabel.Text = "There are no scores saved as of now !";
            }
        }
        public static int GetHighestScoreForUser(string name)
        {

            int highestScore = 0;

            using (StreamReader reader = new StreamReader(path))
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
        public static string ExtractNameFromLine(string line)
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
        public static void LoadNamesFromFile()
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string name = ExtractNameFromLine(line);
                        if (!string.IsNullOrEmpty(name) && !usernameList.Contains(name))
                        {
                            usernameList.Add(name);
                        }
                    }
                }
            }
        }
        public static void HighScoresShow()
        {
            if (!_saveScoresLabel.Visible && !_nameLabel.Visible &&
                !_scoresTextBox.Visible && !_submitScoresButton.Visible &&
                !_resetAllScoresButton.Visible && !_statusTextLabel.Visible)
            {
                _saveScoresLabel.Visible = true;
                _nameLabel.Visible = true;
                _scoresTextBox.Visible = true;
                _submitScoresButton.Visible = true;
                _resetAllScoresButton.Visible = true;
                _statusTextLabel.Visible = true;
            }

        }
        public static void HighScoresHide()
        {

            if (_saveScoresLabel.Visible && _nameLabel.Visible &&
                _scoresTextBox.Visible && _submitScoresButton.Visible &&
                _resetAllScoresButton.Visible && _statusTextLabel.Visible)
            {
                _saveScoresLabel.Visible = false;
                _nameLabel.Visible = false;
                _scoresTextBox.Visible = false;
                _submitScoresButton.Visible = false;
                _resetAllScoresButton.Visible = false;
                _statusTextLabel.Visible = false;
            }
        }

    }
}
