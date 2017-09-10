using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;



namespace Labo {
    /// <summary>
    /// メッシュの座標を得ることができるか試すために作ったクラス。
    /// </summary>
    public class MeshPursuer : MonoBehaviour {
        [SerializeField] private bool drawGizmos;
        private List<Vector3> pursuedVertices = new List<Vector3>();
        private GameObject targetObject;
        private Mesh targetMesh;


        private void Update() {
            Pursue(targetObject);
            if (Input.GetMouseButtonDown(0) == false) { return; }
            RayToMesh();
        }


        private void OnDrawGizmos() {
            if (UnityEditor.EditorApplication.isPlaying == false) { return; }
            if (drawGizmos == false) { return; }

            Gizmos.color = new Color32(255, 0, 0, 255);
            for (int i = 0; i < pursuedVertices.Count; i++) {
                Gizmos.DrawWireSphere(pursuedVertices[i], 0.2f); ;
            }
        }


        /// <summary>
        /// // マウス座標とメインカメラを使ってレイキャストを行い、メッシュを取得 する。
        /// </summary>
        private void RayToMesh() {
            RaycastHit hit = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hitsSomething = Physics.Raycast(ray, out hit, Mathf.Infinity);
            if (hitsSomething == false) { return; }

            // メッシュを取得。
            MeshFilter filter = hit.collider.GetComponent<MeshFilter>();
            targetMesh = filter.mesh;

            targetObject = hit.collider.gameObject;
        }


        /// <summary>
        /// メッシュの追跡を行い、結果をフィールドに反映する。
        /// </summary>
        private void Pursue(GameObject target) {
            if (target == null) { return; }
            if (targetMesh.vertices == null) { return; }
            if(pursuedVertices == null) { return; }
            if (targetMesh == null) { return; }

            // mesh.vertices はメッシュオブジェクトの中心からの相対座標のようなので、
            // オブジェクトの座標を足してverticesのワールド座標を得る。
            pursuedVertices.Clear();
            Vector3 position = target.transform.position;
            for (int i = 0; i < targetMesh.vertices.Length; i++) {
                this.pursuedVertices.Add(position + targetMesh.vertices[i]);
            }
        }

    }
}