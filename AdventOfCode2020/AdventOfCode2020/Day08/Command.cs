using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day8
{
    public class Command
    {
        public string Type { get; set; }
        public int Steps { get; set; }
        public bool AlreadyCalled { get; set; }

        public String InitString { get; set; }

        public Command( string s )
        {
            InitString = s;
            if( !string.IsNullOrEmpty( s ) )
            {
                var ls = s.Split( ' ' );
                Type = ls[0];
                Steps = Int32.Parse( ls[1] );
                AlreadyCalled = false;
            }
        }

    }
}
