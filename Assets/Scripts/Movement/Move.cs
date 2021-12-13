using System;
using UnityEngine;

namespace Movement
{
    public class Move : MonoBehaviour
    {
        public int XDirection { set; get; }
        public float XSpeed { set; get; }

        public int YDirection { set; get; }
        public float YSpeed { set; get; }
        
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _rb.velocity = new Vector2(XDirection * XSpeed, YDirection * YSpeed);
        }
    }
}
