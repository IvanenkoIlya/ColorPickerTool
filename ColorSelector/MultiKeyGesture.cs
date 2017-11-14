using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ColorSelector
{
    class MultiKeyGesture : KeyGesture
    {
        private readonly IList<Key> _keys;
        private int _currentKeyIndex;
        private DateTime _lastKeyPress;
        private static readonly TimeSpan _maximumDelayBetweenKeyPresses = TimeSpan.FromSeconds(1);

        public MultiKeyGesture(IEnumerable<Key> keys, ModifierKeys modifiers)
            : this(keys, modifiers, string.Empty)
        {
        }

        public MultiKeyGesture(IEnumerable<Key> keys, ModifierKeys modifiers, string displayString) 
            :base( Key.None, modifiers, displayString)
        {
            _keys = new List<Key>(keys);

            if(_keys.Count == 0)
            {
                throw new ArgumentException("At least one key must be specified");
            }
        }

        public override bool Matches(object targetElement, InputEventArgs inputEventArgs)
        {
            var args = inputEventArgs as KeyEventArgs;

            if ((args == null) || !IsDefinedKey(args.Key))
            {
                return false;
            }

            if (
                (_currentKeyIndex != 0 && ((DateTime.Now - _lastKeyPress) > _maximumDelayBetweenKeyPresses)) || // Timeout between keypresses
                (_currentKeyIndex == 0 && Modifiers != Keyboard.Modifiers) || // Wrong Modifier on first key
                (_keys[_currentKeyIndex] != args.Key) // Wrong key pressed
               )
            {
                _currentKeyIndex = 0;
                return false;
            }

            ++_currentKeyIndex;
            
            if(_currentKeyIndex != _keys.Count)
            {
                _lastKeyPress = DateTime.Now;
                inputEventArgs.Handled = true;
                return false;
            }

            _currentKeyIndex = 0;
            return true;
        }

        private static bool IsDefinedKey(Key key)
        {
            return ((key >= Key.None) && (key <= Key.OemClear));
        }
    }
}
