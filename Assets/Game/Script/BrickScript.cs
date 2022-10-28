using System;
using UnityEngine;

namespace Game.Script
{
    public class BrickScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            GameController.gameControl.EndGame();
        }
        private void OnTriggerStay2D(Collider2D col)
        {
            GameController.gameControl.EndGame();
        }
    }
}