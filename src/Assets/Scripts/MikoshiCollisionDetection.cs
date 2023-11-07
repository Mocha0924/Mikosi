using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
public class MikoshiCollisionDetection : MonoBehaviour
{
    public int clearConditions;
    [SerializeField] GameObject AfterPeople;
    [SerializeField] GameObject[] aPeopleParents;
    [SerializeField] GameObject aPeopleParent;
    [SerializeField] GameObject Parents;

    [SerializeField] int touchFoodDecrPeople;
    public int peopleCount;
    public bool isFever;
    [SerializeField] private float BonusTime;

    [SerializeField] int scaleCorrection;
    public int behindPeopleCount;
    int behindPeopleRow;
    int behindMax;
    int behind0Max;

    Vector3 pos;
    Vector3 parentPos;

    private AudioSource m_audioSource;
    [SerializeField] private AudioSource MainBGMAudio;
    [SerializeField] private AudioSource BonusBGMAudio;
    [SerializeField] private AudioSource ClearBGMAudio;
    [SerializeField] private AudioSource GameoverBGMAudio;
    public int ColumnCount = 0;

    [SerializeField] private AudioClip PeopleRecoverySound;
    [SerializeField] private AudioClip SubSound;
    [SerializeField] private AudioClip FoodHitSound;
    [SerializeField] private AudioClip StartSound;

    [SerializeField] private GameObject ClearResult;
    [SerializeField] private GameObject GameoverResult;
    [SerializeField] private GameObject Wait;
    [SerializeField] private GameObject BeforePlay;
    [SerializeField] private GameObject PeopleNum;
    [SerializeField]private TextMeshProUGUI WaitText;
    [SerializeField] public TextMeshProUGUI PeopleNumText;
    [SerializeField] private int MaxWaitTime;
    public enum PlayerMode
    { 
        Before,
        Wait,
        Play,
        Bonus,
        Clear,
        Gameover
    }

    public PlayerMode playerMode = PlayerMode.Before;


    // Start is called before the first frame update
    void Start()
    {
        PeopleNumText.text = 0.ToString("000")+"人神輿";
        m_audioSource = GetComponent<AudioSource>();
        peopleCount = 6;
        AfterPeople.transform.localPosition = Vector3.zero;

        isFever = false;

        pos = new Vector3(0.0f, -0.25f, 0.0f);
        parentPos = new Vector3(0.0f, -0.25f, 0.0f);
        behindPeopleCount = 0;
        behindPeopleRow = 0;
        behindMax = 9;
        behind0Max = 12;
        //人の列の親生成
        GenerateParent(0);
    }

    private void Update()
    {
        if (Input.anyKeyDown&&playerMode == PlayerMode.Before)
            WaitStart();
    }

    //神輿との判定
    void OnTriggerEnter(Collider other)
    {
        //人との接触
        if (other.gameObject.tag == "People")
        {
            m_audioSource.PlayOneShot(PeopleRecoverySound);
            Debug.Log("People Touch");

            peopleCount++;
            PeopleNumText.text = (peopleCount-6).ToString("000") + "人神輿";
            behindPeopleCount = peopleCount - 18;
            if (behindPeopleCount % 9 == 1)
            {
                //列に9人いる時、列を増やす
                GenerateParent(1);
            }

            Destroy(other.gameObject);

            Debug.Log(peopleCount);

            //人の生成
            GenerateMikoshiPeople();

            if (peopleCount-6 >= clearConditions&& isFever == false)
            {
                isFever = true;
                FeverTime();
            }
        }
    }

    public void WaitStart()
    {
        PeopleNum.SetActive(true); 
        BeforePlay.SetActive(false);
        playerMode = PlayerMode.Wait;
        Wait.SetActive(true);
        WaitText.text = MaxWaitTime.ToString("0");
        StartCoroutine("WaitGame");
    }
    public void FeverTime()
    {
        Debug.Log("Fever");
        playerMode = PlayerMode.Bonus;
        MainBGMAudio.Stop();
        BonusBGMAudio.Play();
        StartCoroutine("GameClear");
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        MainBGMAudio.Stop();
        GameoverBGMAudio.Play();
        playerMode = PlayerMode.Gameover;
        GameoverResult.SetActive(true);
    }

    public void GameStart()
    {
        MainBGMAudio.Play();
        m_audioSource.PlayOneShot(StartSound);
        playerMode = PlayerMode.Play;
        Wait.SetActive(false);
    }
    private IEnumerator WaitGame()
    {
        Debug.Log("wait");
        for (int WaitTime = 0;WaitTime < MaxWaitTime;WaitTime++)
        {
            m_audioSource.PlayOneShot(SubSound);
            WaitText.text = (MaxWaitTime-WaitTime).ToString("0");
            yield return new WaitForSeconds(1);
        }
        GameStart();
    }
    private IEnumerator GameClear()
    {
        yield return new WaitForSeconds(BonusTime);
        BonusBGMAudio.Stop();
        ClearBGMAudio.Play();
        ClearResult.SetActive(true);
        playerMode = PlayerMode.Clear;
        PeopleNum.SetActive(false);
    }

    public void GenerateParent(float initCorre)
    {
        ColumnCount++;
        int childCount = Parents.transform.childCount;
        Array.Resize(ref aPeopleParents, aPeopleParents.Length + 1);
        parentPos.z = initCorre * (-0.7f - 0.6f * childCount);

        GameObject cloneParent = Instantiate(aPeopleParent, Vector3.zero, Quaternion.identity);
        cloneParent.name = "Parent" + childCount;
        cloneParent.transform.parent = Parents.transform;
        cloneParent.transform.localPosition = parentPos;
        cloneParent.transform.localRotation = Quaternion.identity;

        aPeopleParents[childCount] = cloneParent;
    }

    void DestroyParent()
    {
        ColumnCount--;
        int childCount = Parents.transform.childCount - 1;

        Destroy(Parents.transform.GetChild(childCount).gameObject);

        Array.Resize(ref aPeopleParents, aPeopleParents.Length - 1);
    }

    //人の生成
    public void GenerateMikoshiPeople()
    {
        pos = Vector3.zero;

        //神輿の周りの人
        if (peopleCount > 6 && peopleCount <= 18)
        {
            if (peopleCount > 6 && peopleCount <= 12)
            {
                if (peopleCount % 2 == 0) { pos.x = -1.6f * scaleCorrection; }
                else { pos.x = 1.6f * scaleCorrection; }
            }
            else if (peopleCount > 12 && peopleCount <= 18)
            {
                if (peopleCount % 2 == 0) { pos.x = -2.2f * scaleCorrection; }
                else { pos.x = 2.2f * scaleCorrection; }
            }

            if (peopleCount == 7 || peopleCount == 8 ||
                peopleCount == 13 || peopleCount == 14) { pos.z = 0.5f * scaleCorrection; }
            else if (peopleCount == 9 || peopleCount == 10 ||
                peopleCount == 15 || peopleCount == 16) { pos.z = -0.1f * scaleCorrection; }
            else { pos.z = -0.75f * scaleCorrection; }
        }
        //神輿の後ろの人
        else if (peopleCount > 18)
        {
            behindPeopleCount = peopleCount - 18;

            behindPeopleRow = (behindPeopleCount - 1) / 9 + 1;

            switch (behindPeopleCount % 9)
            {
                case 1:
                    pos.x = 0f * scaleCorrection;
                    break;

                case 2:
                    pos.x = 0.6f * scaleCorrection;
                    break;

                case 3:
                    pos.x = -0.6f * scaleCorrection;
                    break;

                case 4:
                    pos.x = 1.2f * scaleCorrection;
                    break;

                case 5:
                    pos.x = -1.2f * scaleCorrection;
                    break;

                case 6:
                    pos.x = 1.8f * scaleCorrection;
                    break;

                case 7:
                    pos.x = -1.8f * scaleCorrection;
                    break;

                case 8:
                    pos.x = 2.4f * scaleCorrection;
                    break;

                case 0:
                    pos.x = -2.4f * scaleCorrection;
                    break;
            }
        }
        var parent = aPeopleParents[behindPeopleRow].transform;

        AfterPeople.name = peopleCount.ToString();
        AfterPeople.transform.position = pos;
        Instantiate(AfterPeople, parent);
    }

    //食べ物との衝突
    public void FoodTouch()
    {
        Debug.Log("Food Touch");
        if(playerMode == PlayerMode.Play)
        {
            m_audioSource.PlayOneShot(FoodHitSound);
            int childCount = aPeopleParents[behindPeopleRow].transform.childCount, rl;
            Vector3 destroyObj = Vector3.zero;

            for (int i = 0; i < touchFoodDecrPeople; i++)
            {
                if (childCount % 2 == 0) { rl = 1; }
                else { rl = -1; }

                if (peopleCount > 18)
                {
                    destroyObj.x = 0.6f * (childCount / 2) * rl * scaleCorrection;
                    destroyObj.z = 0.0f;
                }
                else
                {
                    if (peopleCount > 6 && peopleCount <= 12)
                    {
                        if (peopleCount % 2 == 0) { destroyObj.x = -1.6f * scaleCorrection; }
                        else { destroyObj.x = 1.6f * scaleCorrection; }
                    }
                    else if (peopleCount > 12 && peopleCount <= 18)
                    {
                        if (peopleCount % 2 == 0) { destroyObj.x = -2.2f * scaleCorrection; }
                        else { destroyObj.x = 2.2f * scaleCorrection; }
                    }

                    if (peopleCount == 7 || peopleCount == 8 ||
                        peopleCount == 13 || peopleCount == 14) { destroyObj.z = 0.5f * scaleCorrection; }
                    else if (peopleCount == 9 || peopleCount == 10 ||
                        peopleCount == 15 || peopleCount == 16) { destroyObj.z = -0.1f * scaleCorrection; }
                    else { destroyObj.z = -0.75f * scaleCorrection; }
                }

                if (peopleCount > 6)
                {
                    for (int j = 0; j < childCount; j++)
                    {
                        Transform childTransform = aPeopleParents[behindPeopleRow].transform.GetChild(j);
                        Vector3 childObj = childTransform.localPosition;

                        //Debug.Log("destroyObj:" + destroyObj);
                        //Debug.Log("childObj" + childObj);

                        if (childObj == destroyObj)
                        {
                            Destroy(aPeopleParents[behindPeopleRow].transform.GetChild(j).gameObject);
                            peopleCount--;
                            childCount--;
                            break;
                        }
                    }

                    //子が0になったら1つ前の親に
                    if (childCount == 0)
                    {
                        if (behindPeopleRow > 0) { behindPeopleRow--; }
                        if (behindPeopleRow == 0) { childCount = behind0Max; }
                        else { childCount = behindMax; }

                        DestroyParent();
                    }
                }
                else
                {
                    GameOver();
                    break;
                }
            }
        PeopleNumText.text = (peopleCount - 6).ToString("000") + "人神輿";
        Debug.Log("peopleCount:" + peopleCount);
        }
       
    }

    public void RightHit()
    {
        Debug.Log("右側");

        bool isR = true;

        int decrCount = 0;

        DecrPeople(isR, ref decrCount);

        //減った部分に後ろから人を補充する
        for (int i = behindPeopleRow; i >= 0; i--)
        {
            int childCount = aPeopleParents[behindPeopleRow].transform.childCount, rl;
            Vector3 moveObj = Vector3.zero;
            GameObject moveObject = null;
            int moveRow = 0, moveChild = 0;
            bool isFirst = true;

            for (int j = 0; j < childCount; j++)
            {
                Transform childTransform = aPeopleParents[i].transform.GetChild(j);
                Vector3 compaObj = childTransform.localPosition;

                //各列最初の対応するオブジェクトの場合はそれを保存、それ以降は保存してある座標より外側かどうか判定
                if (isFirst == true)
                {
                    if ((isR == false) && (compaObj.x >= 1.2f * scaleCorrection) ||
                    (isR == true) && (compaObj.x <= -1.2f * scaleCorrection))
                    {
                        moveRow = behindPeopleRow;
                        moveChild= j;
                        moveObject = aPeopleParents[moveRow].transform.GetChild(moveChild).gameObject;
                    }
                }
                else
                {

                }
            }

            AfterPeopleMoveScript afterPeopleMoveScript = moveObject.GetComponent<AfterPeopleMoveScript>();
            afterPeopleMoveScript.Move(moveObj);

        }
    }

    public void LeftHit()
    {
        Debug.Log("左側");

        bool isR = false;

        int decrCount = 0;

        DecrPeople(isR, ref decrCount);
    }

    void DecrPeople(bool isR, ref int decrCount)
    {
        for (int i = behindPeopleRow; i >= 0; i--)
        {
            int childCount = aPeopleParents[i].transform.childCount;

            for (int j = 0; j < childCount; j++)
            {
                Transform childTransform = aPeopleParents[i].transform.GetChild(j);
                Vector3 childObj = childTransform.localPosition;

                float x = childObj.x;

                if ((isR == true) && (x >= 1.2f * scaleCorrection) || 
                    (isR == false) && (x <= -1.2f * scaleCorrection))
                {
                    Destroy(aPeopleParents[i].transform.GetChild(j).gameObject);
                    peopleCount--;
                    decrCount++;
                }
            }
        }
        Debug.Log("peopleCount:" + peopleCount);
        Debug.Log("decrCount:" + decrCount);
    }
}
