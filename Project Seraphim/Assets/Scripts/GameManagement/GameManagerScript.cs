using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagerScript : SeraphLibrary {


    //Directors
    public GameObject debugUIGO;
    public string m_Scene;
    public GameObject m_MyGameObject;
    public Animator screenTrans;
    [SerializeField]
    private GameObject _inventory;

    [Space]

    ///Settings///
    //Static General Settings
    public static int particleIntensity = 3;
    public static bool screenshake = true;
    public static bool damageText = true;

    [Space]

    // Player info and controls
    [SerializeField]
    private GameObject playerGO;
    public static PlayerMovement PCM;
    [SerializeField]
    private GameObject playerUI;
    public GameObject aimer;
    [Space]
    public GameObject[] thingsToWake;
    /// 

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }

    //Player Handling
    public void StartPlayer()
    {
        int loopcounter = 0;
        while (loopcounter < thingsToWake.Length) //Loop to make sure the loop only checks as many objects as there are in the array.
        {
            thingsToWake[loopcounter].SetActive(false);
            loopcounter++;
        }

    }
    public void StopPlayer()
    {
        PCM.StopAllCoroutines();
        int loopcounter = 0;
        while (loopcounter < thingsToWake.Length) //Loop to make sure the loop only checks as many objects as there are in the array.
        {
            thingsToWake[loopcounter].SetActive(false);
            loopcounter++;
        }
    }



    //Inventory Area

    public void OpenInventory()
    {
        _inventory.SetActive(true);
    }

    public void CloseInventory()
    {
        _inventory.SetActive(false);
    }



    //Scene Area
    public void GoToScene(string sentscene)
    {
        m_Scene = sentscene;
        screenTrans.SetTrigger("FadeOut");
    }

    public void FadeComplete()
    {
        Debug.Log("Loading scene " + m_Scene);
        SceneManager.LoadScene(m_Scene);
        screenTrans.SetTrigger("FadeIn");
    }

    //Debug Area

    public void ToggleDebugUI()
    {
        debugUIGO.SetActive(!(debugUIGO));
    }

}
