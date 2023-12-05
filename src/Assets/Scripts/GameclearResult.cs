using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameclearResult : MonoBehaviour
{
    [SerializeField] private List<Button> buttons;
    [SerializeField] private int ButtonNum;
    [SerializeField] private GameObject Select;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip SelctSound;

    public enum ButtonType
    {
        Normal,
        Up,
        Down
    }

    public ButtonType buttonType = ButtonType.Normal;

    private void Start()
    {
        ButtonNum = 2;
    }
    // Start is called before the first frame update
    void Update()
    {
        //L Stick
        float lsh = Input.GetAxis("Horizontal");
        Debug.Log(lsh);



        if ((lsh >= 0.8f) && buttonType == ButtonType.Normal && ButtonNum > 0)
        {
            ButtonNum--;
            buttonType = ButtonType.Up;
            Select.transform.localPosition += new Vector3(650, 0, 0);
            audioSource.PlayOneShot(SelctSound);

        }
        if ((lsh <= -0.8f) && buttonType == ButtonType.Normal && ButtonNum < buttons.Count - 1)
        {
            ButtonNum++;
            buttonType = ButtonType.Down;
            Select.transform.localPosition += new Vector3(-650, 0, 0);
            audioSource.PlayOneShot(SelctSound);
        }
        if ((lsh == 0) && buttonType == ButtonType.Up)
            buttonType = ButtonType.Normal;
        if ((lsh == 0) && buttonType == ButtonType.Down)
            buttonType = ButtonType.Normal;

        if (Input.GetKeyDown("joystick button 0"))
        {
            buttons[ButtonNum].onClick.Invoke();
        }
    }
}