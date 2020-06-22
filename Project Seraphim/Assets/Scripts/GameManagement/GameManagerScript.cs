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

    // Player 1 info and controls
    public GameObject player1GO;
    public PlayerMovement PC1;
    public GameObject player1UI;
    [Space]
    public GameObject[] thingsToWake;
    /// 

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }



    /// <summary>
    ///  This is the scene swapper area, simple and rudimentary. Will probably update it if project complexity
    ///  increases. For now this is all we need.
    /// </summary>
    /// 

    public void OpenInventory()
    {
        _inventory.SetActive(true);
    }

    public void CloseInventory()
    {
        _inventory.SetActive(false);
    }

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

    public void ToggleDebugUI()
    {
        debugUIGO.SetActive(!(debugUIGO));
    }

}
