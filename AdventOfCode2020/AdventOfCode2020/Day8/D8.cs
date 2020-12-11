

namespace AdventOfCode2020.Day8
{
    using AdventOfCode2020.Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class D8
    {
        private List<Command> input;

        public D8()
        {
            input = new List<Command>();
            ReadInput();
        }

        public void Solve()
        {
            Console.WriteLine( SolvePart1() );
            foreach( var item in input )
            {
                item.AlreadyCalled = false;
            }
            Console.WriteLine( SolvePart2() );
        }

        private int SolvePart1()
        {
            int result = 0;
            int index = 0;
            while( true )
            {
                var cmd = input[index];
                if( cmd.AlreadyCalled )
                    break;
                else
                {
                    input[index].AlreadyCalled = true;
                    switch( cmd.Type )
                    {
                        case "acc":
                            result += cmd.Steps;
                            index++;
                            break;
                        case "jmp":
                            index += cmd.Steps;
                            break;
                        default:
                            index++;
                            break;
                    }
                }

            }
            return result;
        }

        private int SolvePart2()
        {
            int result = 0;
            int index = 0;
            while( true )
            {
                var cmd = input[index];
                if( cmd.AlreadyCalled )
                    break;
                else
                {
                    int currentIndex = index;
                    switch( cmd.Type )
                    {
                        case "acc":
                            result += cmd.Steps;
                            index++;
                            break;
                        case "jmp":
                            {
                                List<Command> alt = new List<Command>();
                                foreach( var item in input )
                                {
                                    alt.Add( new Command( item.InitString ) );
                                }
                                alt[index].Type = "nop";
                                int altResult = result;
                                if( TestAlternative( alt, index, ref altResult ) )
                                {
                                    return altResult;
                                }
                            }

                            index += cmd.Steps;
                            break;
                        default:
                            {
                                List<Command> alt = new List<Command>();
                                foreach( var item in input )
                                {
                                    alt.Add( new Command( item.InitString ) );
                                }
                                alt[index].Type = "jmp";
                                int altResult = result;
                                if( TestAlternative( alt, index, ref altResult ) )
                                {
                                    return altResult;
                                }
                            }
                            index++;
                            break;
                    }
                    input[currentIndex].AlreadyCalled = true;
                }

            }
            return result;
        }

        private bool TestAlternative( List<Command> altInput, int startingIndex, ref int altResult )
        {
            bool res = false;
            while( true )
            {
                var cmd = altInput[startingIndex];
                if( cmd.AlreadyCalled )
                    break;
                else
                {
                    altInput[startingIndex].AlreadyCalled = true;
                    switch( cmd.Type )
                    {
                        case "acc":
                            altResult += cmd.Steps;
                            startingIndex++;
                            break;
                        case "jmp":
                            startingIndex += cmd.Steps;
                            break;
                        default:
                            startingIndex++;
                            break;
                    }
                }
                if( startingIndex == altInput.Count - 1 )
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

        private void ReadInput()
        {
            var s = Resources.input_day8;
            foreach( var item in s.Split( '\n' ).ToList() )
            {
                if( !string.IsNullOrEmpty( item ) )
                    input.Add( new Command( item ) );
            }
        }

    }
}
