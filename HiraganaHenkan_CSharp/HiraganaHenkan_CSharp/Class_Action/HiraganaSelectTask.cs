using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class HiraganaSelectTask
    {
    //***母音のみ***
    /// <summary>
    /// 母音のみの場合のひらがな変換処理
    /// </summary>
    /// <param name="boinnText">母音部分に該当する英字</param>
    /// <param name="boinnNumber">母音部分の行位置（あいうえお）</param>
    /// <returns>該当するひらがなの文字（見つからなかった場合は空文字）を返す</returns>
    public string BoinnOnly(string boinn, int boinnNumber)
    {
        var hiraganaText = boinn;

        //母音+"ん"以外の英字一文字の時は、そのまま英字で返す。
        //※母音が"n"になるのは唯一"ん"の時だけ
        if (Array.IndexOf(RomajiCastTask.kugiriText, boinn) >= 0)
        {
            hiraganaText = (boinn != "N") ? HiraganaIndex.a[boinnNumber] : HiraganaIndex.nn;
        }

        return hiraganaText;
    }


    /// <summary>
    /// 子音（一文字）+ 母音のひらがな変換処理
    /// </summary>
    /// <param name="shiinnText">子音部分に該当する英字</param>
    /// <param name="boinnText">母音部分に該当する英字</param>
    /// <param name="boinnNumber">母音部分の行位置（あいうえお）</param>
    /// <returns>該当するひらがなの文字（見つからなかった場合は空文字）を返す</returns>
    public string ShiinnIchimoji(string shiinnText, string boinnText, int boinnNumber)
    {
        //連想配列内に引数の子音要素をキーとして持つ配列があれば値を抽出
        return (shiinnIchimojiList.ContainsKey(shiinnText)) ? shiinnIchimojiList[shiinnText][boinnNumber] : shiinnText;
    }


    /// <summary>
    /// 子音（二文字）+ 母音のひらがな変換処理
    /// </summary>
    /// <param name="shiinnText">子音部分に該当する英字</param>
    /// <param name="boinnText">母音部分に該当する英字</param>
    /// <param name="boinnNumber">母音部分の行位置（あいうえお）</param>
    /// <returns>該当するひらがなの文字（見つからなかった場合は空文字）を返す</returns>
    public string ShiinnNimoji(string shiinnText, string boinnText, int boinnNumber)
    {
        //子音一文字目チェック → 子音二文字目チェック → 子音その他チェック → 子音該当なし時処理…の順
        var hiraganaText = ShiinnStartsWith(shiinnText);

        if (string.IsNullOrWhiteSpace(hiraganaText))
        {
            hiraganaText = ShiinnSecondText(shiinnText, boinnText, boinnNumber);
        }

        if (string.IsNullOrWhiteSpace(hiraganaText))
        {
            hiraganaText = ShiinnRegexSearch(shiinnText, boinnText, boinnNumber);
        }

        if (string.IsNullOrWhiteSpace(hiraganaText))
        {
            hiraganaText += NoMatchDataFurigana(shiinnText, boinnText, boinnNumber);
        }

        return hiraganaText;
    }

    //子音(二文字)一文字目チェック
    private string ShiinnStartsWith(string shiinnText)
    {
        var hiraganaText = string.Empty;

        //小文字(子音一文字目がl または x付帯)の場合
        if (ShiinnKomojiList.ContainsKey(shiinnText))
        {
            hiraganaText = ShiinnKomojiList[shiinnText];
        }

        return hiraganaText;
    }

    //子音(二文字)二文字目チェック
    private string ShiinnSecondText(string shiinnText, string boinnText, int boinnNumber)
    {
        var hiraganaText = string.Empty;

        char[] shiinnTextYouso = shiinnText.ToCharArray();

        switch (shiinnTextYouso[1])
        {
            case 'h':
                if (shiinnHList.ContainsKey(shiinnText))
                {
                    hiraganaText = shiinnHList[shiinnText][boinnNumber];
                }
                break;

            case 'y':
                if (shiinnYList.ContainsKey(shiinnText))
                {
                    hiraganaText = shiinnYList[shiinnText][boinnNumber];
                }
                break;
        }

        return hiraganaText;
    }

    //子音(二文字)その他チェック
    private string ShiinnRegexSearch(string shiinnText, string boinnText, int boinnNumber)
    {
        var hiraganaText = string.Empty;

        //正規表現の文字列をKeyに、出力するひらがなをValueに設定した連想配列の作成
        Dictionary<string, string> regexList = new Dictionary<string, string>
        {
            {@"([a-mo-z])\1", HiraganaIndex.ltu + ShiinnIchimoji(shiinnText.Remove(0, 1), boinnText, boinnNumber)},
            {@"^ts", HiraganaIndex.ts[boinnNumber]}
        };

        var castItems = from text in regexList
                        where Regex.IsMatch(shiinnText, text.Key)
                        select text;
        if (castItems.Count() != 0)
        {
            hiraganaText = castItems.First().Value;
        }

        return hiraganaText;
    }


    /// <summary>
    /// 子音（三文字）+ 母音のひらがな変換処理
    /// </summary>
    /// <param name="shiinnText">子音部分に該当する英字</param>
    /// <param name="boinnText">母音部分に該当する英字</param>
    /// <param name="boinnNumber">母音部分の行位置（あいうえお）</param>
    /// <returns>該当するひらがなの文字（見つからなかった場合は空文字）を返す</returns>
    public string ShiinnSanmoji(string shiinnText, string boinnText, int boinnNumber)
    {
        var hiraganaText = string.Empty;

        //"xtsu"("っ")の時のみ該当する
        if (shiinnText == @"xts") { hiraganaText = HiraganaIndex.xtsu; }

        if (string.IsNullOrWhiteSpace(hiraganaText))
        {
            hiraganaText += NoMatchDataFurigana(shiinnText, boinnText, boinnNumber);
        }

        return hiraganaText;
    }


    /// <summary>
    /// 該当するひらがなが見つからない場合の処理
    /// </summary>
    /// <param name="shiinnText">子音部分に該当する英字</param>
    /// <param name="boinnText">母音部分に該当する英字</param>
    /// <param name="boinnNumber">母音部分の行位置（あいうえお）</param>
    /// <returns> 不要な子音英字 + 変換可能なひらがなの文字（見つからなかった場合は空文字）を返す</returns>
    public string NoMatchDataFurigana(string shiinnText, string boinnText, int boinnNumber)
    {
        var hiraganaText = string.Empty;

        //母音の位置に"N"がある場合は、子音部分+"ん"として処理する
        if (boinnText == "N" || boinnText == "n")
        {
            hiraganaText = shiinnText + HiraganaIndex.nn;
        }

        if (!RomajiCastTask.kugiriText.Contains(boinnText)) { return shiinnText + boinnText; }
        //母音の有無の検索し、あればひらがなに変換
        if (RomajiCastTask.kugiriText.Contains(boinnText))
        {

            //まずは母音のみをひらがなに変換した文字列を作成しておく（hiraganaText再初期化）
            hiraganaText = shiinnText + BoinnOnly(boinnText, boinnNumber);

            //子音を母音側より一語ずつひらがなに変換してみる
            for (var i = 1; i <= shiinnText.Length; i++)
            {
                var shiinnNearBoinn = shiinnText.Substring(shiinnText.Length - i, i);

                //元の子音になった時点でループを終了（無限ループ要注意）
                if (shiinnNearBoinn == shiinnText) { break; }

                var text = string.Empty;

                switch (shiinnNearBoinn.Length)
                {
                    case 1:
                        text = ShiinnIchimoji(shiinnNearBoinn, boinnText, boinnNumber);
                        break;
                    case 2:
                        text = ShiinnNimoji(shiinnNearBoinn, boinnText, boinnNumber);
                        break;
                    case 3:
                        text = ShiinnSanmoji(shiinnNearBoinn, boinnText, boinnNumber);
                        break;
                    default:
                        break;
                }

                //該当するひらがながある場合、残りの子音要素とひらがなを結合する。
                if (!(string.IsNullOrWhiteSpace(text)))
                {
                    hiraganaText = shiinnText.Remove(shiinnText.Length - i, i) + text;
                }
            }

        }
        //母音すら変換できない場合は、元の文字列に戻して返す。
        else
        {
            hiraganaText = shiinnText + boinnText;
        }

        return hiraganaText;
    }



    /// <summary>
    /// 以下、連想配列として用意するひらがなの列パターン
    /// </summary>
    private static readonly Dictionary<string, string[]> shiinnIchimojiList = new Dictionary<string, string[]>()
        {
            {"b", HiraganaIndex.b}, {"c", HiraganaIndex.c}, {"d", HiraganaIndex.d}, {"f", HiraganaIndex.f},
            {"g", HiraganaIndex.g}, {"h", HiraganaIndex.h}, {"j", HiraganaIndex.j}, {"k", HiraganaIndex.k},
            {"l", HiraganaIndex.l}, {"m", HiraganaIndex.m}, {"n", HiraganaIndex.n}, {"p", HiraganaIndex.p},
            {"q", HiraganaIndex.q}, {"r", HiraganaIndex.r}, {"s", HiraganaIndex.s}, {"t", HiraganaIndex.t},
            {"v", HiraganaIndex.v}, {"w", HiraganaIndex.w}, {"x", HiraganaIndex.x}, {"y", HiraganaIndex.y}, {"z", HiraganaIndex.z},
        };

    private static readonly Dictionary<string, string> ShiinnKomojiList = new Dictionary<string, string>()
        {
            {"lwa",  HiraganaIndex.lwa }, {"lka", HiraganaIndex.lka}, {"lke", HiraganaIndex.lke}, {"ltu", HiraganaIndex.ltu},
            {"xwa", HiraganaIndex.lwa }, {"xka", HiraganaIndex.lka}, {"xke", HiraganaIndex.lke}, {"xtu", HiraganaIndex.ltu}
        };

    private static readonly Dictionary<string, string[]> shiinnHList = new Dictionary<string, string[]>()
        {
                        {"ch", HiraganaIndex.ch}, {"dh", HiraganaIndex.dh}, {"sh", HiraganaIndex.sh},
                        {"hh", HiraganaIndex.hh}, {"nh", HiraganaIndex.nh}, {"th", HiraganaIndex.th}, { "wh", HiraganaIndex.wh}
        };

    private static readonly Dictionary<string, string[]> shiinnYList = new Dictionary<string, string[]>()
        {
            {"cy", HiraganaIndex.ch}, {"dy", HiraganaIndex.dh}, {"sy", HiraganaIndex.sh},
            {"by", HiraganaIndex.by}, {"fy", HiraganaIndex.fy}, {"gy", HiraganaIndex.gy}, {"hy", HiraganaIndex.hy},
            {"jy", HiraganaIndex.jy}, {"ky", HiraganaIndex.ky}, {"ly", HiraganaIndex.ly}, {"my", HiraganaIndex.my},
            {"ny", HiraganaIndex.ny}, {"py", HiraganaIndex.py}, {"qy",HiraganaIndex.qy }, {"ry", HiraganaIndex.ry},
            {"ty", HiraganaIndex.ty}, {"vy", HiraganaIndex.vy}, {"xy", HiraganaIndex.xy}, {"zy", HiraganaIndex.zy}
        };

}
