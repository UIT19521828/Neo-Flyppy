using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.Events;
using UnityEngine.UI;

public class UserAccount : MonoBehaviour
{
    public static UserAccount Instance;
    private string id;
    private string titlename;
    public static UnityEvent onLoginSuccess = new UnityEvent();
    public static UnityEvent<string> onLoginFail = new UnityEvent<string>();
    public static UnityEvent<string> onCreateFail = new UnityEvent<string>();
    void Awake()
    {
        Instance = this;
    }
    public void CreateAccount(string username, string email, string pass)
    {
        PlayFabClientAPI.RegisterPlayFabUser(
            new RegisterPlayFabUserRequest
            {
                Username = username,
                Email = email,
                Password = pass
            },
            reponse => { 
                Debug.Log($"Succesful Account Create");
                SetPlayerData("10000", "0", "0", "0");
                SetUsername(username);
                SignIn(username, pass);              
            },
            error => { 
                Debug.Log($"Fail Creating Account! \n {error.ErrorMessage}");
                onCreateFail.Invoke(error.ErrorMessage);
            }
        );
        
    }
    public void SignIn(string username, string pass)
    {
        PlayFabClientAPI.LoginWithPlayFab(
            new LoginWithPlayFabRequest
            {
                Username = username,
                Password = pass,
            },
            reponse =>
            {
                id = reponse.PlayFabId;
                Debug.Log($"Succesful Sign In");
                GetPlayerData();
                onLoginSuccess.Invoke();
            },
            error =>
            {
                Debug.Log($"User or Password is not valid! \n {error.ErrorMessage}");
                onLoginFail.Invoke(error.ErrorMessage);
            }
        ) ;
    }
    public void SetPlayerData(string unlock, string s, string money, string h)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
                {"unlock", unlock},
                {"selected", s},
                {"money", money},
                {"highScore", h}
            }
        },
        result =>
        {
            Debug.Log($"Set Data Success!");
        },
        error =>
        {
            Debug.Log("Fail Set Data!");
        }
        );
    }
    public void SetUnlockM(string unlock, string m)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
                {"unlock", unlock},
                {"money", m}
            }
        },
        result =>
        {
            Debug.Log($"Set Data Success!");
        },
        error =>
        {
            Debug.Log("Fail Set Data!");
        }
        );
    }
    public void SetMoney(string m)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
                {"money", m}
            }
        },
        result =>
        {
            Debug.Log($"Set Data Success!");
        },
        error =>
        {
            Debug.Log("Fail Set Data!");
        }
        );
    }
    public void SetSelected(string s)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
                {"selected", s}
            }
        },
        result =>
        {
            Debug.Log($"Set Data Success!");
        },
        error =>
        {
            Debug.Log("Fail Set Data!");
        }
        );
    }
    
    public void SetHighScore(string h)
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>()
            {
                {"highScore", h}
            }
        },
        result =>
        {
            Debug.Log($"Set Data Success!");
        },
        error =>
        {
            Debug.Log("Fail Set Data!");
        }
        );
    }
    public void SendLeaderBoard(int diem)
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest()
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Neo Champion",
                    Value = diem
                }
            }
        },
        result =>
        {
            Debug.Log("send leaderboard success!");
        },
        error =>
        {
            Debug.Log("Fail send leaderboard");
        }
        );
    }
    public void GetPlayerData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest() { 
            PlayFabId = id,
            Keys = null
        },
        reponse => {
            Debug.Log($"Succesful Get Data");
            if (reponse.Data == null) Debug.Log("No User Data!");
            else
            {
                PlayerData.pd.GetShopUnlock(reponse.Data["unlock"].Value.ToString());                
                PlayerData.pd.GetSelect(reponse.Data["selected"].Value);
                PlayerData.pd.GetMoney(reponse.Data["money"].Value);
                PlayerData.pd.GetHighScore(reponse.Data["highScore"].Value);
            }
        },
        error =>
        {
            Debug.Log($"Cant Get Data! \n {error.ErrorMessage}");
        });
    }
    public void SetUsername(string name)
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest()
        {
            DisplayName = name
        },
        result => { },
        error => { }
        ) ;
    }
}
