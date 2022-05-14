using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomeManager : Singleton<HomeManager>
{
    public HomeScreenState state = HomeScreenState.MAIN;

    public GameObject sectionMainMenu;
    public GameObject sectionHostGame;
    public GameObject sectionJoinGame;
    public GameObject sectionQuitGamePopup;
    public GameObject sectionSocialAside;
    public GameObject sectionSettingsMenu;
    public GameObject sectionGraphicsSettings;
    public GameObject sectionAudioSettings;
    public GameObject sectionControlsSettings;
    public GameObject sectionAccessibilitySettings;
    public GameObject sectionInterfaceSettings;
    public GameObject sectionSystemSettings;


    private void Awake()
    {
        CreateSingleton(true);

        UpdatePanels();
    }

    public void UpdatePanels()
    {
        DisableAllPanels();

        switch (state)
        {
            case HomeScreenState.MAIN:
                sectionMainMenu.SetActive(true);
                //sectionSocialAside.SetActive(true);
                break;

            case HomeScreenState.HOST_GAME:
                break;

            case HomeScreenState.JOIN_GAME:
                break;

            case HomeScreenState.GRAPH_SETTING:
                sectionSettingsMenu.SetActive(true);
                sectionGraphicsSettings.SetActive(true);
                break;

            case HomeScreenState.AUDIO_SETTING:
                sectionSettingsMenu.SetActive(true);
                sectionAudioSettings.SetActive(true);
                break;

            case HomeScreenState.CONTROL_SETTING:
                sectionSettingsMenu.SetActive(true);
                sectionControlsSettings.SetActive(true);
                break;

            case HomeScreenState.ACCESSIBILITY_SETTING:
                sectionSettingsMenu.SetActive(true);
                sectionAccessibilitySettings.SetActive(true);
                break;

            case HomeScreenState.INTERFACE_SETTING:
                sectionSettingsMenu.SetActive(true);
                sectionInterfaceSettings.SetActive(true);
                break;

            case HomeScreenState.SYSTEM_SETTING:
                sectionSettingsMenu.SetActive(true);
                sectionSystemSettings.SetActive(true);
                break;

            case HomeScreenState.CREDITS: 
                break;

            case HomeScreenState.QUIT_POPUP:
                sectionQuitGamePopup.SetActive(true);
                break;

            default:
                sectionMainMenu.SetActive(true);
                break;
        }
    }

    private void DisableAllPanels() {
        sectionMainMenu.SetActive(false);
        sectionHostGame.SetActive(false);
        sectionJoinGame.SetActive(false);
        sectionQuitGamePopup.SetActive(false);
        sectionSocialAside.SetActive(false);
        sectionSettingsMenu.SetActive(false);
        sectionGraphicsSettings.SetActive(false);
        sectionAudioSettings.SetActive(false);
        sectionControlsSettings.SetActive(false);
        sectionAccessibilitySettings.SetActive(false);
        sectionInterfaceSettings.SetActive(false);
        sectionSystemSettings.SetActive(false);
    }

    public void ActionMainMenu()
    {
        state = HomeScreenState.MAIN;
        UpdatePanels();
    }

    public void ActionHostGame()
    {
        throw new NotImplementedException();
    }

    public void ActionJoinGame()
    {
        throw new NotImplementedException();
    }

    public void ActionGraphSettings()
    {
        state = HomeScreenState.GRAPH_SETTING;
        UpdatePanels();
    }

    public void ActionAudioSettings()
    {
        state = HomeScreenState.AUDIO_SETTING;
        UpdatePanels();
    }

    public void ActionControlSettings()
    {
        state = HomeScreenState.CONTROL_SETTING;
        UpdatePanels();
    }
    
    public void ActionAccessibilitySettings()
    {
        state = HomeScreenState.ACCESSIBILITY_SETTING;
        UpdatePanels();
    }

    public void ActionInterfaceSettings()
    {
        state = HomeScreenState.INTERFACE_SETTING;
        UpdatePanels();
    }

    public void ActionSystemSettings()
    {
        state = HomeScreenState.SYSTEM_SETTING;
        UpdatePanels();
    }

    public void ActionCredits()
    {
        throw new NotImplementedException();
    }

    public void ActionQuitPopup()
    {
        state = HomeScreenState.QUIT_POPUP;
        UpdatePanels();
    }

    public void ActionQuitGame()
    {
        Application.Quit();
    }
}
