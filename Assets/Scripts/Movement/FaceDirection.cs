using System;
using UnityEngine;

namespace Movement
{
    public class FaceDirection : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        private Vector2 _lastPos;

        private void Awake()
        {
            _renderer = gameObject.GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _lastPos = transform.position;
        }

        private void Update()
        {
            float xDir = _lastPos.x - transform.position.x;
            if (xDir > 0)
            {
                _renderer.flipX = false;
            }
            else if (xDir < 0)
            {
                _renderer.flipX = true;
            }
            _lastPos = transform.position;
        }
    }
}
