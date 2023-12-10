using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject PlayerObj;
    [SerializeField] private player Player;
    [SerializeField] private MikosiAnimationController MikosiAnimator;
    [SerializeField] private Vector3 FrontPos;
    [SerializeField] private Vector3 RightPos;
    [SerializeField] private Vector3 LeftPos;
    [SerializeField] private Quaternion FrontAngle;
    [SerializeField] private Quaternion RightAngle;
    [SerializeField] private Quaternion LeftAngle;
    [SerializeField] private float speed;
    [SerializeField] private float Anglespeed;
    [SerializeField] private MikoshiCollisionDetection mikosiCollision;
    [SerializeField] private float adjustment;
    [SerializeField] private int ColumLimit;
    
    [SerializeField] private Vector3 BeforePos;
    [SerializeField] private Quaternion BeforeAngle;
    [SerializeField] private Vector3 ClearPos;
    [SerializeField] private Quaternion ClearAngle;
    [SerializeField] private float ClearSpeed;
    [SerializeField] private float ClearAngleSpeed;
    private bool Clear = false;
    private bool FoodHit = false;
    [SerializeField] private float HitNum;
    [SerializeField] private Vector3 LeftCarHitPos;
    [SerializeField] private Quaternion LeftCarHitAngle;
    [SerializeField] private Vector3 RightCarHitPos;
    [SerializeField] private Quaternion RightCarHitAngle;
    private bool LeftHit = false;
    private bool RightHit = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        if(mikosiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Before||Clear)
        {
            MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, BeforePos, speed);
            MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, BeforeAngle, Anglespeed);
        }

        else if (LeftHit)
        {
            MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, LeftCarHitPos, speed);
            MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, LeftCarHitAngle, Anglespeed);
        }
        else if (RightHit)
        {
            MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, RightCarHitPos, speed);
            MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, RightCarHitAngle, Anglespeed);
        }
        else
        {
            int Colum = ColumLimit < mikosiCollision.ColumnCount ? ColumLimit : mikosiCollision.ColumnCount;
            if (Player.turn_complete_R || Player.turn_complete_L|| MikosiAnimator.JumpCheck||FoodHit)
            {
                switch (Player.Angle)
                {
                    case player.playerType.Right:
                        MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, RightPos - new Vector3(0, 0, (Colum * adjustment) + (Player.forward_or_back_speed - 1) + 20), speed);
                        MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, RightAngle, Anglespeed); break;
                    case player.playerType.Left:
                        MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, LeftPos - new Vector3(0, 0, (Colum * adjustment) + (Player.forward_or_back_speed - 1) + 20), speed);
                        MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, LeftAngle, Anglespeed); break;
                    default:
                        MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, FrontPos - new Vector3(0, 0, (Colum * adjustment) + (Player.forward_or_back_speed - 1) + 20), speed);
                        MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, FrontAngle, Anglespeed); break;
                }
            }
          
            else
            {
                switch (Player.Angle)
                {
                    case player.playerType.Right:
                        MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, RightPos - new Vector3(0, 0, (Player.forward_or_back_speed - 1)), speed);
                        MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, RightAngle, Anglespeed); break;
                    case player.playerType.Left:
                        MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, LeftPos - new Vector3(0, 0, (Player.forward_or_back_speed - 1)), speed);
                        MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, LeftAngle, Anglespeed); break;
                    default:
                        MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, FrontPos - new Vector3(0, 0, (Player.forward_or_back_speed - 1)), speed);
                        MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, FrontAngle, Anglespeed); break;
                }
            }
            if (mikosiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Clear)
            {
                Clear = true;
               
            }
               
            


        }

    }
    public void FoodHitCamera()
    {
        FoodHit = true;
        Invoke("FinishFoodHitCamera", HitNum);
    }
    private void FinishFoodHitCamera()
    {
        FoodHit = false;
    }
    public void LeftHitCamer()
    {
        LeftHit = true;
        Invoke("FinisLeftHitCamera", HitNum);
    }
    private void FinisLeftHitCamera()
    {
        LeftHit = false;
    }
    public void RightHitCamer()
    {
        RightHit = true;
        Invoke("FinisRightHitCamera", HitNum);
    }
    private void FinisRightHitCamera()
    {
        RightHit = false;
    }
}
