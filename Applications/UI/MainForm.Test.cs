using GameAssistant.Configs;
using GameAssistant;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using GameAssitant.Infrastructure.Utils;

namespace GameAssitant.Applications.UI
{
    public partial class MainForm
    {

        private async void test_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {

                // 获取输入框中的图片名称
                string imageName = txtImageName.Text.Trim();
                if (string.IsNullOrEmpty(imageName))
                {
                    MessageBox.Show("请输入图片名称！");
                    return;
                }

                // 拼接图片路径
                string imageFolderPath = Config.Instance.ImageFolderPath; // 从配置中获取资源路径
                string imagePath = Path.Combine(imageFolderPath, imageName + ".png");

                // 检查文件是否存在
                if (!File.Exists(imagePath))
                {
                    MessageBox.Show($"图片文件未找到：{imagePath}");
                    return;
                }

                // 尝试查找图片
                var location = ImageRecognition.FindImageOnScreen(imageName);
                if (location != Point.Empty)
                {
                    MessageBox.Show($"找到图片！位置：({location.X}, {location.Y})");
                }
                else
                {
                    MessageBox.Show("未找到图片！");
                }
            });
        }

        private async void btnTestOther_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
             {
                 (string text1, _) = OcrUtil.RecognizeText(790, 418, 966, 515);
                 (string text2, _) = OcrUtil.RecognizeText(790, 524, 966, 610);
                 MessageBox.Show($"第一排:{text1},第二排:{text2}");

                 ////(string text1, _) = OcrUtil.RecognizeText(686, 336, 747, 384);
                 //////(string text1, _) = OcrUtil.RecognizeTextFromScreen(702, 350, 736, 380);
                 ////var (text, _) = OcrUtil.RecognizeText("挑战次数");
                 //int count = GetChallengeCount();
                 //MessageBox.Show(count.ToString());
                 ////bbb();
                 ////battle();
                 ////aaa();

             });
        }

        private void battle()
        {
            MouseAction.Click("开始挑战", afterDelaySeconds: 3);
            MouseAction.ClickWithUpdate("圣兽战斗", () => ImageAction.IsImagePresent("竞技场录像"), 125, 5000);
            MouseAction.Click("历练左下");
        }

        private void bbb()
        {
            if (ImageAction.IsImagePresent("三倍未选"))
            {
                MouseAction.Click("三倍挑战", afterDelaySeconds: 1);
            }

            for (int i = 0; i < 4; i++)
            {
                MouseAction.Click("开始挑战", afterDelaySeconds: 7);

                MouseAction.Click("历练左下");
            }


        }

        private void aaa()
        {

            bool _isRunning = true;
            int attempt = 0;

            while (_isRunning && attempt < 3)
            {
                try
                {
                    int currentCount = GetChallengeCount();

                    // 处理OCR识别失败的情况
                    if (currentCount == 999)
                    {
                        Logger.Log("无法获取挑战次数，稍后重试...");
                        return;
                    }

                    Logger.Log($"当前挑战次数: {currentCount} attempt:{attempt}");

                    if (currentCount < 20)
                    {


                        // 等待次数更新（根据实际情况调整时间）
                        Thread.Sleep(3);
                        attempt++;
                    }
                    else
                    {
                        _isRunning = false;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"循环检测异常: {ex.Message}");
                    Thread.Sleep(5000);
                }
            }

        }

        private int GetChallengeCount()
        {
            try
            {
                // 调用OCR识别屏幕文字
                var (text, _) = OcrUtil.RecognizeText("挑战次数");

                // 提取所有数字（正则表达式去除非数字字符）
                string numbersOnly = Regex.Replace(text, @"[^\d]", "");

                // 处理无数字的情况
                if (string.IsNullOrWhiteSpace(numbersOnly))
                {
                    Logger.Log("未检测到有效的挑战次数");
                    return 0;
                }

                // 转换为整型
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
