using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikoshiCollisionDetection : MonoBehaviour
{
    [SerializeField] int clearConditions;
    [SerializeField] GameObject AfterPeople;
    [SerializeField] GameObject aPeopleParent;

    [SerializeField] int touchFoodDecrPeople;
    [SerializeField] int peopleCount;
    [SerializeField] bool isFever;

    int behindPeopleCount;
    int behindPeopleRow;
    bool isSpawn;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        peopleCount = 6;
        AfterPeople.transform.localPosition = Vector3.zero;

        isFever = false;

        behindPeopleCount = 0;
        behindPeopleRow = 0;
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

        //食べ物との接触
        if (other.gameObject.tag == "Food")
        {
            Debug.Log("Food Touch");

            Destroy(other.gameObject);

            for (int i = 0; i < touchFoodDecrPeople; i++)
            {
                if (peopleCount > 6)
                {
                    Destroy(aPeopleParent.transform.GetChild(peopleCount - 7).gameObject);
                    peopleCount--;
                }
            }
        }
    }

    void FeverTime()
    {
        Debug.Log("Fever");
    }

    void GenerateMikoshiPeople()
    {
        var parent = aPeopleParent.transform;

        pos = Vector3.zero;
        pos.y += -0.25f;

        //神輿の周りの人
        if (peopleCount > 6 && peopleCount <= 18)
        {
            if (peopleCount > 6 && peopleCount <= 12)
            {
                if (peopleCount % 2 == 0) { pos.z = -1.4f; }
                else { pos.z = 1.4f; }
            }
            else if (peopleCount > 12 && peopleCount <= 18)
            {
                if (peopleCount % 2 == 0) { pos.z = -2.0f; }
                else { pos.z = 2.0f; }
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

            behindPeopleRow = (behindPeopleCount - 1) / 9;

            pos.x = -1.3f - 0.6f * behindPeopleRow;

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

        AfterPeople.name = peopleCount.ToString();
        AfterPeople.transform.position = pos;
        Instantiate(AfterPeople, parent);
    }
}
