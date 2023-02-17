using Infrastructure.DI.Services.StateService;
using Infrastructure.States;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Ui.Windows
{
    public class PauseWindow : Window
    {
        private const string MusicVolume = "MusicVolume";
        private const string EffectsVolume = "EffectsVolume";
        
        [SerializeField] private AudioMixerGroup musicAudioMixerGroup;
        [SerializeField] private AudioMixerGroup effectsAudioMixerGroup;

        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider effectsSlider;

        private GameState _gameState;
        private IGameStateMachine _gameStateMachine;

        public void Construct(IGameStateService gameStateService, IGameStateMachine gameStateMachine)
        {
            _gameState = gameStateService.State;
            _gameStateMachine = gameStateMachine;

            float musicVolume = _gameState.MusicVolume;
            float effectsVolume = _gameState.EffectsVolume;
            
            ChangeVolume(musicAudioMixerGroup, MusicVolume, musicVolume);
            ChangeVolume(effectsAudioMixerGroup, EffectsVolume, effectsVolume);

            musicSlider.value = musicVolume;
            effectsSlider.value = effectsVolume;
        }

        private void Awake()
        {
            ChangeMusicVolume();
            ChangeEffectsVolume();
        }

        protected override void Close()
        {
            _gameState.MusicVolume = musicSlider.value;
            _gameState.EffectsVolume = effectsSlider.value;
            
            base.Close();
        }

        public void OnQuitButtonPressed(string sceneName)
        {
            _gameState.Reset();
            _gameStateMachine.Enter<LoadSceneState, string>(sceneName);
            Close();
        }

        public void OnResumeButtonPressed()
        {
            _gameState.IsGameRunning = true;
            Close();
        }

        public void ChangeMusicVolume()
        {
            ChangeVolume(musicAudioMixerGroup, MusicVolume, musicSlider.value);
        }
        
        public void ChangeEffectsVolume()
        {
            ChangeVolume(effectsAudioMixerGroup, EffectsVolume, effectsSlider.value);
        }

        private void ChangeVolume(AudioMixerGroup group, string param, float value)
        {
            group.audioMixer.SetFloat(param, Mathf.Lerp(-80, 0, value));
        }
    }
}