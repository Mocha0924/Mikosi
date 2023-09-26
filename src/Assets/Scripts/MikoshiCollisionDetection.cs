using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikoshiCollisionDetection : MonoBehaviour
{
    [SerializeField] int peopleCount;
    [SerializeField] int clearConditions;
    [SerializeField] bool isFever;
    [SerializeField] GameObject AfterPeople;
    int behindPeopleCount;
    int behindPeopleRow;
    bool isSpawn;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        peopleCount = 6;
        AfterPeople.transform.localPosition = Vector3.zero;

        clearConditions = 100;
        isFever = false;

        behindPeopleCount = 0;
        behindPeopleRow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFever == false && peopleCount >= clearConditions)
        {
            isFever = true;
            FeverTime();
        }
    }

    //神輿と人の当たり判定(人と当たった時に人を増やす)
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "People")
        {
            peopleCount++;
            Destroy(other.gameObject);
            //Debug.Log("People Touch");
            Debug.Log(peopleCount);

            var parent = this.transform;

            pos = Vector3.zero;
            pos.y += -0.25f;

            //人の生成
            //神輿担ぐ人の隣に置く人
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
            //神輿の後ろに付く人
            else if (peopleCount > 18 && peopleCount <= clearConditions)
            {
                behindPeopleCount = peopleCount - 18;

                if (behindPeopleCount % 9 == 1) { behindPeopleRow++; }

                pos.x = -0.7f - 0.6f * behindPeopleRow;

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

            AfterPeople.transform.localPosition = pos;
            Instantiate(AfterPeople, parent);
            Debug.Log(AfterPeople.transform.localPosition);
        }
    }

    void FeverTime()
    {
        Debug.Log("Fever");
    }
}
