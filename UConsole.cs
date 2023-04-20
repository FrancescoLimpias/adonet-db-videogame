using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    /* UTILITIES for CONSOLE
     * 
     */
    internal static class UConsole
    {
        /* CURSOR LOCKING MECHANISM
         * (private, it's an internal mechanic)
         */
        private static int lockStack = 0;
        private static (int left, int top)? lockedCursorPosition = null;

        private static bool IsCursorLocked()
        {
            return lockedCursorPosition != null;
        }
        private static void LockCursor()
        {
            if (lockStack++ == 0)
            {
                lockedCursorPosition = Console.GetCursorPosition();
            }
        }
        private static void UnlockCursor()
        {
            if (--lockStack == 0)
            {
                lockedCursorPosition = null;
            }
        }
        private static void ResumeCursorPosition()
        {
            Console.SetCursorPosition(lockedCursorPosition.Value.left, lockedCursorPosition.Value.top);
            Console.Write(new string(' ', 10));
            Console.SetCursorPosition(lockedCursorPosition.Value.left, lockedCursorPosition.Value.top);
        }

        //ASK FOR INPUT STRING
        internal static string AskString()
        {
            //Lock cursor
            LockCursor();
            ResumeCursorPosition();

            //Ask for string and check input
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                return AskString();

            //Unlock cursor and return
            UnlockCursor();
            return input;
        }

        //ASK FOR INPUT STRING AND CAST
        internal static T AskStringToCast<T>(Func<string, T> CastingMethod)
        {
            //Lock cursor
            LockCursor();

            string input = AskString();
            T result;
            try
            {
                result = CastingMethod(input);
            }
            catch (Exception)
            {
                result = AskStringToCast(CastingMethod);
            }

            UnlockCursor();
            return result;
        }

        //ASK FOR INPUT STRING AND CAST TO INTEGER
        internal static int AskInt()
        {
            return AskStringToCast((input) => Convert.ToInt32(input));
        }
    }
}
