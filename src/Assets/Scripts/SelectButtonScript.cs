using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectButtonScript : MonoBehaviour
{

    [SerializeField] Button[] Buttons;
    [SerializeField] GameObject cursor;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip SelctSound;
    int Button_Maxnum;
    int Button_Nownum;
    float lsh;

    public enum ButtonType
    {
        Normal,
        Up,
        Down
    }
    public enum input_or
    {
        Vertical,
        Horizontal
    }

    public ButtonType buttonType = ButtonType.Normal;
    public input_or input = input_or.Vertical;
    // Start is called before the first frame update
    void Start()
    {
        Button_Nownum = 0;
        Button_Maxnum = Buttons.Length;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (input == input_or.Vertical)
        {
            lsh = Input.GetAxis("Vertical");
        }
        else
        {
            lsh = -1 * Input.GetAxis("Horizontal");
        }


        if ((lsh >= 0.8f) && buttonType == ButtonType.Normal)
        {
            if (Button_Nownum > 0)
            {
                Button_Nownum--;
                buttonType = ButtonType.Up;
                cursor.transform.localPosition = Buttons[Button_Nownum].transform.localPosition;
                audioSource.PlayOneShot(SelctSound);

            }
            else
            {
                Button_Nownum = Button_Maxnum;
                buttonType = ButtonType.Down;
                cursor.transform.localPosition = Buttons[Button_Nownum].transform.localPosition;
                audioSource.PlayOneShot(SelctSound);
            }

        }
        if ((lsh <= -0.8f) && buttonType == ButtonType.Normal)
        {
            if (Button_Nownum < Button_Maxnum - 1)
            {
                Button_Nownum++;
                buttonType = ButtonType.Down;
                cursor.transform.localPosition = Buttons[Button_Nownum].transform.localPosition;
                audioSource.PlayOneShot(SelctSound);
            }
            else
            {
                Button_Nownum = 0;
                buttonType = ButtonType.Up;
                cursor.transform.localPosition = Buttons[Button_Nownum].transform.localPosition;
                audioSource.PlayOneShot(SelctSound);
            }
        }
        if ((lsh == 0) && buttonType == ButtonType.Up)
            buttonType = ButtonType.Normal;
        if ((lsh == 0) && buttonType == ButtonType.Down)
            buttonType = ButtonType.Normal;

        if (Input.GetKeyDown("joystick button 0"))
        {
            Buttons[Button_Nownum].onClick.Invoke();
        }

        if (Input.GetKeyDown("space"))
        {
            Buttons[Button_Nownum].onClick.Invoke();
        }


    }
}
