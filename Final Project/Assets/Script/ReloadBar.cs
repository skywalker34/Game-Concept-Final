using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public Slider slider;
    private float timer = 0f;
    private float interval = 3f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            if (slider.value != slider.maxValue)
            {
                slider.value++;
            }
            timer = 0f;
        }
    }

    public void SetMaxPower(int power)
    {
        slider.maxValue = power;
    }

    public void SetPower(int power)
    {
        slider.value = power;
    }

    public int GetPower()
    {
        return (int)slider.value;
    }
}
