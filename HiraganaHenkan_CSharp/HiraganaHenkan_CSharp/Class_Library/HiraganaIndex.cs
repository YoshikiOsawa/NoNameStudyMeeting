public class HiraganaIndex
{
    //****子音+"ん"で判定時***
    public static readonly string[] a = { "あ", "い", "う", "え", "お" };

    public static readonly string nn = "ん";


    //****母音 + 子音一文字で判定時***
    public static readonly string[] b = { "ば", "び", "ぶ", "べ", "ぼ" };
    public static readonly string[] c = { "か", "し", "く", "せ", "こ" };
    public static readonly string[] d = { "だ", "ぢ", "づ", "で", "ど" };
    public static readonly string[] f = { "ふぁ", "ふぃ", "ふ", "ふぇ", "ふぉ" };
    public static readonly string[] g = { "が", "ぎ", "ぐ", "げ", "ご" };
    public static readonly string[] h = { "は", "ひ", "ふ", "へ", "ほ" };
    public static readonly string[] j = { "じゃ", "じ", "じゅ", "じぇ", "じょ" };
    public static readonly string[] k = { "か", "き", "く", "け", "こ" };
    public static readonly string[] l = { "ぁ", "ぃ", "ぅ", "ぇ", "ぉ" };
    public static readonly string[] m = { "ま", "み", "む", "め", "も" };
    public static readonly string[] n = { "な", "に", "ぬ", "ね", "の" };
    public static readonly string[] p = { "ぱ", "ぴ", "ぷ", "ぺ", "ぽ" };
    public static readonly string[] q = { "くぁ", "くぃ", "く", "くぇ", "くぉ" };
    public static readonly string[] r = { "ら", "り", "る", "れ", "ろ" };
    public static readonly string[] s = { "さ", "し", "す", "せ", "そ" };
    public static readonly string[] t = { "た", "ち", "つ", "て", "と" };
    public static readonly string[] v = { "ヴぁ", "ヴぃ", "ヴ", "ヴぇ", "ヴぉ" };
    public static readonly string[] w = { "わ", "ゐ", "う", "ゑ", "を" };
    public static readonly string[] x = { "ぁ", "ぃ", "ぅ", "ぇ", "ぉ" };
    public static readonly string[] y = { "や", "い", "ゆ", "いぇ", "よ" };
    public static readonly string[] z = { "ざ", "じ", "ず", "ぜ", "ぞ" };



    //****母音 + 子音二文字で判定時***
    //一文字目がlまたはx 4種◎
    //促音 (= "っ") の場合◎
    public static readonly string ltu = "っ";
    public static readonly string lwa = "ゎ";
    public static readonly string lka = "ヵ";
    public static readonly string lke = "ヶ";

    //二文字目がhまたはyの時 3種◎
    public static readonly string[] ch = { "ちゃ", "ち", "ちゅ", "ちぇ", "ちょ" };
    public static readonly string[] dh = { "でゃ", "でぃ", "でゅ", "でぇ", "でょ" };
    public static readonly string[] sh = { "しゃ", "し", "しゅ", "しぇ", "しょ" };

    //二文字目がyの時 → 小文字「ゃ」15種◎
    public static readonly string[] by = { "びゃ", "びぃ", "びゅ", "びぇ", "びょ" };
    public static readonly string[] fy = { "ふゃ", "ふぃ", "ふゅ", "ふぇ", "ふょ" };
    public static readonly string[] gy = { "ぎゃ", "ぎぃ", "ぎゅ", "ぎぇ", "ぎょ" };
    public static readonly string[] hy = { "ひゃ", "ひぃ", "ひゅ", "ひぇ", "ひょ" };
    public static readonly string[] jy = { "じゃ", "じぃ", "じゅ", "じぇ", "じょ" };
    public static readonly string[] ky = { "きゃ", "きぃ", "きゅ", "きぇ", "きょ" };
    public static readonly string[] ly = { "ゃ", "ぃ", "ゅ", "ぇ", "ょ" };
    public static readonly string[] my = { "みゃ", "みぃ", "みゅ", "みぇ", "みょ" };
    public static readonly string[] ny = { "にゃ", "にぃ", "にゅ", "にぇ", "にょ" };
    public static readonly string[] py = { "ぴゃ", "ぴぃ", "ぴゅ", "ぴぇ", "ぴょ" };
    public static readonly string[] qy = { "くゃ", "くぃ", "くゅ", "くぇ", "くょ" };
    public static readonly string[] ry = { "りゃ", "りぃ", "りゅ", "りぇ", "りょ" };
    public static readonly string[] ty = { "ちゃ", "ちぃ", "ちゅ", "ちぇ", "ちょ" };
    public static readonly string[] vy = { "ヴゃ", "ヴぃ", "ヴゅ", "ヴぇ", "ヴょ" };
    public static readonly string[] xy = { "ゃ", "ぃ", "ゅ", "ぇ", "ょ" };
    public static readonly string[] zy = { "じゃ", "じぃ", "じゅ", "じぇ", "じょ" };

    //二文字目がhの時 4種◎
    public static readonly string[] hh = { "っは", "っひ", "っふ", "っへ", "っほ" };
    public static readonly string[] nh = { "んは", "んひ", "んふ", "んへ", "んほ" };
    public static readonly string[] th = { "てゃ", "てぃ", "てゅ", "てぇ", "てょ" };
    public static readonly string[] wh = { "うぁ", "うぃ", "う", "うぇ", "うぉ" };

    //その他◎
    public static readonly string[] ts = { "つぁ", "つぃ", "つ", "つぇ", "つぉ" };



    //****母音 + 子音三文字で判定時***
    //xtsuの場合のみ◎
    public static readonly string xtsu = "っ";

}
