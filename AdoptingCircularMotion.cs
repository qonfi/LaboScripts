using System.Collections.Generic;
//using UnityEngine.UI;
//using UnityEditor;
using UnityEngine;
using System;


namespace Labo{
    public class AdoptingCircularMotion : MonoBehaviour{
        public GameObject PivotObject { get; private set; }
        [SerializeField] private float radius = 3.00f;
        [SerializeField] private float speed = 1.00f;

        private void Start() {
            // カラのオブジェクトの子にさせて位置をずらすことで、親オブジェクトがピボットの役割をする。
            Transform childTransform = this.transform;
            Vector3 originalPosition = childTransform.position;
            PivotObject = new GameObject();
            PivotObject.name = "Pivot";
            PivotObject.transform.position = originalPosition;
            childTransform.parent = PivotObject.transform;
            childTransform.localPosition = Vector3.zero;
            childTransform.localPosition = Vector3.right * radius;
        }

        private void Update() {
            // 親オブジェクトを回転させる。
            PivotObject.transform.Rotate(0, speed, 0);
        }
    }
}