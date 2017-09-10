//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;


namespace Labo
{
    public class ButtonTester : MonoBehaviour
    {
        private Text buttonText;
        private bool toggle = false;


        private void Start() {
            buttonText = GetComponentInChildren<Text>();
        }


        public void SwitchText()  {
            toggle = !toggle;

            if (toggle) {
                buttonText.text = "Pressed";
            } else {
                buttonText.text = "Button";
            }
            
        }
    }
}