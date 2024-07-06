using Floppy_Game_by_I_M_Marinov.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floppy_Game_by_I_M_Marinov.Validation
{
    public class ValidationMessages
    {
        public const string GameOverMessage = "Game Over !";
        public const string ConfirmQuitMessage = "Are you sure you want to quit ?";
        public const string ConfirmQuitMessageCaption = "Are you leaving ?";
        public const string ConfirmDeleteMessage = "Are you sure you want to delete all saved scores ?";
        public const string ConfirmDeleteMessageCaption = "Confirm Deletion";
        public const string WriteANameMessage = "You need to write a name in to save your score!";
        public const string NewHighScoreMessage = "{0}'s has a new high score --> {1}.";
        public const string DidNotBeatHighScoreMessage = "{0}'s highest score is {1}. Try again !";
        public const string ScoreSavedSuccessfully = "{0} your score has been saved successfully !";
        public const string AllScoresDeletedSuccessfully = "All scores deleted successfully !";
        public const string NoScoresSaved = "There are no scores saved as of now !"; 
    }
}
