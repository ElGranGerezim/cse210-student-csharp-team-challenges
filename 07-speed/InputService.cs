using System;
using Raylib_cs;

namespace _07_speed
{
    class InputService
    {
        /// <summary> 
        public string getInput(){
            int keyInt = Raylib.GetKeyPressed();
            string keyString = "";
            while (keyInt != 0)
            {
                char keyChar = (char)keyInt;
                keyString += keyChar.ToString().ToLower();
                keyInt = Raylib.GetKeyPressed();
            }
            return keyString;
        }

        /// <summary>
        /// Returns true if the user has attempted to close the window.
        /// </summary>
        /// <returns></returns>
        public bool IsWindowClosing()
        {
            return Raylib.WindowShouldClose();
        }
    }
}
