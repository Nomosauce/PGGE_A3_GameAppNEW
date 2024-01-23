using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class PlayerNameInput : MonoBehaviour
{
    private InputField mInputField;
    const string playerNamePrefKey = "PlayerName";

    // Start is called before the first frame update
    void Start()
    {
        mInputField = GetComponent<InputField>(); //refactoring comment: "this." was removed as "this." is typically used to refer to a current instance of an object, 
                                                  //however, GetComponent already operates on the current instance so "this." is redundant.

        string defaultName = string.Empty;

        if (mInputField != null && PlayerPrefs.HasKey(playerNamePrefKey)) //refactoring comment: the code in the if statement only runs only if it meets these two conditions,
                                                                          //instead of having an if statement in an if statement, it can be simplified with && which checks if both conditions are met in a line
        {
            defaultName = PlayerPrefs.GetString(playerNamePrefKey);
            mInputField.text = defaultName;
        }
        PhotonNetwork.NickName = defaultName;
    }

    public void SetPlayerName()
    {
        string value = mInputField.text;
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("Player Name is null or empty");
            return;
        }
        PhotonNetwork.NickName = value;
        PlayerPrefs.SetString(playerNamePrefKey, value);

        Debug.Log("Nickname entered: " + value);
    }
}
