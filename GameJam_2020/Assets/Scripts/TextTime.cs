using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextTime : MonoBehaviour
{
    public float playTime;
    public Text textBox;

    // Update is called once per frame
    void Update()
    {
        playTime -= Time.deltaTime;
        textBox.text = Mathf.RoundToInt(playTime).ToString();
        if ( playTime <= 0 )
        {
            SceneManager.LoadScene(6);
        }
    }
}
