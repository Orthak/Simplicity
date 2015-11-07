using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class LevelBoundary : MonoBehaviour
    {
        public float 
            xMin = -100f,
            xMax = 100f,
            yMin = -100,
            yMax = 100;

        public void KeepInBoundary(GameObject _gameObject)
        {
            _gameObject.transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, xMin, xMax),
            Mathf.Clamp(transform.position.y, yMin, yMax));
        }
    }
}
