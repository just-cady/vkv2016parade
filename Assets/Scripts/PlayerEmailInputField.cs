using UnityEngine;
using UnityEngine.UI;

using System.Collections;

namespace com.kreweofvaporwave.parade
{
	
	[RequireComponent(typeof(InputField))]
	public class PlayerEmailInputField : MonoBehaviour
	{
		#region Private Variables

		// Store the PlayerPref Key to avoid typos
		static string playerEmailPrefKey = "PlayerEmail";

		#endregion

		#region MonoBehaviour CallBacks

		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity during initialization phase.
		/// </summary>
		void Start () {

			string defaultEmail = "";
			InputField _inputField = this.GetComponent<InputField>();

			if (_inputField!=null)
			{
				if (PlayerPrefs.HasKey(playerEmailPrefKey))
				{
					defaultEmail = PlayerPrefs.GetString(playerEmailPrefKey);
					_inputField.text = defaultEmail;
				}
			}

		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Sets the Email of the player, and save it in the PlayerPrefs for future sessions.
		/// </summary>
		/// <param Email="value">The Email of the Player</param>
		public void SetPlayerEmail(string value)
		{
			// #Important


			PlayerPrefs.SetString(playerEmailPrefKey,value);
		}

		#endregion
	}
}
