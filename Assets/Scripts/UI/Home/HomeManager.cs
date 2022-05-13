using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomeManager : Singleton<HomeManager>
{
    public HomeScreenState state = HomeScreenState.MAIN;

    public GameObject sectionMainMenu;
    public GameObject sectionNewGamePopup;
    public GameObject sectionLoadGamePopup;
    public GameObject sectionQuitGamePopup;
    public GameObject sectionSocialAside;
    public GameObject sectionSettingsMenu;
    public GameObject sectionGraphicsSettings;
    public GameObject sectionAudioSettings;
    public GameObject sectionControlsSettings;
    public GameObject sectionInterfaceSettings;
    public GameObject sectionSystemSettings;


    private void Awake()
    {
        CreateSingleton(true);

        UpdatePanels();
    }

    public void UpdatePanels()
    {
        switch (state)
        {
            case HomeScreenState.MAIN:
                sectionMainMenu.SetActive(true);
                sectionNewGamePopup.SetActive(false);
                sectionLoadGamePopup.SetActive(false);
                sectionQuitGamePopup.SetActive(false);
                sectionSocialAside.SetActive(true);
                sectionSettingsMenu.SetActive(false);
                sectionGraphicsSettings.SetActive(false);
                sectionAudioSettings.SetActive(false);
                sectionControlsSettings.SetActive(false);
                sectionInterfaceSettings.SetActive(false);
                sectionSystemSettings.SetActive(false);
                break;

            case HomeScreenState.NEW_POPUP:
                sectionMainMenu.SetActive(false);
                sectionNewGamePopup.SetActive(true);
                sectionLoadGamePopup.SetActive(false);
                sectionQuitGamePopup.SetActive(false);
                sectionSocialAside.SetActive(false);
                sectionSettingsMenu.SetActive(false);
                sectionGraphicsSettings.SetActive(false);
                sectionAudioSettings.SetActive(false);
                sectionControlsSettings.SetActive(false);
                sectionInterfaceSettings.SetActive(false);
                sectionSystemSettings.SetActive(false);
                break;

            case HomeScreenState.LOAD_POPUP:
                sectionMainMenu.SetActive(false);
                sectionNewGamePopup.SetActive(false);
                sectionLoadGamePopup.SetActive(true);
                sectionQuitGamePopup.SetActive(false);
                sectionSocialAside.SetActive(false);
                sectionSettingsMenu.SetActive(false);
                sectionGraphicsSettings.SetActive(false);
                sectionAudioSettings.SetActive(false);
                sectionControlsSettings.SetActive(false);
                sectionInterfaceSettings.SetActive(false);
                sectionSystemSettings.SetActive(false);
                break;

            case HomeScreenState.QUIT_POPUP:
                sectionMainMenu.SetActive(false);
                sectionNewGamePopup.SetActive(false);
                sectionLoadGamePopup.SetActive(false);
                sectionQuitGamePopup.SetActive(true);
                sectionSocialAside.SetActive(false);
                sectionSettingsMenu.SetActive(false);
                sectionGraphicsSettings.SetActive(false);
                sectionAudioSettings.SetActive(false);
                sectionControlsSettings.SetActive(false);
                sectionInterfaceSettings.SetActive(false);
                sectionSystemSettings.SetActive(false);
                break;

            case HomeScreenState.GRAPH_SETTING:
                sectionMainMenu.SetActive(false);
                sectionNewGamePopup.SetActive(false);
                sectionLoadGamePopup.SetActive(false);
                sectionQuitGamePopup.SetActive(false);
                sectionSocialAside.SetActive(false);
                sectionSettingsMenu.SetActive(true);
                sectionGraphicsSettings.SetActive(true);
                sectionAudioSettings.SetActive(false);
                sectionControlsSettings.SetActive(false);
                sectionInterfaceSettings.SetActive(false);
                sectionSystemSettings.SetActive(false);
                break;

            case HomeScreenState.AUDIO_SETTING:
                sectionMainMenu.SetActive(false);
                sectionNewGamePopup.SetActive(false);
                sectionLoadGamePopup.SetActive(false);
                sectionQuitGamePopup.SetActive(false);
                sectionSocialAside.SetActive(false);
                sectionSettingsMenu.SetActive(true);
                sectionGraphicsSettings.SetActive(false);
                sectionAudioSettings.SetActive(true);
                sectionControlsSettings.SetActive(false);
                sectionInterfaceSettings.SetActive(false);
                sectionSystemSettings.SetActive(false);
                break;

            case HomeScreenState.CONTROL_SETTING:
                sectionMainMenu.SetActive(false);
                sectionNewGamePopup.SetActive(false);
                sectionLoadGamePopup.SetActive(false);
                sectionQuitGamePopup.SetActive(false);
                sectionSocialAside.SetActive(false);
                sectionSettingsMenu.SetActive(true);
                sectionGraphicsSettings.SetActive(false);
                sectionAudioSettings.SetActive(false);
                sectionControlsSettings.SetActive(true);
                sectionInterfaceSettings.SetActive(false);
                sectionSystemSettings.SetActive(false);
                break;

            case HomeScreenState.INTERFACE_SETTING:
                sectionMainMenu.SetActive(false);
                sectionNewGamePopup.SetActive(false);
                sectionLoadGamePopup.SetActive(false);
                sectionQuitGamePopup.SetActive(false);
                sectionSocialAside.SetActive(false);
                sectionSettingsMenu.SetActive(true);
                sectionGraphicsSettings.SetActive(false);
                sectionAudioSettings.SetActive(false);
                sectionControlsSettings.SetActive(false);
                sectionInterfaceSettings.SetActive(true);
                sectionSystemSettings.SetActive(false);
                break;

            case HomeScreenState.SYSTEM_SETTING:
                sectionMainMenu.SetActive(false);
                sectionNewGamePopup.SetActive(false);
                sectionLoadGamePopup.SetActive(false);
                sectionQuitGamePopup.SetActive(false);
                sectionSocialAside.SetActive(false);
                sectionSettingsMenu.SetActive(true);
                sectionGraphicsSettings.SetActive(false);
                sectionAudioSettings.SetActive(false);
                sectionControlsSettings.SetActive(false);
                sectionInterfaceSettings.SetActive(false);
                sectionSystemSettings.SetActive(true);
                break;

            default:
                sectionMainMenu.SetActive(false);
                sectionNewGamePopup.SetActive(false);
                sectionLoadGamePopup.SetActive(false);
                sectionQuitGamePopup.SetActive(false);
                sectionSocialAside.SetActive(false);
                sectionSettingsMenu.SetActive(false);
                sectionGraphicsSettings.SetActive(false);
                sectionAudioSettings.SetActive(false);
                sectionControlsSettings.SetActive(false);
                sectionInterfaceSettings.SetActive(false);
                sectionSystemSettings.SetActive(false);
                break;
        }
    }

    public void ActionMainMenu()
    {
        state = HomeScreenState.MAIN;
        UpdatePanels();
    }

    public void ActionNewPopup()
    {
        state = HomeScreenState.NEW_POPUP;
        UpdatePanels();
    }

    public void ActionNewGame()
    {
        throw new NotImplementedException();
    }

    public void ActionLoadPopup()
    {
        state = HomeScreenState.LOAD_POPUP;
        UpdatePanels();
    }

    public void ActionLoadGame()
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
}
