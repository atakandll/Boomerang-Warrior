using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Managers
{
    public class ScrollerManager : MonoBehaviour
    {
        [SerializeField] private RawImage image;
        [SerializeField] private float x, y;

        private void Update()
        {
            image.uvRect = new Rect(image.uvRect.position + new Vector2(x, y) * Time.deltaTime, image.uvRect.size);
        }
    }
}