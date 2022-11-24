using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace StockDemo.Behaviors
{
    public class SelectAllTextOnFocusBehavior : Behavior<TextBox>
	{
		//Focus Textbox時 全選Textbox內容

		protected override void OnAttached()
		{
			base.OnAttached();
			AssociatedObject.GotKeyboardFocus += AssociatedObjectGotKeyboardFocus;
			AssociatedObject.GotMouseCapture += AssociatedObjectGotMouseCapture;
			AssociatedObject.PreviewMouseLeftButtonDown += AssociatedObjectPreviewMouseLeftButtonDown;
			AssociatedObject.FocusableChanged += AssociatedObject_FocusableChanged;
		}

		private void AssociatedObject_FocusableChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
		{
			AssociatedObject.SelectAll();
		}

		protected override void OnDetaching()
		{
			base.OnDetaching();
			AssociatedObject.GotKeyboardFocus -= AssociatedObjectGotKeyboardFocus;
			AssociatedObject.GotMouseCapture -= AssociatedObjectGotMouseCapture;
			AssociatedObject.PreviewMouseLeftButtonDown -= AssociatedObjectPreviewMouseLeftButtonDown;
		}

		private void AssociatedObjectGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
		{
			AssociatedObject.SelectAll();
		}

		private void AssociatedObjectGotMouseCapture(object sender, MouseEventArgs e)
		{
			AssociatedObject.SelectAll();
		}

		private void AssociatedObjectPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (!AssociatedObject.IsKeyboardFocusWithin)
			{
				AssociatedObject.Focus();
				e.Handled = true;
			}
		}

	}
}