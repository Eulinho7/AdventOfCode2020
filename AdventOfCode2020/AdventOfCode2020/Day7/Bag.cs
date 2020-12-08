using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day7
{
    public class Bag
    {
        public string Color { get; set; }
        public string Modifier { get; set; }

        public List<Bag> Bags { get; set; }

        private bool alreadyChecked = false;
        private bool containsBag = false;

        public Bag()
        {
            Bags = new List<Bag>();
        }

        public bool ContainsBag( Bag bag, ref List<Bag> rules )
        {
            bool ret = false;
            if( alreadyChecked )
                return containsBag;
            else
            {
                alreadyChecked = true;

                if( Bags.Count == 0 )
                {
                    ret = false;
                }
                else if( Bags.Contains( bag ) )
                {
                    ret = true;
                }
                else
                {
                    foreach( var b in this.Bags.Distinct().ToList() )
                    {
                        ret = ret || rules.FirstOrDefault( c => c.Equals( b ) ).ContainsBag( bag, ref rules );
                        if( ret )
                        {
                            break;
                        }
                    }
                }
            }
            containsBag = ret;
            return ret;
        }

        public int CountBags( ref List<Bag> rules )
        {
            int ret = Bags.Count;

            foreach( var bag in Bags )
            {
                ret += rules.FirstOrDefault( c => c.Equals( bag ) ).CountBags( ref rules );
            }

            return ret;
        }

        public override bool Equals( object obj )
        {
            var bag = obj as Bag;
            return bag.Color == this.Color && bag.Modifier == this.Modifier;
        }

    }
}
