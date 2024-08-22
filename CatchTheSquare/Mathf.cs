using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheSquare
{
    class Mathf
    {
        public static Random Random = new Random();

        public static Vector2f MoveTowards(Vector2f current, Vector2f target, float maxDistnceDelta) 
        {
            Vector2f dir = target - current;
            float magnitude = (float)Math.Sqrt(dir.X * dir.X + dir.Y * dir.Y);

            if (magnitude <= maxDistnceDelta || magnitude == 0f)
            {
                return target;
            }
            else
            {
                return current + dir / magnitude * maxDistnceDelta;
            }
        }

    }
}
