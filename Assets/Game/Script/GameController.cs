using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.Script
{
    public class GameController : MonoBehaviour
    {
        public static GameController gameControl;
        public GameObject gameResult;
        public bool isStart = false;
        public int score = 0;
        public int lives = 3;
        public Text txtLive;
        public Text txtResult;
        public Text txtHighScore;

        void Start()
        {
            gameControl = this;
            gameResult.SetActive(false);
            txtLive.text = "Lives: " + lives;
        }

        public void OnBallMoveOut()
        {
            lives--;
            txtLive.text = "Lives: " + lives;
            if (lives == 0)
            {
                EndGame();
            }
        }

        public void EndGame()
        {
            Time.timeScale = 0;
            gameResult.SetActive(true);
            if (PlayerPrefs.HasKey("HighScore"))
            {
                var hightScore = PlayerPrefs.GetInt("HighScore", 0);
                if (score > hightScore)
                {
                    SaveHighScore();
                }
                else
                {
                    txtResult.text = "Your score: " + score;
                    txtHighScore.text = "The highest score: " + hightScore;
                }
            }
            else
            {
                SaveHighScore();
            }
        }

        private void SaveHighScore()
        {
            txtHighScore.text = "";
            txtResult.text = "New high score: " + score;
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }

        public void ReplayGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}