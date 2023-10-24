using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject PlayerObj;
    [SerializeField] private player Player;
    [SerializeField] private Vector3 FrontPos;
    [SerializeField] private Vector3 RightPos;
    [SerializeField] private Vector3 LeftPos;
    [SerializeField] private Quaternion FrontAngle;
    [SerializeField] private Quaternion RightAngle;
    [SerializeField] private Quaternion LeftAngle;
    [SerializeField] private float speed;
    [SerializeField] private float Anglespeed;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (Player.Angle)
        {
            case player.playerType.Right:MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, RightPos, speed);
                MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, RightAngle, Anglespeed); break;
            case player.playerType.Left:MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, LeftPos, speed);
                MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, LeftAngle, Anglespeed); break;
            default: MainCamera.transform.localPosition = Vector3.Lerp(MainCamera.transform.localPosition, FrontPos, speed);
                MainCamera.transform.localRotation = Quaternion.Lerp(MainCamera.transform.localRotation, FrontAngle, Anglespeed); break;
        }
        
    }
}