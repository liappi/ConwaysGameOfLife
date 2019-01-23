using System;
using System.Runtime.CompilerServices;

namespace ConwaysGameOfLife
{
    public class Position : IEquatable<Position>
    {
        public readonly int x;
        public readonly int y;

        public Position(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Position other)
        {
            if (other is null) 
                return false;
            
            return x == other.x && y == other.y;
        }
        
        public override bool Equals(object obj) => Equals(obj as Position);
        public override int GetHashCode() => (x, y).GetHashCode();
    }
    
}