using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(RectTransform))]
    public class ButtonPop : MonoBehaviour
    {
        private Vector2 displace;
        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            displace = rectTransform.anchoredPosition;
        }

        public void Perform()
        {
            StartCoroutine(Process());
        }

        private IEnumerator Process()
        {
            rectTransform.anchoredPosition = Vector2.zero;
            yield return new WaitForSeconds(0.03f);
            rectTransform.anchoredPosition = displace;
        }
    }
}