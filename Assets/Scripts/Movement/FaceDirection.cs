using System;
using UnityEngine;

namespace Movement
{
    public class FaceDirection : MonoBehaviour
    {
        private SpriteRenderer _renderer;

        private Vector2 lastPos;

        private void Awake()
        {
            _renderer = gameObject.GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            lastPos = transform.position;
        }

        private void Update()
        {
            float xDir = lastPos.x - transform.position.x;
            if (xDir > 0)
            {
                _renderer.flipX = false;
            }
            else if (xDir < 0)
            {
                _renderer.flipX = true;
            }
            lastPos = transform.position;
        }
    }
}
