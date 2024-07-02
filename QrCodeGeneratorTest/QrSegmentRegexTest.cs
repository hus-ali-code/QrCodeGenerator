﻿/* 
 * QR code generator library (.NET)
 *
 * Copyright (c) Manuel Bleichenbacher (MIT License)
 * https://github.com/manuelbl/QrCodeGenerator
 * Copyright (c) Project Nayuki (MIT License)
 * https://www.nayuki.io/page/qr-code-generator-library
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
 * IN THE SOFTWARE.
 */

using Xunit;

namespace Net.Codecrete.QrCodeGenerator.Test
{
    public class QrSegmentRegexTest
    {
        [Fact]
        public void IsNumeric()
        {
            Assert.True(QrSegment.IsNumeric("1234"));
        }

        [Fact]
        public void EmptyIsNumeric()
        {
            Assert.True(QrSegment.IsNumeric(""));
        }

        [Fact]
        public void TextIsNotNumeric()
        {
            Assert.False(QrSegment.IsNumeric("123a"));
        }

        [Fact]
        public void WhitespaceIsNotNumeric()
        {
            Assert.False(QrSegment.IsNumeric("123\n345"));
        }

        [Fact]
        public void ValidAlphanumeric()
        {
            Assert.True(QrSegment.IsAlphanumeric("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ $%*+-./"));
        }

        [Fact]
        public void EmptyIsAlphanumeric()
        {
            Assert.True(QrSegment.IsAlphanumeric(""));
        }

        [Fact]
        public void InvalidAlphanumeric()
        {
            Assert.False(QrSegment.IsAlphanumeric(","));
            Assert.False(QrSegment.IsAlphanumeric("^"));
            Assert.False(QrSegment.IsAlphanumeric("("));
            Assert.False(QrSegment.IsAlphanumeric("a"));
        }
    }
}
