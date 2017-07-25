//using UnityEngine.SceneManagement;
//using UnityEngine.Networking; // (needs NetworkBehaviour)
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;
using System;


namespace Labo
{
    public class EasyTimer 
    {
        public float PassedTime { get; private set; }
        public float IntervalSecond { get; set; }
        public bool Running { get; private set; }
        public bool HasTimeCome { get; private set; }

        private float lastEventTime = 0.00f;


        public EasyTimer(float intervalSecond = 1.00f)
        {
            PassedTime = 0.00f;
            this.IntervalSecond = intervalSecond;
            Running = true;
        }


        public void Restart(float intervalSecond = 1.00f)
        {
            this.IntervalSecond = intervalSecond;
            Running = true;
        }


        public void Stop()
        {
            Running = false;
        }


        // ここで bool を返して、利用側のコードを簡略化するという手もなくはない。
        public void Update()
        {
            if (Running == false) { return; }

            // 条件を満たすフレームになったあと、再び呼ばれたら通知を破棄。
            if (HasTimeCome) { HasTimeCome = false; }

            PassedTime += Time.deltaTime;
            
            if (PassedTime > lastEventTime + IntervalSecond)
            {
                // この処理が行われて、再び Update が呼ばれるまでの間のみ結果が true となる
                HasTimeCome = true;
                lastEventTime = PassedTime;
            }
        }
    }
}