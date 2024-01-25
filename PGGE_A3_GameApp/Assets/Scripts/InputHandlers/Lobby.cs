using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    [SerializeField] private AudioSource lobbyBackSFX;
    private bool lobbyBtnPressed;

    // Start is called before the first frame update
    void Start()
    {
        lobbyBtnPressed = false; //such that the boolean for lobbyBtnPressed goes back to false when the player enters the lobby scene again
    }

    public void OnClickLobbyBack()
    {
        if (!lobbyBtnPressed) //plays the couroutine if its not already operating/after its done operating
        {
            StartCoroutine(PlayLobbyBackSFX());
            lobbyBtnPressed = true;
        }
    }

    public IEnumerator PlayLobbyBackSFX() //delays the scene loading to be after the sound is played to avoid the sound being cut off as soon as the scene changes normally
    {
        lobbyBackSFX.Play();
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Menu");
    }
}
