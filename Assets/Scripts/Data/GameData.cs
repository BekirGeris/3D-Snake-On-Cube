using UnityEngine;

namespace Snake.Data
{
    [CreateAssetMenu(menuName = "Snake/Data/Game Data")]
    public class GameData : ScriptableObject
    {
        public string gameMessage = "";
        public int Score = 0;
        public bool GameState = false;
        public int HighScore = 0;
    }
}
