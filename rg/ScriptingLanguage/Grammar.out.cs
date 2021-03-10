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
		Comma = TokenKind.Separator,
		Semicolon = TokenKind.Separator,
		LBrack,
		RBrack,
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
			// line 82
			_startIndex = InputPosition;
			// line 83
			_value = null;
			// Line 84: ( (Num | Id | Newline | [\t ] ([\t ])*) | ([<] [=] / [>] [=] / [=] [=] / [!] [=] / [>] / [<] / [=] / [*] / [/] / [+] / [\-] / [(] / [)] / [[] / [\]] / [,] / [;]) )
			la0 = LA0;
			switch (la0) {
			case '.': case '0': case '1': case '2':
			case '3': case '4': case '5': case '6':
			case '7': case '8': case '9':
				{
					// line 84
					_type = TT.Num;
					Num();
				}
				break;
			case '\n': case '\r':
				{
					// line 86
					_type = TT.Newline;
					Newline();
				}
				break;
			case '\t': case ' ':
				{
					// line 87
					_type = TT.Spaces;
					Skip();
					// Line 87: ([\t ])*
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
						Skip(); // line 126
						_type = TT.LE; // line 126
						_value = S.LE;
					} else {
						Skip(); // line 126
						_type = TT.LT; // line 126
						_value = S.LT;
					}
				}
				break;
			case '>':
				{
					la1 = LA(1);
					if (la1 == '=') {
						Skip();
						Skip(); // line 126
						_type = TT.GE; // line 126
						_value = S.GE;
					} else {
						Skip(); // line 126
						_type = TT.GT; // line 126
						_value = S.GT;
					}
				}
				break;
			case '=':
				{
					la1 = LA(1);
					if (la1 == '=') {
						Skip();
						Skip(); // line 126
						_type = TT.Eq; // line 126
						_value = S.Eq;
					} else {
						Skip(); // line 126
						_type = TT.Assign; // line 126
						_value = S.Assign;
					}
				}
				break;
			case '!':
				{
					Skip();
					Match('='); // line 126
					_type = TT.NotEq; // line 126
					_value = S.NotEq;
				}
				break;
			case '*':
				{
					Skip(); // line 126
					_type = TT.Mul; // line 126
					_value = S.Mul;
				}
				break;
			case '/':
				{
					Skip(); // line 126
					_type = TT.Div; // line 126
					_value = S.Div;
				}
				break;
			case '+':
				{
					Skip(); // line 126
					_type = TT.Add; // line 126
					_value = S.Add;
				}
				break;
			case '-':
				{
					Skip(); // line 126
					_type = TT.Sub; // line 126
					_value = S.Sub;
				}
				break;
			case '(':
				{
					Skip(); // line 126
					_type = TT.LParen; // line 126
					_value = null;
				}
				break;
			case ')':
				{
					Skip(); // line 126
					_type = TT.RParen; // line 126
					_value = null;
				}
				break;
			case '[':
				{
					Skip(); // line 126
					_type = TT.LBrace; // line 126
					_value = null;
				}
				break;
			case ']':
				{
					Skip(); // line 126
					_type = TT.RBrace; // line 126
					_value = null;
				}
				break;
			case ',':
				{
					Skip(); // line 126
					_type = TT.Comma; // line 126
					_value = S.Comma;
				}
				break;
			case ';':
				{
					Skip(); // line 126
					_type = TT.Semicolon; // line 126
					_value = S.Semicolon;
				}
				break;
			default:
				if (la0 >= 'A' && la0 <= 'Z' || la0 == '_' || la0 >= 'a' && la0 <= 'z') {
					// line 85
					_type = TT.Id;
					Id();
				} else {
					// Line 89: ([^\$])?
					la0 = LA0;
					if (la0 != -1)
						Skip();
					// line 89
					return NoValue.Value;
				}
				break;
			}
			// line 91
			return new Token((int) _type, _startIndex, InputPosition - _startIndex, NodeStyle.Default, _value);
		}
		static readonly HashSet<int> Id_set0 = NewSetOfRanges('0', '9', 'A', 'Z', '_', '_', 'a', 'z');

		private void Id()
		{
			int la0;
			Skip();
			// Line 99: ([0-9A-Z_a-z])*
			for (;;) {
				la0 = LA0;
				if (Id_set0.Contains(la0))
					Skip();
				else
					break;
			}
			// line 100
			_value = (Symbol) (CharSource.Slice(_startIndex, InputPosition - _startIndex).ToString());
		}

		private void Num()
		{
			int la0, la1;
			// line 104
			bool dot = false;
			// Line 105: ([.])?
			la0 = LA0;
			if (la0 == '.') {
				Skip();
				// line 105
				dot = true;
			}
			MatchRange('0', '9');
			// Line 106: ([0-9])*
			for (;;) {
				la0 = LA0;
				if (la0 >= '0' && la0 <= '9')
					Skip();
				else
					break;
			}
			// Line 107: (&!{dot} [.] [0-9] ([0-9])*)?
			la0 = LA0;
			if (la0 == '.') {
				if (!dot) {
					la1 = LA(1);
					if (la1 >= '0' && la1 <= '9') {
						Skip();
						Skip();
						// Line 107: ([0-9])*
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
			// line 108
			_value = double.Parse(CharSource.Slice(_startIndex, InputPosition - _startIndex).ToString());
		}
		
		//private token List() @[
		//	'[' Id() (',' Id())* ']'
		//];
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
			result = Expr();
			Match((int) EOF);
			return result;
		}

		// Handle multiple precedence levels with one rule, as explained in Part 5 article
		public LNode Expr(int prec = 0)
		{
			LNode result = default(LNode);
			result = PrefixExpr();
			// Line 179: greedy( &{prec <= 10} TT.LBrace Expr TT.RBrace | &{prec <= 20} TT.Assign Expr | &{prec < 30} (TT.Eq|TT.GE|TT.GT|TT.LE|TT.LT|TT.NotEq) Expr | &{prec < 40} (TT.Add|TT.Sub) Expr | &{prec < 50} (TT.Div|TT.Mul) Expr )*
			for (;;) {
				switch ((TokenType) LA0) {
				case TT.LBrace:
					{
						if (prec <= 10) {
							Skip();
							var index = Expr();
							Match((int) TT.RBrace);
							// line 181
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
							// line 184
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
							// line 187
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
							// line 190
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
							// line 193
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
			// Line 198: (TT.Sub Term | Term)
			la0 = (TokenType) LA0;
			if (la0 == TT.Sub) {
				var minus = MatchAny();
				got_Term = Term();
				// line 198
				return F.Call(S.Sub, got_Term, minus.StartIndex, got_Term.Range.EndIndex);
			} else {
				got_Term = Term();
				// line 199
				return got_Term;
			}
		}

		private LNode Term()
		{
			TokenType la0;
			LNode first = default(LNode);
			List<LNode> rest = new List<LNode>();
			LNode result = default(LNode);
			// Line 203: ( TT.Id | TT.Num | TT.LBrace TT.RBrace | TT.LBrace Expr (TT.Comma Expr)* TT.RBrace | TT.LParen Expr TT.RParen )
			do {
				la0 = (TokenType) LA0;
				if (la0 == TT.Id) {
					var t = MatchAny();
					// line 203
					result = F.Id(t);
				} else if (la0 == TT.Num) {
					var t = MatchAny();
					// line 204
					result = F.Literal(t);
				} else if (la0 == TT.LBrace) {
					switch ((TokenType) LA(1)) {
					case TT.RBrace:
						{
							Skip();
							Skip();
							// line 205
							result = F.AltList();
						}
						break;
					case TT.Id: case TT.LBrace: case TT.LParen: case TT.Num:
					case TT.Sub:
						{
							Skip();
							first = Expr();
							// Line 206: (TT.Comma Expr)*
							for (;;) {
								la0 = (TokenType) LA0;
								if (la0 == TT.Comma) {
									Skip();
									rest.Add(Expr());
								} else
									break;
							}
							Match((int) TT.RBrace);
							// line 206
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
					// line 207
					result = F.InParens(result);
				} else
					goto error;
				break;
			error:
				{
					// line 208
					result = F.Missing;
					Error(0, "Expected identifer, number, or (parens)");
				}
			} while (false);
			return result;
		}
	}
}