/* 
* Copyright Wemade Play Co., Ltd. All Rights Reserved
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* 
* @author Han Hyeonggeun <hyeonggeun.han@wemadeplay.com>
* @created 2022-04-08
* @desc SoundManager
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace common
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        private static AudioSource _audioBGM;
        private static AudioSource _audioSFX;
        private static AudioSource _audioVoice;
        private static AudioSource _audioMove;

        public static AudioClip SFX_BUTTON;
        public static List<AudioClip> BGM_INGAME = new List<AudioClip>();
        public static List<AudioClip> SFXS = new List<AudioClip>();
        public static List<AudioClip> VOICES = new List<AudioClip>();

        public bool init = false;

        public GameManager manager { get; private set; }

        public void Init(GameManager manager)
        {
            init = true;
            this.manager = manager;
        }

        void LoadSounds()
        {
            //state mute
            _audioBGM.volume = PlayerPrefs.GetInt("MuteBGM") == 1 ? 0 : 0.5f;
            _audioSFX.volume = PlayerPrefs.GetInt("MuteSFX") == 1 ? 0 : 0.6f;
            _audioVoice.volume = PlayerPrefs.GetInt("MuteSFX") == 1 ? 0 : 0.7f;

            SFXS.Add(Resources.Load<AudioClip>("Sound/common_bt"));

            SFXS.Add(Resources.Load<AudioClip>("Sound/Button"));

            SFXS.Add(Resources.Load<AudioClip>("Sound/BookDrop"));
            SFXS.Add(Resources.Load<AudioClip>("Sound/BookNext"));
            SFXS.Add(Resources.Load<AudioClip>("Sound/BookSelect"));
            SFXS.Add(Resources.Load<AudioClip>("Sound/Goodjob3sec"));
            SFXS.Add(Resources.Load<AudioClip>("Sound/GroupComplete"));

            SFXS.Add(Resources.Load<AudioClip>("Sound/Intro"));
            SFXS.Add(Resources.Load<AudioClip>("Sound/Powerup"));
            SFXS.Add(Resources.Load<AudioClip>("Sound/Win"));

            //SFXS.Add(Resources.Load<AudioClip>("Sound/Stage_Clear"));
            //SFXS.Add(Resources.Load<AudioClip>("Sound/Stage_Fail"));
            //SFXS.Add(Resources.Load<AudioClip>("Sound/Item_buy_success"));

            //VOICES.Add(Resources.Load<AudioClip>("Sound/donotdrop_start_voice"));
            //VOICES.Add(Resources.Load<AudioClip>("Sound/donotdrop_fail_voice"));
            //VOICES.Add(Resources.Load<AudioClip>("Sound/donotdrop_voice_sfx_A"));
            //VOICES.Add(Resources.Load<AudioClip>("Sound/donotdrop_voice_sfx_B"));
            //VOICES.Add(Resources.Load<AudioClip>("Sound/donotdrop_voice_sfx_C"));
            //VOICES.Add(Resources.Load<AudioClip>("Sound/donotdrop_voice_sfx_D"));
        }

        public void SetMuteState(bool isBGM, bool isMute)
        {
            if (isBGM == true)
            {
                _audioBGM.volume = isMute ? 0 : 0.5f;
            }
            else
            {
                _audioSFX.volume = isMute ? 0 : 1;
                _audioVoice.volume = isMute ? 0 : 1;
                _audioMove.volume = isMute ? 0 : 1;
            }
        }

        public void SetVolumeBGM(float volume)
        {
            if (PlayerPrefs.GetInt("MuteBGM") == 1)
                return;

            if (_audioBGM.isPlaying)
                _audioBGM.volume = volume;

            if (_audioSFX.isPlaying)
                _audioSFX.volume = volume;
        }

        public void InTitleBGM()
        {
            string bgmName = "sound/bgm/bgm_title";
            if (_audioBGM.isPlaying)
            {
                _audioBGM.Stop();
            }

            _audioBGM.clip = Resources.Load<AudioClip>(bgmName);
            _audioBGM.loop = true;
            _audioBGM.Play();
        }

        public void InGameBGM()
        {
            string str = "Sound/BGM_Ingame";
            AudioClip clip = Resources.Load<AudioClip>(str);

            if (_audioBGM.clip == clip)
                return;

            if (_audioBGM.isPlaying)
            {
                _audioBGM.Stop();
            }

            _audioBGM.clip = clip;
            _audioBGM.loop = true;
            _audioBGM.Play();
        }

        public void StopBGM(bool forceStop = false)
        {
            if (forceStop == true)
            {
                _audioBGM.Stop();
                _audioBGM.clip = null;
            }
            else
            {
                if (_audioBGM.isPlaying)
                {
                    _audioBGM.Stop();
                    _audioBGM.clip = null;
                }
            }
        }

        public void PauseBGM()
        {
            if (_audioBGM.isPlaying)
                _audioBGM.Pause();
        }

        public void ResumeBGM()
        {
            if (_audioBGM.isPlaying == false && _audioBGM.clip != null)
                _audioBGM.Play();
        }

        public void StopSFX()
        {
            if (_audioSFX.isPlaying)
            {
                _audioSFX.Stop();
                _audioSFX.clip = null;
            }
        }

        public void StopVoice()
        {
            if (_audioVoice.isPlaying)
            {
                _audioVoice.Stop();
                _audioVoice.clip = null;
            }
        }

        public void StopMove()
        {
            if (_audioMove.isPlaying)
            {
                _audioMove.Stop();
                _audioMove.clip = null;
            }
        }

        public void PauseAllSFX()
        {
            _audioSFX.Stop();
            _audioVoice.Stop();
        }

        public void ResumeAllSFX()
        {
            _audioSFX.Play();
            _audioVoice.Play();
        }

        public void PlayVoice(string name, bool loop = false)
        {
            AudioClip audioClip;

            for (int i = 0; i < VOICES.Count; i++)
            {
                audioClip = VOICES[i];
                if (audioClip == null)
                    continue;

                if (audioClip.name == name)
                {
                    if (loop == true)
                    {
                        _audioVoice.loop = true;
                        _audioVoice.clip = audioClip;
                        _audioVoice.Play();
                    }
                    else
                    {
                        _audioVoice.loop = false;
                        _audioVoice.PlayOneShot(audioClip);
                    }
                    break;
                }
            }
        }

        public void PlayMove(string name, bool loop = false)
        {
            AudioClip audioClip;

            for (int i = 0; i < VOICES.Count; i++)
            {
                audioClip = VOICES[i];
                if (audioClip == null)
                    continue;

                if (audioClip.name == name)
                {
                    if (_audioSFX.volume > 0)
                    {
                        if (name.Equals("BookNext")) _audioSFX.volume = 0.6f;
                        else if (name.Equals("BookDrop")) _audioSFX.volume = 0.8f;
                        else _audioSFX.volume = 1;
                    }

                    if (loop == true)
                    {
                        _audioMove.loop = true;
                        _audioMove.clip = audioClip;
                        _audioMove.Play();
                    }
                    else
                    {
                        _audioMove.loop = false;
                        _audioMove.PlayOneShot(audioClip);
                    }
                    break;
                }
            }
        }

        public void PlaySFX(string name, bool loop = false)
        {
            AudioClip audioClip;

            for (int i = 0; i < SFXS.Count; i++)
            {
                audioClip = SFXS[i];
                if (audioClip == null)
                    continue;

                if (audioClip.name == name)
                {
                    if (_audioSFX.volume > 0)
                    {
                        if (name.Equals("BookNext")) _audioSFX.volume = 0.6f;
                        else if (name.Equals("BookDrop")) _audioSFX.volume = 0.8f;
                        else _audioSFX.volume = 1;
                    }
                    
                    if (loop == true)
                    {
                        _audioSFX.loop = true;
                        _audioSFX.clip = audioClip;
                        _audioSFX.Play();
                    }
                    else
                    {
                        _audioSFX.loop = false;
                        _audioSFX.PlayOneShot(audioClip);
                    }
                    break;
                }
            }
        }

        public void PlaySFX(string name, float fromSecond, float toSecond)
        {
            AudioClip audioClip;

            for (int i = 0; i < SFXS.Count; i++)
            {
                audioClip = SFXS[i];
                if (audioClip == null)
                    continue;

                if (audioClip.name == name)
                {
                    _audioSFX.time = fromSecond;
                    _audioSFX.loop = false;
                    _audioSFX.clip = audioClip;
                    _audioSFX.Play();
                    _audioSFX.SetScheduledEndTime(AudioSettings.dspTime + (toSecond - fromSecond));
                    break;
                }
            }
        }

        static SoundManager _instance;
        public static SoundManager instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Common.CreateSingleton<SoundManager>("(Singleton)SoundManager");
                    _audioBGM = _instance.gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
                    _audioSFX = _instance.gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
                    _audioVoice = _instance.gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
                    _audioMove = _instance.gameObject.AddComponent(typeof(AudioSource)) as AudioSource;

                    _instance.LoadSounds();
                }
                return _instance;
            }
        }
    }
}