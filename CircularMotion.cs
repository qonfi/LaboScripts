//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;
using System;


namespace Labo{
    public class CircularMotion : MonoBehaviour{
        [SerializeField] private float radius = 5.00f;
        [SerializeField] private float speed = 1.00f;
        

        // Time.time がどんどん大きくなっていくことは考慮していない。
        private void Update() {
            Vector3 pos = transform.position;

            // cos(degree) = x / radius
            // x  = cos(degree) * radius
            float xDestination = Mathf.Cos(Time.time * speed) * radius;

            // sin(degree) = radius / y
            // y = sin(degree * radius
            float zDestination = Mathf.Sin(Time.time * speed) * radius;

            Vector3 translation = new Vector3(
                xDestination - pos.x,
                0,
                zDestination - pos.z);

            transform.Translate(translation);
        }
    }
}