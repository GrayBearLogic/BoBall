using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class Shift : MonoBehaviour
    {
        [SerializeField] private Function function;
        [SerializeField] private float amplitude = 0.5f;
        [SerializeField] private float friction = 2f;
        [SerializeField] private Vector2 dir = Vector2.up;
        private Vector2 localPositionInit;
        
        private void Start()
        {
            dir = dir.normalized;
            localPositionInit = transform.localPosition;
        }

        private void Update()
        {
            var shift = function.Calculate(Time.time * friction) * amplitude;
            transform.localPosition = localPositionInit + dir * shift;

        }

    }
}