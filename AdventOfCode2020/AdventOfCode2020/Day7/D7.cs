namespace AdventOfCode2020.Day7
{
    using AdventOfCode2020.Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class D7
    {
        private List<Bag> rules;

        public D7()
        {
            rules = new List<Bag>();
            ReadInput();
        }

        public void Solve()
        {
            Console.WriteLine( SolvePart1() );
            Console.WriteLine( SolvePart2() );
        }

        private int SolvePart1()
        {
            Bag b = new Bag();
            b.Color = "gold";
            b.Modifier = "shiny";
            int count = 0;
            foreach( var bag in rules )
            {
                if( bag.ContainsBag( b, ref rules ) )
                    count++;
            }
            return count;

        }

        private int SolvePart2()
        {
            Bag b = new Bag();
            b.Color = "gold";
            b.Modifier = "shiny";

            return rules.FirstOrDefault( c => c.Equals( b ) ).CountBags( ref rules );
        }

        private void ReadInput()
        {
            var s = Resources.input_day7;
            foreach( var item in s.Split( '\n' ).ToList() )
            {
                int count = -1;
                var ls = item.Split( new string[] { "contain" }, StringSplitOptions.RemoveEmptyEntries ).ToList();

                if( ls.Count > 0 )
                {
                    Bag b = String2Bag( ls[0].Trim(), out count );

                    if( !ls[1].Trim().Equals( "no other bags", StringComparison.CurrentCultureIgnoreCase ) )
                    {
                        var ls2 = ls[1].Split( ',' ).ToList();
                        foreach( var subItem in ls2 )
                        {
                            count = 0;
                            Bag b2 = String2Bag( subItem.Trim(), out count );
                            for( int i = 0; i < count; i++ )
                            {
                                b.Bags.Add( b2 );
                            }
                        }
                    }
                    rules.Add( b );
                }
            }
            rules = rules.OrderBy( c => c.Color ).ThenBy( c => c.Modifier ).ToList();
        }

        private Bag String2Bag( string s, out int count )
        {
            Bag b = new Bag();
            var ls = s.Split( ' ' ).ToList();
            if( Int32.TryParse( ls[0], out count ) )
            {
                ls.RemoveAt( 0 );
            }
            b.Modifier = ls[0];
            b.Color = ls[1];

            return b;
        }
    }
}
