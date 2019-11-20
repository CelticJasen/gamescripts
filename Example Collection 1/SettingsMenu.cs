using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
	private const string MasterVolumeKey = "MasterVolume";
	private const string MusicVolumeKey = "MusicVolume";
	private const string SoundVolumeKey = "SoundVolume";


	[Header("Audio Settings")]
	[SerializeField] private AudioMixer audioMixer;
	[SerializeField] private AnimationCurve volumeCurve;
	[SerializeField] private Slider masterVolumeSlider;
	[SerializeField] private Slider musicVolumeSlider;
	[SerializeField] private Slider soundVolumeSlider;

	[Header("Graphics Settings")]
	[SerializeField] private Dropdown resolutionDropdown;
	[SerializeField] private Toggle fullscreenToggle;
	[SerializeField] private Dropdown qualityDropdown;

	private void Awake()
	{
		resolutionDropdown.ClearOptions ();
		var resolutions = new List<string> ();

		foreach (var resolution in Screen.resolutions)
		{
			resolutions.Add (string.Format("{0}\tx\t{1}", resolution.width, resolution.height));
		}

		resolutionDropdown.AddOptions (resolutions);

		qualityDropdown.ClearOptions ();
		qualityDropdown.AddOptions(QualitySettings.names.ToList());
	}

	private void OnEnable()
	{
		masterVolumeSlider.normalizedValue = PlayerPrefs.GetFloat(MasterVolumeKey, 1f);
		musicVolumeSlider.normalizedValue = PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
		soundVolumeSlider.normalizedValue = PlayerPrefs.GetFloat(SoundVolumeKey, 1f);
		qualityDropdown.value = QualitySettings.GetQualityLevel ();
		resolutionDropdown.value = Screen.resolutions.ToList ().FindIndex (obj => obj.width == Screen.width && obj.height == Screen.height);
		fullscreenToggle.isOn = Screen.fullScreen;
	}

	private void Update()
	{
		audioMixer.SetFloat (MasterVolumeKey, volumeCurve.Evaluate(masterVolumeSlider.normalizedValue));
		audioMixer.SetFloat (MusicVolumeKey, volumeCurve.Evaluate(musicVolumeSlider.normalizedValue));
		audioMixer.SetFloat (SoundVolumeKey, volumeCurve.Evaluate(soundVolumeSlider.normalizedValue));
	}

	public void Apply()
	{
		PlayerPrefs.SetFloat (MasterVolumeKey, masterVolumeSlider.normalizedValue);
		PlayerPrefs.SetFloat (MusicVolumeKey, musicVolumeSlider.normalizedValue);
		PlayerPrefs.SetFloat (SoundVolumeKey, soundVolumeSlider.normalizedValue);
		QualitySettings.SetQualityLevel (qualityDropdown.value, true);
		Screen.SetResolution (Screen.resolutions [resolutionDropdown.value].width, Screen.resolutions [resolutionDropdown.value].height, fullscreenToggle.isOn);
	}

	public void Revert()
	{
		audioMixer.SetFloat (MasterVolumeKey, volumeCurve.Evaluate(PlayerPrefs.GetFloat(MasterVolumeKey, 1f)));
		audioMixer.SetFloat (MusicVolumeKey, volumeCurve.Evaluate(PlayerPrefs.GetFloat(MusicVolumeKey, 1f)));
		audioMixer.SetFloat (SoundVolumeKey, volumeCurve.Evaluate(PlayerPrefs.GetFloat(SoundVolumeKey, 1f)));
	}
}