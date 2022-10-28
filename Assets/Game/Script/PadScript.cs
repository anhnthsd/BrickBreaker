using UnityEngine;

namespace Game.Script
{
    public class PadScript : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButton(0) && GameController.gameControl.isStart)
            {
                var x = Mathf.Clamp(transform.position.x + Input.GetAxis("Mouse X"), -8, 8);
                transform.position = new Vector3(x, -4.5f, 0);
            }
        }
    }
}