using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class Function : ScriptableObject
    {
        public abstract float Calculate(float x);
    }
}