
/*************************************************************************/
/* Copyright (c) 2020 Chay Palton                                        */
/*                                                                       */
/* Permission is hereby granted, free of charge, to any person obtaining */
/* a copy of this software and associated documentation files (the       */
/* "Software"), to deal in the Software without restriction, including   */
/* without limitation the rights to use, copy, modify, merge, publish,   */
/* distribute, sublicense, and/or sell copies of the Software, and to    */
/* permit persons to whom the Software is furnished to do so, subject to */
/* the following conditions:                                             */
/*                                                                       */
/* The above copyright notice and this permission notice shall be        */
/* included in all copies or substantial portions of the Software.       */
/*                                                                       */
/* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,       */
/* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF    */
/* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.*/
/* IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY  */
/* CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,  */
/* TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE     */
/* SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                */
/*************************************************************************/

using System;

namespace Chess.utils
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chay's chess.\n");

            string fen1 = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq r1 0 1";

            System.UInt64 knownHash = 5060803636482931868;
            System.UInt64 hash1 = ZobristHash.GetHash(fen1);
            ZobristHash.Result rep1 = ZobristHash.GetHashResult(fen1);

            string strboard = "";
            string refBoard = "3124521300000000666666666666666666666666666666660000000031245213";

            for (int idx = 0; idx < 64; idx++)
            {
                strboard += rep1.board[idx];
            }

            if (strboard == refBoard)
            {
                System.Console.WriteLine("Test Passed\n");
            }
 
            Console.WriteLine("FEN to hash key\n\n");
            string fen = "";
            System.UInt64 key = 0;
            System.UInt64 hash = 0;

            // Get next move from current board loyout, which in this case is      
            // the first open move. So should be in every openng book.
             fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            key = 5060803636482931868;
            hash = ZobristHash.GetHash(fen);
            System.Console.WriteLine("Test pass:{0}, hash=0x{1}, FEN={2}\n\n", (hash == key), hash.ToString("X"), fen);

            //en-passant test
            fen = "rnbqkbnr/p1pppppp/8/8/PpP4P/8/1P1PPPP1/RNBQKBNR b KQkq c3 0 3";
            key = 0x3c8123ea7b067637;
            hash = ZobristHash.GetHash(fen);
            System.Console.WriteLine("Test pass:{0}, hash=0x{1}, FEN={2}\n\n", (hash == key), hash.ToString("X"), fen);

            // Open start position..
            fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            key = 0x463b96181691fc9c;
            hash = ZobristHash.GetHash(fen);
            System.Console.WriteLine("Test opening position pass:{0}, hash=0x{1}, FEN={2}\n\n", (hash == key), hash.ToString("X"), fen);
            
            // Does some extra , rubish FENs
            fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            hash = ZobristHash.GetHash(fen);
            Console.WriteLine("Hash=({0}), FEN({1})", hash, fen);

            fen = "rnbqkbnr/ppp2ppp/3p4/4p3/8/5NPP/PPPPPP2/RNBQKB1R";
            hash = ZobristHash.GetHash(fen);
            Console.WriteLine("Hash=({0}), FEN({1})", hash, fen);

            // Report en-passant test
            fen = "rnbqkbnr/p1pppppp/8/8/PpP4P/8/1P1PPPP1/RNBQKBNR b KQkq c3 0 3";
            ZobristHash.Result rep = ZobristHash.GetHashResult(fen);
            Console.WriteLine("Hash=({0}), FEN({1})", rep.hash, fen);
            System.Console.WriteLine(rep);

            fen = "rnbqkbnr/ppp2ppp/3p4/4p3/8/5NPP/PPPPPP2/RNBQKB1R";
            rep = ZobristHash.GetHashResult(fen);
            Console.WriteLine("Hash=({0}), FEN({1})", rep.hash, fen);
            System.Console.WriteLine(rep);

            Console.WriteLine("\n");
        }
    }
}
