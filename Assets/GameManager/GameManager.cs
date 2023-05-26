using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 public class GameManager : MonoBehaviour
{
    public const string DefaultName = "Manager";

    private PlayerController playerController;
    private AudioSource audioSource;

    private static GameManager instance;
    private static DataManager dataManager;

    public static GameManager Instance { get { return instance; } }
    public static DataManager Data {  get { return dataManager; } }

    // 현재 플레이어의 상태를 저장하는 변수
    PlayerState currentPlayerState = GameManager.Instance.GetCurrentPlayerState();

    // 현재 플레이어 상태를 반환하는 함수
    public PlayerState GetCurrentPlayerState()
    {
        return playerController.currentState; //현재 플레이어 상태 변환
    }

    private void Awake()
    {
        if (instance != null)   // 게임매니저 스크립트(this)를 하나만 제외하고 모두 삭제시킴
        {
            Destroy(this);
            return;
        }

        // 씬 전환상태에서도 게임오브젝트가 사라지지 않게 많들어주는 방식
        DontDestroyOnLoad(this);

        instance = this;
        InitManagers();
    }

    private void OnDestroy()
    {
        if(instance == this)
            instance = null;
    }


    private void InitManagers()
    {
        // DataManager Init
        GameObject dataObj = new GameObject() { name = "DataManager" };
        dataObj.transform.SetParent(transform);
        dataManager = dataObj.AddComponent<DataManager>();
    }

   
}
