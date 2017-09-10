using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;
using System;


namespace Labo {
    public class SpiralStairDesigner : MonoBehaviour {
        [SerializeField] private GameObject stairObject;
        private List<GameObject> stairs;
        
        [SerializeField, Range(0.01f, 5f)] private float stairHeightScale = 1.0f;
        [SerializeField, Range(1f, 50f)] private float stairWidthScale = 1.0f;
        [SerializeField, Range(0.1f, 10f)] private float stairDepthScale = 1.0f;

        /// <summary>
        /// 階段の水平方向の拡散ぐあい。螺旋の中心軸からの距離。
        /// </summary>
        [SerializeField, Range(3f, 100f)] private float horizontalDiffusitivity = 5.0f;

        /// <summary>
        /// 階段の垂直方向の拡散ぐあいのスケール値。(この値 * 階段の高さ) が階段の段差となる。
        /// </summary>
        [SerializeField, Range(0.1f, 2f)] private float verticalDiffusitivityScale = 1.0f; 

        [SerializeField, Range(72, 360)] private int stepNumber = 72;
        [SerializeField] private bool apply;


        private void Start() {
            stairs = new List<GameObject>();

            // 階段オブジェクトのルート。
            GameObject rootObject = new GameObject();
            rootObject.transform.position = Vector3.zero;
            rootObject.name = "SpiralStair";

            // Prefab が指定されていればそれを使い、されていなければ Cube を新しく作る。
            GameObject stair =
                stairObject == null ? CreateStair() : stairObject;

            // これ以降、カラのGameObject が階段の一段として扱われ、3Dオブジェクトはその子となるので注意。
            GameObject adoptedStair = AdoptIntoPivot(stair);
            adoptedStair.transform.parent = rootObject.transform;

            // 階段を積み上げる。
            for (int i = 0; i < 72; i++) {
                GameObject baby = Instantiate(adoptedStair);    // 生成
                Transform babyTrans = baby.transform;       
                babyTrans.Rotate(0, i * 10, 0);     // 回転
                babyTrans.parent = rootObject.transform;    // ルートに入れる
                stairs.Add(baby);       // リストに加える
            }

            Refresh();
        }
         

        /// <summary>
        /// 階段として積み上げる Cube を作る。Prefabを渡さなかった場合のみ。
        /// </summary>
        /// <returns></returns>
        private GameObject CreateStair() {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localScale = new Vector3(stairWidthScale, stairHeightScale, stairDepthScale);
            cube.name = "Stair";
            return cube;
        }


        /// <summary>
        /// オブジェクトの親を作り、子(オブジェクト)を少しずらすことで、親の座標を軸としてオブジェクトが回転できるようにする。
        /// </summary>
        /// <param name="stair"></param>
        /// <returns></returns>
        private GameObject AdoptIntoPivot(GameObject stair) {
            GameObject pivotObject = new GameObject();
            pivotObject.name = "PivotObject";
            stair.transform.parent = pivotObject.transform;
            stair.transform.Translate(Vector3.right * horizontalDiffusitivity);
            return pivotObject;
        }


        private void Update() {
            // applyトグルにチェックが入ったら、インスペクタの値を反映させて、またチェックを外す。
            if (apply) { Refresh(); }
        }



        /// <summary>
        /// インスペクタの値を階段オブジェクトに反映する。エディタでの実行中に使う。
        /// </summary>
        private void Refresh() {
            if (stairs == null) { return; }
            for (int i = 0; i < stairs.Count; i++) {
                Transform trans = stairs[i].transform;
                Transform childTrans = trans.GetChild(0).transform;
                trans.localPosition = new Vector3(
                    trans.localPosition.x, stairHeightScale * i * verticalDiffusitivityScale, trans.localPosition.z);   // 階段の高さを参考にして縦方向の密度を調整する。
                childTrans.localScale = new Vector3(stairWidthScale, stairHeightScale, stairDepthScale);   // 階段のスケーリング。
                childTrans.Translate(horizontalDiffusitivity - childTrans.localPosition.x, 0, 0);      // 階段の水平方向の密度を反映する。
            }
            apply = false;
        }
    }
}