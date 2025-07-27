using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIVisible : MonoBehaviour
{
    public GameObject panel;
    private bool isVisible;
    void Start()
    {
        panel.SetActive(true);
        isVisible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isVisible)
            {
                panel.SetActive(false);
                isVisible = false;
            }
            else
            {
                panel.SetActive(true);
                isVisible = true;
            }
        }
    }
}
