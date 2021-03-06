//
// GengoException.cs
//
// Author:
//       Jarl Erik Schmidt <github@jarlerik.com>
//
// Copyright (c) 2013 Jarl Erik Schmidt
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace Winterday.External.Gengo
{
    using System;

    /// <summary>
    /// Represents an exception raised by the Gengo service
    /// </summary>
    public class GengoException : Exception
    {
        readonly string _opStat;
        readonly string _code;

        /// <summary>
        /// The raw operation status result returned by the service
        /// </summary>
        public string OpStat
        {
            get
            {
                return _opStat;
            }
        }

        /// <summary>
        /// The error code returned by the service. See the API docs for an
        /// <a href="http://developers.gengo.com/v2/error_codes/">exhaustive
        /// reference.</a>.
        /// </summary>
        public string ErrorCode
        {
            get
            {
                return _code;
            }
        }

        internal GengoException(string message, string opStat, string code)
            : base(message ?? "An unknown error happened")
        {
            _opStat = opStat ?? "N/A";
            _code = code ?? "N/A";
        }
    }
}

