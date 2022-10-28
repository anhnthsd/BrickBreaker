using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Game.Script
{
    public class CreateBrickScript : MonoBehaviour
    {
        public int gameMode = 1;
        public int timeCreateBrick = 3;
        public int timeCountdown = 3;
        public GameObject screenCountdown;
        public Text txtCountdown;

        private void Start()
        {
            Time.timeScale = 1;
            screenCountdown.SetActive(true);
            StartCoroutine(CountdownStart());
            if (gameMode == 1)
            {
                StartCoroutine(AddBricks());
            }
            else
            {
                CreateBricks2();
            }
        }

        private IEnumerator CountdownStart()
        {
            int count = timeCountdown;
            while (count > 0)
            {
                txtCountdown.text = count.ToString();
                yield return new WaitForSeconds(1);
                count--;
            }

            GameController.gameControl.isStart = true;
            screenCountdown.SetActive(false);
        }

        private IEnumerator AddBricks()
        {
            yield return new WaitForSeconds(timeCountdown);
            while (true)
            {
                CreateBricks1();
                yield return new WaitForSeconds(timeCreateBrick);
            }
        }

        private void CreateBricks1()
        {
            BrickPooler.BrickInstance.UpdatePosition();
            int num = Random.Range(1, 5);
            for (int i = 0; i < num; i++)
            {
                GameObject newBrick = BrickPooler.BrickInstance.GetObject();
                if (newBrick != null)
                {
                    newBrick.transform.position = new Vector3(Random.Range(-7f, 7f), 4, 0);
                    newBrick.SetActive(true);
                }
            }
        }

        private void CreateBricks2()
        {
            BrickPooler.BrickInstance.UpdatePosition();
            for (int i = 0; i < 4; i++)
            {
                var y = 4 - 0.5f * i;
                for (int j = 0; j < 5; j++)
                {
                    GameObject newBrick = BrickPooler.BrickInstance.GetObject();
                    if (newBrick != null)
                    {
                        newBrick.transform.position = new Vector3(7 - 3.5f * j, y, 0);
                        newBrick.SetActive(true);
                    }
                }
            }
        }
    }
}