//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using System.Collections;
using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEditor;

namespace Labo {
    /// <summary>
    /// 色名からColorを得るためのユーティリティ。Color はRGBAの値を0~1の間で、Color32は0~255の間で指定する。
    /// どちらも構造体。
    /// </summary>
    public class ColorPalette  : MonoBehaviour{
#region
        // Prefix: Pale , Light, Medium, Dark, Deep
        // LightPale, Pale, Light, Medium, Deep, Dark, DeepDark
        // Ash, Shadow, Bright, vivid


        public static Color32 TealBlue = new Color32(0, 255, 127, 255);

        public static Color32 SpringGreen = new Color32(0, 255, 63, 255);

        public static Color32 Green = new Color32(0, 255, 0, 255);

        public static Color32 UraniumGreen = new Color32(63, 255, 0, 255);

        public static Color32 ChartreuseGreen= new Color32(127, 255, 0, 255);

        public static Color32 LimeGreen = new Color32(191, 255, 0, 255);

        public static Color32 Yellow = new Color32(255, 255, 0, 255);
        
         public static Color32 Amber = new Color32(255, 191, 0, 255);

        //[[ KakiOrange ]]//
        //public static Color32 Pale = new Color32(, 255);
        //public static Color32 Ash = new Color32(, 255);
        //public static Color32 Light = new Color32(, 255);
        //public static Color32  = new Color32(, 255);
        public static Color32 KakiOrange = new Color32(255, 63, 0, 255);
        //public static Color32  = new Color32(, 255);
        public static Color32 Brown = new Color32(152, 38, 0, 255);
        //public static Color32  = new Color32(, 255);
        public static Color32 DarkBrown = new Color32(50, 12, 0, 255);

        //[[ Red ]]//
        public static Color32 PaleRed = new Color32(255, 204, 204, 255);
        //public static Color32 Ash = new Color32(, 255);
        public static Color32 SalmonPink = new Color32(255, 101, 101, 255);
        //public static Color32  = new Color32(, 255);
        public static Color32 Red = new Color32(255, 0, 0, 255);
        //public static Color32  = new Color32(, 255);
        public static Color32 DarkRed = new Color32(152, 0, 0, 255);
        //public static Color32  = new Color32(, 255);
        //public static Color32 Black = new Color32(, 255);

        public static Color32 Crimson = new Color32(255, 0, 63, 255);

        public static Color32 RedPink = new Color32(255, 0, 127, 255);

        public static Color32 Pink = new Color32(255, 0, 191, 255);

        public static Color32 PurplePink = new Color32(255, 0, 255, 255);

        public static Color32 Purple = new Color32(191, 0, 255, 255);

        public static Color32 PurpleBlue = new Color32(127, 0, 255, 255);

        public static Color32 Indigo = new Color32(63, 0, 255, 255);

        public static Color32 Blue = new Color32(0,0,255, 255);

        public static Color32 Cerulean = new Color32(0, 63, 255, 255);

        public static Color32 SkyBlue = new Color32(0,127,255, 255);

        public static Color32 Turquoise = new Color32(0, 191, 255, 255);

        //[[ Cyan ]]//
        public static Color32 PaleCyan = new Color32(0, 50, 50, 255);
        //public static Color32 Ash = new Color32(, 255);
        //public static Color32 Light = new Color32(, 255);
        //public static Color32  = new Color32(, 255);
        public static Color32 Cyan = new Color32(0, 255, 255, 255);
        //public static Color32  = new Color32(, 255);
        //public static Color32 Dark = new Color32(, 255);
        //public static Color32  = new Color32(, 255);
        //public static Color32 Black = new Color32(, 255);

        public static Color32 PaleGrey = new Color32(229,229,229, 255);
        public static Color32 AshGrey = new Color32(204, 204, 204, 255);
        public static Color32 LightGrey = new Color32(178,178,178, 255);
        //public static Color32  = new Color32(, 255);
        public static Color32 Grey = new Color32(127, 127, 127, 255);
        //public static Color32  = new Color32(, 255);
        public static Color32 DarkGrey = new Color32(76, 76, 76, 255);
        public static Color32 CharcoalGrey = new Color32(50, 50, 50, 255);
        public static Color32 BlackGrey = new Color32(25, 25, 25, 255);

        public static Color32 White = new Color32(255, 255, 255, 255);
        public static Color32 Black = new Color32(0, 0, 0, 255);


        //public static Color32  = new Color32(, 255);

        //[[  ]]//
        //public static Color32 Pale = new Color32(, 255);
        //public static Color32 Ash = new Color32(, 255);
        //public static Color32 Light = new Color32(, 255);
        //public static Color32  = new Color32(, 255);
        //public static Color32 Normal = new Color32(, 255);
        //public static Color32  = new Color32(, 255);
        //public static Color32 Dark = new Color32(, 255);
        //public static Color32  = new Color32(, 255);
        //public static Color32 Black = new Color32(, 255);
#endregion

        private void Start() {
           
        }

        /// <summary>
        /// 0~255 での色表記を 0~1.0f の表記に変換する。
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        private Color CreateRGBA(float r, float g, float b, float a) {
            float scale = 255.00f;
            r /= scale;
            g /= scale;
            b /= scale;
            a /= scale;
            return new Color(r, g, b, a);
        }

        private void OnDrawGizmos() {
            if (EditorApplication.isPlaying == false) { return; }
            Gizmos.color = Red;
            Gizmos.DrawCube(Vector3.zero, Vector3.one);
        }
    }
}