
using UnityEngine;
using UnityEngine.UI;

public class MenuSoundValue : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private  AudioSource audio;
    [SerializeField] private Slider slider;
    [SerializeField] private Text text;

    [Header("Keys")]
    [SerializeField] private string saveVolumeKey;

    [Header("Tags")]
    [SerializeField] private string sliderTag;
    [SerializeField] private string textVolumeTag;

    [Header("Parameters")]
    [SerializeField] private float volume;


    private void Awake()
    {

    }
    private void LateUpdate()
    {
        GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
        if(sliderObj != null)
        {
            this.slider = sliderObj.GetComponent<Slider>();
            this.volume = slider.value;

            if(this.audio.volume != this.volume)
            {
                PlayerPrefs.SetFloat(saveVolumeKey, this.volume);
            }

            GameObject textObj = GameObject.FindWithTag(this.textVolumeTag);
            if(textObj != null)
            {
                this.text = textObj.GetComponent<Text>();

                this.text.text = Mathf.Round(f: this.volume * 100) + "%";
            }
        }
        this.audio.volume = this.volume;
    }
}
