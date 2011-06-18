using System;
using System.Collections.Generic;
using System.Linq;

namespace EZLibrary
{
	public static class StringExtensions
	{
		/// <summary>
		/// Renders an IEnumerable<typeparamref name="T"/> as a comma-delimited list of strings
		/// </summary>
		/// <typeparam name="T">The generic type</typeparam>
		/// <param name="enumerable">The IEnumerable to render</param>
		/// <param name="stringSelector">String selector to be applied to each item in the IEnumerable</param>
		/// <returns>A comma-delimited list of strings</returns>
		public static String ToCommaDelimitedList<T>(this IEnumerable<T> enumerable, Func<T, String> stringSelector)
		{
			return ToDelimitedList(enumerable, stringSelector, ", ");
		}

		/// <summary>
		/// Renders an IEnumerable<typeparamref name="T"/> as a delimited list of strings
		/// </summary>
		/// <typeparam name="T">The generic type</typeparam>
		/// <param name="enumerable">The IEnumerable to render</param>
		/// <param name="stringSelector">String selector to be applied to each item in the IEnumerable</param>
		/// <param name="delimiter">The delimiter to use</param>
		/// <returns>A delimited list of strings</returns>
		public static String ToDelimitedList<T>(this IEnumerable<T> enumerable, Func<T, String> stringSelector, String delimiter)
		{
			return enumerable.Aggregate(String.Empty,
										(list, thing) => list
														 + (list.Length == 0 ? String.Empty : delimiter)
														 + stringSelector(thing));
		}
	}
}
