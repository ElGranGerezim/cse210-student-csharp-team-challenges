using System;
using Raylib_cs;

namespace _07_speed
{
    class InputService
    {
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
    }
}
