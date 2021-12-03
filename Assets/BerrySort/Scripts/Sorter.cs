using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Berries;

public class Sorter : MonoBehaviour
{

    // --- Control ---
    bool move = false;
    // --- Animation ---
    float elapsed = 0f;
    public float backwardsMomentum;
    public float forwardMomentun;
    public float speed;
    public Transform endPoint;
    public GameObject piston;
    public Transform startPoint;
    public Transform destination;

    public int moveFactor;

    // --- Result Computation ---

    // A Good Berries - Correctly let through (Trait: 1 Classification: 1)
    private int correctPositive;

    // B Bad Berries - Correctly Sorted (Trait: 0 Classification: 0)
    private int correctNegative;

    // C Bad Berries - Falsly let through Sorted (Trait: 0 Classification: 1)
    private int falsePositive;

    // D Good Berries - Falsly Sorted  (Trait: 1 Classification: 0)
    private int falseNegative;

    private float currentRatio = 0;

    public int goalAmount = 100;
    private float GoldRatio = 0.90f;
    private float SilverRatio = 0.80f;
    private float BronzeRatio = 0.70f;



    private List<int> berryList;

    public GameObject goalScreenText;
    public GameObject currentRatioText;
    public GameObject correctPositiveText;
    public GameObject correctNegativeText;
    public GameObject falseNegativeText;
    public GameObject falsePositiveText;

    public GameObject GoldTrophy;
    public GameObject SilverTrophy;
    public GameObject BronzeTrophy;

    public GameObject GoldText;
    public GameObject SilverText;

    public GameObject BronzeText;


    public GameObject Progress;


    // Start is called before the first frame update
    void Start()
    {
        this.goalScreenText.GetComponent<TextMesh>().text = this.GoldRatio * 100 + "%";

        this.correctNegative = 0;
        this.correctPositive = 0;
        this.falsePositive = 0;
        this.falseNegative = 0;

        this.berryList = new List<int>();


        this.GoldText.GetComponent<TextMesh>().text = (string)"" + this.GoldRatio * 100 + "%";
        this.SilverText.GetComponent<TextMesh>().text = (string)"" + this.SilverRatio * 100 + "%";
        this.BronzeText.GetComponent<TextMesh>().text = (string)"" + this.BronzeRatio * 100 + "%";

        this.GoldTrophy.GetComponent<Renderer>().enabled = false;
        this.SilverTrophy.GetComponent<Renderer>().enabled = false;
        this.BronzeTrophy.GetComponent<Renderer>().enabled = false;


        this.move = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (piston.transform.position.z == endPoint.position.z && piston.transform.position.z != startPoint.position.z)
        {
            move = false;
        }

        if (move)
        {
            piston.transform.position = Vector3.MoveTowards(piston.transform.position, endPoint.position, forwardMomentun * Time.deltaTime);
        }
        if (!move)
        {
            piston.transform.position = Vector3.MoveTowards(piston.transform.position, startPoint.position, backwardsMomentum * Time.deltaTime);
        }


    }

    void OnTriggerEnter(Collider other)
    {

        {
            var berry = (Berry)other.gameObject.GetComponent<Berry>();

            if (berry.classification == 0)
            {
                this.move = true;
                var berryGameObject = other.gameObject;
                var target = destination.position - berryGameObject.transform.position;
                var normalized = target.normalized * moveFactor;
                berryGameObject.GetComponent<Rigidbody>().velocity = normalized;

            }

            this.updateClassification(berry.trait, berry.classification);

            this.updateResult();
            updateClassificationText();

        }
    }

    public float computeRatio(int correctPositive, int correctNegative, int falsePositive, int falseNegative, int total)
    {
        float correct = ((float)correctPositive / (float)total) + ((float)correctNegative / (float)total);
        float incorrect = ((float)falsePositive / (float)total) + ((float)falseNegative / (float)total);
        float result = (float)correct - (float)incorrect;
        this.currentRatio = (float)result;

        return result;
    }

    public void updateResult()
    {

        this.currentRatio = this.computeRatio(this.correctPositive, this.correctNegative, this.falsePositive, this.falseNegative, this.goalAmount);

        if (this.currentRatio >= this.GoldRatio)
        {

            this.GoldTrophy.GetComponent<Renderer>().enabled = true;
        }
        else
        if (this.currentRatio >= this.SilverRatio)
        {
            this.SilverTrophy.GetComponent<Renderer>().enabled = true;

        }
        else
        if (this.currentRatio >= this.BronzeRatio)
        {
            this.BronzeTrophy.GetComponent<Renderer>().enabled = true;
        }
        else
        {

            this.GoldTrophy.GetComponent<Renderer>().enabled = false;
            this.SilverTrophy.GetComponent<Renderer>().enabled = false;
            this.BronzeTrophy.GetComponent<Renderer>().enabled = false;
        }

    }

    public void resetCounter()
    {
        this.correctPositive = 0;
        this.correctNegative = 0;
        this.falsePositive = 0;
        this.falseNegative = 0;
        this.goalAmount = 100;
        berryList.Clear();
    }



    public void updateClassificationText()
    {

        this.correctPositiveText.GetComponent<TextMesh>().text = (string)"" + this.correctPositive;
        this.correctNegativeText.GetComponent<TextMesh>().text = (string)"" + this.correctNegative;
        this.falsePositiveText.GetComponent<TextMesh>().text = (string)"" + this.falsePositive;
        this.falseNegativeText.GetComponent<TextMesh>().text = (string)"" + this.falseNegative;
        this.currentRatioText.GetComponent<TextMesh>().text = (string)"" + currentRatio * 100 + "%";

    }
    // Returns true on a correct classification and updates the counter accordingly.
    // For efficency reasons we're not counting the whole array each frame but instead increase/decreased based on the element in the list to keep track.
    // 1 = CorPos | 2 = CorNeg | 3 = FalsePos | 4 FalseNeg
    // Could Probably be a nice Switch Case but I had an argument with a switch-case that was supposed to take two parameters but-
    public void updateClassification(int trait, int classification)
    {
        // Increase the Counter Without Overhead.

        if (trait == 1 && classification == 1)
        {
            this.berryList.Add(1);
            this.correctPositive = this.correctPositive + 1;
        }
        else
        if (trait == 0 && classification == 0)
        {
            this.berryList.Add(2);
            this.correctNegative = this.correctNegative + 1;
        }
        else
        if (trait == 0 && classification == 1)
        {
            this.berryList.Add(3);
            this.falsePositive = this.falsePositive + 1;
        }
        else
        if (trait == 1 && classification == 0)
        {
            this.berryList.Add(4);
            this.falseNegative = this.falseNegative + 1;
        }
        else
        {
            Debug.Log("This Should not be printed");
        }


        // Decrease The Counter after the GoalAmount has been met.
        if (berryList.Count > goalAmount)
        {

            int current = berryList[0];
            berryList.RemoveAt(0);

            switch (current)
            {
                case (1):
                    this.berryList.Add(1);
                    this.correctPositive = this.correctPositive - 1;
                    break;
                case (2):
                    this.berryList.Add(2);
                    this.correctNegative = this.correctNegative - 1;
                    break;
                case (3):
                    this.berryList.Add(3);
                    this.falsePositive = this.falsePositive - 1;
                    break;
                case (4):
                    this.berryList.Add(4);
                    this.falseNegative = this.falseNegative - 1;
                    break;
                default:
                    this.berryList.Add(4);
                    Debug.Log("This Should not be printed");
                    break;
            }
        }
    }


}
