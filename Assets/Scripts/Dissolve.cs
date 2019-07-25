using UnityEngine;

public class Dissolve : MonoBehaviour
{
    // Toggle the dissolve shader on/off
    // when 'E' key is pressed

    public Material dissolveMat;
    string matRef;
    float dissolveValue;
    bool isToggled;

    // Start is called before the first frame update
    void Start()
    {
        dissolveValue = 0f;
        isToggled = false;
        matRef = "Vector1_7FD5BE8A";
        dissolveMat.shader = Shader.Find("Shader Graphs/Dissolve");
        dissolveMat.SetFloat(matRef, dissolveValue);
    }

    void dissolveToggleOn()
    {
        if (dissolveMat.GetFloat(matRef) < 1)
        {
            dissolveValue += 0.002f;
            dissolveMat.SetFloat(matRef, dissolveValue);
        }
    }

    void dissolveToggleOff()
    {
        if (dissolveMat.GetFloat(matRef) > 0)
        {
            dissolveValue -= 0.002f;
            dissolveMat.SetFloat(matRef, dissolveValue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isToggled == false)
            {
                isToggled = true;
            }
            else
            {
                isToggled = false;
            }
        }
        if (isToggled == false)
        {
            dissolveToggleOff();
        }
        else
        {
            dissolveToggleOn();
        }
    }
}
