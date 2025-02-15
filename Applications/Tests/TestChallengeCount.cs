using GameAssitant.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameAssitant.Applications.Tests
{
    public class TestChallengeCount : TestBase
    {
        public override string TestName => "挑战次数";

        public override void Execute()
        {
            int count = GetChallengeCount();
            MessageBox.Show(count.ToString());
        }

        private int GetChallengeCount()
        {
            try
            {
                var (text, _) = OcrUtil.RecognizeText("挑战次数");
                string numbersOnly = Regex.Replace(text, @"[^\d]", "");
                if (string.IsNullOrWhiteSpace(numbersOnly))
                {
                    Logger.Log("未检测到有效的挑战次数");
                    return 0;
                }
                return int.Parse(numbersOnly);
            }
            catch (Exception ex)
            {
                Logger.Log($"获取挑战次数失败: {ex.Message}");
                return 999;
            }
        }
    }
}
