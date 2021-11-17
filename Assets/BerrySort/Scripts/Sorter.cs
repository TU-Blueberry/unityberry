using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private int goalAmount = 0;
    private float goalRatio = 0.95f;

    public GameObject goalScreenText;
    public GameObject currentRatioText;
    public GameObject correctPositiveText;
    public GameObject correctNegativeText;
    public GameObject falseNegativeText;
    public GameObject falsePositiveText;


    // Start is called before the first frame update
    void Start()
    {
        this.goalScreenText.GetComponent<TextMesh>().text = "We are aiming for a ratio of: " + goalRatio + "%";

        this.correctNegative = 0;
        this.correctPositive = 0;
        this.falsePositive = 0;
        this.falseNegative = 0;

        bool move = false;
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
        updateClassificationText();

    }

    void OnTriggerEnter(Collider other)
    {
        {
            var berry = (Berry)other.gameObject.GetComponent<Berry>();
            //Debug.Log("Classification:" + berry.classification);
            //Debug.Log("BerryTrait:" + berry.trait);
            if (berry.classification == 0)
            {
                this.move = true;
                var berryGameObject = other.gameObject;
                berryGameObject.GetComponent<Rigidbody>().velocity = destination.position * 2;


            }
            this.updateClassification(berry.trait, berry.classification);
            this.updateResult();

        }
    }

    public float computeRatio(int correctPositive, int correctNegative, int falsePositive, int falseNegative, int total)
    {
        float correct = ((float)correctPositive / (float)total) + ((float)correctNegative / (float)total);
        float incorrect = ((float)falsePositive / (float)total) + ((float)falseNegative / (float)total);
        float result = (float)correct - (float)incorrect;
        this.currentRatio = (float)result;
        // Debug.Log(total);
        // Debug.Log(result);
        return result;
    }

    public void updateResult()
    {

        this.currentRatio = this.computeRatio(this.correctPositive, this.correctNegative, this.falsePositive, this.falseNegative, this.goalAmount);

    }

    public void updateClassificationText()
    {


        this.correctPositiveText.GetComponent<TextMesh>().text = (string)"Cor. Pos : " + this.correctPositive;
        this.correctNegativeText.GetComponent<TextMesh>().text = (string)"Cor. Neg: " + this.correctNegative;
        this.falsePositiveText.GetComponent<TextMesh>().text = (string)"Fal. Pos: " + this.falsePositive;
        this.falseNegativeText.GetComponent<TextMesh>().text = (string)"Fal. Neg: " + this.falseNegative;
        this.currentRatioText.GetComponent<TextMesh>().text = "Current Ratio: " + currentRatio;

    }
    // Returns true on a correct classification and updates the counter accordingly.
    // Could be a Nicer Switch Case.
    public bool updateClassification(int trait, int classification)
    {

        // CorrectPositive
        if (trait == 1 && trait == classification)
        {
            correctPositive = correctPositive + 1;
            this.goalAmount = this.goalAmount + 1;
            return true;
        }
        // CorrectNegative
        if (trait == 0 && trait == classification)
        {
            this.correctNegative = this.correctNegative + 1;
            this.goalAmount = this.goalAmount + 1;
            return true;
        }
        // FalsePositive
        if (trait == 1 && trait != classification)
        {
            this.falsePositive = this.falsePositive + 1;
            this.goalAmount = this.goalAmount + 1;
            return false;
        }
        // FalseNegative
        if (trait == 0 && trait != classification)
        {
            this.falseNegative = this.falseNegative + 1;
            this.goalAmount = this.goalAmount + 1;
            return false;
        }
        else
        {
            Debug.Log("This Should not be printed");
            return false;
        }
    }
}
