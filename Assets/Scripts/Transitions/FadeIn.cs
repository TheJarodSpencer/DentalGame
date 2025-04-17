using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeIn : MonoBehaviour
{
    [SerializeField]
    private Image b;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        b = GetComponentInChildren<Image>();
        b.color = new Color(0,0,0,1);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Fade", 0.1f);
    }

    private void Fade() {
        time += 0.05f;
        b.color = new Color(0,0,0,b.color.a - 0.05f);

        if (time > 1) {
            b.color = new Color(0,0,0,0);
        }
        else {
            Invoke("Fade", 0.1f);
        }
    }
}
