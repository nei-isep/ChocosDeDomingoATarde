using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine("SpotlightCreation");
        }
    }

    IEnumerator SpotlightCreation()
    {
        // Make a game object
        GameObject lightGameObject = new GameObject("The Light");

        // Add the light component
        Light lightComp = lightGameObject.AddComponent<Light>();
        lightComp.type = LightType.Spot;

        // Set the position (or any transform property)
        lightGameObject.transform.position = Input.mousePosition;

        yield return new WaitForSeconds(2f);

        //lightComp

    }
}
