using System.Collections;
using UnityEngine;

public class BolaBillarDisplay : MonoBehaviour
{
    public float timer = 1;
    private int currentIndex = 1;
    
    public Material material;     
    public string propertyName = "_Index";
    
    void Start()
    {
        material.SetFloat(propertyName, currentIndex);
        StartCoroutine(ChangeIndex());
    }

    IEnumerator ChangeIndex()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            currentIndex++;

            if (currentIndex <= 16)
                material.SetFloat(propertyName, currentIndex);
            else
            {
                currentIndex = 1;
                material.SetFloat(propertyName, currentIndex);
            }
        }
    }
}
