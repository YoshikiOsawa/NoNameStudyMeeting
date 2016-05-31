using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

//ローマ字をひらがなに変換するクラス
public class RomajiCastTask
{
    //文字列を区切るための配列（ひらがな各行で共通する母音＋唯一母音を含まない"ん"）
    public static readonly string[] kugiriText = { "a", "i", "u", "e", "o", "N" };

    HiraganaIndex hiraganaIndex = new HiraganaIndex();
    HiraganaSelectTask hiraganaSelectTask = new HiraganaSelectTask();

    //ローマ字をひらがなでの一文字単位に分割し、変換してゆく。
    public string Henkan(string romaji)
    {
        var hiragana = string.Empty;

        //入力文字は、基本的に小文字に変換する
        romaji = romaji.ToLower();

        //nが連続して出る箇所は"ん"と認識して区切る。（母音外対策）
        romaji = romaji.Replace("nn", "N");

        //母音を目安にひらがな一文字ずつに分解
        string[] tango = TextHiraganaBunnkai(romaji);


        //母音は配列boinn内で該当する位置の数字に置き換える
        for (var i = 0; i < tango.Length; i++)
        {
            //子音と母音を分割
            string[] textInn = TextInnBunnkai(tango[i]);

            var shiinn = string.Empty;
            var boinn = string.Empty;

            if (textInn.Length <= 1)
            {
                boinn = textInn[0];
            }
            else
            {
                shiinn = textInn[0];
                boinn = textInn[1];
            }

            //母音の行位置（あいうえお）を取得
            int boinnNumber = Array.IndexOf(kugiriText, boinn);

            switch (shiinn.Length)
            {
                //母音のみの場合
                case 0:
                    hiragana += hiraganaSelectTask.BoinnOnly(boinn, boinnNumber);
                    break;
                //子音（一文字）+ 母音の場合
                //母音が"n"…"ん"が一つだけ存在するので注意
                case 1:
                    hiragana += hiraganaSelectTask.ShiinnIchimoji(shiinn, boinn, boinnNumber);
                    break;
                //子音（二文字）+ 母音の場合
                case 2:
                    hiragana += hiraganaSelectTask.ShiinnNimoji(shiinn, boinn, boinnNumber);
                    break;
                //子音（三文字）+ 母音の場合
                case 3:
                    hiragana += hiraganaSelectTask.ShiinnSanmoji(shiinn, boinn, boinnNumber);
                    break;
                //該当なし…誤入力時などの場合
                default:
                    hiragana += hiraganaSelectTask.NoMatchDataFurigana(shiinn, boinn, boinnNumber);
                    break;
            }
        }
        return hiragana;
    }

    //単語単位での文字分割メソッド（"ushi"→"u|shi|"→"u" ,"shi"）
    private string[] TextHiraganaBunnkai(string text)
    {
        //var; s = new { Value = "i", Index = 1 };
        for (var i = 0; i < kugiriText.Length; i++)
        {
            text = text.Replace(kugiriText[i], (kugiriText[i] + "|"));
        }

        //このままだと、配列生成時に空の配列要素を生成してしまうので、語尾に存在する区切り文字を削除する。
        //if (text.EndsWith("|")) { text = text.Remove(text.Length - 1, 1); }

        string[] bunnkatsuText = text.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
        var s = text.Split('|').Where(e => !String.IsNullOrWhiteSpace(e)).ToArray();
        return bunnkatsuText;
    }

    //韻単位での文字分割メソッド（"shi"→"sh|i"→"sh" ,"i"）
    //母音と子音の計二つの値を持つ配列となる
    private string[] TextInnBunnkai(string text)
    {
        for (var i = 0; i < kugiriText.Length; i++)
        {
            text = text.Replace(kugiriText[i], "|" + kugiriText[i]);
        }

        string[] bunnkatsuText = text.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

        return bunnkatsuText;
    }

}
