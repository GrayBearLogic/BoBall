using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class Beat : MonoBehaviour
    {
        [SerializeField] private Function function;
        [SerializeField] private float amplitude = 0.5f;
        [SerializeField] private float friction = 2f;
        private Vector3 initScale;
        
        private void Start()
        {
            initScale = transform.localScale;
        }

        private void Update()
        {
            var scale = function.Calculate(Time.time * friction) * amplitude;
            transform.localScale = Vector3.one * scale + initScale;
        }
        
    }
}