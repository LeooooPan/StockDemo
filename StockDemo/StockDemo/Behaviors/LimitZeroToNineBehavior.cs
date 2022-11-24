using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace StockDemo.Behaviors
{
	public class LimitZeroToNineBehavior : Behavior<TextBox>
	{
		//鎖定0~9以外的輸入 輸入鎖定英文-> TextBox InputMethod.IsInputMethodEnabled="False"
		Regex regex = new Regex("[^0-9]+$");

		protected override void OnAttached()
		{
			AssociatedObject.PreviewTextInput += AssociatedObject_PreviewTextInput;
			AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
		}

		private void AssociatedObject_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key.Space)
			{
				e.Handled = true;
			}
		}

		private void AssociatedObject_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
		{
			e.Handled = regex.IsMatch(e.Text);
		}

		protected override void OnDetaching()
		{
			AssociatedObject.PreviewTextInput -= AssociatedObject_PreviewTextInput;
			AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
		}
	}
}
