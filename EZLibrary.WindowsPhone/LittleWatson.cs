﻿using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using Microsoft.Phone.Tasks;

namespace TodotxtTouch.WindowsPhone
{
	/// <summary>
	/// http://blogs.msdn.com/b/andypennell/archive/2010/11/01/error-reporting-on-windows-phone-7.aspx
	/// </summary>
	public class LittleWatson
	{
		private const string filename = "LittleWatson.txt";

		internal static void ReportException(Exception ex, string extra)
		{
			try
			{
				using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
				{
					SafeDeleteFile(store);

					using (TextWriter output = new StreamWriter(store.CreateFile(filename)))
					{
						output.WriteLine(extra);

						output.WriteLine(ex.Message);

						output.WriteLine(ex.StackTrace);
					}
				}
			}

			catch (Exception)
			{
			}
		}


		internal static void CheckForPreviousException(string reportSubject, string reportToEmail)
		{
			try
			{
				string contents = null;

				using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
				{
					if (store.FileExists(filename))
					{
						using (
							TextReader reader = new StreamReader(store.OpenFile(filename, FileMode.Open, FileAccess.Read, FileShare.None)))
						{
							contents = reader.ReadToEnd();
						}

						SafeDeleteFile(store);
					}
				}

				if (contents != null)
				{
					if (
						MessageBox.Show(
							"A problem occurred the last time you ran this application. Would you like to send an email to report it?",
							"Problem Report", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
					{
						var email = new EmailComposeTask();

						email.To = reportToEmail;

						email.Subject = reportSubject;

						email.Body = contents;

						SafeDeleteFile(IsolatedStorageFile.GetUserStoreForApplication()); // line added 1/15/2011
						email.Show();
					}
				}
			}

			catch (Exception)
			{
			}

			finally
			{
				SafeDeleteFile(IsolatedStorageFile.GetUserStoreForApplication());
			}
		}


		private static void SafeDeleteFile(IsolatedStorageFile store)
		{
			try
			{
				store.DeleteFile(filename);
			}

			catch (Exception ex)
			{
			}
		}
	}
}