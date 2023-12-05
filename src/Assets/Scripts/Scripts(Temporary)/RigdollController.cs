using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigdollController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody[] rBody;
    void Start()
    {
        //自身が持つリジッドボディを全て配列に格納
        rBody = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody RB in rBody)
        {
            RB.isKinematic = true;
        }
    }
    private void Update()
    {
        if(Input.anyKeyDown)
        {
            if(rBody[0].isKinematic == true)
            {
                SetRagDoll(false);
            }
            else
                SetRagDoll(true);
        }
    }
    //ラグドールのオン・オフ関数
    void SetRagDoll(bool on_off)
    {
        //rBody配列内のリジッドボディ全てのisKinematicを切り替える
        foreach (Rigidbody RB in rBody)
        {
            RB.isKinematic = on_off;
        }
    }
}
