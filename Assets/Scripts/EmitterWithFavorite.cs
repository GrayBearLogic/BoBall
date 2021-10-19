using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class EmitterWithFavorite : Emitter
    {
        [SerializeField] private Section favorite;

        protected override Section ChooseNext()
        {
            return Random.value > 0.5f ? favorite : base.ChooseNext();
        }
    }
}