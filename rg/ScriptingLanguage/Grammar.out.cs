// Generated from Grammar.ecs by LeMP custom tool. LeMP version: 2.9.0.3
// Note: you can give command-line arguments to the tool via 'Custom Tool Namespace':
// --no-out-header       Suppress this message
// --verbose             Allow verbose messages (shown by VS as 'warnings')
// --timeout=X           Abort processing thread after X seconds (default: 10)
// --macros=FileName.dll Load macros from FileName.dll, path relative to this file 
// Use #importMacros to use macros in a given namespace, e.g. #importMacros(Loyc.LLPG);

using System;
using System.Text;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Loyc;
using Loyc.Collections;
using Loyc.Syntax.Lexing;
using Loyc.Syntax;

namespace rg.ScriptingLanguage
{
	using TT = TokenType;
	using S = CodeSymbols;
	using ES = ExtraCodeSymbols;

	static class ExtraCodeSymbols
	{
		public static readonly Symbol PrintSymbol = GSymbol.Get("'print");
	}
	[GeneratedCode("ECS", null)] public enum TokenType
	{
		EOF = 0,
		Spaces = TokenKind.Spaces + 1,
		Newline = TokenKind.Spaces + 2,
		Id = TokenKind.Id,
		Num = TokenKind.Literal,
		
		LE = TokenKind.Operator + 1,
		GE = TokenKind.Operator + 2,
		Eq = TokenKind.Operator + 3,
		NotEq = TokenKind.Operator + 4,
		GT = TokenKind.Operator + 5,
		LT = TokenKind.Operator + 6,
		Assign = TokenKind.Assignment,
		Mul = TokenKind.Operator + 7,
		Div = TokenKind.Operator + 8,
		Add = TokenKind.Operator + 9,
		Sub = TokenKind.Operator + 10,
		LParen = TokenKind.LParen,
		RParen = TokenKind.RParen,
		LBrace = TokenKind.LBrace,
		RBrace = TokenKind.RBrace,
		LBrack = TokenKind.LBrack,
		RBrack = TokenKind.RBrack,
		Comma = TokenKind.Separator,
		Semicolon = TokenKind.Separator,
		Colon = TokenKind.Separator,
		ForEach = TokenKind.OtherKeyword + 1,
		Print = TokenKind.OtherKeyword + 2,
		Unknown
	}

	[GeneratedCode("ECS", null)] 
	public static class TokenExt
	{
		// In this parser we'll use the predefined "Token" type in Loyc.Syntax.dll.
		// This extension method is defined because Token only has TypeInt, an integer.
		[DebuggerStepThrough] 
		public static TT Type(this Token t) { return (TT) t.TypeInt; }
	}

	[GeneratedCode("ECS", null)] 
	partial class MyLexer : BaseILexer<ICharSource, Token>
	{
		public MyLexer(UString text, string fileName = "") : this((ICharSource) text, fileName) { }
		public MyLexer(ICharSource text, string fileName = "") : base(text, fileName) { }

		private new ISourceFile SourceFile => base.SourceFile;

		TT _type;
		object _value;
		int _startIndex;

		public override Maybe<Token> NextToken()
		{
			int la0, la1;
			// line 92
			_startIndex = InputPosition;
			// line 93
			_value = null;
			// Line 94: ( ([f] [o] [r] | [p] [r] [i] [n] [t] | Num | Id | Newline | [\t ] ([\t ])*) | ([<] [=] / [>] [=] / [=] [=] / [!] [=] / [>] / [<] / [=] / [*] / [/] / [+] / [\-] / [(] / [)] / [[] / [\]] / [{] / [}] / [,] / [;] / [:] / [f] [o] [r] / [p] [r] [i] [n] [t]) )
			do {
				switch (LA0) {
				case 'f':
					{
						la1 = LA(1);
						if (la1 == 'o') {
							// line 94
							_type = TT.ForEach;
							Skip();
							Skip();
							Match('r'); // line 134
							_type = TT.ForEach; // line 134
							_value = S.ForEach;
						} else
							goto matchId;
					}
					break;
				case 'p':
					{
						la1 = LA(1);
						if (la1 == 'r') {
							// line 95
							_type = TT.Print;
							Skip();
							Skip();
							Match('i');
							Match('n');
							Match('t'); // line 134
							_type = TT.Print; // line 134
							_value = ES.PrintSymbol;
						} else
							goto matchId;
					}
					break;
				case '.': case '0': case '1': case '2':
				case '3': case '4': case '5': case '6':
				case '7': case '8': case '9':
					{
						// line 96
						_type = TT.Num;
						Num();
					}
					break;
				case 'A': case 'B': case 'C': case 'D':
				case 'E': case 'F': case 'G': case 'H':
				case 'I': case 'J': case 'K': case 'L':
				case 'M': case 'N': case 'O': case 'P':
				case 'Q': case 'R': case 'S': case 'T':
				case 'U': case 'V': case 'W': case 'X':
				case 'Y': case 'Z': case '_': case 'a':
				case 'b': case 'c': case 'd': case 'e':
				case 'g': case 'h': case 'i': case 'j':
				case 'k': case 'l': case 'm': case 'n':
				case 'o': case 'q': case 'r': case 's':
				case 't': case 'u': case 'v': case 'w':
				case 'x': case 'y': case 'z':
					goto matchId;
				case '\n': case '\r':
					{
						// line 98
						_type = TT.Newline;
						Newline();
					}
					break;
				case '\t': case ' ':
					{
						// line 99
						_type = TT.Spaces;
						Skip();
						// Line 99: ([\t ])*
						for (;;) {
							la0 = LA0;
							if (la0 == '\t' || la0 == ' ')
								Skip();
							else
								break;
						}
					}
					break;
				case '<':
					{
						la1 = LA(1);
						if (la1 == '=') {
							Skip();
							Skip(); // line 134
							_type = TT.LE; // line 134
							_value = S.LE;
						} else {
							Skip(); // line 134
							_type = TT.LT; // line 134
							_value = S.LT;
						}
					}
					break;
				case '>':
					{
						la1 = LA(1);
						if (la1 == '=') {
							Skip();
							Skip(); // line 134
							_type = TT.GE; // line 134
							_value = S.GE;
						} else {
							Skip(); // line 134
							_type = TT.GT; // line 134
							_value = S.GT;
						}
					}
					break;
				case '=':
					{
						la1 = LA(1);
						if (la1 == '=') {
							Skip();
							Skip(); // line 134
							_type = TT.Eq; // line 134
							_value = S.Eq;
						} else {
							Skip(); // line 134
							_type = TT.Assign; // line 134
							_value = S.Assign;
						}
					}
					break;
				case '!':
					{
						Skip();
						Match('='); // line 134
						_type = TT.NotEq; // line 134
						_value = S.NotEq;
					}
					break;
				case '*':
					{
						Skip(); // line 134
						_type = TT.Mul; // line 134
						_value = S.Mul;
					}
					break;
				case '/':
					{
						Skip(); // line 134
						_type = TT.Div; // line 134
						_value = S.Div;
					}
					break;
				case '+':
					{
						Skip(); // line 134
						_type = TT.Add; // line 134
						_value = S.Add;
					}
					break;
				case '-':
					{
						Skip(); // line 134
						_type = TT.Sub; // line 134
						_value = S.Sub;
					}
					break;
				case '(':
					{
						Skip(); // line 134
						_type = TT.LParen; // line 134
						_value = null;
					}
					break;
				case ')':
					{
						Skip(); // line 134
						_type = TT.RParen; // line 134
						_value = null;
					}
					break;
				case '[':
					{
						Skip(); // line 134
						_type = TT.LBrace; // line 134
						_value = null;
					}
					break;
				case ']':
					{
						Skip(); // line 134
						_type = TT.RBrace; // line 134
						_value = null;
					}
					break;
				case '{':
					{
						Skip(); // line 134
						_type = TT.LBrack; // line 134
						_value = null;
					}
					break;
				case '}':
					{
						Skip(); // line 134
						_type = TT.RBrack; // line 134
						_value = null;
					}
					break;
				case ',':
					{
						Skip(); // line 134
						_type = TT.Comma; // line 134
						_value = S.Comma;
					}
					break;
				case ';':
					{
						Skip(); // line 134
						_type = TT.Semicolon; // line 134
						_value = S.Semicolon;
					}
					break;
				case ':':
					{
						Skip(); // line 134
						_type = TT.Colon; // line 134
						_value = S.Colon;
					}
					break;
				default:
					{
						// Line 101: ([^\$])?
						la0 = LA0;
						if (la0 != -1)
							Skip();
						// line 101
						return NoValue.Value;
					}
				}
				break;
			matchId:
				{
					// line 97
					_type = TT.Id;
					Id();
				}
			} while (false);
			// line 103
			return new Token((int) _type, _startIndex, InputPosition - _startIndex, NodeStyle.Default, _value);
		}
		static readonly HashSet<int> Id_set0 = NewSetOfRanges('0', '9', 'A', 'Z', '_', '_', 'a', 'z');

		private void Id()
		{
			int la0;
			Skip();
			// Line 111: ([0-9A-Z_a-z])*
			for (;;) {
				la0 = LA0;
				if (Id_set0.Contains(la0))
					Skip();
				else
					break;
			}
			// line 112
			_value = (Symbol) (CharSource.Slice(_startIndex, InputPosition - _startIndex).ToString());
		}

		private void Num()
		{
			int la0, la1;
			// line 116
			bool dot = false;
			// Line 117: ([.])?
			la0 = LA0;
			if (la0 == '.') {
				Skip();
				// line 117
				dot = true;
			}
			MatchRange('0', '9');
			// Line 118: ([0-9])*
			for (;;) {
				la0 = LA0;
				if (la0 >= '0' && la0 <= '9')
					Skip();
				else
					break;
			}
			// Line 119: (&!{dot} [.] [0-9] ([0-9])*)?
			la0 = LA0;
			if (la0 == '.') {
				if (!dot) {
					la1 = LA(1);
					if (la1 >= '0' && la1 <= '9') {
						Skip();
						Skip();
						// Line 119: ([0-9])*
						for (;;) {
							la0 = LA0;
							if (la0 >= '0' && la0 <= '9')
								Skip();
							else
								break;
						}
					}
				}
			}
			// line 120
			_value = double.Parse(CharSource.Slice(_startIndex, InputPosition - _startIndex).ToString());
		}
	}

	[GeneratedCode("ECS", null)] 
	public partial class MyParser : BaseParserForList<Token, int>
	{
		public static MyParser New(UString input)
		{
			var lexer = new MyLexer(input);
			var tokens = new List<Token>();
			for (var next = lexer.NextToken(); next.HasValue; next = lexer.NextToken())
				if (next.Value.Kind != TokenKind.Spaces)
					tokens.Add(next.Value);
			return new MyParser(tokens, lexer.SourceFile);
		}

		public MyParser(IList<Token> list, ISourceFile file, int startIndex = 0)
			 : base(list, new Token((int) TT.EOF, 0, 0, null), file, startIndex)
		{
			F = new LNodeFactory(file);
		}

		// BaseParser.Match() uses this for constructing error messages.
		protected override string ToString(int tokenType)
		{
			return ((TokenType) tokenType).ToString();
		}

		readonly LNodeFactory F;

		LNode BinOp(Symbol type, LNode lhs, LNode rhs) => 
		F.Call(type, lhs, rhs, lhs.Range.StartIndex, rhs.Range.EndIndex);

		public LNode Start()
		{
			LNode result = default(LNode);
			List<LNode> stmts = new List<LNode>();
			// Line 181: (Statement)*
			for (;;) {
				switch ((TokenType) LA0) {
				case TT.ForEach: case TT.Id: case TT.LBrace: case TT.LParen:
				case TT.Num: case TT.Print: case TT.Sub:
					stmts.Add(Statement());
					break;
				default:
					goto stop;
				}
			}
		stop:;
			Match((int) EOF);
			// line 181
			result = F.Braces(stmts);
			return result;
		}

		private LNode Statement()
		{
			TokenType la0;
			LNode got_Expr = default(LNode);
			LNode result = default(LNode);
			List<LNode> stmts = new List<LNode>();
			// Line 185: ( TT.ForEach TT.LParen TT.Id TT.Colon Expr TT.RParen TT.LBrack (Statement)* TT.RBrack | TT.Print TT.LParen Expr TT.RParen TT.Semicolon | Expr TT.Semicolon )
			la0 = (TokenType) LA0;
			if (la0 == TT.ForEach) {
				Skip();
				Match((int) TT.LParen);
				var t = Match((int) TT.Id);
				Match((int) TT.Colon);
				got_Expr = Expr();
				Match((int) TT.RParen);
				Match((int) TT.LBrack);
				// Line 185: (Statement)*
				for (;;) {
					switch ((TokenType) LA0) {
					case TT.ForEach: case TT.Id: case TT.LBrace: case TT.LParen:
					case TT.Num: case TT.Print: case TT.Sub:
						stmts.Add(Statement());
						break;
					default:
						goto stop;
					}
				}
			stop:;
				Match((int) TT.RBrack);
				// line 186
				result = F.Call(S.ForEach, F.Id(t), got_Expr, F.Braces(stmts));
			} else if (la0 == TT.Print) {
				Skip();
				Match((int) TT.LParen);
				got_Expr = Expr();
				Match((int) TT.RParen);
				Match((int) TT.Semicolon);
				// line 188
				result = F.Call(ES.PrintSymbol, got_Expr);
			} else {
				result = Expr();
				Match((int) TT.Semicolon);
			}
			return result;
		}

		// Handle multiple precedence levels with one rule, as explained in Part 5 article
		private LNode Expr(int prec = 0)
		{
			LNode result = default(LNode);
			result = PrefixExpr();
			// Line 198: greedy( &{prec <= 10} TT.LBrace Expr TT.RBrace | &{prec <= 20} TT.Assign Expr | &{prec < 30} (TT.Eq|TT.GE|TT.GT|TT.LE|TT.LT|TT.NotEq) Expr | &{prec < 40} (TT.Add|TT.Sub) Expr | &{prec < 50} (TT.Div|TT.Mul) Expr )*
			for (;;) {
				switch ((TokenType) LA0) {
				case TT.LBrace:
					{
						if (prec <= 10) {
							Skip();
							var index = Expr();
							Match((int) TT.RBrace);
							// line 200
							result = F.Call(S.IndexBracks, F.AltList(result, index));
						} else
							goto stop;
					}
					break;
				case TT.Assign:
					{
						if (prec <= 20) {
							var op = MatchAny();
							var r = Expr(20);
							// line 203
							result = BinOp((Symbol) op.Value, result, r);
						} else
							goto stop;
					}
					break;
				case TT.Eq: case TT.GE: case TT.GT: case TT.LE:
				case TT.LT: case TT.NotEq:
					{
						if (prec < 30) {
							var op = MatchAny();
							var r = Expr(30);
							// line 206
							result = BinOp((Symbol) op.Value, result, r);
						} else
							goto stop;
					}
					break;
				case TT.Add: case TT.Sub:
					{
						if (prec < 40) {
							var op = MatchAny();
							var r = Expr(40);
							// line 209
							result = BinOp((Symbol) op.Value, result, r);
						} else
							goto stop;
					}
					break;
				case TT.Div: case TT.Mul:
					{
						if (prec < 50) {
							var op = MatchAny();
							var r = Expr(50);
							// line 212
							result = BinOp((Symbol) op.Value, result, r);
						} else
							goto stop;
					}
					break;
				default:
					goto stop;
				}
			}
		stop:;
			return result;
		}

		private LNode PrefixExpr()
		{
			TokenType la0;
			LNode got_Term = default(LNode);
			// Line 217: (TT.Sub Term | Term)
			la0 = (TokenType) LA0;
			if (la0 == TT.Sub) {
				var minus = MatchAny();
				got_Term = Term();
				// line 217
				return F.Call(S.Sub, got_Term, minus.StartIndex, got_Term.Range.EndIndex);
			} else {
				got_Term = Term();
				// line 218
				return got_Term;
			}
		}

		private LNode Term()
		{
			TokenType la0;
			LNode first = default(LNode);
			List<LNode> rest = new List<LNode>();
			LNode result = default(LNode);
			// Line 222: ( TT.Id | TT.Num | TT.LBrace TT.RBrace | TT.LBrace Expr (TT.Comma Expr)* TT.RBrace | TT.LParen Expr TT.RParen )
			do {
				la0 = (TokenType) LA0;
				if (la0 == TT.Id) {
					var t = MatchAny();
					// line 222
					result = F.Id(t);
				} else if (la0 == TT.Num) {
					var t = MatchAny();
					// line 223
					result = F.Literal(t);
				} else if (la0 == TT.LBrace) {
					switch ((TokenType) LA(1)) {
					case TT.RBrace:
						{
							Skip();
							Skip();
							// line 224
							result = F.AltList();
						}
						break;
					case TT.Id: case TT.LBrace: case TT.LParen: case TT.Num:
					case TT.Sub:
						{
							Skip();
							first = Expr();
							// Line 225: (TT.Comma Expr)*
							for (;;) {
								la0 = (TokenType) LA0;
								if (la0 == TT.Comma) {
									Skip();
									rest.Add(Expr());
								} else
									break;
							}
							Match((int) TT.RBrace);
							// line 225
							result = F.AltList(rest?.Prepend(first) ?? Enumerable.Repeat(first, 1));
						}
						break;
					default:
						goto error;
					}
				} else if (la0 == TT.LParen) {
					Skip();
					result = Expr();
					Match((int) TT.RParen);
					// line 226
					result = F.InParens(result);
				} else
					goto error;
				break;
			error:
				{
					// line 227
					result = F.Missing;
					Error(0, "Expected identifer, number, or (parens)");
				}
			} while (false);
			return result;
		}
	}
}