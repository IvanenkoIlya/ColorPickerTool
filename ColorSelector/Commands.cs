using System.Windows.Input;

namespace ColorSelector
{
    public static class Commands
    {
        public static readonly ICommand ColorPickerCommand;

        static Commands()
        {
            var inputGestures = new InputGestureCollection();
            inputGestures.Add(new MultiKeyGesture(new Key[] { Key.C, Key.P }, ModifierKeys.Control, "Ctrl+C,P"));
            ColorPickerCommand = new RoutedCommand("ColorPicker", typeof(Commands), inputGestures);
        }
    }
}
