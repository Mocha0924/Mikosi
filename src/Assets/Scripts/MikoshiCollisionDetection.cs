using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikoshiCollisionDetection : MonoBehaviour
{
    [SerializeField] int clearConditions;
    [SerializeField] GameObject AfterPeople;
    [SerializeField] GameObject[] aPeopleParents;
    [SerializeField] GameObject aPeopleParent;

    [SerializeField] int touchFoodDecrPeople;
    [SerializeField] int peopleCount;
    [SerializeField] bool isFever;

    int behindPeopleCount;
    int behindPeopleRow;
    int rowMax;
    int behindMax;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        peopleCount = 6;
        AfterPeople.transform.localPosition = Vector3.zero;

        isFever = false;

        pos = new Vector3(0.0f, -0.25f, 0.0f);
        behindPeopleCount = 0;
        behindPeopleRow = 0;
        behindMax = 9;
        rowMax = (clearConditions - 18) / 9;
        if ((clearConditions - 18) % 9 != 0) { rowMax++; }
        aPeopleParents= new GameObject[rowMax];

        //人の列の親生成
        for (int i = 0; i < rowMax; i++)
        {
            GameObject cloneParent = Instantiate(aPeopleParent, Vector3.zero, Quaternion.identity);
            cloneParent.name = "Parent" + i;
            cloneParent.transform.parent = this.transform;
            cloneParent.transform.localPosition = pos;
            cloneParent.transform.localRotation = Quaternion.identity;

            pos.x = -1.3f - 0.6f * i;
            aPeopleParents[i] = cloneParent;
        }
    }

    //神輿との判定
    void OnTriggerEnter(Collider other)
    {
        //人との接触
        if (other.gameObject.tag == "People")
        {
            Debug.Log("People Touch");

            peopleCount++;
            Destroy(other.gameObject);

            Debug.Log(peopleCount);

            //人の生成
            GenerateMikoshiPeople();

            if (peopleCount >= clearConditions&& isFever == false)
            {
                isFever = true;
                FeverTime();
            }
        }
    }

    void FeverTime()
    {
        Debug.Log("Fever");
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    //人の生成
    void GenerateMikoshiPeople()
    {
        pos = Vector3.zero;

        //神輿の周りの人
        if (peopleCount > 6 && peopleCount <= 18)
        {
            if (peopleCount > 6 && peopleCount <= 12)
            {
                if (peopleCount % 2 == 0) { pos.z = -1.6f; }
                else { pos.z = 1.6f; }
            }
            else if (peopleCount > 12 && peopleCount <= 18)
            {
                if (peopleCount % 2 == 0) { pos.z = -2.2f; }
                else { pos.z = 2.2f; }
            }

            if (peopleCount == 7 || peopleCount == 8 ||
                peopleCount == 13 || peopleCount == 14) { pos.x = 0.5f; }
            else if (peopleCount == 9 || peopleCount == 10 ||
                peopleCount == 15 || peopleCount == 16) { pos.x = -0.1f; }
            else { pos.x = -0.75f; }
        }
        //神輿の後ろの人
        else if (peopleCount > 18 && peopleCount <= clearConditions)
        {
            behindPeopleCount = peopleCount - 18;

            behindPeopleRow = (behindPeopleCount - 1) / 9 + 1;

            switch (behindPeopleCount % 9)
            {
                case 1:
                    pos.z = 0f;
                    break;

                case 2:
                    pos.z = 0.6f;
                    break;

                case 3:
                    pos.z = -0.6f;
                    break;

                case 4:
                    pos.z = 1.2f;
                    break;

                case 5:
                    pos.z = -1.2f;
                    break;

                case 6:
                    pos.z = 1.8f;
                    break;

                case 7:
                    pos.z = -1.8f;
                    break;

                case 8:
                    pos.z = 2.4f;
                    break;

                case 0:
                    pos.z = -2.4f;
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

        int childCount = aPeopleParents[behindPeopleRow].transform.childCount - 1;

        for (int i = 0; i < touchFoodDecrPeople; i++)
        {
            if (peopleCount > 6)
            {
                Debug.Log("childCount:"+childCount);

                Destroy(aPeopleParents[behindPeopleRow].transform.GetChild(childCount).gameObject);
                peopleCount--;
                Debug.Log(peopleCount);
                if (childCount == 0) 
                { 
                    if(behindPeopleRow>0) { behindPeopleRow--; }
                    if(behindPeopleRow==0) { childCount = 11; }
                    else { childCount = behindMax - 1; }
                }
                else { childCount--; }
            }
        }
    }

    public void RightHit()
    {
        Debug.Log("右側");

        int decrCount = 0;

        for (int i = behindPeopleRow; i >= 0; i--)
        {
            int childCount = aPeopleParents[i].transform.childCount;

            for (int j = 0; j < childCount; j++)
            {
                Transform childTransform = aPeopleParents[i].transform.GetChild(j);
                Vector3 childObj = childTransform.localPosition;

                float z = childObj.z;

                if (z <= -1.2f)
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

    public void LeftHit()
    {
        Debug.Log("左側");

        int decrCount = 0;

        for (int i = behindPeopleRow; i >= 0; i--)
        {
            int childCount = aPeopleParents[i].transform.childCount;

            for (int j = 0; j < childCount; j++)
            {
                Transform childTransform = aPeopleParents[i].transform.GetChild(j);
                Vector3 childObj = childTransform.localPosition;

                float z = childObj.z;

                if (z >= 1.2f)
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
