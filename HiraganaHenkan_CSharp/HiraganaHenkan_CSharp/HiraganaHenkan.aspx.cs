using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HiraganaHenkan_CSharp
{
    public partial class HiraganaHenkan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FileSelect.Focus();

            //初回表示時
            if (!IsPostBack)
            {
                HiraganaLabel.Text = "(ここにひらがなが表示されます。)";
                HiraganaLabel.ForeColor = System.Drawing.Color.Blue;
            }
        }


        protected void CastButton_Click(object sender, EventArgs e)
        {
            var filePath = @"C:\Users\user01\Downloads\Challenge1\Challenge1\test2.txt";

            textHenkan(filePath);
        }

        //TODO:nが含まれるワード部分の変換不具合。未だ解決できず。
        protected void FileSelect_Click(object sender, EventArgs e)
        {
            var filePath = @"C:\Users\user01\Downloads\Challenge1\Challenge1\test1.txt";

            textHenkan(filePath);
        }

        protected void textHenkan(string filePath)
        {
            var romajiText = string.Empty;

            TxtIOFile txtIOFile = new TxtIOFile();
            romajiText = txtIOFile.readTxtFile(filePath);

            RomajiShoshikiCheck errorCheck = new RomajiShoshikiCheck();
            var errorMessage = errorCheck.ShoshikiCheck(romajiText);

            if (String.IsNullOrWhiteSpace(errorMessage))
            {
                RomajiCastTask castTask = new RomajiCastTask();
                HiraganaLabel.Text = castTask.Henkan(romajiText);
            }
            else
            {
                HiraganaLabel.Text = "変換出来ませんでした。";
            }

        }

    }
}