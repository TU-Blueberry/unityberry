using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class AngularTranslator : MonoBehaviour
{

    float elapsed = 0f;
    float resetTimer = 0f;

    bool debug = true;

    public GameObject berryProducer;

    public GameObject berrySorter;


    List<int> traitList;
    List<int> classList;

    public string badBerry = "berrybad-";
    public string goodBerry = "berrygood-";
    public string basePath = "berries/";



    void Start()
    {
        if (debug)
        {
            testProduction();
        }
    }
    void Update()
    {

        elapsed += Time.deltaTime;

        if (elapsed >= 1)
        {
            elapsed = elapsed % 1;
        }

        if (debug)
        {

        }


    }

    // --- Unity Communication Calls ---

    // Berry characteristings separated by comma values 
    // "trait,classification,imagepath"
    public void queueBerry(string berry)
    {
        string[] berryParts = berry.Split(',');
        string trait = berryParts[0];
        string classification = berryParts[1];
        string imagePath = berryParts[2];
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        //producer.queueBerry(Int32.Parse(trait), Int32.Parse(classification), imagePath));
        producer.queueBerry(Int32.Parse(trait), Int32.Parse(classification), imagePath);
    }

    // Image Data separated by comma values 
    // "imagepath,image"
    public void acceptImage(string data)
    {
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        string[] imageparts = data.Split(',');
        string path = imageparts[0];
        string image = imageparts[1];
        producer.acceptImage(path, image);

    }

    // Berry characteristings separated by comma values 
    // "trait,classification,imagepath,image"
    public void queueBerryWithImage(string berry)
    {
        string[] berryParts = berry.Split(',');
        string trait = berryParts[0];
        string classification = berryParts[1];
        string imagePath = berryParts[2];
        string image = berryParts[3];
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.queueBerry(Int32.Parse(trait), Int32.Parse(classification), imagePath, image);
    }

    public void start(string data)
    {

        var sorter = (Sorter)berrySorter.GetComponent<Sorter>();
        string[] split = data.Split(',');
        int amount = Int32.Parse(split[0]);
        string classification = split[1];

        sorter.startNewSorting(amount, classification);

    }

    public void stop()
    {
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.setActive(false);
    }
    public void enableManual()
    {
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.setManual(true);
    }

    public void disableManual()
    {
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.setManual(false);
    }

    public void reset()
    {
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        var sorter = (Sorter)berrySorter.GetComponent<Sorter>();

        sorter.reset();
        producer.reset();

    }

    // --- Debug Logic --- 
    public void testProduction()
    {

        string traitString = "1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0";
        string classString = "1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1";
        string dummyImage = "/9j/4AAQSkZJRgABAQAAAQABAAD/2wBDAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDL/2wBDAQkJCQwLDBgNDRgyIRwhMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wAARCABAAEADASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD04mkJpua5bxT42sfDY8pv310wyIlPT6+lOMXJ2Qm0jp3kCjrWLqniGz09T591HF9TzXlur/EnVbsGK3KQA9SvauIvdRmu7gtLM8rd2Y9TXQsO18Rn7S+x7ePF2nXP+rvVb606PWIp2xHOj+wavChNIi4BPPoaltryaEhhKytngg9Kt0IpCU2z3hZ9/fmp0mKnINec+G/FZkdLa9kG88LIe/sa7qKXfisJRsaJmz4h1uLRNLluZGAYDCgnqa+etV1CTU7+W5lcs7tkkmuz+JmsNdat9hVz5cA6erd68+jLEkkcVvh1yq5jN3YxzjOOTTUQ55qwdoPSotyl85reRKHcdKjbvQXAJqCSQgHFYynYtRFjuGWQYY5Br2DwvqL3ejwO7ZYDaSfavGIeWzXo/gm7P2Z4h0VsisL3NUYXiuVz4jvi55EzD9ayElBXkV2HxJ0WSx1x71FzDc/Nn0bvXCFjirjPQytqTPKXfao/GmyB41yw69xREyhDkc0s0g8jGcms5VKjnZbGyhBRv1K4kB4NRSEs3tTc8nNKOabZAqdMV6F4LtXjtGlI5c8VxmmWD317FBGpZnPavadE0D7LbxK/AUDiocrFRN7xFokOvaW9pLgN1Rv7prwfXPD95ot20N1EQAflbHDV9IPGRWbqek2mq2rW93EsiHpnqPpURk0NxufM53BuKictnkmvYbz4U2juTb3rop6BlziqTfCeLHzai2faOqdRC5WeVBSa1NI0C/1i4WGzgZyepxwPqa9NsPhVYRSK89zLKo7YABrutO0q00yAQ2kKxoPQdal1Ow1Duc94R8DW+gw+dORLeMPmbsvsK69IUXtTwtSKPaoepaP/2Q==";

        this.traitList = traitString.Split(',').Select(Int32.Parse).ToList();
        this.classList = classString.Split(',').Select(Int32.Parse).ToList();
        var producer = (BerrySpawner)berryProducer.GetComponent<BerrySpawner>();
        producer.setActive(true);
        enableManual();
        string imagePath;

        for (int i = 0; i < traitList.Count(); i++)
        {

            imagePath = traitList.ElementAt(i) == 0 ? this.basePath + this.badBerry : this.basePath + this.goodBerry;
            this.queueBerryWithImage(traitList.ElementAt(i) + "," + classList.ElementAt(i) + "," + imagePath + "," + dummyImage);
        }

    }

}
