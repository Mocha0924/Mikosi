using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private player Player;
    [SerializeField] private Vector3 FrontPos;
    [SerializeField] private Vector3 RightPos;
    [SerializeField] private Vector3 LeftPos;
    [SerializeField] private float speed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //switch (Player.Angle)
        //{
        //    case player.playerType.Right: MainCamera.transform.localPosition = Vector3.MoveTowards(transform.position,RightPos, speed * Time.deltaTime); ; break;
        //    case player.playerType.Left: MainCamera.transform.localPosition = Vector3.MoveTowards(transform.position, LeftPos, speed * Time.deltaTime); break;
        //    default: MainCamera.transform.localPosition = Vector3.MoveTowards(transform.position, FrontPos, speed * Time.deltaTime); break;
        //}
    }
}
