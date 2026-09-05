using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("Players")]
    [SerializeField] private Movement player1;
    [SerializeField] private Movement player2;

    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Main Menu Buttons")]
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;
    [SerializeField] private Button btnQuit;

    [Header("Pause Menu Buttons")]
    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnPauseSettings;
    [SerializeField] private Button btnPauseCredits;
    [SerializeField] private Button btnPauseQuit;

    [Header("Settings Panel")]
    [SerializeField] private Slider sliderP1Speed;
    [SerializeField] private Slider sliderP2Speed;
    [SerializeField] private TMP_Text textP1Speed;
    [SerializeField] private TMP_Text textP2Speed;
    [SerializeField] private Button btnBackSettings;

    [Header("Credits Panel")]
    [SerializeField] private Button btnBackCredits;

    private bool isPaused = false;

    private GameObject lastPanel;

    private void Awake()
    {
        btnPlay.onClick.AddListener(OnPlayClicked);
        btnSettings.onClick.AddListener(() => OpenPanel(settingsPanel, mainMenuPanel));
        btnCredits.onClick.AddListener(() => OpenPanel(creditsPanel, mainMenuPanel));
        btnQuit.onClick.AddListener(OnQuitClicked);

        btnContinue.onClick.AddListener(OnContinueClicked);
        btnPauseSettings.onClick.AddListener(() => OpenPanel(settingsPanel, pausePanel));
        btnPauseCredits.onClick.AddListener(() => OpenPanel(creditsPanel, pausePanel));
        btnPauseQuit.onClick.AddListener(OnQuitClicked);

        btnBackSettings.onClick.AddListener(OnBackClicked);
        btnBackCredits.onClick.AddListener(OnBackClicked);

        sliderP1Speed.onValueChanged.AddListener(OnPlayer1SpeedChanged);
        sliderP2Speed.onValueChanged.AddListener(OnPlayer2SpeedChanged);
    }

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);

        sliderP1Speed.value = player1.moveSpeed;
        sliderP2Speed.value = player2.moveSpeed;
        textP1Speed.text = player1.moveSpeed.ToString("F2");
        textP2Speed.text = player2.moveSpeed.ToString("F2");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void OnDestroy()
    {
        btnPlay.onClick.RemoveAllListeners();
        btnSettings.onClick.RemoveAllListeners();
        btnCredits.onClick.RemoveAllListeners();
        btnQuit.onClick.RemoveAllListeners();

        btnContinue.onClick.RemoveAllListeners();
        btnPauseSettings.onClick.RemoveAllListeners();
        btnPauseCredits.onClick.RemoveAllListeners();
        btnPauseQuit.onClick.RemoveAllListeners();

        btnBackSettings.onClick.RemoveAllListeners();
        btnBackCredits.onClick.RemoveAllListeners();

        sliderP1Speed.onValueChanged.RemoveAllListeners();
        sliderP2Speed.onValueChanged.RemoveAllListeners();
    }

    // --- Menu principal ---

    private void OnPlayClicked()
    {
        mainMenuPanel.SetActive(false);
    }

    private void OnQuitClicked()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }

    // --- Pausa ---

    private void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    private void OnContinueClicked()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // --- Settings / Credits  ---

    private void OpenPanel(GameObject panelToOpen, GameObject callerPanel)
    {
        lastPanel = callerPanel;
        callerPanel.SetActive(false);
        panelToOpen.SetActive(true);
    }

    private void OnBackClicked()
    {
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        if (lastPanel != null)
            lastPanel.SetActive(true);
    }

    // --- Sliders ---

    private void OnPlayer1SpeedChanged(float value)
    {
        player1.moveSpeed = value;
        textP1Speed.text = value.ToString("F2");
    }

    private void OnPlayer2SpeedChanged(float value)
    {
        player2.moveSpeed = value;
        textP2Speed.text = value.ToString("F2");
    }
}
