using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ZXing.Common;
using ZXing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public partial class index : System.Web.UI.Page
{
    // 全局变量
    private string imgURL;
    private string shebeiID;
    private DatabaseManager DB;

    protected void Page_Load(object sender, EventArgs e)
    {
        imgURL = "";
        shebeiID = "";
    }

    /**********************************************
     * Function name : buttonCode_Click
     * Description : 生成条码
     * Variables : object sender, EventArgs e
     **********************************************/
    protected void buttonCode_Click(object sender, EventArgs e)
    {
        // 检查输入状况
        if (TextBox1.Text.ToString() == "")
        {
            return;
        }
        shebeiID = TextBox1.Text.ToString();

        // 1.设置条形码规格
        EncodingOptions encodeOption = new EncodingOptions();
        encodeOption.Height = 130; // 必须制定高度、宽度
        encodeOption.Width = 300;

        // 2.生成条形码图片并保存
        ZXing.BarcodeWriter wr = new BarcodeWriter();
        wr.Options = encodeOption;
        wr.Format = BarcodeFormat.CODE_39;
        Bitmap img = wr.Write(shebeiID); // 生成图片
        string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "\\image\\" + shebeiID + ".jpg";
        img.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

        // 3.读取保存的图片
        imgURL = "~/image/" + shebeiID + ".jpg";
        Image1.ImageUrl = imgURL;
    }

    /**********************************************
     * Function name : buttonPdf_Click
     * Description : 生成PDF文件
     * Variables : object sender, EventArgs e
     **********************************************/
    protected void buttonPdf_Click(object sender, EventArgs e)
    {
        string name = TextBox1.Text.ToString();
        Document document = new Document();
        PdfWriter.GetInstance(document, new FileStream("H:\\mySoftware1\\pdfCodeCreater\\image\\" + name + ".pdf", FileMode.Create));
        document.Open();
        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("H:\\mySoftware1\\pdfCodeCreater\\image\\" + name + ".jpg");
        img.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
        document.Add(img);
        document.Close();
    }


    /**********************************************
     * Function name : batchOperate_Click
     * Description : 批量生成条码
     * Variables : object sender, EventArgs e
     **********************************************/
    protected void batchOperate_Click(object sender, EventArgs e)
    {
        // 操作开始
        Label1.Text = "运行状态：正在生成编号组...";

        // 获取前缀、后缀和条码数量
        string strf = TextBox3.Text.ToString();
        string strb = TextBox4.Text.ToString();
        string sAmount = TextBox5.Text.ToString();
        int amount = Int16.Parse(sAmount);
        int suffix = Int16.Parse(strb);

        // 生成依次排列的编码
        string[] code = new string[amount];
        for (int i = 0; i < amount; i++)
        {
            code[i] = strf + (suffix++);
        }

        // 开始生成条码并写入PDF
        Label1.Text = "运行状态：正在生成条码...";
        string filename = strf + strb + "-" + strf + suffix;
        Document document = new Document();
        PdfWriter.GetInstance(document, new FileStream("H:\\mySoftware1\\pdfCodeCreater\\image\\" + filename + ".pdf", FileMode.Create));
        document.Open();
        for (int i = 0; i < amount; i++)
        {
            // 生成条码
            EncodingOptions encodeOption = new EncodingOptions();
            encodeOption.Height = 130;
            encodeOption.Width = 300;
            ZXing.BarcodeWriter wr = new BarcodeWriter();
            wr.Options = encodeOption;
            wr.Format = BarcodeFormat.CODE_39;
            Bitmap cimg = wr.Write(code[i]); // 生成图片
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "\\image\\" + code[i] + ".jpg";
            cimg.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

            // 添加到PDF
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("H:\\mySoftware1\\pdfCodeCreater\\image\\" + code[i] + ".jpg");
            img.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
            document.Add(img);
        }
        document.Close();

        // 运行结束
        Label1.Text = "运行状态：操作完成！";
    }
}