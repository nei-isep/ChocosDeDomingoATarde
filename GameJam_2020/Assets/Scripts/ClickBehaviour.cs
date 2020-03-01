using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickBehaviour : MonoBehaviour
{

    public GameObject spotlight;
    public GameObject timer;
    public static int noSpotlights = 0;
    public int timeDamage = 2;
    public static DateTime lastSpotlightTime = DateTime.MinValue;
    //public AudioSource spotlightTurningOn;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(spotlight, new Vector3(71, 35, 28), spotlight.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (lastSpotlightTime == DateTime.MinValue || (DateTime.Now - lastSpotlightTime).TotalSeconds >= 5))
        {
            lastSpotlightTime = DateTime.Now;
            noSpotlights++;
            //spotlightTurningOn.Play();
            StartCoroutine(CreateSpotlight());
        }
    }

    IEnumerator CreateSpotlight()
    {
        // Make a game object
        GameObject lightGameObject = new GameObject("The Light" + noSpotlights.ToString());

        // Add the light component
        Light lightComp = lightGameObject.AddComponent<Light>();
        lightComp.type = LightType.Spot;
        lightComp.intensity = 5;
        lightComp.range = 50;
        lightComp.spotAngle = 55;
        lightComp.color = Color.white;
        lightComp.shadows = LightShadows.Hard;

        // Set the position (or any transform property)
        //https://answers.unity.com/questions/540888/converting-mouse-position-to-world-stationary-came.html
        var v3 = Input.mousePosition;
        v3.z = 60.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        lightGameObject.transform.position = new Vector3(v3.x, 35, v3.z);
        lightGameObject.transform.eulerAngles = new Vector3(90, 0, 0);

        timer.GetComponent<TextTime>().playTime -= timeDamage;

        yield return new WaitForSeconds(2f);

        if (lightGameObject != null)
        {
            GameObject.Destroy(lightGameObject);
        }
    }
}
