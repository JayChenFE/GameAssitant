using GameAssitant.Infrastructure.Utils;
using System.Windows.Forms;

namespace GameAssitant.Applications.Tests
{
    public class TestBonus : TestBase
    {
        public override string TestName => "悬赏";

        public override void Execute()
        {
            (string text1, _) = OcrUtil.RecognizeText("悬赏1");
            (string text2, _) = OcrUtil.RecognizeText("悬赏2");
            MessageBox.Show($"第一排: {text1},\n第二排:{text2}");
        }
    }
}
