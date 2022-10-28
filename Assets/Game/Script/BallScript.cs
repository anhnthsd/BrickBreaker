using UnityEngine;
using UnityEngine.UI;

namespace Game.Script
{
    public class BallScript : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigibody;
        public Text txtScore;
        public Transform paddle;
        private bool _inPlay = false;

        private void Start()
        {
            transform.position = paddle.position;
        }

        void OnGUI()
        {
            Event e = Event.current;
            if (e.isMouse)
            {
                if (!_inPlay)
                {
                    transform.position = paddle.position;
                    if (GameController.gameControl.isStart && e.clickCount == 2)
                    {
                        _inPlay = true;
                        rigibody.AddForce(Vector2.up * 500);
                    }
                }
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("wall"))
            {
                _inPlay = false;
                rigibody.velocity = Vector2.zero;
                transform.position = paddle.position;
                GameController.gameControl.OnBallMoveOut();
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("brick"))
            {
                col.gameObject.SetActive(false);
                GameController.gameControl.score++;
                txtScore.text = "Score: " + GameController.gameControl.score;
            }

            if (!_inPlay) return;
            var temp = rigibody.velocity.normalized;
            temp.x = temp.x > 0 ? (temp.x < 0.1f ? 0.1f : temp.x) : (temp.x > -0.1f ? -0.1f : temp.x);
            temp.y = temp.y > 0 ? (temp.y < 0.1f ? 0.1f : temp.y) : (temp.y > -0.1f ? -0.1f : temp.y);
            rigibody.velocity = Vector2.zero;
            rigibody.AddForce(temp * 500);
        }
    }
}