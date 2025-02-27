﻿using System;
using System.Text;

using UnityEngine;

using UnityEngine.Windows.Speech;

using UnityEngine.Video;

public class VoiceDetector : MonoBehaviour {

	[SerializeField]

	private string[] m_Keywords;

	private KeywordRecognizer m_Recognizer;

	public VideoPlayer vid;

	private AudioSource aus;

	public Animator animm;

	void Start() {

		m_Keywords = new string[2];

		m_Keywords[0] = "Open";

		m_Keywords[1] = "Play";

		m_Recognizer = new KeywordRecognizer(m_Keywords);

		m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;

		m_Recognizer.Start();

		aus = GetComponent<AudioSource> ();

	}

	private void OnPhraseRecognized(PhraseRecognizedEventArgs args) {

		StringBuilder builder = new StringBuilder();
	
		float newX = UnityEngine.Random.Range(-3, 3);

		float newZ = UnityEngine.Random.Range(-3, 3);

		if (args.text == m_Keywords[0]) {


			//animm.SetTrigger (openDooor);
			animm.SetBool ("Slide", true);
			aus.Play ();

			//Instantiate(Cube, new Vector3(newX, newZ, 1), Quaternion.identity);

		}

		else {
			vid.Play ();
			//Instantiate(Sphere, new Vector3(newX, newZ, 1), Quaternion.identity);

		}

		builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);

		builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);

		builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);

		Debug.Log(builder.ToString());

	}

}