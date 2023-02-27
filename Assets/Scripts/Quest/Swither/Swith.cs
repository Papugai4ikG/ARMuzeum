using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Swith : MonoBehaviour
{
    private void Start()
    {
        var r= Random.Range(1, 3);

        for (int i = 0; i < r; i++)
        {
            transform.Rotate(0, 0, 90f);
        }
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (!GetComponentInParent<ControllSwith>().Win())
            {
                transform.Rotate(0, 0, 90);
                GetComponentInParent<ControllSwith>().CheckPosition();
            }
        });
      
    }
}
