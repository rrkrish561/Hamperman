using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeController : MonoBehaviour
{
    public static VolumeController _volumeController;
    public GameObject SoundImage;
    public Sprite[] soundImages;
    public float currentVolume;
    public GameObject VolumeSliderObject;
    private Slider VolumeSlider;
    private Sprite currentSoundImage;
    private float soundSegmentSize;
    private int currentImageIndex;
    private bool volumeChanged;
    private Camera cameraxx;
    private AudioSource audioSourcexx;


    // Start is called before the first frame update
    void Start()
    {
        if (_volumeController !=null)
          GameObject.Destroy(_volumeController);
        else
          _volumeController=this;

        DontDestroyOnLoad(this);

        VolumeSlider = VolumeSliderObject.GetComponent<Slider>();
        volumeChanged = true;
        soundSegmentSize = 1f/(soundImages.Length-1);

        setVolumeImage();
    }

  
     
     // Update is called once per frame
    void Update()
    {

        if (volumeChanged)
            {
            setVolume();
            setVolumeImage();
            }
    }


    void setVolume()
    {
        if (GameObject.Find("Main Camera").GetComponent<Camera>().GetComponent<AudioSource>())
        {
            audioSourcexx = GameObject.Find("Main Camera").GetComponent<Camera>().GetComponent<AudioSource>();
            audioSourcexx.volume = currentVolume;
            volumeChanged = false;
        }
    }

    
    void setVolumeImage()
    {
        currentImageIndex = Mathf.RoundToInt(currentVolume / soundSegmentSize);
        if ((currentImageIndex == 0) && (currentVolume > 0))
            currentImageIndex = 1;

        SoundImage.GetComponent<Image>().sprite = soundImages[currentImageIndex];
        
    }


    public void setVolume(float _volume)
    {
        currentVolume = _volume;
        volumeChanged = true;
    }


    public void showVolumeSlider()
    {

        if (VolumeSliderObject.active)
        {
            Time.timeScale = 1;
            VolumeSliderObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            VolumeSlider.value = currentVolume;
            VolumeSliderObject.SetActive(true);
        }

    }
    

    public void hideVolumeSlider()
    {
        VolumeSliderObject.SetActive(false);
        Time.timeScale = 1;
        volumeChanged = true;
    }


}
