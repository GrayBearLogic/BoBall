using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CollisionController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            EndGame();
        }

        private void EndGame()
        {
            print("WALL !!!!!!!!!");
            Application.Quit();
        }
    }
}