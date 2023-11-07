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
            RightSliser.value = RightSliser.maxValue;
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
            LeftSliser.value = LeftSliser.maxValue;
    }
    public void LeftTurnEnd()
    {
        LeftSliderObj.SetActive(false);
    }
    // Start is called before the first frame update

}
