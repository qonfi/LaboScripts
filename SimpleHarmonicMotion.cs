using System.Collections.Generic;
//using UnityEngine.UI;
//using UnityEditor;
using UnityEngine;
using System;


namespace Labo{
    /// <summary>
    /// 単振動の挙動を簡易に実装するコンポーネント。
    /// 往復するごとに座標にプラス/マイナス0.4前後の変動がある。あくまで簡易的なもの。
    /// </summary>
    public class SimpleHarmonicMotion : MonoBehaviour{
        [SerializeField] private float xLength = 0.00f;
        [SerializeField] private float xSpeed = 1.00f;
        [SerializeField] private float yLength = 0.00f;
        [SerializeField] private float ySpeed = 1.00f;
        [SerializeField] private float zLength = 0.00f;
        [SerializeField] private float zSpeed = 1.00f;


        private void Update() {
            Vector3 pos = transform.position;
            float xDestination = pos.x + CalculatePoint(xSpeed, xLength);
            float yDestination = pos.y + CalculatePoint(ySpeed, yLength);
            float zDestination = pos.z + CalculatePoint(zSpeed, zLength);

            Vector3 translation = new Vector3(
                xDestination - pos.x,
                yDestination - pos.y,
                zDestination - pos.z
                );

            transform.Translate(translation);
        }


        /// <summary>
        /// 単振動の動きをする物体の、ある時点での座標を算出する。
        /// 長時間経過して Time.time が非常に大きくなった場合などは考慮していない。
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private float CalculatePoint(float speed, float length) {
            float point = Mathf.Cos(Time.time * speed) * length;
            return point;
        }
    }
    
}