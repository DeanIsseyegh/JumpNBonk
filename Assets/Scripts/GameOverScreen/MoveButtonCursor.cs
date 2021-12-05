using System;
using UnityEngine;

namespace GameOverScreen
{
    public class MoveButtonCursor : MonoBehaviour
    {
        [SerializeField] private GameObject cursor;
        private Vector2 _desiredPosition;

        private void Start()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            float width = rectTransform.rect.width;
            var position = gameObject.transform.position;
            _desiredPosition = new Vector2(position.x - width / 2 - width / 5,
                position.y);
        }

        public void MoveCursorTo()
        {
            cursor.transform.position = _desiredPosition;
        }
    }
}