using System;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace School
{
	public class ThemeChangedMessage : ValueChangedMessage<string>
	{
		public ThemeChangedMessage(string value) : base(value)
		{
		}
	}
}