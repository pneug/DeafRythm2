using UnityEngine;
using UnityEngine.UI;

public class Notificator : MonoBehaviour
{
    public static Notificator inst;

    private static Text txt;

    private void Awake()
    {
        inst = this;
        txt = GetComponent<Text>();
        //SetAlpha(0);
    }

    private void SetAlpha(float a)
    {
        Color c = txt.color;
        if (a < 0 && c.a > 0)
        {
            c.a += a;
            if (c.a < 0)
                c.a = 0;
        }
        else
        {
            c.a = a;
        }
        txt.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        SetAlpha(-Time.deltaTime/2f);
    }

    public void ShowNotif(string msg)
    {
        SetAlpha(1f);
        txt.text = msg;
    }
}
