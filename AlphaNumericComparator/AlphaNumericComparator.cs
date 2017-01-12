using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaNumericComparator
{
    public class AlphaNumericComparator : IComparer<string>
    {
        private string GetChunk(string s, int length, int marker)
        {
            var chunk = new StringBuilder();
            var c = s[marker];
            chunk.Append(c);
            marker++;
            if (char.IsDigit(c))
            {
                while (marker < length)
                {
                    c = s[marker];
                    if (!char.IsDigit(c))
                        break;
                    chunk.Append(c);
                    marker++;
                }
            }
            else
            {
                while (marker < length)
                {
                    c = s[marker];
                    if (char.IsDigit(c))
                        break;
                    chunk.Append(c);
                    marker++;
                }
            }

            return chunk.ToString();
        }

        public int Compare(string s1, string s2)
        {
            var thisMarker = 0;
            var thatMarker = 0;
            var s1Length = s1.Length;
            var s2Length = s2.Length;

            while (thisMarker < s1Length && thatMarker < s2Length)
            {
                var thisChunk = GetChunk(s1, s1.Length, thisMarker);
                var thisChunkLen = thisChunk.Length;
                thisMarker += thisChunkLen;

                var thatChunk = GetChunk(s2, s2.Length, thatMarker);
                var thatChunkLen = thatChunk.Length;
                thatMarker += thatChunkLen;

                //If both chunks contain numberic characters, sort them numberically
                int result;
                if (char.IsDigit(thisChunk[0]) && char.IsDigit(thatChunk[0]))
                {
                    thisChunk = TrimLeadingZeros(thisChunk);
                    thatChunk = TrimLeadingZeros(thatChunk);

                    // Simple chunk comparison by length.
                    var thisChunkLength = thisChunk.Length;
                    result = thisChunkLength - thatChunk.Length;
                    // If equal, the first different number counts
                    if (result == 0)
                    {
                        for (var i = 0; i < thisChunkLength; i++)
                        {
                            result = thisChunk[i] - thatChunk[i];
                            if (result != 0)
                            {
                                return result;
                            }
                        }

                        if (result == 0)
                            result = thisChunkLen - thatChunkLen;
                    }
                }
                else
                {
                    result = string.Compare(thisChunk, thatChunk, StringComparison.CurrentCulture);
                }

                if (result != 0)
                    return result;
            }
            return s1Length - s2Length;
        }

        private string TrimLeadingZeros(string source)
        {
            var len = source.Length;

            if (len < 2) return source;

            int i;
            for (i = 0; i < len - 1; i++)
            {
                var c = source[i];
                if (c != '0') break;
            }

            return i == 0 ? source : source.Substring(i);
        }
    }
}
