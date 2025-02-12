using UnityEngine;

namespace Boundaries
{
    public class ScreenBoundaries : MonoBehaviour
    {
        private void FixedUpdate()
        {
            ClampPosition();
        }

        private void ClampPosition()
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }
    }
}