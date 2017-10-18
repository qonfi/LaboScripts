// using System.Collections.Generic;
using UnityEngine;


namespace Labo{
    /// <summary>
    /// パッと動かしたいときのためのコンポーネント。何に対しても依存しておらず、このスクリプトだけで動く。
    /// </summary>
    public class EazyController : MonoBehaviour{
        [SerializeField, Range(10f , 30f)] private float WalkSpeed = 18f;
        [SerializeField, Range(0.1f, 5f)] private float RightStickSensitivityX = 3.0f;
        [SerializeField, Range(0.1f, 5f)] private float RightStickSensitivityY = 1.4f;
        private GameObject face;


        private void Start() {
            face = new GameObject();
            face.transform.parent = this.transform;
            face.transform.localPosition = new Vector3(0, 0.5f, 0.5f);
            face.name = "Face";

            Camera.main.transform.parent = face.transform;
            Camera.main.transform.localPosition = new Vector3(0f, 3f, -8f);
            Camera.main.transform.Rotate(12f, 0, 0);
        }


        private void Update() {
            float movementX = Input.GetAxis("Horizontal") * WalkSpeed * Time.deltaTime;
            float movementY = Input.GetAxis("Vertical") * WalkSpeed * Time.deltaTime;
            this.transform.Translate(movementX, 0, movementY);

            float rotationX = Input.GetAxis("Mouse X") * RightStickSensitivityX;
            float rotationY = Input.GetAxis("Mouse Y") * RightStickSensitivityY;
            AntiTiltRotate(face, 0,-rotationY );
            AntiTiltRotate(this.gameObject, rotationX, 0);
        }



        /// <summary>
        /// 上下左右の回転のみで、Z軸の(ドアノブをひねるような)回転はしないRotate。
        /// </summary>
        /// <param name="objectToRotate"></param>
        /// <param name="horizontalRotation"></param>
        /// <param name="verticalRotation"></param>
        public static void AntiTiltRotate(GameObject objectToRotate, float horizontalRotation, float verticalRotation) {
            // 回転がローカル軸に対してか、ワールド軸に対してか指定することができる。
            // Y軸方向の回転はワールド軸でないと、あちこち回転しているうちにオブジェクトが傾いてしまう。
            objectToRotate.transform.Rotate(0, horizontalRotation, 0, Space.World);
            objectToRotate.transform.Rotate(verticalRotation, 0, 0);
        }
    }
}