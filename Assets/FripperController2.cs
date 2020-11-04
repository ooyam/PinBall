using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController2 : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    int leftid = -1;
    int rightid = -2;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            // タッチ情報の取得
            foreach (Touch touch in Input.touches)
            {
                //画面左側をタップしたとき
                if (touch.phase == TouchPhase.Began && Input.mousePosition.x <= Screen.width / 2.0 && tag == "LeftFripperTag" && leftid == -1)
                {
                    SetAngle(this.flickAngle);
                    leftid = touch.fingerId;
                }
                //画面右側をタップしたとき
                if (touch.phase == TouchPhase.Began && Input.mousePosition.x >= Screen.width / 2.0 && tag == "RightFripperTag" && rightid == -2)
                {
                    SetAngle(this.flickAngle);
                    rightid = touch.fingerId;
                }
                
                //タップが離された時左フリッパーを元に戻す
                if (touch.phase == TouchPhase.Ended && leftid == touch.fingerId && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                    leftid = -1;
                }
                //タップが離された時右フリッパーを元に戻す
                if (touch.phase == TouchPhase.Ended && rightid == touch.fingerId && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                    rightid = -2;
                }
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}