using UnityEngine;
using UnityEngine.UI;

public class TextTime : MonoBehaviour
{
    float playTime = 120f;
    public Text textBox;

    // Update is called once per frame
    void Update()
    {
        playTime -= Time.deltaTime;
        textBox.text = Mathf.RoundToInt(playTime).ToString();
    }
}
