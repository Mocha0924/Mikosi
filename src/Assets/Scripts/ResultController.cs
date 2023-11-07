using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultController : MonoBehaviour
{
    [SerializeField] private List<Button> buttons;
    [SerializeField]private int ButtonNum = 0;
    public enum ButtonType
    {
        Normal,
        Up,
        Down
    }
    public ButtonType buttonType = ButtonType.Normal;
    // Start is called before the first frame update
    void Update()
    {
        //L Stick
        float lsh = Input.GetAxis("Vertical");
        Debug.Log(lsh);
        if ((lsh >= 0.8f)&&buttonType == ButtonType.Normal&&ButtonNum>0)
        {
            ButtonNum--;
            buttonType = ButtonType.Up;
        }
        if ((lsh <= -0.8f) && buttonType == ButtonType.Normal && ButtonNum < buttons.Count-1)
        {
            ButtonNum++;
            buttonType = ButtonType.Down;
        }
        if ((lsh <= -0.8f) && buttonType == ButtonType.Up)
            buttonType = ButtonType.Normal;
        if ((lsh >= 0.8f) && buttonType == ButtonType.Down)
            buttonType = ButtonType.Normal;

        if (Input.GetKeyDown("joystick button 0"))
        {
            buttons[ButtonNum].onClick.Invoke();
        }
    }
}