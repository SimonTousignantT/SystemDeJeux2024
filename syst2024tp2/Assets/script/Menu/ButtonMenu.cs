using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject m_soundManager;
    private AudioSource m_sourceAudio;
    [SerializeField]
    private AudioClip Foghorn;
    [SerializeField]
    private DataSave m_dataSave;
    // Start is called before the first frame update
    private void Start()
    {
        m_sourceAudio = m_soundManager.GetComponent<AudioSource>();
    }
    public void BouttonNouvellePartieOnClick()
    {
        SceneManager.LoadScene("LvlSelector");
        m_sourceAudio.PlayOneShot(Foghorn);
        m_dataSave.DeleteSaveFile();
    }
    public void BouttonCargerPartieOnClick()
    {
        SceneManager.LoadScene("LvlSelector");
        m_sourceAudio.PlayOneShot(Foghorn);

    }
    public void BouttonQuitterOnClick()
    {
        Application.Quit();
        m_sourceAudio.PlayOneShot(Foghorn);
    }

}
