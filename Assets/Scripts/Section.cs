using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class Section : MonoBehaviour
    {
        [SerializeField] private float width = 8;
        [SerializeField] private SpeedAsset speed;

        public float Width
        {
            get => width;
        }

        private void Update()
        {
            transform.Translate(Vector2.left * (Time.deltaTime * speed.Value));
            
            if (transform.position.x <= -20)
            {
                Destroy(this.gameObject);
            }
        }
    }
}