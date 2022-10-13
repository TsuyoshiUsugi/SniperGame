using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class LoginWithCustomId : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayFabClientAPI.LoginWithCustomID(
            new LoginWithCustomIDRequest
            {
                TitleId = PlayFabSettings.TitleId,
                CustomId = "100",
                CreateAccount = true
            }
            , result => { Debug.Log("ƒƒOƒCƒ“¬Œ÷"); }
            , error => { Debug.Log(error.GenerateErrorReport()); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
