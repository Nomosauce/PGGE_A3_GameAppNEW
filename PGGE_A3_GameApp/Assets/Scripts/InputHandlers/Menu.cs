using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioSource singlePlayerBtnSFX;
    [SerializeField] private AudioSource multiPlayerBtnSFX;
    private bool menuBtnPressed;

    // Start is called before the first frame update
    void Start()
    {
        menuBtnPressed = false; //such that the boolean for menuBtnPressed goes back to false when the player enters the lobby scene again
    }

    public void OnClickSinglePlayer()
    {
        if (!menuBtnPressed) //plays the couroutine if its not already operating/after its done operating
        {
            StartCoroutine(PlaySinglePlayerSFX()); 
            menuBtnPressed = true;
        }
    }

    public IEnumerator PlaySinglePlayerSFX() //delays the scene loading to be after the sound is played to avoid the sound being cut off as soon as the scene changes normally
    {
        singlePlayerBtnSFX.Play();
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("SingleplayerMap00"); //(refactor comment: because of the change in scene name, this has to be updated to the new scene name)
    }

    public void OnClickMultiPlayer()
    {
        if (!menuBtnPressed) //plays the couroutine if its not already operating/after its done operating
        {
            StartCoroutine(PlayMultiPlayerSFX());
            menuBtnPressed = true;
        }
    }

    public IEnumerator PlayMultiPlayerSFX() //delays the scene loading to be after the sound is played to avoid the sound being cut off as soon as the scene changes normally
    {
        multiPlayerBtnSFX.Play();
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("MultiplayerLobby"); //(refactor comment: because of the change in scene name, this has to be updated to the new scene name)
    }
}
