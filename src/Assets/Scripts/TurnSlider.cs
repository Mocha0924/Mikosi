using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSlider : MonoBehaviour
{
    [SerializeField] private GameObject RightSliderObj;
    [SerializeField] private GameObject LeftSliderObj;
    [SerializeField] private MikoshiCollisionDetection MikosiCollision;
    public Slider RightSliser;
    public Slider LeftSliser;
    public TurnStick turnStick;
    public EndCorner endCorner;
    public int TurnTime_CompleteEnd;
    public void RightTurn()
    {
        RightSliderObj.SetActive(true);
        RightSliser.value = 0;
        RightSliser.maxValue = TurnTime_CompleteEnd;
        if (MikosiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Bonus)
        {
            RightSliser.value = RightSliser.maxValue;
            RightSliderObj.SetActive(false);
        }
          
       
    }
    public void RightTurnEnd()
    {
        RightSliderObj.SetActive(false);
    }
    public void LeftTurn()
    {
        LeftSliderObj.SetActive(true);
        LeftSliser.value = 0;
        LeftSliser.maxValue = TurnTime_CompleteEnd;
        if (MikosiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Bonus)
        {
            LeftSliser.value = LeftSliser.maxValue;
            LeftSliderObj.SetActive(false);
        }
           
    }
    public void LeftTurnEnd()
    {
        LeftSliderObj.SetActive(false);
    }
    private void Update()
    {
        if (MikosiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Bonus
            || MikosiCollision.playerMode == MikoshiCollisionDetection.PlayerMode.Clear)
        {
            if(RightSliser.enabled == true)
            {
                RightSliser.value = RightSliser.maxValue;
                RightSliderObj.SetActive(false);
            }
            if(LeftSliser.enabled == true)
            {
                LeftSliser.value = LeftSliser.maxValue;
                LeftSliderObj.SetActive(false);
            }
           
        }
    }
    // Start is called before the first frame update

}
