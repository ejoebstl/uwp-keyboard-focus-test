using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Input.Preview.Injection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Keyboard_Focus_Test
{
    public sealed partial class Keyboard : UserControl
    {
        InputInjector inputInjector;

        public Keyboard()
        {
            this.InitializeComponent();
            this.AllowFocusOnInteraction = false;
            this.AllowFocusWhenDisabled = false;

            this.ButtonLeft.AllowFocusOnInteraction = false;
            this.ButtonRight.AllowFocusOnInteraction = false;

            this.inputInjector = InputInjector.TryCreate();
        }

        private void SendUnicodeKey(char unicodeKey)
        {
            // API In Background: https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-keybdinput
            var key = new InjectedInputKeyboardInfo();
            key.ScanCode = (ushort)unicodeKey;
            key.KeyOptions = InjectedInputKeyOptions.Unicode;

            this.inputInjector.InjectKeyboardInput(new[] { key });
        }
        private void SendVirtualKey(VirtualKey vk)
        {
            var key = new InjectedInputKeyboardInfo();
            key.VirtualKey = (ushort)vk;
            key.KeyOptions = InjectedInputKeyOptions.None;

            this.inputInjector.InjectKeyboardInput(new[] { key });
        }

        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            SendUnicodeKey('Ä');
        }

        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            SendVirtualKey(VirtualKey.Back);
        }
        private void ButtonLeftBottom_Click(object sender, RoutedEventArgs e)
        {
            SendUnicodeKey('a');
        }

        private void ButtonRightBottom_Click(object sender, RoutedEventArgs e)
        {
            SendUnicodeKey('Á');
        }
    }
}
