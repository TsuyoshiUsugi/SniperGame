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
            Debug.Log(" ���߂łƂ� ������ �܂��I ���O�C�� ���� �ł��I"); 
        }
        , error => 
        { 
            Debug.Log(" ���O�C�� ���s...(�L�G �ցG�M)"); 
        });


    }
}



      