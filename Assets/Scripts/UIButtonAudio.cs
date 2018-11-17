using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIButtonAudio : MonoBehaviour, IPointerEnterHandler, IDeselectHandler {

    #region variables
    // public
    public SoundItem highlightedSound;
    public SoundItem selectedSound;
    // private
    private AudioSource source;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        SetInitialReferences();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!EventSystem.current.alreadySelecting)
        {
            EventSystem.current.SetSelectedGameObject(this.gameObject);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        this.GetComponent<Selectable>().OnPointerExit(null);
    }
    #endregion

    #region MyMethods
    private void SetInitialReferences()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayHighlightSound()
    {
        source.clip = highlightedSound.clip;
        source.volume = highlightedSound.volume;
        source.pitch = highlightedSound.pitch;
        source.loop = highlightedSound.loop;
        source.Play();
    }

    public void PlaySelectSound()
    {
        source.clip = selectedSound.clip;
        source.volume = selectedSound.volume;
        source.pitch = selectedSound.pitch;
        source.loop = selectedSound.loop;
        source.Play();
    }
    #endregion
}
