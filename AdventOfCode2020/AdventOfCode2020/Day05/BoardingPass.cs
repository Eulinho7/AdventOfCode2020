namespace AdventOfCode2020.Day5
{
    using System;
    public class BoardingPass
    {
        public int SeatID { get; set; }
        public BoardingPass( String s )
        {
            s = s.Replace( 'B', '1' ).Replace( 'F', '0' ).Replace( 'R', '1' ).Replace( 'L', '0' );
            SeatID = Convert.ToInt32( s.Substring( 0, 7 ), 2 ) * 8 + Convert.ToInt32( s.Substring( 7, 3 ), 2 );
        }


    }
}
