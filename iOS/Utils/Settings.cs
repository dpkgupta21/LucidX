
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace IosUtils
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string RemeberMeKey = "rememberme_key";
		private const string UserNameKey = "username_key";
		private const string PasswordKey = "password_key";
		private const string LanguageKey = "language_key";
		

		#endregion

		public static bool IsRememberMeSelected
		{
			get
			{
				return AppSettings.GetValueOrDefault(RemeberMeKey, false);
			}
			set
			{
				AppSettings.AddOrUpdateValue(RemeberMeKey, value);
			}
		}

		public static string UserName
		{
			get
			{
				return AppSettings.GetValueOrDefault(UserNameKey, string.Empty);
			}
			set
			{
				AppSettings.AddOrUpdateValue(UserNameKey, value);
			}
		}

		public static string Password
		{
			get
			{
				return AppSettings.GetValueOrDefault(PasswordKey, string.Empty);
			}
			set
			{
				AppSettings.AddOrUpdateValue(PasswordKey, value);
			}
		}

		public static string CurrentLanguage
		{
			get
			{
				return AppSettings.GetValueOrDefault(LanguageKey, "en");
			}
			set
			{
				AppSettings.AddOrUpdateValue(LanguageKey, value);
			}
		}


		public static void RemoveLoginInfo() {
			AppSettings.Remove(UserNameKey);
			AppSettings.Remove(PasswordKey);
			AppSettings.Remove(RemeberMeKey);
		}

	}
}