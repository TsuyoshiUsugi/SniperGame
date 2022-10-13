using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
public class PlayFabController : MonoBehaviour
{
    void Start()
    {
        PlayFabClientAPI.LoginWithCustomID(new LoginWithCustomIDRequest 
        { 
            CustomId = "GettingStartedGuide",
            CreateAccount = true 
        }
        , result => 
        { 
            Debug.Log(" おめでとう ござい ます！ ログイン 成功 です！"); 
        }
        , error => 
        { 
            Debug.Log(" ログイン 失敗...(´； ω；｀)"); 
        });


    }
}



      