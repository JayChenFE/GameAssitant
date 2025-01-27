using GameAssistant.Configs;
using GameAssistant.Utils;
using GameAssistant;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameAssitant.Configs;

namespace GameAssitant
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
                 (string text, _) = OcrUtil.RecognizeTextFromScreen(918, 358, 961, 396);
                 MessageBox.Show($"悬赏积分 {text}");
             });
        }
    }
}
