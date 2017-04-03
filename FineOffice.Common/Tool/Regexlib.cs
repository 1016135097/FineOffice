using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FineOffice.Common.Tool
{
    public class Regexlib
    {
        /// <summary>
        /// 整数
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool MatchInt(string input)
        {
            return Regex.IsMatch(input, @"^-?\d+$");
        }

        /// <summary>
        /// 浮点数
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool MatchDecimal(string strIn)
        {
            return Regex.IsMatch(strIn, @"^(-?\d+)(\.\d+)?$");
        }

        /// <summary>
        /// 验证年月日
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool MatchDate(string strIn)
        {
            return Regex.IsMatch(strIn, @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]" +
                                @"|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|" +
                                @"1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?" +
                                @"2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468]" +
                                @"[048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
        }

        /// <summary>  
        /// 是否为日期+时间型字符串  
        /// </summary>  
        /// <param name="strIn"></param>  
        /// <returns></returns>  
        public static bool MatchDateTime(string strIn)
        {
            return Regex.IsMatch(strIn, @"^(((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?" +
                                @"[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?" +
                                @"[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]" +
                                @"|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-" +
                                @"9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[" +
                                @"2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23" +
                                @"|[0-1]?\d):[0-5]?\d:[0-5]?\d)$ ");
        }
    }
}
