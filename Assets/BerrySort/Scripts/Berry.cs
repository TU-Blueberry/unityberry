using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Berries
{
    public class Berry : MonoBehaviour
    {

        public int classification;
        public int trait;
        public string image; //Base64


        // Path to the Image
        public string imagePath;

        // public GameObject berryObject;
        /* 
            void Start()
            {
                Destroy(berryObject, 1);
            } */

        void Awake()
        {

        }

        void Update()
        {

        }


        // A good Berry will always be generated with a classification 1 and a bad with 0 since they call their parent Constructor.
        // In the two classes which extend the berry they receive their classification.
        // Basic Berry Generator.
        public Berry(int classification)
        {
            this.classification = classification;

        }

        // TODO: Consider Handling Image generation here or in the Spawn script.
        public Berry(int trait, int classification, string imagePath)
        {
            this.classification = classification;
            this.trait = trait;
            this.imagePath = imagePath;

        }

        public void getSorted()
        {


        }
    }

    public class BerryData
    {

        public int classification;
        public int trait;
        public string image; //Base64

        // Path to the Image
        public string imagePath;


        // TODO: Consider Handling Image generation here or in the Spawn script.
        public BerryData(int trait, int classification, string imagePath)
        {
            this.classification = classification;
            this.trait = trait;
            this.imagePath = imagePath;

        }

        public BerryData(int trait, int classification, string imagePath, string image)
        {
            this.classification = classification;
            this.trait = trait;
            this.imagePath = imagePath;
            this.image = image;

        }
    }
}