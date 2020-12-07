
Copyright 2020 Chay Palton

C# implementation of Zobrist Hash for FEN strings
Used to lookup opening book moves for computer player in my chess program.

We convert the current board pieces layout and game info such as (castling, en-passant, fifty-move-draw, moves)
to FEN, and than look it up to see if there are any known moves for the board layout. 

This is a more robust implementation, as we don't want to generate rubish keys.
Also I want error reporting to show problem in the FEN.

Software to be used with my chess game (Computer player lookup). 
This is part of a pair of implementations the other being my ZobristCSharp Hash, https://github.com/cjpdev/PolyglotCSharp
