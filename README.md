
Copyright 2020 Chay Palton

C# implementation of Zobrist Hash for FEN strings
Used to lookup opening book moves for computer player in my chess program.

Convert the current board pieces layout and game info such as (castling, en-passant, fifty move draw counter, moves)
from FEN formated string to a Zorbrist Hash, and than look it up to see if there are any known moves for the board layout. 

This is a more robust implementation, as we don't want to generate rubish keys.
Also I want error reporting to show problem in the FEN. 

Software to be used with my chess game (Computer player lookup). 
This is part of a pair of implementations the other being my PolyglotCSharp Hash, https://github.com/cjpdev/PolyglotCSharp

The intergration test app is: https://github.com/cjpdev/ZobristPolyglotCSharp

